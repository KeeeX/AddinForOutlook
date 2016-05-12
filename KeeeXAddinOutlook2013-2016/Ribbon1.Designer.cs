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

namespace KeeeXAddinOutlook2013_2016
{
    partial class Ribbon1 : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon1()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.button1 = this.Factory.CreateRibbonButton();
            this.button2 = this.Factory.CreateRibbonButton();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.button3 = this.Factory.CreateRibbonButton();
            this.group3 = this.Factory.CreateRibbonGroup();
            this.button4 = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.group2.SuspendLayout();
            this.group3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group1);
            this.tab1.Groups.Add(this.group2);
            this.tab1.Groups.Add(this.group3);
            this.tab1.Label = "KeeeX";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.button1);
            this.group1.Items.Add(this.button2);
            this.group1.Label = "Actions";
            this.group1.Name = "group1";
            this.group1.Visible = false;
            // 
            // button1
            // 
            this.button1.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button1.Enabled = false;
            this.button1.Image = global::KeeeXAddinOutlook2013_2016.Properties.Resources.ic_attach_file_black_48dp;
            this.button1.Label = "Ajouter un fichier";
            this.button1.Name = "button1";
            this.button1.ShowImage = true;
            this.button1.SuperTip = "Ajouter un fichier";
            this.button1.Visible = false;
            this.button1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button2.Image = global::KeeeXAddinOutlook2013_2016.Properties.Resources.ic_insert_drive_file_black_48dp;
            this.button2.Label = "Voir les pièces jointes";
            this.button2.Name = "button2";
            this.button2.ShowImage = true;
            this.button2.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button2_Click);
            // 
            // group2
            // 
            this.group2.Items.Add(this.button3);
            this.group2.Label = "Application";
            this.group2.Name = "group2";
            // 
            // button3
            // 
            this.button3.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button3.Image = global::KeeeXAddinOutlook2013_2016.Properties.Resources.keeex_app_logo;
            this.button3.Label = "Démarrer KeeeX";
            this.button3.Name = "button3";
            this.button3.ShowImage = true;
            this.button3.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button3_Click);
            // 
            // group3
            // 
            this.group3.Items.Add(this.button4);
            this.group3.Label = "Contacts";
            this.group3.Name = "group3";
            this.group3.Visible = false;
            // 
            // button4
            // 
            this.button4.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button4.Image = global::KeeeXAddinOutlook2013_2016.Properties.Resources.ic_group_black_48dp;
            this.button4.Label = "Liste de contacts";
            this.button4.Name = "button4";
            this.button4.ShowImage = true;
            // 
            // Ribbon1
            // 
            this.Name = "Ribbon1";
            this.RibbonType = "Microsoft.Outlook.Explorer, Microsoft.Outlook.Mail.Read";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.group3.ResumeLayout(false);
            this.group3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button2;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button3;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button4;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon1 Ribbon1
        {
            get { return this.GetRibbon<Ribbon1>(); }
        }
    }
}

keeex self xumin-capas-fykob-tukuh-mones-tafud-papyn-kuced-kazil-cebim-lefyg-pecek-tocim-gosov-pelut-citih-kexex , {main} xeeek
keeex self 14LzjdeoEmWkNRq2FF7yZgUR7V45EC3BWiTdAcn , {alg:sha224,enc:b58,recursive:1} xeeek
keeex name "Ribbon1.Designer.cs" , {main} xeeek
keeex prop "kx.author", "rerom-tumit-fucuz-vicur-tiluc-hotec-vuses-cafoz-cazyr-nitaf-vuhyf-dunal-fygob-levom-vevor-korap-loxyr" xeeek
keeex ref "ruvog-lalyc-pyhos-tetun-lyten-furym-zymec-benot-buhit-sivad-cedot-hogak-zapig-filag-lytav-kyhef-hyxyr" , {mine} xeeek
keeex signer rerom-cityz-bivyc-ralav-bumon-mudyh-hocyr-pikyv-sysyz-cunat-gesiz-lipig-cozof-harif-sapor-gacaf-nixer xeeek
keeex prop "kx.time", "Thu, 12 May 2016 14:08:54 GMT" xeeek
keeex prop "kx.pattern", "%f" xeeek
keeex prop "kx.folder", "KeeeXAddinOutlook2013-2016" xeeek
keeex ref "rezop-peced-terip-vivap-debal-mutyz-pahan-motod-pavan-vynuc-keboh-kofav-mupek-dycur-benyh-vyduk-kyxur" xeeek
keeex ref "rozip-vovis-cocuh-putyv-vufad-zuruh-benen-ketop-zezyt-zetug-hacel-coher-vedyk-zumud-cevep-tives-vixir" xeeek
keeex ref "roled-tymyz-hizoc-gehaf-fazom-fizyd-forar-pozyh-bibad-zicah-vigiv-kameh-nyvan-loteg-lusil-pynod-kexyr" xeeek
keeex ref "rehev-cycyz-deboc-cukoz-geliv-vyked-lysys-buzyr-fufif-bycyk-gafic-puhef-rybyl-puhed-hinic-toziz-fexer" xeeek
keeex ref "rorop-kelys-zanyz-gyfig-vuzig-cisit-malur-zamav-tinus-rapur-nebin-zosit-parac-locig-lypud-kytil-naxyr" xeeek

