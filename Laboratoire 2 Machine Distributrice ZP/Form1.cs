/**
 * @file   Form1.cs, Lab_2_Machine_Distributrice_Zachary_Poulin
 * @author Zachary Poulin
 * @date  20 septembre 2022 
 * @brief  : Le but du laboratoire est de créer l'interface d'une machine distributrice pour pouvoir gérer l'inventaire de la machine et l'interface client. 
 * Dans l'interface cliente, nous utilisons une listeBox avec une classe LCD4Ligne pour pouvoir afficher les différentes informations a l'utilisateur. 
 * Tell que l'article, le montant à payer, etc. L'utilisateur peut interagir avec la machine avec l'aide de deux claviers possédant plusieurs boutons regroupés.
 * Par la suite, il y a un autre onglet nommé inventaire qui permet de sélectionner un article grâce à deux comboBox et d'afficher la quantité restant et le prix de l'article. 
 * Il est aussi possible de modifier ces deux paramètres avec les deux texteBox et ensuite appuyer sur le bouton modifier l'inventaire. 
 * Finalement, une classe ItemInventaire s'occupe de la gestion des fonctions qui modifie les valeurs de l'inventaire.
 * Environnement:
 *     Développement: Visual Studio 2022 (version 17.3.1)
 */


using System;
using System.Windows.Forms;



namespace Laboratoire_2_Machine_Distributrice_Zachary_Poulin
{
    public partial class Form1 : Form
    {
        /********* constantes ***********/
        public const int NBRANGEE = 6;
        public const int NBCOLONNE = 10;
        const int NB_BOUTON = 10;

        /********** variables membres ***********/
        private Lcd4Lignes m_objAffichage;
        private ItemInventaire[,] m_tabInventaire = new ItemInventaire[NBRANGEE, NBCOLONNE];  //tableau contenant l'inventaire
        private Button[] m_Clavier = new Button[NB_BOUTON]; //tableau contenant les objets (Button) du clavier

        /*** Les variables ci-dessous sont utilisées par m_objAffichage pour générer l'affichage ***/
        private int m_prixCourant = 0;
        private int m_credit = 0;
        private int m_retourCredit = 0;
        private int m_indexRangee = 255;
        private int m_indexColonne = 255;
        private Boolean m_manqueCredit;
        private Boolean m_annulationVente;
        private Boolean m_distributionActive;
        private Boolean m_qteZero;


        public Form1()
        {
            int prixTemp = 25;
            Control ctrlSuivant; //déclaration d'un objet Control
            InitializeComponent();
            m_objAffichage = new Lcd4Lignes(); //Création de l'objet affichage avec l'appel du constructeur LCD4Lignes

            for (int i = 0; i < NBRANGEE; i++) //Boucle pour initialiser le tableau inventaire
            {
                for (int j = 0; j < NBCOLONNE; j++) 
                {
                    m_tabInventaire[i, j] = new ItemInventaire(prixTemp, 2); //Initialiser prix et quantité dans tableau inventaire
                    prixTemp = prixTemp + 10; //Incrémentation du prix de 10 cents
                }
                prixTemp = prixTemp - 75;
            }

            prixTBox.Text = Convert.ToString(m_tabInventaire[0, 0].prix); //Affichier dans la texte box prix le prix du premiere article
            quantiteTBox.Text = Convert.ToString(m_tabInventaire[0, 0].quantite); //Affichier dans la texte box quantité la quantité du premiere article
            comboBoxRangee.DropDownStyle = ComboBoxStyle.DropDownList; //Pour éviter que l'utilisateur écrive dans la comboBox
            comboBoxColonne.DropDownStyle = ComboBoxStyle.DropDownList; //Pour éviter que l'utilisateur écrive dans la comboBox

            affiche(); //Fonction pour l'affichage LCD dans la liste box

            ctrlSuivant = panelClavier; // Le point de départ de la recherche sera le Pannel

            for (int i = 0; i < NB_BOUTON; i++) //Boucle
            {
                ctrlSuivant = GetNextControl(ctrlSuivant, true);
                m_Clavier[i] = (Button)ctrlSuivant; //casting de l'objet Control trouvé (ctrlSuivant) en bouton
            }
        }
        /// <summary>
        /// La fonction va s'occuper de gérer les interactions de l'utilisateur avec le clavier ce qui lui permet de choisir
        /// la rangée et la colonne de l'objet qu'il veut obtenir dans la machine distributrice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClavier_Click(object sender, EventArgs e)
        {
            Button bouton;
            char c;

            bouton = (Button)sender; //Casting du sender en Button
            c = Convert.ToChar(bouton.Text);  //Récupérer la lettre inscrite dans le bouton


            if (c >= '0' && c <= '9') //Si le bouton appuyé est un chiffre
            {
                m_indexColonne = c - '0'; //Calcul de l'index en utilisant le caractere afficher moin le code ASCCI de 0
                m_prixCourant = m_tabInventaire[m_indexRangee, m_indexColonne].prix; //Trouver le prix de l'item grace au index trouvé
                if (m_tabInventaire[m_indexRangee, m_indexColonne].quantite == 0) //Vérification si le distributeur est vide
                {
                    m_qteZero = true; //variable global pour indiquer quantité est vide
                    timer1.Enabled = true; //Démarrer le timer pour l'affichage
                }
                barreClavier(true); //Vérouiller le clavier
            }
            else //Si le bouton appuyé est une lettre
            {
                m_indexRangee = c - 'A'; //Calcul de l'index en utilisant le caractere afficher moin le code ASCCI de A
                setClavierChiffre(true); // Remplacer les lettre du clavier par des chiffres
            }
            affiche(); //Fonction pour l'affichage LCD dans la liste box

        }

