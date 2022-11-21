namespace Laboratoire_4_StationMétéo_ZP
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tBoxTemp = new System.Windows.Forms.TextBox();
            this.tBoxHumi = new System.Windows.Forms.TextBox();
            this.tBoxVitesse = new System.Windows.Forms.TextBox();
            this.tBoxDirection = new System.Windows.Forms.TextBox();
            this.tBoxPression = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripConfigPort = new System.Windows.Forms.ToolStripButton();
            this.fileSavebtn = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enregistrerSousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quittéToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portSérieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Temps = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Température = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Humidite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pression = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vitesse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Température(°C)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Humidité(%)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Vent";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Pression(kPa)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Vitesse(km/h)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Direction";
            // 
            // tBoxTemp
            // 
            this.tBoxTemp.Location = new System.Drawing.Point(14, 50);
            this.tBoxTemp.Name = "tBoxTemp";
            this.tBoxTemp.Size = new System.Drawing.Size(100, 22);
            this.tBoxTemp.TabIndex = 6;
            // 
            // tBoxHumi
            // 
            this.tBoxHumi.Location = new System.Drawing.Point(17, 52);
            this.tBoxHumi.Name = "tBoxHumi";
            this.tBoxHumi.Size = new System.Drawing.Size(100, 22);
            this.tBoxHumi.TabIndex = 7;
            // 
            // tBoxVitesse
            // 
            this.tBoxVitesse.Location = new System.Drawing.Point(17, 58);
            this.tBoxVitesse.Name = "tBoxVitesse";
            this.tBoxVitesse.Size = new System.Drawing.Size(100, 22);
            this.tBoxVitesse.TabIndex = 8;
            // 
            // tBoxDirection
            // 
            this.tBoxDirection.Location = new System.Drawing.Point(17, 126);
            this.tBoxDirection.Name = "tBoxDirection";
            this.tBoxDirection.Size = new System.Drawing.Size(100, 22);
            this.tBoxDirection.TabIndex = 9;
            // 
            // tBoxPression
            // 
            this.tBoxPression.Location = new System.Drawing.Point(17, 49);
            this.tBoxPression.Name = "tBoxPression";
            this.tBoxPression.Size = new System.Drawing.Size(100, 22);
            this.tBoxPression.TabIndex = 10;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripConfigPort,
            this.fileSavebtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1087, 27);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripConfigPort
            // 
            this.toolStripConfigPort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripConfigPort.Image = global::Laboratoire_4_StationMétéo_ZP.Properties.Resources.gear;
            this.toolStripConfigPort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripConfigPort.Name = "toolStripConfigPort";
            this.toolStripConfigPort.Size = new System.Drawing.Size(29, 24);
            this.toolStripConfigPort.Text = "toolStripButton1";
            this.toolStripConfigPort.Click += new System.EventHandler(this.toolStripConfigPort_Click);
            // 
            // fileSavebtn
            // 
            this.fileSavebtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fileSavebtn.Image = global::Laboratoire_4_StationMétéo_ZP.Properties.Resources.Blue_FloppyDisk;
            this.fileSavebtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fileSavebtn.Name = "fileSavebtn";
            this.fileSavebtn.Size = new System.Drawing.Size(29, 24);
            this.fileSavebtn.Text = "toolStripButton2";
            this.fileSavebtn.Click += new System.EventHandler(this.fileSavebtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.configurationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1087, 28);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enregistrerSousToolStripMenuItem,
            this.quittéToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.fichierToolStripMenuItem.Text = "Fichier";
            // 
            // enregistrerSousToolStripMenuItem
            // 
            this.enregistrerSousToolStripMenuItem.Name = "enregistrerSousToolStripMenuItem";
            this.enregistrerSousToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.enregistrerSousToolStripMenuItem.Text = "Enregistrer sous";
            this.enregistrerSousToolStripMenuItem.Click += new System.EventHandler(this.enregistrerSousToolStripMenuItem_Click);
            // 
            // quittéToolStripMenuItem
            // 
            this.quittéToolStripMenuItem.Name = "quittéToolStripMenuItem";
            this.quittéToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.quittéToolStripMenuItem.Text = "Quitté";
            this.quittéToolStripMenuItem.Click += new System.EventHandler(this.quittéToolStripMenuItem_Click);
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.portSérieToolStripMenuItem});
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.configurationToolStripMenuItem.Text = "Configuration";
            // 
            // portSérieToolStripMenuItem
            // 
            this.portSérieToolStripMenuItem.Name = "portSérieToolStripMenuItem";
            this.portSérieToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.portSérieToolStripMenuItem.Text = "Port Série";
            this.portSérieToolStripMenuItem.Click += new System.EventHandler(this.portSérieToolStripMenuItem_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel6});
            this.statusStrip1.Location = new System.Drawing.Point(0, 435);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1087, 26);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel3.Text = "toolStripStatusLabel3";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel4.Text = "toolStripStatusLabel4";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel5.Text = "toolStripStatusLabel5";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel6.Text = "toolStripStatusLabel6";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tBoxTemp);
            this.panel1.Location = new System.Drawing.Point(45, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(130, 126);
            this.panel1.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.tBoxHumi);
            this.panel2.Location = new System.Drawing.Point(193, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(130, 126);
            this.panel2.TabIndex = 15;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.tBoxVitesse);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.tBoxDirection);
            this.panel3.Location = new System.Drawing.Point(349, 71);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(130, 162);
            this.panel3.TabIndex = 16;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.tBoxPression);
            this.panel4.Location = new System.Drawing.Point(504, 71);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(130, 126);
            this.panel4.TabIndex = 17;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Temps,
            this.Source,
            this.Température,
            this.Humidite,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Pression,
            this.Direction,
            this.Vitesse,
            this.Column6});
            this.dataGridView1.Location = new System.Drawing.Point(-2, 265);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1091, 167);
            this.dataGridView1.TabIndex = 18;
            // 
            // Temps
            // 
            this.Temps.HeaderText = "Temps";
            this.Temps.MinimumWidth = 6;
            this.Temps.Name = "Temps";
            this.Temps.Width = 80;
            // 
            // Source
            // 
            this.Source.HeaderText = "Source";
            this.Source.MinimumWidth = 6;
            this.Source.Name = "Source";
            this.Source.Width = 90;
            // 
            // Température
            // 
            this.Température.HeaderText = "Temp1 int (°C)";
            this.Température.MinimumWidth = 6;
            this.Température.Name = "Température";
            this.Température.Width = 60;
            // 
            // Humidite
            // 
            this.Humidite.HeaderText = "Temp2 Ext (°C)";
            this.Humidite.MinimumWidth = 6;
            this.Humidite.Name = "Humidite";
            this.Humidite.Width = 60;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Temp3 Ext (°C)";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 60;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Temp4 int (°C)";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 60;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Hum1 int (%)";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 60;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Hum2 ext (%)";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 60;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Hum3 ext (%)";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 60;
            // 
            // Pression
            // 
            this.Pression.HeaderText = "Pression (kPa)";
            this.Pression.MinimumWidth = 6;
            this.Pression.Name = "Pression";
            this.Pression.Width = 60;
            // 
            // Direction
            // 
            this.Direction.HeaderText = "Dir Vent";
            this.Direction.MinimumWidth = 6;
            this.Direction.Name = "Direction";
            this.Direction.Width = 60;
            // 
            // Vitesse
            // 
            this.Vitesse.HeaderText = "Vitesse Vent (km/h)";
            this.Vitesse.MinimumWidth = 6;
            this.Vitesse.Name = "Vitesse";
            this.Vitesse.Width = 60;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Rad sol (W/M2)";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 60;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 461);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tBoxTemp;
        private System.Windows.Forms.TextBox tBoxHumi;
        private System.Windows.Forms.TextBox tBoxVitesse;
        private System.Windows.Forms.TextBox tBoxDirection;
        private System.Windows.Forms.TextBox tBoxPression;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripConfigPort;
        private System.Windows.Forms.ToolStripButton fileSavebtn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enregistrerSousToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quittéToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem portSérieToolStripMenuItem;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Temps;
        private System.Windows.Forms.DataGridViewTextBoxColumn Source;
        private System.Windows.Forms.DataGridViewTextBoxColumn Température;
        private System.Windows.Forms.DataGridViewTextBoxColumn Humidite;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pression;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direction;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vitesse;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}

