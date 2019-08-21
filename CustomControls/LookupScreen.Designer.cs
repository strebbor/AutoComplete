namespace IDComplete.CustomControls
{
    partial class LookupScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridData = new System.Windows.Forms.DataGridView();
            this.IDNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Club = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Province = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
            this.SuspendLayout();
            // 
            // gridData
            // 
            this.gridData.AllowUserToAddRows = false;
            this.gridData.AllowUserToDeleteRows = false;
            this.gridData.AllowUserToOrderColumns = true;
            this.gridData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridData.ColumnHeadersHeight = 25;
            this.gridData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDNumber,
            this.FirstName,
            this.LastName,
            this.Club,
            this.Province});
            this.gridData.Location = new System.Drawing.Point(12, 12);
            this.gridData.Name = "gridData";
            this.gridData.RowHeadersWidth = 45;
            this.gridData.Size = new System.Drawing.Size(760, 704);
            this.gridData.TabIndex = 1;
            this.gridData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GridData_KeyDown);
            this.gridData.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.GridData_MouseDoubleClick);
            // 
            // IDNumber
            // 
            this.IDNumber.DataPropertyName = "IDNumber";
            this.IDNumber.HeaderText = "ID Number";
            this.IDNumber.MinimumWidth = 6;
            this.IDNumber.Name = "IDNumber";
            this.IDNumber.ReadOnly = true;
            // 
            // FirstName
            // 
            this.FirstName.DataPropertyName = "FirstName";
            this.FirstName.HeaderText = "First Name";
            this.FirstName.MinimumWidth = 6;
            this.FirstName.Name = "FirstName";
            this.FirstName.ReadOnly = true;
            // 
            // LastName
            // 
            this.LastName.DataPropertyName = "LastName";
            this.LastName.HeaderText = "LastName";
            this.LastName.MinimumWidth = 6;
            this.LastName.Name = "LastName";
            this.LastName.ReadOnly = true;
            // 
            // Club
            // 
            this.Club.DataPropertyName = "Club";
            this.Club.HeaderText = "Club";
            this.Club.MinimumWidth = 6;
            this.Club.Name = "Club";
            this.Club.ReadOnly = true;
            // 
            // Province
            // 
            this.Province.DataPropertyName = "Province";
            this.Province.HeaderText = "Province";
            this.Province.MinimumWidth = 6;
            this.Province.Name = "Province";
            this.Province.ReadOnly = true;
            // 
            // LookupScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 728);
            this.Controls.Add(this.gridData);
            this.Name = "LookupScreen";
            this.Text = "Lookup";
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView gridData;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Club;
        private System.Windows.Forms.DataGridViewTextBoxColumn Province;
    }
}