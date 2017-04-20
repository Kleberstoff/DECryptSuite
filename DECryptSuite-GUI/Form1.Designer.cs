namespace DECryptSuite_GUI
{
    partial class Form1
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
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.materialFlatButton1 = new MaterialSkin.Controls.MaterialFlatButton();
            this.OutputField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.FileExtensionField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.HeadersOnlyButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.HeaderField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.PasswordField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.EncryptFolderButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.DecryptButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.EncryptButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.materialFlatButton5 = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BaseTabControl = this.materialTabControl1;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Location = new System.Drawing.Point(-3, 60);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(423, 69);
            this.materialTabSelector1.TabIndex = 0;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabPage1);
            this.materialTabControl1.Controls.Add(this.tabPage2);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Location = new System.Drawing.Point(-3, 126);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(423, 233);
            this.materialTabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.materialFlatButton1);
            this.tabPage1.Controls.Add(this.OutputField);
            this.tabPage1.Controls.Add(this.FileExtensionField);
            this.tabPage1.Controls.Add(this.HeadersOnlyButton);
            this.tabPage1.Controls.Add(this.HeaderField);
            this.tabPage1.Controls.Add(this.PasswordField);
            this.tabPage1.Controls.Add(this.EncryptFolderButton);
            this.tabPage1.Controls.Add(this.DecryptButton);
            this.tabPage1.Controls.Add(this.EncryptButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(415, 207);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Home";
            // 
            // materialFlatButton1
            // 
            this.materialFlatButton1.AutoSize = true;
            this.materialFlatButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton1.Depth = 0;
            this.materialFlatButton1.Icon = null;
            this.materialFlatButton1.Location = new System.Drawing.Point(0, 89);
            this.materialFlatButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton1.Name = "materialFlatButton1";
            this.materialFlatButton1.Primary = false;
            this.materialFlatButton1.Size = new System.Drawing.Size(179, 36);
            this.materialFlatButton1.TabIndex = 8;
            this.materialFlatButton1.Text = "Select Output Folder";
            this.materialFlatButton1.UseVisualStyleBackColor = true;
            this.materialFlatButton1.Click += new System.EventHandler(this.OutputFolderSelect_Click);
            // 
            // OutputField
            // 
            this.OutputField.Depth = 0;
            this.OutputField.Enabled = false;
            this.OutputField.Hint = "Output Folder";
            this.OutputField.Location = new System.Drawing.Point(6, 130);
            this.OutputField.MaxLength = 32767;
            this.OutputField.MouseState = MaterialSkin.MouseState.HOVER;
            this.OutputField.Name = "OutputField";
            this.OutputField.PasswordChar = '\0';
            this.OutputField.SelectedText = "";
            this.OutputField.SelectionLength = 0;
            this.OutputField.SelectionStart = 0;
            this.OutputField.Size = new System.Drawing.Size(182, 23);
            this.OutputField.TabIndex = 7;
            this.OutputField.TabStop = false;
            this.OutputField.UseSystemPasswordChar = false;
            // 
            // FileExtensionField
            // 
            this.FileExtensionField.Depth = 0;
            this.FileExtensionField.Hint = "File Extension";
            this.FileExtensionField.Location = new System.Drawing.Point(6, 64);
            this.FileExtensionField.MaxLength = 32767;
            this.FileExtensionField.MouseState = MaterialSkin.MouseState.HOVER;
            this.FileExtensionField.Name = "FileExtensionField";
            this.FileExtensionField.PasswordChar = '\0';
            this.FileExtensionField.SelectedText = "";
            this.FileExtensionField.SelectionLength = 0;
            this.FileExtensionField.SelectionStart = 0;
            this.FileExtensionField.Size = new System.Drawing.Size(182, 23);
            this.FileExtensionField.TabIndex = 6;
            this.FileExtensionField.TabStop = false;
            this.FileExtensionField.UseSystemPasswordChar = false;
            // 
            // HeadersOnlyButton
            // 
            this.HeadersOnlyButton.AutoSize = true;
            this.HeadersOnlyButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.HeadersOnlyButton.Depth = 0;
            this.HeadersOnlyButton.Icon = null;
            this.HeadersOnlyButton.Location = new System.Drawing.Point(221, 160);
            this.HeadersOnlyButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.HeadersOnlyButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.HeadersOnlyButton.Name = "HeadersOnlyButton";
            this.HeadersOnlyButton.Primary = false;
            this.HeadersOnlyButton.Size = new System.Drawing.Size(185, 36);
            this.HeadersOnlyButton.TabIndex = 5;
            this.HeadersOnlyButton.Text = "Decrypt Header\'s Only";
            this.HeadersOnlyButton.UseVisualStyleBackColor = true;
            this.HeadersOnlyButton.Click += new System.EventHandler(this.HeadersOnlyButton_Click);
            // 
            // HeaderField
            // 
            this.HeaderField.Depth = 0;
            this.HeaderField.Hint = "Header (Required)";
            this.HeaderField.Location = new System.Drawing.Point(6, 35);
            this.HeaderField.MaxLength = 32767;
            this.HeaderField.MouseState = MaterialSkin.MouseState.HOVER;
            this.HeaderField.Name = "HeaderField";
            this.HeaderField.PasswordChar = '\0';
            this.HeaderField.SelectedText = "";
            this.HeaderField.SelectionLength = 0;
            this.HeaderField.SelectionStart = 0;
            this.HeaderField.Size = new System.Drawing.Size(182, 23);
            this.HeaderField.TabIndex = 4;
            this.HeaderField.TabStop = false;
            this.HeaderField.UseSystemPasswordChar = false;
            // 
            // PasswordField
            // 
            this.PasswordField.Depth = 0;
            this.PasswordField.Hint = "Password";
            this.PasswordField.Location = new System.Drawing.Point(6, 6);
            this.PasswordField.MaxLength = 32767;
            this.PasswordField.MouseState = MaterialSkin.MouseState.HOVER;
            this.PasswordField.Name = "PasswordField";
            this.PasswordField.PasswordChar = '\0';
            this.PasswordField.SelectedText = "";
            this.PasswordField.SelectionLength = 0;
            this.PasswordField.SelectionStart = 0;
            this.PasswordField.Size = new System.Drawing.Size(182, 23);
            this.PasswordField.TabIndex = 3;
            this.PasswordField.TabStop = false;
            this.PasswordField.UseSystemPasswordChar = true;
            // 
            // EncryptFolderButton
            // 
            this.EncryptFolderButton.AutoSize = true;
            this.EncryptFolderButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.EncryptFolderButton.Depth = 0;
            this.EncryptFolderButton.Icon = null;
            this.EncryptFolderButton.Location = new System.Drawing.Point(83, 162);
            this.EncryptFolderButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.EncryptFolderButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.EncryptFolderButton.Name = "EncryptFolderButton";
            this.EncryptFolderButton.Primary = false;
            this.EncryptFolderButton.Size = new System.Drawing.Size(135, 36);
            this.EncryptFolderButton.TabIndex = 2;
            this.EncryptFolderButton.Text = "Encrypt Folder";
            this.EncryptFolderButton.UseVisualStyleBackColor = true;
            this.EncryptFolderButton.Click += new System.EventHandler(this.EncryptFolderButton_Click);
            // 
            // DecryptButton
            // 
            this.DecryptButton.AutoSize = true;
            this.DecryptButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DecryptButton.Depth = 0;
            this.DecryptButton.Icon = null;
            this.DecryptButton.Location = new System.Drawing.Point(325, 117);
            this.DecryptButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.DecryptButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.DecryptButton.Name = "DecryptButton";
            this.DecryptButton.Primary = false;
            this.DecryptButton.Size = new System.Drawing.Size(81, 36);
            this.DecryptButton.TabIndex = 1;
            this.DecryptButton.Text = "Decrypt";
            this.DecryptButton.UseVisualStyleBackColor = true;
            this.DecryptButton.Click += new System.EventHandler(this.DecryptButton_Click);
            // 
            // EncryptButton
            // 
            this.EncryptButton.AutoSize = true;
            this.EncryptButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.EncryptButton.Depth = 0;
            this.EncryptButton.Icon = null;
            this.EncryptButton.Location = new System.Drawing.Point(4, 162);
            this.EncryptButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.EncryptButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.EncryptButton.Name = "EncryptButton";
            this.EncryptButton.Primary = false;
            this.EncryptButton.Size = new System.Drawing.Size(81, 36);
            this.EncryptButton.TabIndex = 0;
            this.EncryptButton.Text = "Encrypt";
            this.EncryptButton.UseVisualStyleBackColor = true;
            this.EncryptButton.Click += new System.EventHandler(this.EncryptButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.materialLabel1);
            this.tabPage2.Controls.Add(this.materialFlatButton5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(415, 207);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings & Credits";
            // 
            // materialFlatButton5
            // 
            this.materialFlatButton5.AutoSize = true;
            this.materialFlatButton5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton5.Depth = 0;
            this.materialFlatButton5.Icon = null;
            this.materialFlatButton5.Location = new System.Drawing.Point(281, 162);
            this.materialFlatButton5.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton5.Name = "materialFlatButton5";
            this.materialFlatButton5.Primary = false;
            this.materialFlatButton5.Size = new System.Drawing.Size(125, 36);
            this.materialFlatButton5.TabIndex = 0;
            this.materialFlatButton5.Text = "Change Theme";
            this.materialFlatButton5.UseVisualStyleBackColor = true;
            this.materialFlatButton5.Click += new System.EventHandler(this.ChangeTheme);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto Medium", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(6, 15);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(239, 108);
            this.materialLabel1.TabIndex = 1;
            this.materialLabel1.Text = "Kleberstoff - Again? What an Nerd.\r\nGuy that made MaterialSkin\r\nGuy that Made Fod" +
    "y + Costura\r\n\r\nTesters:\r\nUbuntu.exe#8553";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 344);
            this.Controls.Add(this.materialTabControl1);
            this.Controls.Add(this.materialTabSelector1);
            this.Name = "Form1";
            this.Text = "DECryptSuite GUI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.materialTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private MaterialSkin.Controls.MaterialFlatButton EncryptButton;
        private MaterialSkin.Controls.MaterialFlatButton DecryptButton;
        private MaterialSkin.Controls.MaterialFlatButton EncryptFolderButton;
        private MaterialSkin.Controls.MaterialSingleLineTextField PasswordField;
        private MaterialSkin.Controls.MaterialSingleLineTextField HeaderField;
        private MaterialSkin.Controls.MaterialFlatButton HeadersOnlyButton;
        private MaterialSkin.Controls.MaterialSingleLineTextField FileExtensionField;
        private MaterialSkin.Controls.MaterialSingleLineTextField OutputField;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton5;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
    }
}

