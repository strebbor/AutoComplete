namespace IDComplete.CustomControls
{
    partial class SetupScreen
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
            this.gridSetup = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbPermanent = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTriggerCharacter = new System.Windows.Forms.TextBox();
            this.txtFirstRow = new System.Windows.Forms.TextBox();
            this.btnConfigFileLocation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridSetup)).BeginInit();
            this.SuspendLayout();
            // 
            // gridSetup
            // 
            this.gridSetup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSetup.Location = new System.Drawing.Point(12, 38);
            this.gridSetup.Name = "gridSetup";
            this.gridSetup.RowHeadersWidth = 45;
            this.gridSetup.Size = new System.Drawing.Size(776, 206);
            this.gridSetup.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(713, 415);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // cbPermanent
            // 
            this.cbPermanent.AutoSize = true;
            this.cbPermanent.Checked = true;
            this.cbPermanent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPermanent.Location = new System.Drawing.Point(651, 11);
            this.cbPermanent.Name = "cbPermanent";
            this.cbPermanent.Size = new System.Drawing.Size(137, 19);
            this.cbPermanent.TabIndex = 3;
            this.cbPermanent.Text = "Update permanently";
            this.cbPermanent.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "Column Setup";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 261);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "Sheet Setup";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 308);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Trigger Character";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 343);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Sheet First Row";
            // 
            // txtTriggerCharacter
            // 
            this.txtTriggerCharacter.Location = new System.Drawing.Point(135, 308);
            this.txtTriggerCharacter.Name = "txtTriggerCharacter";
            this.txtTriggerCharacter.Size = new System.Drawing.Size(100, 20);
            this.txtTriggerCharacter.TabIndex = 8;
            // 
            // txtFirstRow
            // 
            this.txtFirstRow.Location = new System.Drawing.Point(135, 343);
            this.txtFirstRow.Name = "txtFirstRow";
            this.txtFirstRow.Size = new System.Drawing.Size(100, 20);
            this.txtFirstRow.TabIndex = 9;
            // 
            // btnConfigFileLocation
            // 
            this.btnConfigFileLocation.Location = new System.Drawing.Point(20, 415);
            this.btnConfigFileLocation.Name = "btnConfigFileLocation";
            this.btnConfigFileLocation.Size = new System.Drawing.Size(116, 23);
            this.btnConfigFileLocation.TabIndex = 10;
            this.btnConfigFileLocation.Text = "Open Config Files";
            this.btnConfigFileLocation.UseVisualStyleBackColor = true;
            this.btnConfigFileLocation.Click += new System.EventHandler(this.BtnConfigFileLocation_Click);
            // 
            // SetupScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnConfigFileLocation);
            this.Controls.Add(this.txtFirstRow);
            this.Controls.Add(this.txtTriggerCharacter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPermanent);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gridSetup);
            this.Name = "SetupScreen";
            this.Text = "Setup";
            ((System.ComponentModel.ISupportInitialize)(this.gridSetup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridSetup;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox cbPermanent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTriggerCharacter;
        private System.Windows.Forms.TextBox txtFirstRow;
        private System.Windows.Forms.Button btnConfigFileLocation;
    }
}