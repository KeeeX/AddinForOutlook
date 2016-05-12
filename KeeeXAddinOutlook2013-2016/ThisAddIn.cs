/*
Copyright (c) 2016 KeeeX SAS 

This is an open source project available under the MIT license.
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.Windows.Forms;
using System.IO;
using KeeeXAddinOutlook2013_2016.Model.KeeeX;
using System.Web.Script.Serialization;
using KeeeXAddinOutlook2013_2016.Model;
using KeeeXAddinOutlook2013_2016.Controller;
using System.Diagnostics;

namespace KeeeXAddinOutlook2013_2016
{
    public partial class ThisAddIn
    {
        Outlook.NameSpace outlookNameSpace;
        Outlook.MAPIFolder inbox;
        Outlook.Items items;
        string error = "";

        // RECIPIENTS OF THE MAIL, AS KEEEX CONTACTS
        List<Contact> recipients;
        // KEEEX BUT OT CIPHERED ATTACHMENTS
        List<KeeeX_File_Treated> attachmentsClear;

        /// <summary>
        /// Called when the add-in is started (At the Outlook starting)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            // Send button clicked listener
            Application.ItemSend += new Outlook.ApplicationEvents_11_ItemSendEventHandler(Application_ItemSend);
            
            // Mail received listener
            outlookNameSpace = this.Application.GetNamespace("MAPI");
            inbox = outlookNameSpace.GetDefaultFolder(
                    Microsoft.Office.Interop.Outlook.
                    OlDefaultFolders.olFolderInbox);
            items = inbox.Items;
            items.ItemAdd +=
                new Outlook.ItemsEvents_ItemAddEventHandler(Application_ItemReceived);
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Remarque : Outlook ne déclenche plus cet événement. Si du code
            //    doit s'exécuter à la fermeture d'Outlook, voir http://go.microsoft.com/fwlink/?LinkId=506785
        }


        /// <summary>
        /// This handler is called when a user click on the default "Send" button
        /// This is where the KeeeX magic has to be done... :D
        /// </summary>
        /// <param name="Item">The MailItem instance</param>
        /// <param name="Cancel">After executing this method, should the mail be canceled or not</param>
        void Application_ItemSend(object Item, ref bool Cancel)
        {
            Outlook.MailItem mailItem = Item as Outlook.MailItem;

            if(!Cancel)
                Cancel = getKeeeXContacts(mailItem);
            if(!Cancel)
                Cancel = manageAttachments(mailItem, Cancel);
            else
            {
                // KeeeX not started or one of the recipients doesn't use KeeeX : send a classic mail ?
                DialogResult result = MessageBox.Show(error + "Voulez-vous envoyer ce message tout de même ?\nAttention : Ni ce mail, ni ses pièces jointes ne seront protégés !", "Envoyer le mail malgré tout ?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                
                if (result.Equals(DialogResult.Yes))
                    Cancel = false;
                else
                    Cancel = true;
            }


            // ATTENTION: When this method exits, Outlook will send item ONLY if Cancel.Equals(false)
        }


        /// <summary>
        /// This handler is called when a user receive a new mail
        /// May be useful
        /// </summary>
        /// <param name="Item">The MailItem instance</param>
        void Application_ItemReceived(object Item)
        {
            Outlook.MailItem mail = (Outlook.MailItem)Item;
            if (mail != null)
            {

            }

        }


        /// <summary>
        /// This method will manage the attachment before sending
        /// </summary>
        /// <param name="mailItem">The current MailItem instance, representing the mail</param>
        /// <returns>True if cancel sending needed (on exception), False else</returns>
        private Boolean manageAttachments(Outlook.MailItem mailItem, Boolean Cancel)
        {
            
            if (mailItem.Attachments.Count > 0)
            {
                string body = mailItem.HTMLBody; 
                // As we treat attachments, we add the topic idx of attachments to retreive them on receive.
                
                body += "<br />Nombre de fichiers joints (protégés par KeeeX): " + mailItem.Attachments.Count + "<br />";
                //mailItem.HTMLBody += "Vous pouvez retrouver ces fichiers sur l'application KeeeX ou via l'add-in KeeeX pour Outlook.<br />";
                body += "Pour ouvrir les fichiers joints, cliquez sur ceux-ci. KeeeX les déchiffrera pour vous.<br />";
                body += "<a href=\"https://keeex.me\">https://keeex.me</a><br />\n<!--KEEEX\n";

                List<Idx> idxs = new List<Idx>();
                try
                {
                    attachmentsClear = new List<KeeeX_File_Treated>();
                    List<string> newAttachmentList = new List<string>();

                // For each attachment
                   for (int i = 1; i <= mailItem.Attachments.Count; i++)
                   {
                        // We save the attachment into KeeeX Folder
                        string tempFile = saveAttachmentToKeeeXFolder(mailItem.Attachments[i]);

                        // We create a request for the local API to keeex, cipher and send SHARE notification for the saved attachment
                        KeeeX_File_Request request = new KeeeX_File_Request(tempFile, null, null, mailItem.Subject, false, false);
                        KeeeX_File_Treated treated = LocalApi.keeexFile(request);
                        if(treated != null)
                            attachmentsClear.Add(treated);
                        CipherResponse cipherResponse = LocalApi.cipherFile(treated, recipients);
                        ShareRequest shareRequest = new ShareRequest(cipherResponse.idx, cipherResponse.hash, recipients);
                        LocalApi.sendSharedNotification(shareRequest);
                        
                        // We remove current attachment and replace it via the new exact same one, keeexed and protected
                        newAttachmentList.Add(cipherResponse.path);
                        Idx thisIdx = new Idx();
                        thisIdx.idx = treated.topic.idx;
                        idxs.Add(thisIdx); 
                    }
                    for (int i = mailItem.Attachments.Count; i >= 0; i--)
                    {
                        mailItem.Attachments.Remove(i);
                    }
                    foreach(string attachmentPath in newAttachmentList)
                    {
                        mailItem.Attachments.Add(attachmentPath);
                    }
                }

                catch (Exception e)
                {
                    // On error, we cancel the mail sending by returning TRUE
                    MessageBox.Show("Impossible d'envoyer cet e-mail en raison d'un problème lors du traitement des pièces jointes : " + e.Message, "Envoi annulé", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
                string json = new JavaScriptSerializer().Serialize(idxs);
                body += json + "\nXEEEK-->";
                mailItem.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatHTML;
                mailItem.HTMLBody = body;
                
            }
            // We DO NOT cancel sending if everything is fine
            return false;
        }

        /// <summary>
        /// This method is used to save an attachmentin the %HOMEPATH%/KeeeX/signed/Mail Attachment/ folder
        /// </summary>
        /// <param name="attachment">The attachment we want to save</param>
        /// <returns>The filepath of the saved attachment</returns>
        private string saveAttachmentToKeeeXFolder(Outlook.Attachment attachment)
        {
            string tempDir = Environment.GetEnvironmentVariable("homepath") + "\\KeeeX\\signed\\Mail Attachments";
            Directory.CreateDirectory(tempDir);
            string fileName = tempDir + "\\" + attachment.FileName;
            attachment.SaveAsFile(fileName);
            
           
            return fileName;
            }

        /// <summary>
        /// This method is used for few things :
        /// - It gets contacts from KeeeX
        /// - Compare them to recipients of mail
        /// - If recipient not in KeeeX contact list, error
        /// - Save the recipient list for further use (cipher call)
        /// </summary>
        /// <param name="mailItem">The mail to check</param>
        /// <returns>True if error (cancel the sending), false to continue</returns>
        private Boolean getKeeeXContacts(Outlook.MailItem mailItem)
        {
            List<string> recipientList = Utils.GetSMTPAddressForRecipients(mailItem);
            List<Contact> keeexContacts;
            try
            {
                keeexContacts = new List<Contact>(JSONParser.jsonToContactArray(LocalApi.getAllContacts()));
            }
            catch (Exception e)
            {
             // MessageBox.Show("Impossible de contacter l'application KeeeX. Assurez-vous que KeeeX est démarré, et réessayez.\n" + e.Message, "Envoi annulé", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = "Impossible de contacter l'application KeeeX. Assurez-vous que KeeeX est démarré, et réessayez.\n";
                return true;
            }

            recipients = new List<Contact>();

            if (keeexContacts != null && recipientList != null && recipientList.Count > 0 && keeexContacts.Count > 0)
            {
                foreach (string email in recipientList)
                    foreach (Contact contact in keeexContacts)
                        if (contact != null && email != null && email.Contains("@") && contact.email != null && contact.email.Equals(email) && contact.state.Equals("ACCEPTED"))
                            recipients.Add(contact);

                if (!recipientList.Count.Equals(recipients.Count))
                { 
                 // MessageBox.Show("Un ou plusieurs destinataires ne sont pas dans votre liste de contacts dans l'application KeeeX ou ne peuvent communiquer avec vous.", "Envoi annulé", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = "Un ou plusieurs destinataires ne sont pas dans votre liste de contacts dans l'application KeeeX ou ne peuvent communiquer avec vous.";
                    return true;
                }
            }
            else {
             // MessageBox.Show("Votre liste de contact acceptés sur KeeeX est vide. Ajoutez des contacts et réessayez.", "Envoi annulé", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = "Votre liste de contact acceptés sur KeeeX est vide. Ajoutez des contacts et réessayez.";
                return true;
            }
            return false;
        }

        #region Code généré par VSTO

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}

keeex self xikac-nezyg-hadyl-hokek-hinok-tivub-civac-hekuv-rylib-zesec-reran-lyhub-fedar-molol-hopel-lihyb-vexex , {main} xeeek
keeex self 1Eb4XCcExk1s5jff5apZSgHyT2RQVihLacnziWu , {alg:sha224,enc:b58,recursive:1} xeeek
keeex name "ThisAddIn.cs" , {main} xeeek
keeex prop "kx.author", "rerom-tumit-fucuz-vicur-tiluc-hotec-vuses-cafoz-cazyr-nitaf-vuhyf-dunal-fygob-levom-vevor-korap-loxyr" xeeek
keeex ref "ruvog-lalyc-pyhos-tetun-lyten-furym-zymec-benot-buhit-sivad-cedot-hogak-zapig-filag-lytav-kyhef-hyxyr" , {mine} xeeek
keeex signer rerom-cityz-bivyc-ralav-bumon-mudyh-hocyr-pikyv-sysyz-cunat-gesiz-lipig-cozof-harif-sapor-gacaf-nixer xeeek
keeex prop "kx.time", "Thu, 12 May 2016 14:09:01 GMT" xeeek
keeex prop "kx.pattern", "%f" xeeek
keeex prop "kx.folder", "KeeeXAddinOutlook2013-2016" xeeek
keeex ref "rezop-peced-terip-vivap-debal-mutyz-pahan-motod-pavan-vynuc-keboh-kofav-mupek-dycur-benyh-vyduk-kyxur" xeeek
keeex ref "rozip-vovis-cocuh-putyv-vufad-zuruh-benen-ketop-zezyt-zetug-hacel-coher-vedyk-zumud-cevep-tives-vixir" xeeek
keeex ref "roled-tymyz-hizoc-gehaf-fazom-fizyd-forar-pozyh-bibad-zicah-vigiv-kameh-nyvan-loteg-lusil-pynod-kexyr" xeeek
keeex ref "rehev-cycyz-deboc-cukoz-geliv-vyked-lysys-buzyr-fufif-bycyk-gafic-puhef-rybyl-puhed-hinic-toziz-fexer" xeeek
keeex ref "rorop-kelys-zanyz-gyfig-vuzig-cisit-malur-zamav-tinus-rapur-nebin-zosit-parac-locig-lypud-kytil-naxyr" xeeek

