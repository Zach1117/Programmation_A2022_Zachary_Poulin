/**
 * @file   Form1.cs, Lab_3_Communication_Série_Zachary_Poulin
 * @author Zachary Poulin
 * @date  06 octobre 2022 
 * @brief  :Le but du laboratoire est de créer un logiciel permettant de contrôler un port série pour envoyer et recevoir des messages à l'aide de celui-ci comme terminal.exe. 
 * Pour commencer, nous avons créé 2 texte box. Une se nommant tx pour transmettre un message et une se nommant rx pour recevoir des messages. 
 * Ensuite, il y a un bouton tx qui envoie le message saisi dans la boite de texte tx. 
 * De plus, il y a un bouton config qui permet de modifier les paramètres du port série tell que le COM utilisé, le baud rate, 
 * le nombre de databits, la parité et le nombre de stopbits. Ensuite, il y a un bouton qui permet d'ouvrir et de fermer le port série. 
 * Finalement, un statusStrip va afficher les différents paramètres du port série et s'il est fermé ou ouvert.
 * Environnement:
 *     Développement: Visual Studio 2022 (version 17.3.1)
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3_CommSerie_Zachary_Poulin
{
    public partial class Form1 : Form
    {
        public delegate void monProtoDelegate(string ligne);
        monProtoDelegate objDelegate; //Objet delegate
        public Form1()
        {
            InitializeComponent();
            objDelegate = methodeDelegateAffiche;

            serialPort1.Encoding = Encoding.GetEncoding(28591); //Permet l'utilisation des caractères ASCII étendus
            toolStripStatusLabel1.Text = "COMx,"; //Initialisation par défaut des paramètres afficher dans la statusStrip
            toolStripStatusLabel2.Text = Convert.ToString(serialPort1.BaudRate) + ',';
            toolStripStatusLabel3.Text = Convert.ToString(serialPort1.Parity) + ',';
            toolStripStatusLabel4.Text = Convert.ToString(serialPort1.DataBits) + ',';
            toolStripStatusLabel5.Text = Convert.ToString(serialPort1.StopBits) + ',';
            toolStripStatusLabel6.Text = "Fermé";
            toolStripStatusLabel6.ForeColor = System.Drawing.Color.Red;   //Modifié le texte de l'état du port COM en Rouge      
        }

        private void btnTX_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.WriteLine(tBoxTransmit.Text); //Envoyée la commande
            }
            catch //Si le port COM n'est pas ouvert
            {
                MessageBox.Show(serialPort1.PortName + " est fermé"); //Faire apparaitre une message Box avec un message d'erreur
            }

        }
        /// <summary>
        /// La fonction s'occupe de lire l'entrée du port COM lorsque un message est reçu et de traiter le message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serialCom_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string sRx; //String pour contenir le texte reçu
            sRx = serialPort1.ReadLine(); //Lire l'entrée du port COM et conserver donné dans la string
            BeginInvoke(objDelegate, sRx);
        }
        /// <summary>
        /// La fonction s'occupe d'afficher le résultat de la lecture du port
        /// </summary>
        /// <param name="stLigne"></param>
        private void methodeDelegateAffiche(string stLigne)
        {
            tBoxReceive.Text = stLigne; //Inscrire le résultat reçu dans la texte box rx
        }

        /// <summary>
        /// La fonction va s'occuper d'ouvrir la deuxième fenêtre lorsque que le bouton config port série est appuyé 
        /// et de fermer la deuxième fenêtre lorsque que le bouton ok ou annuler de celle-ci est appuyé.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfigSerialPort_Click(object sender, EventArgs e)
        {
            //Crée la feuille de config. Appelle le constructeur et on lui passe la config. actuelle du port série.
            ConfigPort fConfig = new ConfigPort(serialPort1.PortName, serialPort1.BaudRate,
                                            serialPort1.DataBits, serialPort1.Parity, (int)serialPort1.StopBits);

            //Ouvre la fenêtre de config et attend que l'usager la ferme par le bouton OK ou Annuler
            if (fConfig.ShowDialog() == DialogResult.OK) //Note: La propriété DialogResult du bouton ok doit être à OK.
            {
                //On récupère les informations de configurations et on les assignent à au port série
                if (serialPort1.IsOpen) //Si le port COM est ouvert le fermé avant de modifier ses paramètres
                    serialPort1.Close();
                serialPort1.PortName = fConfig.m_nom; //Modification des paramètres du port COM
                serialPort1.BaudRate = fConfig.m_vitesse;
                serialPort1.DataBits = fConfig.m_nbBit;
                serialPort1.Parity = fConfig.m_parite;
                serialPort1.StopBits = (StopBits)fConfig.m_stopBit;
                btnOuvrir.PerformClick(); //Fonction qui simule avoir appuyé sur le bouton ouvrir
            }
        }

        /// <summary>
        /// La fonction va s'occuper d'ouvrir et fermé le port COM, d'afficher ses paramètres dans la statusStrip 
        /// et de gérer les différentes erreurs qui peuvent être causés par l'ouverture d'un port COM.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOuvrir_Click(object sender, EventArgs e)
        {
            if(!serialPort1.IsOpen) //Si le port COM est fermé
            {
                try
                {
                    toolStripStatusLabel1.Text = serialPort1.PortName + ',';  //Afficher les information du port COM dans la statusStrip
                    toolStripStatusLabel2.Text = Convert.ToString(serialPort1.BaudRate) + ',';
                    toolStripStatusLabel3.Text = Convert.ToString(serialPort1.Parity) + ',';
                    toolStripStatusLabel4.Text = Convert.ToString(serialPort1.DataBits) + ',';
                    toolStripStatusLabel5.Text = Convert.ToString(serialPort1.StopBits) + ',';
                    serialPort1.Open();   //Ouvrir le port COM
                    btnOuvrir.Text = "Fermé"; //Changer le texte du bouton pour fermé
                    toolStripStatusLabel6.Text = "Ouvert"; //Changer l'état du port COM dans la statusStrip
                    toolStripStatusLabel6.ForeColor = System.Drawing.Color.Green; //Modifier le texte en vert                    
                }
                catch (UnauthorizedAccessException) //Port COM deja utilisé
                {
                    MessageBox.Show(serialPort1.PortName + " déja utilisé");  
                }
                catch (System.InvalidOperationException)
                {
                    MessageBox.Show(serialPort1.PortName + " déja utilisé"); //Faire apparaitre une message Box avec un message d'erreur
                }
                catch(System.IO.IOException) //Tenter d'ouvrir un port COM inexistant
                {
                    MessageBox.Show(serialPort1.PortName + " n'existe pas"); //Faire apparaitre une message Box avec un message d'erreur
                }
            }
            else //Si le port COM est ouvert
            {
                serialPort1.Close(); //Fermé le port COM
                toolStripStatusLabel6.Text = "Fermé"; //Changer l'état du port COM dans la statusStrip
                toolStripStatusLabel6.ForeColor = System.Drawing.Color.Red; //Modifier la couleur du texte en rouge
                btnOuvrir.Text = "Ouvrir"; //Modifier le texte du bouton
            }
            
        }
        /// <summary>
        /// Fonction qui quitte l'application lorsque que le bouton quitter est appuyé
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit(); //Ferme l'application
        }
    }
}
