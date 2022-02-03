using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetHopital
{
    class Ordonnance
    {
        private List<Ligne> liste;

        public Ordonnance()
        {
            this.liste = new List<Ligne>();
        }
        public List<Ligne> Liste
        {
            get { return liste; }
        }
        public void AjouterLigne(Ligne ligne)
        {
            liste.Add(ligne);
        }
        public int PrixGlobal()
        {
            int prixGlobal=0;
            foreach (Ligne l in liste)
                prixGlobal += l.PrixLigne;
            return prixGlobal;
        }
        public override string ToString()
        {
            string reponse = "";
            reponse += "\t__________________________________________\n";
            reponse += "\n\t\t**************";
            reponse += "\n\t\t* ORDONNANCE *";
            reponse += "\n\t\t**************\n";
            reponse += "\n-------------------------------------------------------------------------------------------------";
            reponse += "\nID\tNOM\t\t\tQUANTITE\tPRIX(EUROS)";
            reponse += "\n------------------------------------------------------------------------------------------------ - ";
            foreach (Ligne l in liste)
                reponse += "\n"+l.ToString();
            reponse += "\n------------------------------------------------------------------------------------------------ - ";
            reponse += "\n\n\t\t\tPrix Global : " + PrixGlobal();
            return reponse;
        }
    }
}
