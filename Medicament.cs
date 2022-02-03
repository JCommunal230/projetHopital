using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetHopital
{
    class Medicament
    {
        private int idMedicaments;
        private string nom;
        private int prix;
        private int quantite;

        public Medicament() { }
        public Medicament(int idMedicaments, string nom, int prix, int quantite)
        {
            this.idMedicaments = idMedicaments;
            this.nom = nom;
            this.prix = prix;
            this.quantite = quantite;
        }
        public int IdMedicaments
        {
            get { return idMedicaments; }
            set { idMedicaments = value; }
        }
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        public int Prix
        {
            get { return prix; }
            set { prix = value; }
        }
        public int Quantite
        {
            get { return quantite; }
            set { quantite = value; }
        }
        public override string ToString()
        {
            return idMedicaments+"\t"+nom+ "\t\t"+prix+ "\t\t" + quantite;
        }
    }
}
