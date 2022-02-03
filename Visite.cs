using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetHopital
{
    class Visite
    {
        private int num_visite;
        private int id_patient;
        private string date_entree;
        private string nom_medecin;
        private int num_salle;
        private int tarif;
        private string ordonnance;

        public Visite() { }
        public Visite(int num_visite, int id_patient, string date_entree, string nom_medecin, int num_salle, int tarif, string ordonnance)
        {
            this.num_visite = num_visite;
            this.id_patient = id_patient;
            this.date_entree = date_entree;
            this.nom_medecin = nom_medecin;
            this.num_salle = num_salle;
            this.tarif = tarif;
            this.ordonnance = ordonnance;
        }
        public int Num_visite
        {
            set { num_visite = value; }
            get { return num_visite; }
        }
        public int Id_patient
        {
            set { id_patient = value; }
            get { return id_patient; }
        }
        public string Date_entree
        {
            set { date_entree = value; }
            get { return date_entree; }
        }
        public string Nom_medecin
        {
            set { nom_medecin = value; }
            get { return nom_medecin; }
        }
        public int Num_salle
        {
            set { num_salle = value; }
            get { return num_salle; }
        }
        public int Tarif
        {
            set { tarif = value; }
            get { return tarif; }
        }
        public string Ordonnance
        {
            set { ordonnance = value; }
            get { return ordonnance; }
        }
        public override string ToString()
        {
            return num_visite+"\t"+id_patient+"\t"+date_entree+"\t"+nom_medecin+"\t"+num_salle+"\t"+tarif+"\t"+ordonnance;
        }
    }
}