        /// <summary>
        /// La fonction va s'occuper de modifier l'apparence du clavier utilisé pour le choix des index 
        /// </summary>
        /// <param name="etat">Vrai pour afficher les chiffres sur clavier et faux pour afficher les lettres</param>
        private void setClavierChiffre(bool etat)
        {
            char affichage;
            if (etat == true)
            {
                affichage = '0'; 
                for (int i = 0; i < NB_BOUTON; i++) //Boucle pour chaque boutons
                {
                    m_Clavier[i].Text = affichage.ToString(); //Modifier le texte sur le bouton pour des chiffres
                    affichage++; //Incrémentation de la valeur
                }
            }
            else
            {
                affichage = 'C';
                for (int i = NB_BOUTON - 1; i > -1; i--) //Boucle pour chaque boutons
                {
                    if (i == 6) //Si arrivé deuxieme rangée de bouton
                    {
                        affichage = 'F'; //Le première bouton est F
                    }
                    else if (i == 3) //Pour la troisième rangée de boutons
                    {
                        affichage = ' '; //Afficher des espaces
                    }
                    m_Clavier[i].Text = affichage.ToString(); //Modifier le texte sur les boutons pour afficher les lettre
                    affichage--; //Décrémentation de la valeur
                }
            }

        }
        /// <summary>
        /// Fonction pour gérer le bouton « Clear » quand il est appuyé
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            m_annulationVente = true; //Variable global pour afficher annulation de la vente
            timer1.Enabled = true; //Activer le timer pour l'affichage
            barreClavier(true); //Vérouiller le clavier
            m_retourCredit = m_credit; //Calcul du crédit a retourner
            affiche(); //Fonction pour l'affichage LCD dans la liste box
        }
        /// <summary>
        /// Fonction pour gérer le bouton « Enter » quand il est appuyé
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (m_indexRangee == 255 || m_indexColonne == 255); //Si la rangée ou la colonne n'a pas été sélectionné

