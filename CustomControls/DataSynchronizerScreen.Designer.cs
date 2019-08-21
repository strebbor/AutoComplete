namespace IDComplete.CustomControls
{
    partial class DataSynchronizerScreen
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalRows = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNewRows = new System.Windows.Forms.Label();
            this.lblUpdatedRows = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbFilterOption = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblExcludedRows = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
            this.SuspendLayout();
            // 
            // gridData
            // 
            this.gridData.AllowUserToAddRows = false;
            this.gridData.AllowUserToDeleteRows = false;
            this.gridData.AllowUserToOrderColumns = true;
            this.gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridData.Location = new System.Drawing.Point(12, 71);
            this.gridData.Name = "gridData";
            this.gridData.RowHeadersWidth = 45;
            this.gridData.Size = new System.Drawing.Size(984, 645);
            this.gridData.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total rows in sheet";
            // 
            // lblTotalRows
            // 
            this.lblTotalRows.AutoSize = true;
            this.lblTotalRows.Location = new System.Drawing.Point(124, 9);
            this.lblTotalRows.Name = "lblTotalRows";
            this.lblTotalRows.Size = new System.Drawing.Size(41, 15);
            this.lblTotalRows.TabIndex = 2;
            this.lblTotalRows.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(396, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Total new rows";
            // 
            // lblNewRows
            // 
            this.lblNewRows.AutoSize = true;
            this.lblNewRows.Location = new System.Drawing.Point(500, 9);
            this.lblNewRows.Name = "lblNewRows";
            this.lblNewRows.Size = new System.Drawing.Size(41, 15);
            this.lblNewRows.TabIndex = 4;
            this.lblNewRows.Text = "label2";
            // 
            // lblUpdatedRows
            // 
            this.lblUpdatedRows.AutoSize = true;
            this.lblUpdatedRows.Location = new System.Drawing.Point(707, 9);
            this.lblUpdatedRows.Name = "lblUpdatedRows";
            this.lblUpdatedRows.Size = new System.Drawing.Size(41, 15);
            this.lblUpdatedRows.TabIndex = 6;
            this.lblUpdatedRows.Text = "label2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(575, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Total changed rows";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(921, 42);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // cbFilterOption
            // 
            this.cbFilterOption.FormattingEnabled = true;
            this.cbFilterOption.Items.AddRange(new object[] {
            "NEW",
            "UPDATED",
            "UNCHANGED",
            "EXCLUDED"});
            this.cbFilterOption.Location = new System.Drawing.Point(12, 44);
            this.cbFilterOption.Name = "cbFilterOption";
            this.cbFilterOption.Size = new System.Drawing.Size(140, 21);
            this.cbFilterOption.TabIndex = 9;
            this.cbFilterOption.SelectedIndexChanged += new System.EventHandler(this.CbFilterOption_SelectedIndexChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(828, 42);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(189, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Total excluded rows";
            // 
            // lblExcludedRows
            // 
            this.lblExcludedRows.AutoSize = true;
            this.lblExcludedRows.Location = new System.Drawing.Point(311, 9);
            this.lblExcludedRows.Name = "lblExcludedRows";
            this.lblExcludedRows.Size = new System.Drawing.Size(41, 15);
            this.lblExcludedRows.TabIndex = 12;
            this.lblExcludedRows.Text = "label2";
            // 
            // DataSynchronizerScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 728);
            this.Controls.Add(this.lblExcludedRows);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cbFilterOption);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblUpdatedRows);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblNewRows);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTotalRows);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridData);
            this.Name = "DataSynchronizerScreen";
            this.Text = "Data Synchronizer";
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalRows;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNewRows;
        private System.Windows.Forms.Label lblUpdatedRows;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbFilterOption;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblExcludedRows;
    }
}