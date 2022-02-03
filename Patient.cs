using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetHopital
{
    [Serializable]
    class Patient
    {
        private int id;
        private string nom;
        private string prenom;
        private int age;
        private string adresse;
        private string telephone;  

        public Patient() { }
        public Patient(int id, string nom, string prenom, int age)
        {
            this.id= id;
            this.nom=nom;
            this.prenom = prenom;
            this.age = age;
        }
        public Patient(int id, string nom, string prenom, int age,string adresse,string telephone)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.age = age;
            this.adresse = adresse;
            this.telephone = telephone;
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Adresse
        {
            get { return adresse; }
            set { adresse = value; }
        }
        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }
        public override string ToString()
        {
            return id+"\t"+nom+"\t"+prenom+"\t"+age+"\t"+adresse+ "\t"+telephone;
        }
    }
}
