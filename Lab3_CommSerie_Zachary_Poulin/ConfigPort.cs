/**
 * @file   ConfigPort.cs, Lab_3_Communication_Série_Zachary_Poulin
 * @author Zachary Poulin
 * @date  06 octobre 2022 
 * @brief  : S'occupe de gérer la deuxième fenêtre qui permet de paramétrer le port COM que l'on souhaite utiliser
 * Environnement:
 *     Développement: Visual Studio 2022 (version 17.3.1)
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab3_CommSerie_Zachary_Poulin
{
    public partial class ConfigPort : Form
    {
        //variables membres de la classe frmConfigPort
        public string m_nom { get; set; }
        public int m_vitesse { get; set; }
        public int m_nbBit { get; set; }
        public Parity m_parite { get; set; }
        public int m_stopBit { get; set; }
        public ConfigPort(string name, int baud, int dataBits,Parity parity,int stopBits)
        {
            InitializeComponent();

            cBPort.DropDownStyle = ComboBoxStyle.DropDownList;  //Empêcher l'écriture dans les Combo Box
            cBVitesse.DropDownStyle = ComboBoxStyle.DropDownList;
            cBParite.DropDownStyle = ComboBoxStyle.DropDownList;
            cBNbBits.DropDownStyle = ComboBoxStyle.DropDownList;
            cBbitsStop.DropDownStyle = ComboBoxStyle.DropDownList;
            cBPort.DataSource = SerialPort.GetPortNames(); //Ajouter tout les ports présentement disponible dans la comboBox
            cBVitesse.DataSource = new int[] { 2400, 4800, 9600, 14400, 19200, 28800, 38400, 56000, 57600, 115200, 128000, 256000 }; //Ajouter tout les baud rate disponible dans la combo box
            cBParite.DataSource = Enum.GetNames(typeof(Parity)); //Ajouter les parité dans la combo box
            cBNbBits.DataSource = new int[] { 7, 8 }; //Ajouter les databits dans la combo box
            cBbitsStop.DataSource = new int[] { 1, 2 }; //Ajouter les stopbits dans la combo box
            cBPort.SelectedItem = name; //Afficher les paramètres du port COM par défaut dans les combo box
            cBVitesse.SelectedItem = baud;
            cBParite.SelectedItem = Convert.ToString(parity);
            cBNbBits.SelectedItem = dataBits;
            cBbitsStop.SelectedItem = stopBits;
        }

        
        /// <summary>
        /// Fonction qui s'occupe de changer la valeur des variables lorsque que le bouton ok est appuyé
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            m_nom = cBPort.Text; //Assigne la valeur des combo Box sélectionnées aux variables
            m_vitesse = Convert.ToInt32(cBVitesse.Text);
            m_parite = (Parity)cBParite.SelectedIndex;
            m_nbBit = Convert.ToInt32(cBNbBits.Text);
            m_stopBit = (cBbitsStop.SelectedIndex+1);
        }
    }
}
