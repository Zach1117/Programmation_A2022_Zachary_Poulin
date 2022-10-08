/**
 * @file   Form1.cs, Lab_2_Machine_Distributrice_Zachary_Poulin
 * @author Zachary Poulin
 * @date  20 septembre 2022 
 * @brief  : La classe ItemInventaire contient les différentes fonctions qui s'occupent de créer le tableau inventaire et de gérer ses paramètre. 
 * Par exemple, affecter une nouvelle quantité à l'article sélectionné.
 * Environnement:
 *     Développement: Visual Studio 2022 (version 17.3.1)
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratoire_2_Machine_Distributrice_Zachary_Poulin
{
    internal class ItemInventaire
    {
        private int m_prix; //Variable pour le prix
        private int m_quantite;//Variable pour la quantité

        //Création des propriétés prix et quantite et des méthodes get permettant de lire les variables privées 
        //m_prix et m_quantite.
        //Aucune méthode set, car on protège nos variables privées. L'usager devra utiliser les méthodes
        //modifierInventaire et diminuerInventaire pour modifier les variables
        public int prix
        {
            get
            {
                return m_prix;
            }
        }

        public int quantite
        {
            get
            {
                return m_quantite;
            }
        }

        /// <summary>
        /// Constructeur. Doit utiliser la méthode modifierInventaire pour assigner les prix et quantite
        /// </summary>
        /// <param name="prixItem"> on reçoit le prix de l'item lors de sa création</param>
        /// <param name="qteItem"> on reçoit la quantité de l'item lors de sa création<</param>
        public ItemInventaire(int prixItem, int qteItem)
        {
            m_prix = prixItem; //Affecter le nouveau prix
            m_quantite = qteItem; //Affecter la nouvelle quantité
        }

        /// <summary>
        /// Permet de modifier le prix et la quantité d'un item de l'inventaire s'ils sont valides
        /// </summary>
        /// <param name="oPrix">Doit être entre 0.25$ et 3.00$ et un multiple de 5 cents</param>
        /// <param name="oQuantite">Doit être entre 1 et 9 inclusivement</param>
        /// <returns>Vrai si la modification a réussi. Faux si non.</returns>
        public bool modifierInventaire(int oPrix, int oQuantite)
        {
            bool modification = false;
            if(oPrix >= 25 && oPrix <= 300 && (oPrix%5 == 0)) //Vérification si le prix est entre 25 cents et 3$ et qu'il est un multiple de 5
            {
                m_prix = oPrix; //Modifier l'ancien prix par le nouveau
                modification = true;
            }
            else
            {
                MessageBox.Show("Prix Invalide"); //Sinon faire apparaître message d'erreur
            }
            if(oQuantite >= 1 && oQuantite <= 9) //Si la quantité est entre 1 et 9
            {
                m_quantite = oQuantite; //Modifier variable quantité par nouvelle quantité
                modification = true;
            }
            else
            {
                MessageBox.Show("Quantité doit etre entre 1 et 9"); //Sinon faire apparaître message d'erreur
            }
            return modification; //retourner vrai si modification effecter
        }

        /// <summary>
        /// Moins un sur la qte si > 0
        /// </summary>
        public void diminuerInventaire()
        {
            if(m_quantite > 0) //Si la quantité est supérieur a 0
            {
                m_quantite--; //Décrémenter la quantité
            }
        }
    }
}
