/**
 * @file   ConfigPort.cs, Lab_4_Station_Meteo_Zachary_Poulin
 * @author Zachary Poulin
 * @date  17 novembre 2022 
 * @brief  : S'occupe de gérer la réception des données sur le port série et les données reçues en UDP
 *     Développement: Visual Studio 2022 (version 17.3.1)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Laboratoire_4_StationMétéo_ZP.Form1;

namespace Laboratoire_4_StationMétéo_ZP
{
    internal class ThreadRxUDP
    {
        List<byte> m_lstTrameRx = new List<byte>();

        public delegate void protoDelegate(List<byte> buffer, string srcIp);
        public protoDelegate objDelegate;

        private UdpClient udpClient;
        private Form ptrMain;
        const int PORT_RX = 2223;  //Port de réception UDP
        const int MAX_TRAME = 21; //Grosseur max du buffer de réception

        private byte[] m_trameRx = new byte[MAX_TRAME];  //buffer de Rx


        private IPAddress ipClient;  //à titre d'info pour savoir qui a émit la trame UDP
        private int portClient; //idem pour le port


        /// <summary>
        /// Constructeur
        /// </summary>
        public ThreadRxUDP(Form ptrDeLaFormPrincipale)
        {
            ptrMain = ptrDeLaFormPrincipale; //Adresse du pointeur

            udpClient = new UdpClient(PORT_RX);
        }


        /// <summary>
        /// Méthode principale appelée par le Thread. Elle permet de lire les communications UDP recu et de retourner l'information à la form principal
        /// </summary>
        public void FaitTravail()
        {
            IPEndPoint IpDistant = new IPEndPoint(IPAddress.Any, 0);

            //le thread tourne toujours dans cette boucle en attente d'une trame UDP
            while (true)
            {
                m_trameRx = udpClient.Receive(ref IpDistant); //le mot ref permet de passer l'adresse d'IpDistant pour que la méthode Receive puisse le modifier. Équivalent à &IpAdresse en C)
                ipClient = IpDistant.Address;  //ip du client UDP qui a émit la trame
                portClient = IpDistant.Port;   //port du client UDP qui a émit la trame
                string UDP = Convert.ToString(ipClient) + ":" + Convert.ToString(portClient);
                m_lstTrameRx.Clear(); //Vider la liste
                if(m_trameRx.Count() == MAX_TRAME) //Vérification si la trame est complète
                {
                    for(int i = 0; i < MAX_TRAME;i++) //Ajout des données reçues dans la list
                    {
                        m_lstTrameRx.Add(m_trameRx[i]);
                    }
                    if(Form1.verifTrame(m_lstTrameRx)) //Vérification de la trame reçue
                    {
                        ptrMain.BeginInvoke(objDelegate, m_lstTrameRx, UDP); //pointeur de delegate pour afficher les données
                    }
                }
            }
        }
        /// <summary>
        /// Fonction qui va fermer le client UDP
        /// </summary>
        public void ArreteClientUDP()
        {
            udpClient.Close(); //Fermeture du client UDP
        }

    
    }
}
