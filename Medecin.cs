using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetHopital
{
    class Medecin
    {
        private int num_salle;
        private string nom;
        private List<Visite> liste;
        private Patient patientActuel;
        private Patient prochainPatient;
        private const int tarif = 23;
        private Hopital h;
       
        public Medecin()
        {
            this.liste = new List<Visite>();
            this.patientActuel = null;
            this.prochainPatient = null;
        }
        public Medecin(int num_salle, string nom)
        {
            this.num_salle = num_salle;
            this.nom = nom;
            this.liste = new List<Visite>();
            this.patientActuel = null;
            this.prochainPatient = null ;
        }
        public int Num_salle
        {
            get { return num_salle; }
            set { num_salle = value; }
        }
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        public Patient PatientActuel
        {
            get { return patientActuel; }
        }
        public override string ToString()
        {
            return "Nom Medecin: "+nom+" Salle: "+num_salle;
        }
        public void setHopital(Hopital h)
        {
            this.h = h;
        }
        public void notif()
        {
            prochainPatient = h.ProchainPatient;
        }
        public bool EnregistrerVisites()
        {
            DAOVisite db = new DAOVisite();
            foreach(Visite v in liste)
            {
                db.Insert(v);
            }
            liste.Clear();
            return true;
        }
        public void RendreSalleDispo()
        {
            patientActuel = prochainPatient;
            h.AvancerProchainPatient();
            if(patientActuel != null)
            {
                DateTime localDate = DateTime.Now;
                string date = localDate.ToString(new CultureInfo("fr-FR"));
                Visite v = new Visite(0, patientActuel.Id, date, nom, num_salle, tarif, "");
                liste.Add(v);
                if (liste.Count >= 10)
                {
                    EnregistrerVisites();
                }
            }
        }
        public void AjoutOrdonnance(Ordonnance ordo)
        {
            if (ordo != null)
            {
                string champOrdo = "";
                foreach (Ligne l in ordo.Liste)
                {
                    champOrdo += "Id:" + l.IdMedicament + "-Qte:" + l.Quantite + "/";
                }
                this.liste[liste.Count - 1].Ordonnance = champOrdo;
                this.liste[liste.Count - 1].Tarif += ordo.PrixGlobal();
            }
        }
    }
}
