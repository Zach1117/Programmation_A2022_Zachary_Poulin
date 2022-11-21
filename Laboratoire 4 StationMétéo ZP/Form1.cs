/**
 * @file   Form1.cs, Lab_4_Station_Meteo_Zachary_Poulin
 * @author Zachary Poulin
 * @date  17 novembre 2022 
 * @brief  :Le but du laboratoire est de créer un logiciel permettant d'afficher les données reçues par la station météo sur le toit du cégep. 
 * Pour cela, nous avons un affichage constitué de boites de textes et d'un datagridview permettant d'afficher la température, l'humidité, le vent, la direction du vent et la pression. 
 * La trame contenant les données peut être reçue par le port série, mais aussi en UDP. 
 * Finalement, une vérification de la trame va être réalisée avant d'afficher les données pour s'assurer qu'elle est complète.
 * Environnement:
 *     Développement: Visual Studio 2022 (version 17.3.1)
 */
using Lab3_CommSerie_Zachary_Poulin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Laboratoire_4_StationMétéo_ZP
{
    public partial class Form1 : Form
    {
        public delegate void monProtoDelegate(List<byte> ligne,string s);
        monProtoDelegate objDelegate; //Objet delegate
        const int LIMITE_BUFFER = 50;
        const int LONGEUR_TRAME = 13;

        // variables membres liées à la gestion des trames
        List<byte> m_lstTrameRx = new List<byte>(); //conserve les octets reçus du port série
                                                    //Seule la méthode DataReceived du port 
                                                    //série utilise cette variable
        SaveFileDialog diaSauveFichier = new SaveFileDialog(); //Pour sauvegarde fichier CSV
        // variables membres liées à la gestion des trames
        const Byte SOH = 0x01; // défini dans le protocole

        enum enumTrame // les différentes positions sont les index des différents bytes
        {
            soh = 0, // début 
            ID,
            tempMSBDHT1,
            tempLSBDHT1,
            humDHT1,
            tempMSBDHT2,
            tempLSBDHT2,
            humDHT2,
            tempMSBDHT3,
            tempLSBDHT3,
            humDHT3,
            tempMSBBMP,
            tempLSBBMP,
            pressEntier,
            pressDecimal,
            dirVentMSB,
            dirVentLSB,
            vitVent,
            radSolaireMSB,
            radSolaireLSB,
            checksum,
            maxTrame
        };

        enum enumDirVent { Nord = 0, NordEst, Est, SudEst, Sud, SudOuest, Ouest, NordOuest };

        //UDP
        Thread objTh;  //On fera tourner l'objet objThUDP dans un Thread pour la rx de la trame
        ThreadRxUDP objUDP;

        public Form1()
        {
            InitializeComponent();
            objDelegate = methodeDelegateAffiche;


            //Affichage par défaut de la statusStrip
            toolStripStatusLabel1.Text = serialPort1.PortName + ',';  //Afficher les information du port COM dans la statusStrip
            toolStripStatusLabel2.Text = Convert.ToString(serialPort1.BaudRate) + ',';
            toolStripStatusLabel3.Text = Convert.ToString(serialPort1.Parity) + ',';
            toolStripStatusLabel4.Text = Convert.ToString(serialPort1.DataBits) + ',';
            toolStripStatusLabel5.Text = Convert.ToString(serialPort1.StopBits) + ',';
            toolStripStatusLabel6.Text = "Fermé";
            toolStripStatusLabel6.ForeColor = System.Drawing.Color.Red;

            objUDP = new ThreadRxUDP(this);
            objTh = new Thread(objUDP.FaitTravail);
            objTh.Start();

            objUDP.objDelegate = methodeDelegateAffiche;
        }

        /// <summary>
        /// La fonction va s'occuper d'ouvrir la deuxième fenêtre lorsque que le bouton config port série est appuyé 
        /// et de fermer la deuxième fenêtre lorsque que le bouton ok ou annuler de celle-ci est appuyé.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripConfigPort_Click(object sender, EventArgs e)
        {
            ConfigPort fConfig = new ConfigPort(serialPort1.PortName, serialPort1.BaudRate,
                serialPort1.DataBits, serialPort1.Parity, (int)serialPort1.StopBits);
            toolStripStatusLabel6.Text = "Fermé";
            toolStripStatusLabel6.ForeColor = System.Drawing.Color.Red;

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

                if (!serialPort1.IsOpen) //Si le port COM est fermé
                {
                    try
                    {
                        toolStripStatusLabel1.Text = serialPort1.PortName + ',';  //Afficher les information du port COM dans la statusStrip
                        toolStripStatusLabel2.Text = Convert.ToString(serialPort1.BaudRate) + ',';
                        toolStripStatusLabel3.Text = Convert.ToString(serialPort1.Parity) + ',';
                        toolStripStatusLabel4.Text = Convert.ToString(serialPort1.DataBits) + ',';
                        toolStripStatusLabel5.Text = Convert.ToString(serialPort1.StopBits) + ',';
                        serialPort1.Open();   //Ouvrir le port COM
                        toolStripStatusLabel6.Text = "Ouvert"; //Changer l'état du port COM dans la statusStrip
                        toolStripStatusLabel6.ForeColor = System.Drawing.Color.Green; //Modifier le texte en vert                    
                    }
                    catch (UnauthorizedAccessException) //Port COM deja utilisé
                    {
                        MessageBox.Show(serialPort1.PortName + " déja utilisé"); //Faire apparaitre une message Box avec un message d'erreur
                        toolStripStatusLabel6.Text = "Fermé";
                        toolStripStatusLabel6.ForeColor = System.Drawing.Color.Red;
                    }
                    catch (System.InvalidOperationException)
                    {
                        MessageBox.Show(serialPort1.PortName + " déja utilisé"); //Faire apparaitre une message Box avec un message d'erreur
                    }
                    catch (System.IO.IOException) //Tenter d'ouvrir un port COM inexistant
                    {
                        MessageBox.Show(serialPort1.PortName + " n'existe pas"); //Faire apparaitre une message Box avec un message d'erreur
                    }
                }
            }
        }
        /// <summary>
        /// Fonction qui permet de lire les données reçues sur le port série
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int nbALire;
            byte[] lecture = new byte[LIMITE_BUFFER];
            m_lstTrameRx.Clear(); //Vider la liste
            nbALire = serialPort1.BytesToRead;  //on a reçu combien de bytes
            if(nbALire > (int)enumTrame.maxTrame) //Si la trame est supérieur a sa longeur supposé
            {
                serialPort1.DiscardInBuffer(); //Vider le buffer parce que données indésirables
                nbALire = 0; //Nombre à lire a zéro
            }

            if (nbALire == LONGEUR_TRAME)  //Petit test car, de temps en temps on a un événement dataReceive et il n'y a pas de bytes à lire !!!!
            {
                serialPort1.Read(lecture, 0, nbALire); //Lecture du port série
                for (int i = 0; i < nbALire; i++)
                {
                    m_lstTrameRx.Add(lecture[i]); //Ajouter les données dans la liste
                }
                if (verifTrame(m_lstTrameRx))//Retourne vrai, si la trame est valide. Faux si la trame est incomplète ou invalide.
                {
                    BeginInvoke(objDelegate, m_lstTrameRx, "COM"); //Delegé pour afficher les informations de la trame
                }
            }
        }
        /// <summary>
        /// Fonction delegate permettent de faire l'affichage des données dans les textebox et le datagridview
        /// </summary>
        /// <param name="trame">La trame de 13 bytes reçus</param>
        /// <param name="Com">String du moyen de communication utilisé pour recevoir la trame</param>
        private void methodeDelegateAffiche(List<byte> trame, string Com)
        {
            int temp1 = 0;
            int temp2 = 0;
            int temp3 = 0;
            int temp4 = 0;
            int temp1Dec = 0;
            int temp2Dec = 0;
            int temp3Dec = 0;
            int temp4Dec = 0;
            int vent = 0;

            if (tBoxTemp.Text.Length != 0) //Si il y a déja du texte dans la textebox Température
            {
                dataGridView1.Rows.Insert(0); //Ajouté une rangée au datagrid view
                dataGridView1.Rows[1].Selected = false; //Retirer la sélection de la deuxième rangée
            }
            temp1 = ((byte)trame[(int)enumTrame.tempMSBDHT1] << 8) + (byte)trame[(int)enumTrame.tempLSBDHT1];
            temp1Dec = Math.Abs((short)temp1 % 10);
            temp1 = (Int16)temp1 / 10;
            temp2 = ((byte)trame[(int)enumTrame.tempMSBDHT2] << 8) + (byte)trame[(int)enumTrame.tempLSBDHT2];
            temp2Dec = Math.Abs((short)temp2%10);
            temp2 = (Int16)temp2/10;
            temp3 = ((byte)trame[(int)enumTrame.tempMSBDHT3] << 8) + (byte)trame[(int)enumTrame.tempLSBDHT3];
            temp3Dec = Math.Abs((short)temp3 % 10);
            temp3 = (Int16)temp3%10;
            temp4 = ((byte)trame[(int)enumTrame.tempMSBBMP] << 8) + (byte)trame[(int)enumTrame.tempLSBBMP];
            temp4Dec = Math.Abs((short)temp4 % 10);
            temp4 = (Int16)temp4 / 10;
            vent = (trame[(int)enumTrame.dirVentMSB] << 8) + trame[(int)enumTrame.dirVentLSB];
            tBoxTemp.Text = Convert.ToString(temp2) + "," + Convert.ToString(temp2Dec); //Inscrire les informaations dans les textebox
            tBoxHumi.Text = Convert.ToString(trame[(int)enumTrame.humDHT2]);
            tBoxVitesse.Text = Convert.ToString(trame[(int)enumTrame.vitVent]);
            tBoxDirection.Text = Convert.ToString(vent);
            tBoxPression.Text = Convert.ToString(trame[(int)enumTrame.pressEntier]);
            tBoxPression.Text = tBoxPression.Text + ',' + Convert.ToString(trame[(int)enumTrame.pressDecimal]);
            

            string temps = string.Format("{0:HH:mm:ss tt}", DateTime.Now); //Permet de trouvé l'heure actuelle

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; //Change le mode de sélection en rangée
            dataGridView1.Rows[0].Cells[0].Value = temps; //Ajouter les informations dans le datagridview
            dataGridView1.Rows[0].Cells[1].Value = Com;
            dataGridView1.Rows[0].Cells[2].Value = temp1 + "," + temp1Dec;
            dataGridView1.Rows[0].Cells[3].Value = tBoxTemp.Text;
            dataGridView1.Rows[0].Cells[4].Value = temp3 + "," + temp3Dec;
            dataGridView1.Rows[0].Cells[5].Value = temp4 + "," + temp4Dec;
            dataGridView1.Rows[0].Cells[6].Value = Convert.ToString(trame[(int)enumTrame.humDHT1]);
            dataGridView1.Rows[0].Cells[7].Value = Convert.ToString(trame[(int)enumTrame.humDHT2]);
            dataGridView1.Rows[0].Cells[8].Value = Convert.ToString(trame[(int)enumTrame.humDHT3]);
            dataGridView1.Rows[0].Cells[9].Value = Convert.ToString(trame[(int)enumTrame.pressEntier]) + "," + Convert.ToString(trame[(int)enumTrame.pressDecimal]);
            dataGridView1.Rows[0].Cells[10].Value = Convert.ToString(vent);
            dataGridView1.Rows[0].Cells[11].Value = Convert.ToString(trame[(int)enumTrame.vitVent]);
            dataGridView1.Rows[0].Cells[12].Value = Convert.ToString(trame[(int)enumTrame.radSolaireMSB]) + "," + Convert.ToString(trame[(int)enumTrame.radSolaireLSB]);
            dataGridView1.Rows[0].Selected = true; //Sélectionne la première rangée
           
        }
        /// <summary>
        /// Fonction qui permet de sauvegarder localement les données enregistrées dans le datagridview dans un fichier CSV
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileSavebtn_Click(object sender, EventArgs e)
        {
            diaSauveFichier.DefaultExt = "csv"; //Extension du fichier
            StreamWriter swFichier;
            int i, j;
            if (diaSauveFichier.ShowDialog() == DialogResult.OK) 
            {
                swFichier = File.CreateText(diaSauveFichier.FileName);
                swFichier.Write("Données de la station météo le " + DateTime.Now.ToString("MM/dd/yyyy") + " à " + string.Format("{0:HH:mm:ss tt}", DateTime.Now)); //Affiche la date et l'heure dans le CSV
                swFichier.WriteLine(""); //Saut de ligne
                for (j = 0; j < dataGridView1.Rows.Count; j++) // Les rangées
                {
                    for (i = 0; i < dataGridView1.Columns.Count; i++) // Les cellules des rangées
                    {
                        swFichier.Write((string)(dataGridView1.Rows[j].Cells[i].Value)); //Ajout les valeurs du gridview dans le fichier CSV
                        swFichier.Write(";"); //Point virgule pour séparer les données.
                    }
                    swFichier.WriteLine(""); //Saut de ligne
                }
                swFichier.Close(); //Fermer le fichier
            }
        }
        /// <summary>
        /// Fonction qui permet de vérifier si la trame reçue est bonne
        /// </summary>
        /// <param name="trame"></param>
        /// <returns></returns>
        public static bool verifTrame(List<byte> trame)
        {
            if (trame[(int)enumTrame.soh] != SOH) //Si le SOH n'est pas a 1
            {
                return false; //Retourner faux
            }
            if (trame.Count != (int)enumTrame.maxTrame) //Si la trame ne contient pas 13 bytes
            {
                return false; //Retourner faux
            }
            if(calculChecksum(trame) != trame[(int)enumTrame.checksum]) //Si le checksum n'est pas égal
            {
                return false; //Retourner faux
            }
            return true; //Retourner vrai
        }
        /// <summary>
        /// Fonction qui permet de calculer le checksum de la trame recu.
        /// </summary>
        /// <param name="trame"></param>
        /// <returns></returns>
        public static byte calculChecksum(List<byte> trame)
        {
            int checksum = 0;
            for(int i = 2; i < trame.Count -1; i++) //Boucle sur chaque byte sauf le SOH et checksum de la trame
            {
                checksum = checksum + trame[i]; //Addition de chaque byte
            }
            checksum = checksum & 0xFF; //Conserver seulement les 8 lsb

            return (byte) checksum; //Retourne le checksum
        }
        /// <summary>
        /// Fonction qui permet d'ouvrir le menu pour configurer le port série.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void portSérieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripConfigPort_Click(sender, e); //Fonction pour configurer le port série
        }
        /// <summary>
        /// Fonction qui permet de sauvegarder le fichier CSV avec le menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enregistrerSousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileSavebtn_Click(sender, e); // Fonction pour sauvegarder le CSV
        }
        /// <summary>
        /// Fonction qui permet de fermé l'application avec le menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quittéToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit(); //Fermer l'application
        }
        /// <summary>
        /// Fonction qui s'assure que le cient UDP est fermé lorsque que la forme est fermé
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            objUDP.ArreteClientUDP(); //Arret du client UDP
            objTh.Abort();
        }
    }
   
}
