namespace Picture_Viewer
{
    partial class OptionsForms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForms));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabOptions = new System.Windows.Forms.TabControl();
            this.pgeGeneral = new System.Windows.Forms.TabPage();
            this.chkPromptOnExit = new System.Windows.Forms.CheckBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.pgeAppearance = new System.Windows.Forms.TabPage();
            this.grpDefaultBackColor = new System.Windows.Forms.GroupBox();
            this.optBackgroundWhite = new System.Windows.Forms.RadioButton();
            this.optBackgroundColor = new System.Windows.Forms.RadioButton();
            this.tabOptions.SuspendLayout();
            this.pgeGeneral.SuspendLayout();
            this.pgeAppearance.SuspendLayout();
            this.grpDefaultBackColor.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(305, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(304, 38);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabOptions
            // 
            this.tabOptions.Controls.Add(this.pgeGeneral);
            this.tabOptions.Controls.Add(this.pgeAppearance);
            this.tabOptions.Location = new System.Drawing.Point(12, 12);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.SelectedIndex = 0;
            this.tabOptions.Size = new System.Drawing.Size(287, 145);
            this.tabOptions.TabIndex = 6;
            // 
            // pgeGeneral
            // 
            this.pgeGeneral.Controls.Add(this.chkPromptOnExit);
            this.pgeGeneral.Controls.Add(this.txtUserName);
            this.pgeGeneral.Controls.Add(this.lblUserName);
            this.pgeGeneral.Location = new System.Drawing.Point(4, 22);
            this.pgeGeneral.Name = "pgeGeneral";
            this.pgeGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.pgeGeneral.Size = new System.Drawing.Size(279, 119);
            this.pgeGeneral.TabIndex = 0;
            this.pgeGeneral.Text = "General";
            this.pgeGeneral.UseVisualStyleBackColor = true;
            // 
            // chkPromptOnExit
            // 
            this.chkPromptOnExit.AutoSize = true;
            this.chkPromptOnExit.Location = new System.Drawing.Point(87, 52);
            this.chkPromptOnExit.Name = "chkPromptOnExit";
            this.chkPromptOnExit.Size = new System.Drawing.Size(145, 17);
            this.chkPromptOnExit.TabIndex = 7;
            this.chkPromptOnExit.Text = "Prompt to confirm on exit.";
            this.chkPromptOnExit.UseVisualStyleBackColor = true;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(87, 11);
            this.txtUserName.MaxLength = 10;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(139, 20);
            this.txtUserName.TabIndex = 6;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(22, 14);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(63, 13);
            this.lblUserName.TabIndex = 5;
            this.lblUserName.Text = "User Name:";
            // 
            // pgeAppearance
            // 
            this.pgeAppearance.Controls.Add(this.grpDefaultBackColor);
            this.pgeAppearance.Location = new System.Drawing.Point(4, 22);
            this.pgeAppearance.Name = "pgeAppearance";
            this.pgeAppearance.Padding = new System.Windows.Forms.Padding(3);
            this.pgeAppearance.Size = new System.Drawing.Size(279, 119);
            this.pgeAppearance.TabIndex = 1;
            this.pgeAppearance.Text = "Appearance";
            this.pgeAppearance.UseVisualStyleBackColor = true;
            // 
            // grpDefaultBackColor
            // 
            this.grpDefaultBackColor.Controls.Add(this.optBackgroundWhite);
            this.grpDefaultBackColor.Controls.Add(this.optBackgroundColor);
            this.grpDefaultBackColor.Location = new System.Drawing.Point(28, 20);
            this.grpDefaultBackColor.Name = "grpDefaultBackColor";
            this.grpDefaultBackColor.Size = new System.Drawing.Size(200, 72);
            this.grpDefaultBackColor.TabIndex = 6;
            this.grpDefaultBackColor.TabStop = false;
            this.grpDefaultBackColor.Text = "Default Picture Background Color";
            // 
            // optBackgroundWhite
            // 
            this.optBackgroundWhite.AutoSize = true;
            this.optBackgroundWhite.Location = new System.Drawing.Point(14, 42);
            this.optBackgroundWhite.Name = "optBackgroundWhite";
            this.optBackgroundWhite.Size = new System.Drawing.Size(53, 17);
            this.optBackgroundWhite.TabIndex = 1;
            this.optBackgroundWhite.Text = "White";
            this.optBackgroundWhite.UseVisualStyleBackColor = true;
            // 
            // optBackgroundColor
            // 
            this.optBackgroundColor.AutoSize = true;
            this.optBackgroundColor.Checked = true;
            this.optBackgroundColor.Location = new System.Drawing.Point(14, 19);
            this.optBackgroundColor.Name = "optBackgroundColor";
            this.optBackgroundColor.Size = new System.Drawing.Size(84, 17);
            this.optBackgroundColor.TabIndex = 0;
            this.optBackgroundColor.TabStop = true;
            this.optBackgroundColor.Text = "Default Gray";
            this.optBackgroundColor.UseVisualStyleBackColor = true;
            // 
            // OptionsForms
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(384, 262);
            this.Controls.Add(this.tabOptions);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Picture Viewer Options";
            this.Load += new System.EventHandler(this.OptionsForms_Load);
            this.tabOptions.ResumeLayout(false);
            this.pgeGeneral.ResumeLayout(false);
            this.pgeGeneral.PerformLayout();
            this.pgeAppearance.ResumeLayout(false);
            this.grpDefaultBackColor.ResumeLayout(false);
            this.grpDefaultBackColor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabControl tabOptions;
        private System.Windows.Forms.TabPage pgeGeneral;
        private System.Windows.Forms.CheckBox chkPromptOnExit;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TabPage pgeAppearance;
        private System.Windows.Forms.GroupBox grpDefaultBackColor;
        private System.Windows.Forms.RadioButton optBackgroundWhite;
        private System.Windows.Forms.RadioButton optBackgroundColor;
    }
}