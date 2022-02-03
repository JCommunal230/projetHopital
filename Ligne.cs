using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetHopital
{
    class Ligne
    {
        private int quantite;
        private int idMedicament;
        private string nomMedicament;
        private int prixLigne;

        public Ligne() { }
        public Ligne(int quantite, int idMedicament, string nomMedicament, int prixLigne)
        {
            this.quantite = quantite;
            this.idMedicament = idMedicament;
            this.nomMedicament = nomMedicament;
            this.prixLigne = prixLigne;
        }
        public int Quantite
        {
            get { return quantite; }
            set { quantite = value; }
        }
        public int IdMedicament
        {
            get { return idMedicament; }
            set { idMedicament = value; }            
        }
        public string NomMedicament
        {
            get { return nomMedicament; }
            set { nomMedicament = value; }
        }
        public int PrixLigne
        {
            get { return prixLigne; }
            set { prixLigne = value; }
        }
        public override string ToString()
        {
            return idMedicament+"\t"+nomMedicament+ "\t\t" + quantite+ "\t\t" + prixLigne;
        }
    }
}
