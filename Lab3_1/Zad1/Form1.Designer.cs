namespace Zad1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            algorithmComboBox = new ComboBox();
            generateKeyIVButton = new Button();
            encryptButton = new Button();
            decryptButton = new Button();
            keyTextBox = new TextBox();
            ivTextBox = new TextBox();
            plainTextBox = new TextBox();
            AsciiTextBox = new TextBox();
            HexTextBox = new TextBox();
            encryptionTimeLabel = new Label();
            decryptionTimeLabel = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // algorithmComboBox
            // 
            algorithmComboBox.FormattingEnabled = true;
            algorithmComboBox.Location = new Point(25, 29);
            algorithmComboBox.Name = "algorithmComboBox";
            algorithmComboBox.Size = new Size(150, 23);
            algorithmComboBox.TabIndex = 0;
            algorithmComboBox.SelectedIndexChanged += algorithmComboBox_SelectedIndexChanged;
            // 
            // generateKeyIVButton
            // 
            generateKeyIVButton.Location = new Point(25, 70);
            generateKeyIVButton.Name = "generateKeyIVButton";
            generateKeyIVButton.Size = new Size(150, 30);
            generateKeyIVButton.TabIndex = 1;
            generateKeyIVButton.Text = "Generate Key and IV";
            generateKeyIVButton.UseVisualStyleBackColor = true;
            generateKeyIVButton.Click += generateKeyIVButton_Click;
            // 
            // encryptButton
            // 
            encryptButton.Location = new Point(25, 127);
            encryptButton.Name = "encryptButton";
            encryptButton.Size = new Size(150, 30);
            encryptButton.TabIndex = 2;
            encryptButton.Text = "Encrypt";
            encryptButton.UseVisualStyleBackColor = true;
            encryptButton.Click += encryptButton_Click;
            // 
            // decryptButton
            // 
            decryptButton.Location = new Point(25, 271);
            decryptButton.Name = "decryptButton";
            decryptButton.Size = new Size(150, 30);
            decryptButton.TabIndex = 3;
            decryptButton.Text = "Decrypt";
            decryptButton.UseVisualStyleBackColor = true;
            decryptButton.Click += decryptButton_Click;
            // 
            // keyTextBox
            // 
            keyTextBox.Location = new Point(254, 29);
            keyTextBox.Name = "keyTextBox";
            keyTextBox.Size = new Size(323, 23);
            keyTextBox.TabIndex = 6;
            // 
            // ivTextBox
            // 
            ivTextBox.Location = new Point(254, 77);
            ivTextBox.Name = "ivTextBox";
            ivTextBox.Size = new Size(323, 23);
            ivTextBox.TabIndex = 7;
            // 
            // plainTextBox
            // 
            plainTextBox.Location = new Point(254, 132);
            plainTextBox.Name = "plainTextBox";
            plainTextBox.Size = new Size(323, 23);
            plainTextBox.TabIndex = 8;
            // 
            // AsciiTextBox
            // 
            AsciiTextBox.Location = new Point(254, 177);
            AsciiTextBox.Name = "AsciiTextBox";
            AsciiTextBox.ReadOnly = true;
            AsciiTextBox.Size = new Size(323, 23);
            AsciiTextBox.TabIndex = 9;
            // 
            // HexTextBox
            // 
            HexTextBox.Location = new Point(254, 214);
            HexTextBox.Name = "HexTextBox";
            HexTextBox.ReadOnly = true;
            HexTextBox.Size = new Size(323, 23);
            HexTextBox.TabIndex = 10;
            // 
            // encryptionTimeLabel
            // 
            encryptionTimeLabel.AutoSize = true;
            encryptionTimeLabel.Location = new Point(254, 362);
            encryptionTimeLabel.Name = "encryptionTimeLabel";
            encryptionTimeLabel.Size = new Size(80, 15);
            encryptionTimeLabel.TabIndex = 12;
            encryptionTimeLabel.Text = "Encrypt time: ";
            // 
            // decryptionTimeLabel
            // 
            decryptionTimeLabel.AutoSize = true;
            decryptionTimeLabel.Location = new Point(254, 388);
            decryptionTimeLabel.Name = "decryptionTimeLabel";
            decryptionTimeLabel.Size = new Size(81, 15);
            decryptionTimeLabel.TabIndex = 13;
            decryptionTimeLabel.Text = "Decrypt time: ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(254, 11);
            label1.Name = "label1";
            label1.Size = new Size(26, 15);
            label1.TabIndex = 15;
            label1.Text = "Key";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(254, 59);
            label2.Name = "label2";
            label2.Size = new Size(17, 15);
            label2.TabIndex = 16;
            label2.Text = "IV";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(254, 114);
            label3.Name = "label3";
            label3.Size = new Size(56, 15);
            label3.TabIndex = 17;
            label3.Text = "Plain text";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(210, 180);
            label4.Name = "label4";
            label4.Size = new Size(35, 15);
            label4.TabIndex = 18;
            label4.Text = "ASCII";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(210, 217);
            label5.Name = "label5";
            label5.Size = new Size(29, 15);
            label5.TabIndex = 19;
            label5.Text = "HEX";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(601, 450);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(decryptionTimeLabel);
            Controls.Add(encryptionTimeLabel);
            Controls.Add(HexTextBox);
            Controls.Add(AsciiTextBox);
            Controls.Add(plainTextBox);
            Controls.Add(ivTextBox);
            Controls.Add(keyTextBox);
            Controls.Add(decryptButton);
            Controls.Add(encryptButton);
            Controls.Add(generateKeyIVButton);
            Controls.Add(algorithmComboBox);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox algorithmComboBox;
        private Button generateKeyIVButton;
        private Button encryptButton;
        private Button decryptButton;
        private TextBox keyTextBox;
        private TextBox ivTextBox;
        private TextBox plainTextBox;
        private TextBox AsciiTextBox;
        private TextBox HexTextBox;
        private Label encryptionTimeLabel;
        private Label decryptionTimeLabel;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}
