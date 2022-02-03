using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace projetHopital
{
    //Secretaire interface de hopital
    //Singleton, 1 seule instance de hopital
    //Medecin observer de hopital
    class Hopital 
    {
        private Queue<Patient> fileAttente = new Queue<Patient>();
        private string nom_secretaire;
        private List<Medecin> listeMedecin = new List<Medecin>();
        private Patient prochainPatient = new Patient();
        private static Hopital instance = new Hopital();
        List<string> listeEntree = new List<string>();        
        private string path = @"c:\tmp\fileAttente.txt";
        private string path2 = @"c:\tmp\ArriveePatientDansFile.txt";

        private Hopital() { }
        public static Hopital Instance
        {
            get { return instance; }
        }
        public string Nom_secretaire
        {
            get { return nom_secretaire; }
            set { nom_secretaire = value; }
        }
        public Queue<Patient> FileAttente
        {
            get { return fileAttente; }
        }
        public  Patient ProchainPatient
        {
            set
            {
                prochainPatient = value;
                notifyAll();
            }
            get  { return prochainPatient; }
        }
        public void Attach(Medecin med)
        {
            listeMedecin.Add(med);
            med.notif();
        }
        public void Detacher(Medecin med)
        {
            listeMedecin.Remove(med);            
        }
        private void notifyAll()
        {
            foreach (Medecin m in listeMedecin)
                m.notif();
        }
        public void AddPatient(Patient p)
        {
            instance.FileAttente.Enqueue(p);
            if (instance.fileAttente.Count == 1)
                instance.ProchainPatient = instance.fileAttente.Peek();
        }
        public void AvancerProchainPatient()
        {
            if (instance.fileAttente.Count != 0)
                instance.fileAttente.Dequeue();
            if (instance.fileAttente.Count !=0)
                instance.ProchainPatient = instance.fileAttente.Peek();
            else
                instance.ProchainPatient = null;
        }        
        public void ClearQueue()
        {
            instance.fileAttente.Clear();
            instance.ProchainPatient = null;
        }
        public void DeserialiserFileAttente()
        {
            FileStream inStream = new FileStream(instance.path, FileMode.Open, FileAccess.Read);
            BinaryFormatter binReader = new BinaryFormatter();
            instance.fileAttente = (Queue<Patient>)binReader.Deserialize(inStream);
            inStream.Close();
            if (instance.fileAttente.Count >= 1)
                instance.ProchainPatient = instance.fileAttente.Peek();
        }
        public void SerialiserFileAttente()
        {
            FileStream outStream = new FileStream(instance.path, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter binWriter = new BinaryFormatter();
            binWriter.Serialize(outStream, instance.fileAttente);
            outStream.Close();
        }
        public void AjoutArriveePatientDansFichierTxt(int id)
        {            
            DateTime localDate = DateTime.Now;            
            string arrivee = id + "\t";
            arrivee += localDate.ToString(new CultureInfo("fr-FR"));
            instance.listeEntree.Add(arrivee);
            using (StreamWriter sw = new StreamWriter(instance.path2))
            {
                sw.WriteLine("------------------------------------------");
                sw.WriteLine("ID\tDATE ET HEURE D'ARRIVEE");
                sw.WriteLine("------------------------------------------");
                foreach (string s in instance.listeEntree)
                    sw.WriteLine(s);
                sw.WriteLine("------------------------------------------");
            }
        }
    }
}
