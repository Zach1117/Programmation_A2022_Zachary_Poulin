namespace Lab3_CommSerie_Zachary_Poulin
{
    partial class ConfigPort
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
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cBbitsStop = new System.Windows.Forms.ComboBox();
            this.cBNbBits = new System.Windows.Forms.ComboBox();
            this.cBParite = new System.Windows.Forms.ComboBox();
            this.cBVitesse = new System.Windows.Forms.ComboBox();
            this.cBPort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(94, 290);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 16);
            this.label6.TabIndex = 23;
            this.label6.Text = "Bits d\'arrêt";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(94, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "Nb Bits";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(94, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "Parité";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(94, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 20;
            this.label3.Text = "Vitesse";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "Port";
            // 
            // cBbitsStop
            // 
            this.cBbitsStop.FormattingEnabled = true;
            this.cBbitsStop.Location = new System.Drawing.Point(183, 290);
            this.cBbitsStop.Name = "cBbitsStop";
            this.cBbitsStop.Size = new System.Drawing.Size(121, 24);
            this.cBbitsStop.TabIndex = 18;
            // 
            // cBNbBits
            // 
            this.cBNbBits.FormattingEnabled = true;
            this.cBNbBits.Location = new System.Drawing.Point(183, 232);
            this.cBNbBits.Name = "cBNbBits";
            this.cBNbBits.Size = new System.Drawing.Size(121, 24);
            this.cBNbBits.TabIndex = 17;
            // 
            // cBParite
            // 
            this.cBParite.FormattingEnabled = true;
            this.cBParite.Location = new System.Drawing.Point(183, 179);
            this.cBParite.Name = "cBParite";
            this.cBParite.Size = new System.Drawing.Size(121, 24);
            this.cBParite.TabIndex = 16;
            // 
            // cBVitesse
            // 
            this.cBVitesse.FormattingEnabled = true;
            this.cBVitesse.Location = new System.Drawing.Point(183, 127);
            this.cBVitesse.Name = "cBVitesse";
            this.cBVitesse.Size = new System.Drawing.Size(121, 24);
            this.cBVitesse.TabIndex = 15;
            // 
            // cBPort
            // 
            this.cBPort.FormattingEnabled = true;
            this.cBPort.Location = new System.Drawing.Point(183, 72);
            this.cBPort.Name = "cBPort";
            this.cBPort.Size = new System.Drawing.Size(121, 24);
            this.cBPort.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 24;
            this.label1.Text = "Configuration";
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(97, 345);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 25;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(262, 345);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 26;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // ConfigPort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 401);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cBbitsStop);
            this.Controls.Add(this.cBNbBits);
            this.Controls.Add(this.cBParite);
            this.Controls.Add(this.cBVitesse);
            this.Controls.Add(this.cBPort);
            this.Name = "ConfigPort";
            this.Text = "ConfigPort";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cBbitsStop;
        private System.Windows.Forms.ComboBox cBNbBits;
        private System.Windows.Forms.ComboBox cBParite;
        private System.Windows.Forms.ComboBox cBVitesse;
        private System.Windows.Forms.ComboBox cBPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}