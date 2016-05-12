using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;
using Microsoft.Office.Core;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using Inspector = Microsoft.Office.Interop.Outlook.Inspector;
using System.Net;
using System.IO;
using KeeeXAddinOutlook2013_2016.Model;
using KeeeXAddinOutlook2013_2016.Controller;
using System.Diagnostics;
using KeeeXAddinOutlook2013_2016.Model.KeeeX;
using System.Runtime.InteropServices;

namespace KeeeXAddinOutlook2013_2016
{
    public partial class Ribbon1
    {
        // The Current mail item
        // Outlook.MailItem mailItem;
        // The KeeeX recipients of a file
        // List<Contact> recipients;
        // The file's filepath
        // string filepath;


        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }


        /// <summary>
        /// Depricated : was used to add programaticaly attachments, now this is done on sent.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            /*
            var inspector = this.Context as Inspector;
            mailItem = inspector.CurrentItem as Outlook.MailItem;

            OpenFileDialog attachment = new OpenFileDialog();

            attachment.Title = "Sélectionner un fichier à transmettre...";
            attachment.ShowDialog();
            filepath = attachment.FileName;


            if (getKeeeXContacts() < 0)
                MessageBox.Show("Some of the recipents are not using KeeeX. Please invite them via KeeeX before sending files.", "Contact error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (getKeeeXContacts() > 0)
                MessageBox.Show("Could not communicate with the local API. Are you running KeeeX ?", "Network error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Number of recipients: " + recipients.Count, "Everything OK.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show("Fichier à keeexer: " + filepath, "Keeex me", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //mailItem.Body;
            */
        }


        /// <summary>
        /// Handler when a click is made on the "View attached files" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, RibbonControlEventArgs e)
        {
            Outlook.Explorer explorer = new Microsoft.Office.Interop.Outlook.Application().ActiveExplorer();
            Outlook.Selection selection = explorer.Selection;

            if (selection.Count > 0)   // Check that selection is not empty.
            {
                object selectedItem = selection[1];   // Index is one-based.
                Outlook.MailItem mailItem = selectedItem as Outlook.MailItem;

                if (mailItem != null)    // Check that selected item is a message.
                {
                    // DO THE KEEEX MAGIC HERE
                    List<Idx> idxs = parseMail(mailItem.HTMLBody);
                    if(idxs != null & idxs.Count > 0)
                    {

                    }
                    //AttachmentList attachList = new AttachmentList();
                    //attachList.title = mailItem.Subject;
                    //attachList.Show();
                }
            }

        }



        /// <summary>
        /// This parser's goal is to retreive the Idxs of attached file within the mail
        /// </summary>
        /// <param name="htmlBody">The HTML body of the mail</param>
        /// <returns>A list of Idxs found</returns>
        private List<Idx> parseMail(string htmlBody)
        {
            List<Idx> idxs = new List<Idx>();

            if(htmlBody.Contains("<!--KEEEX") && htmlBody.Contains("XEEEK-->")) 
            {
                int start = htmlBody.LastIndexOf("<!--KEEEX\n");
                int end = htmlBody.LastIndexOf("\nXEEEK-->");

                if(start != 0 && end != 0 && end > start && start < htmlBody.Length && end < htmlBody.Length)
                {
                    string json = htmlBody.Substring(start+10, end-(start+10));
                    idxs = JSONParser.jsonToIdx(json);
                    MessageBox.Show("Idxs found : " + idxs.Count);
                }
                else
                {
                    MessageBox.Show("Outta range");
                }
            }
            else
            {
                MessageBox.Show("Pattern not found");
            }

            return idxs;
        }


        /// <summary>
        /// Button to start KeeeX. Will only work if user didn't change installation directory.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, RibbonControlEventArgs e)
        {
            bool is64 = System.Environment.Is64BitOperatingSystem;
            if (!is64)
                System.Diagnostics.Process.Start("C:\\Program Files\\KeeeX\\KeeeX.exe", "");
            else
                System.Diagnostics.Process.Start("C:\\Program Files (x86)\\KeeeX\\KeeeX.exe", "");
            return;
        }
    }
}