            else
            {
                m_tabInventaire[m_indexRangee, m_indexColonne].diminuerInventaire(); //Appel fonction pour diminuer la quantité de 1
      
                if (m_credit >= m_tabInventaire[m_indexRangee, m_indexColonne].prix) //Vérification si le montant entrer est égal ou suprérieur au prix
                {
                    m_retourCredit = m_credit - m_tabInventaire[m_indexRangee, m_indexColonne].prix; //Calcul du montant de crédit a retourner
                    m_distributionActive = true; //Variable global pour afficher achat est effectuer
                    affiche(); //Fonction pour l'affichage LCD dans la liste box
                    timer1.Enabled = true; //Activer le timer pour l'affichage
                }
                else //Si le montant de crédit est inférieur au prix
                {
                    m_manqueCredit = true; //Variable global pour l'affichage manque crédit
                    affiche(); //Fonction pour l'affichage LCD dans la liste box
                    timer1.Enabled = true; //Activer le timer pour l'affichage
                }
            }

        }
        /// <summary>
        /// Fonction pour gérer les boutons crédit pour ajouter un montant de crédit quand ils sont appuyés
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCredit_Click(object sender, EventArgs e)
        {
            Button bouton;
            string chaine;

            bouton = (Button)sender; //Casting du sender en Button
            chaine = bouton.Text;  //Récupérer le texte incrit dans le bouton

            chaine = chaine.Trim('$');         //Enleve le signe de $
            chaine = chaine.Replace(".", "");   //Enleve le point

            m_credit = m_credit + Convert.ToInt16(chaine); //Addition le montant de crédit
            affiche(); //Fonction pour l'affichage LCD dans la liste box
        }
        /// <summary>
        /// Fonction pour générer l'affichage LCD dans la liste box
        /// </summary>
        void affiche()
        {

            m_objAffichage.genererAffichage(m_indexRangee, m_indexColonne, m_credit, m_retourCredit, m_prixCourant, m_distributionActive, m_manqueCredit, m_annulationVente, m_qteZero); //Objet contenant les variable pour l'affichage

            listBox1.Items.Clear(); //Effacer l'affichage
            for (int i = 0; i < 4; i++) //Boucle pour chaque ligne de l'affichage
            {
                listBox1.Items.Add(m_objAffichage.lignesAffichage[i]); //Afficher la ligne dans la liste box
            }
        }
        /// <summary>
        /// Fonction qui s'occupe de gérer le timer et reset les variable modifier selon l'état de la machine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false; //Désactiver le timer
            if (m_manqueCredit) //Si manque de crédit
            {
                m_manqueCredit = false; //Reset la variable
            }
            else if (m_annulationVente) //Si le bouton cleare est appuyé annuler la vente
            {
                m_credit = 0; //Reset du crédit insérer
                m_annulationVente = false; //Reset de la variable
                m_prixCourant = 0; //Reset du prix à payer
                m_retourCredit = 0; //Reset du crédit a retourner
                m_indexRangee = 255; //Reset de l'index
                m_indexColonne = 255; //Reset de l'index
                barreClavier(false); //Dévérouiller le clavier
                setClavierChiffre(false); //Afficher les lettres sur le clavier
            }
            else if (m_qteZero) //Si le distributeur est vide
            {
                m_qteZero = false; //Reset de la variable
                m_indexRangee = 255; //Reset de l'index
                m_indexColonne = 255; //Reset de l'index
                barreClavier(false); //Dévérouiller le clavier
                setClavierChiffre(false); //Afficher les lettres sur le clavier
            }
            else if(m_distributionActive) //Si le produit a été acheté
            {
                m_distributionActive = false; //Reset de la variable
                m_credit = 0; //Reset du crédit insérer
                m_prixCourant = 0; //Reset du prix à payer
                m_retourCredit = 0; //Reset du crédit a retourner
                m_indexRangee = 255; //Reset de l'index
                m_indexColonne = 255; //Reset de l'index
                barreClavier(false); //Dévérouiller le clavier
                setClavierChiffre(false); //Afficher les lettres sur le clavier
            }
            affiche(); //Fonction pour l'affichage LCD dans la liste box
        }
        /// <summary>
        /// Permet de vérrouiller ou de dévérrouiller le clavier selon le paramètre reçu
        /// </summary>
        /// <param name="etat">Vrai,le clavier va être désactivé et faux le clavier va être activé</param>
        private void barreClavier(bool etat)
        {
            for (int i = 0; i < NB_BOUTON; i++) //Boucle pour chaque bouton du clavier
            {
                m_Clavier[i].Enabled = !etat; //Selon l'état le clavier va etre disable ou enable
            }
        }
        /// <summary>
        /// Fonction qui est appelée quand l'une des deux comboBox est modifié par l'utilisateur dans l'onglet inventaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            prixTBox.Text = Convert.ToString(m_tabInventaire[comboBoxRangee.SelectedIndex, comboBoxColonne.SelectedIndex].prix); //Écrire dans la texte box prix le prix de l'article
            quantiteTBox.Text = Convert.ToString(m_tabInventaire[comboBoxRangee.SelectedIndex, comboBoxColonne.SelectedIndex].quantite); //Écrire dans la texte box quantité le nombre d'article
        }
        /// <summary>
        /// Fonction qui est appelée quand le bouton « Modifier inventaire » est appuyé dans l'onglet inventaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifierInventaire_Click(object sender, EventArgs e)
        {
            m_tabInventaire[comboBoxRangee.SelectedIndex, comboBoxColonne.SelectedIndex].modifierInventaire(Convert.ToInt32(prixTBox.Text), Convert.ToInt32(quantiteTBox.Text)); //Utilisation de la fonction modifier inventaire qui se retrouve dans la class ItemInventaire qui reçoit en paramètre le prix et la quantité
        }
        /// <summary>
        /// Fonction qui est appelée quand l'utilisateur clique sur l'onglet inventaire pour affichier les informations du produit sélectionner
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inventaireClick(object sender, EventArgs e)
        {
            prixTBox.Text = Convert.ToString(m_tabInventaire[comboBoxRangee.SelectedIndex, comboBoxColonne.SelectedIndex].prix); //Écrire dans la texte box prix le prix de l'article
            quantiteTBox.Text = Convert.ToString(m_tabInventaire[comboBoxRangee.SelectedIndex, comboBoxColonne.SelectedIndex].quantite); //Écrire dans la texte quantité le nombre d'article
        }
    }
}
