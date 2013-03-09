namespace TP1_Telematique
{
    partial class frmMain
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
            this.btnEmettre = new System.Windows.Forms.Button();
            this.opfSource = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTailleTampon = new System.Windows.Forms.TextBox();
            this.txtDelaiTemporisation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFichierSource = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFichierDestination = new System.Windows.Forms.TextBox();
            this.btnConfiguration = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnEmettre
            // 
            this.btnEmettre.Location = new System.Drawing.Point(255, 207);
            this.btnEmettre.Name = "btnEmettre";
            this.btnEmettre.Size = new System.Drawing.Size(263, 23);
            this.btnEmettre.TabIndex = 0;
            this.btnEmettre.Text = "Émettre";
            this.btnEmettre.UseVisualStyleBackColor = true;
            this.btnEmettre.Click += new System.EventHandler(this.btnEmettre_Click);
            // 
            // opfSource
            // 
            this.opfSource.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Taille du tampon :";
            // 
            // txtTailleTampon
            // 
            this.txtTailleTampon.Location = new System.Drawing.Point(170, 21);
            this.txtTailleTampon.Name = "txtTailleTampon";
            this.txtTailleTampon.Size = new System.Drawing.Size(100, 20);
            this.txtTailleTampon.TabIndex = 2;
            // 
            // txtDelaiTemporisation
            // 
            this.txtDelaiTemporisation.Location = new System.Drawing.Point(170, 57);
            this.txtDelaiTemporisation.Name = "txtDelaiTemporisation";
            this.txtDelaiTemporisation.Size = new System.Drawing.Size(100, 20);
            this.txtDelaiTemporisation.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Délai de temporisation :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fichier source :";
            // 
            // txtFichierSource
            // 
            this.txtFichierSource.Location = new System.Drawing.Point(170, 94);
            this.txtFichierSource.Name = "txtFichierSource";
            this.txtFichierSource.Size = new System.Drawing.Size(631, 20);
            this.txtFichierSource.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fichier de destination :";
            // 
            // txtFichierDestination
            // 
            this.txtFichierDestination.Location = new System.Drawing.Point(170, 129);
            this.txtFichierDestination.Name = "txtFichierDestination";
            this.txtFichierDestination.Size = new System.Drawing.Size(631, 20);
            this.txtFichierDestination.TabIndex = 8;
            // 
            // btnConfiguration
            // 
            this.btnConfiguration.Location = new System.Drawing.Point(580, 28);
            this.btnConfiguration.Name = "btnConfiguration";
            this.btnConfiguration.Size = new System.Drawing.Size(178, 23);
            this.btnConfiguration.TabIndex = 9;
            this.btnConfiguration.Text = "Configuration";
            this.btnConfiguration.UseVisualStyleBackColor = true;
            this.btnConfiguration.Click += new System.EventHandler(this.btnConfiguration_Click);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(47, 248);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox.Size = new System.Drawing.Size(717, 204);
            this.textBox.TabIndex = 10;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 464);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.btnConfiguration);
            this.Controls.Add(this.txtFichierDestination);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFichierSource);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDelaiTemporisation);
            this.Controls.Add(this.txtTailleTampon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEmettre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEmettre;
        private System.Windows.Forms.OpenFileDialog opfSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTailleTampon;
        private System.Windows.Forms.TextBox txtDelaiTemporisation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFichierSource;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFichierDestination;
        private System.Windows.Forms.Button btnConfiguration;
        private System.Windows.Forms.TextBox textBox;
    }
}