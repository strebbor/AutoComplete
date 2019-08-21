namespace IDComplete
{
    partial class Ribbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ribbon));
            this.tab1 = this.Factory.CreateRibbonTab();
            this.rgAutoComplete = this.Factory.CreateRibbonGroup();
            this.btnStatus = this.Factory.CreateRibbonButton();
            this.btnSynchronize = this.Factory.CreateRibbonButton();
            this.btnSetup = this.Factory.CreateRibbonButton();
            this.btnStart = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.rgAutoComplete.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.rgAutoComplete);
            this.tab1.Label = "RoadRace Tools";
            this.tab1.Name = "tab1";
            // 
            // rgAutoComplete
            // 
            this.rgAutoComplete.Items.Add(this.btnStatus);
            this.rgAutoComplete.Items.Add(this.btnSynchronize);
            this.rgAutoComplete.Items.Add(this.btnSetup);
            this.rgAutoComplete.Items.Add(this.btnStart);
            this.rgAutoComplete.Label = "Auto Complete";
            this.rgAutoComplete.Name = "rgAutoComplete";
            // 
            // btnStatus
            // 
            this.btnStatus.Image = ((System.Drawing.Image)(resources.GetObject("btnStatus.Image")));
            this.btnStatus.Label = "Status: Off";
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.ShowImage = true;
            this.btnStatus.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.BtnStatus_Click);
            // 
            // btnSynchronize
            // 
            this.btnSynchronize.Image = global::IDComplete.Properties.Resources.synchronize;
            this.btnSynchronize.Label = "Synchronize";
            this.btnSynchronize.Name = "btnSynchronize";
            this.btnSynchronize.ShowImage = true;
            this.btnSynchronize.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.BtnSynchronize_Click);
            // 
            // btnSetup
            // 
            this.btnSetup.Image = ((System.Drawing.Image)(resources.GetObject("btnSetup.Image")));
            this.btnSetup.Label = "Setup";
            this.btnSetup.Name = "btnSetup";
            this.btnSetup.ShowImage = true;
            this.btnSetup.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.BtnSetup_Click);
            // 
            // btnStart
            // 
            this.btnStart.Label = "";
            this.btnStart.Name = "btnStart";
            // 
            // Ribbon
            // 
            this.Name = "Ribbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.rgAutoComplete.ResumeLayout(false);
            this.rgAutoComplete.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup rgAutoComplete;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnStart;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSetup;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnStatus;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSynchronize;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon Ribbon
        {
            get { return this.GetRibbon<Ribbon>(); }
        }
    }
}
