using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetHopital
{
    //Classe contenant toutes les méthodes utilisant la console comme les méthodes d'affichages et de saisies.

    class Traitement
    {
        //Affichage Console
        public static void AffichageMenuAdmin()
        {
            Console.WriteLine("\t__________________________________________");
            Console.WriteLine("\n\t\t*******************");
            Console.WriteLine("\t\t* MENU DES ADMINS *");
            Console.WriteLine("\t\t*******************\n");
            Console.WriteLine("\t1- Ajouter un medicament");
            Console.WriteLine("\t2- Mettre à jour un medicament");
            Console.WriteLine("\t3- Supprimer un medicament");
            Console.WriteLine("\t4- Afficher tous les medicaments");
            Console.WriteLine("\t5- Quitter le menu des admins");
            Console.Write("\n\tEntrez votre choix : ");
        }
        public static void AffichageMenuMedecin()
        {
            Console.WriteLine("\t__________________________________________");
            Console.WriteLine("\n\t\t*********************");
            Console.WriteLine("\t\t* MENU DES MEDECINS *");
            Console.WriteLine("\t\t*********************\n");
            Console.WriteLine("\t1- Afficher la file d'attente");
            Console.WriteLine("\t2- Ajouter une ordonnance au patient actuel");
            Console.WriteLine("\t3- Sauvegarde de la liste des visites dans la base de données");
            Console.WriteLine("\t4- Rendre la salle disponible");
            Console.WriteLine("\t5- Quitter le menu des medecins");
            Console.Write("\n\tEntrez votre choix : ");
        }
        public static void AffichageMenuSecretaire()
        {
            Console.WriteLine("\t__________________________________________");
            Console.WriteLine("\n\t\t************************");
            Console.WriteLine("\t\t* MENU DES SECRETAIRES *");
            Console.WriteLine("\t\t************************\n");
            Console.WriteLine("\t1- Ajouter un patient à la file d'attente");
            Console.WriteLine("\t2- Sauvegarder la file d'attente");
            Console.WriteLine("\t3- Charger la file d'attente");
            Console.WriteLine("\t4- Nouvelle journée");
            Console.WriteLine("\t5- Afficher la file d'attente");
            Console.WriteLine("\t6- Afficher toutes les visites");
            Console.WriteLine("\t7- Afficher les visites d'un patient");
            Console.WriteLine("\t8- Afficher les visites d'un medecin");
            Console.WriteLine("\t9- Afficher le prochain patient");
            Console.WriteLine("\t10- Compléter/Modifier une fiche patient");
            Console.WriteLine("\t11- Quitter le menu des secretaires");
            Console.Write("\n\tEntrez votre choix : ");
        }
        public static void AfficherFileAttente(Queue<Patient> file)
        {
            Console.WriteLine("\t__________________________________________");
            Console.WriteLine("\nListe des patients en file d'attente : ");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("N°\tNOM\tPRENOM\tAGE\tADRESSE\t\tTELEPHONE");
            Console.WriteLine("----------------------------------------------------------------");
            foreach (Patient p in file)
                Console.WriteLine(p);
            Console.WriteLine("----------------------------------------------------------------\n");
        }
        public static void AfficherProchainPatient(Patient p)
        {
            Console.WriteLine("\t__________________________________________");
            Console.WriteLine("\nProchain patient : ");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("N°\tNOM\tPRENOM\tAGE\tADRESSE\t\tTELEPHONE");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine(p);
            Console.WriteLine("----------------------------------------------------------------\n");
        }
        public static void AfficherNouveauPatient(Patient p)
        {
            Console.WriteLine("\t__________________________________________");
            Console.WriteLine("\nNouveau patient : ");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("N°\tNOM\tPRENOM\tAGE\tADRESSE\t\tTELEPHONE");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine(p);
            Console.WriteLine("----------------------------------------------------------------\n");
        }
        public static void AfficherToutesVisites()
        {
            Console.WriteLine("\t__________________________________________");
            Console.WriteLine("\n\tListe de toutes les visites : \n");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine("N°\tPATIENT\tDATE\t\t\tMEDECIN\t\t\tSALLE\tTARIF\tORDONNANCE");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            DAOVisite db = new DAOVisite();
            List<Visite> liste = new List<Visite>();
            liste = db.Select();
            foreach (Visite v in liste)
                Console.WriteLine(v);
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
        }
        public static void AfficherVisiteDePatient()
        {
            string numSecuSaisie;
            int numSecu = 0;
            bool success = false;
            do
            {
                Console.WriteLine("\nVeuillez entrer le numero de sécurité social du patient (13 chiffres maximum) : ");
                numSecuSaisie = Console.ReadLine();
                int nombreSaisie = 0;
                if (numSecuSaisie != "")
                    success = Int32.TryParse(numSecuSaisie, out nombreSaisie);
                if (success)
                    numSecu = nombreSaisie;
            } while (!success && numSecuSaisie != "");

            DAOVisite db = new DAOVisite();
            List<Visite> liste = new List<Visite>();
            liste = db.SelectById(numSecu);
            Console.WriteLine("\t__________________________________________");
            Console.WriteLine("\n\tListe des visites du patient n°" + numSecu + " : \n");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine("N°\tPATIENT\tDATE\t\t\tMEDECIN\t\t\tSALLE\tTARIF\tORDONNANCE");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            foreach (Visite v in liste)
                Console.WriteLine(v);
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
        }
        public static void AfficherVisiteDeMedecin()
        {
            Console.WriteLine("\nVeuillez entrer le nom du medecin : ");
            string nom_medecin = Console.ReadLine();
            DAOVisite db = new DAOVisite();
            List<Visite> liste = new List<Visite>();
            liste = db.SelectByMedecin(nom_medecin);
            Console.WriteLine("\t__________________________________________");
            Console.WriteLine("\n\tListe des visites du medecin " + nom_medecin + " : \n");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine("N°\tPATIENT\tDATE\t\t\tMEDECIN\t\t\tSALLE\tTARIF\tORDONNANCE");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            foreach (Visite v in liste)
                Console.WriteLine(v);
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
        }
        public static void AfficherMedicaments()
        {
            DAOMedicament db = new DAOMedicament();

            List<Medicament> liste = new List<Medicament>();
            liste = db.Select();
            Console.WriteLine("\t__________________________________________");
            Console.WriteLine("\n\tListe des médicaments disponibles :  ");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine("ID\tNOM\t\t\tPRIX(EUROS)\tQUANTITE EN STOCK");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            foreach (Medicament med in liste)
                Console.WriteLine(med);
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
        }

        //Saisie Console et accès base de donées
        public static void MAJMedicamentBDD()
        {
            DAOMedicament db = new DAOMedicament();
            Medicament med = new Medicament();
            med = null;

            string idMedicamentSaisie;
            bool success = false;
            int idMed = 0;
            do
            {
                Console.WriteLine("\nVeuillez entrer le numéro du médicament à modifier (obligatoire) : ");
                idMedicamentSaisie = Console.ReadLine();
                int nombreSaisie = 0;
                if (idMedicamentSaisie != "")
                    success = Int32.TryParse(idMedicamentSaisie, out nombreSaisie);
                if (success)
                    idMed = nombreSaisie;
            } while (!success);

            med = db.SelectById(idMed);

            if (med != null)
            {
                Console.WriteLine("\t__________________________________________");
                Console.WriteLine("\n\tMédicament à modifier  :  ");
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                Console.WriteLine("ID\tNOM\t\t\tPRIX(EUROS)\tQUANTITE EN STOCK");
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                Console.WriteLine(med);
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                string nom;
                Console.WriteLine("\nVeuillez entrer le nouveau nom du médicament (facultatif) : ");
                nom = Console.ReadLine();
                if (nom != "")
                    med.Nom = nom;

                string prixSaisie;
                bool success2 = false;
                do
                {
                    prixSaisie = "";
                    Console.WriteLine("\nVeuillez entrer le nouveau prix du médicament (facultatif) :");
                    prixSaisie = Console.ReadLine();
                    int nombreSaisie = 0;
                    if (prixSaisie != "")
                        success2 = Int32.TryParse(prixSaisie, out nombreSaisie);
                    if (success2)
                        med.Prix = nombreSaisie;
                } while (!success2 || prixSaisie == "");

                string qteSaisie;
                bool success3 = false;
                do
                {
                    qteSaisie = "";
                    Console.WriteLine("\nVeuillez entrer la nouvelle quantité du médicament (facultatif) :");
                    qteSaisie = Console.ReadLine();
                    int nombreSaisie = 0;
                    if (qteSaisie != "")
                        success3 = Int32.TryParse(qteSaisie, out nombreSaisie);
                    if (success3)
                        med.Quantite = nombreSaisie;
                } while (!success3 || qteSaisie == "");

                db.UpdateAll(med);
                Console.WriteLine("\t__________________________________________");
                Console.WriteLine("\n\tMédicament modifié :  ");
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                Console.WriteLine("ID\tNOM\t\t\tPRIX(EUROS)\tQUANTITE EN STOCK");
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                Console.WriteLine(med);
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("\t__________________________________________");
                Console.WriteLine("\n\tMedicament n°" + idMed + " absent de la base de données !");
            }
        }
        public static void AjouterMedicamentBDD()
        {
            DAOMedicament db = new DAOMedicament();
            Medicament med = new Medicament();

            string idMedicamentSaisie;
            bool success = false;
            do
            {
                Console.WriteLine("\nVeuillez entrer le numéro du médicament à ajouter (obligatoire) : ");
                idMedicamentSaisie = Console.ReadLine();
                int nombreSaisie = 0;
                if (idMedicamentSaisie != "")
                    success = Int32.TryParse(idMedicamentSaisie, out nombreSaisie);
                if (success)
                    med.IdMedicaments = nombreSaisie;
            } while (!success);
            if(db.SelectById(med.IdMedicaments) == null)
            {
                string nom;
                do
                {
                    Console.WriteLine("\nVeuillez entrer le nom du médicament (30 lettres maximum, obligatoire) : ");
                    nom = Console.ReadLine();
                } while (nom == "");
                med.Nom = nom;

                string prixSaisie;
                bool success2 = false;
                do
                {
                    Console.WriteLine("\nVeuillez entrer le prix du médicament (obligatoire) :");
                    prixSaisie = Console.ReadLine();
                    int nombreSaisie = 0;
                    if (prixSaisie != "")
                        success2 = Int32.TryParse(prixSaisie, out nombreSaisie);
                    if (success2)
                        med.Prix = nombreSaisie;
                } while (!success2);

                string qteSaisie;
                bool success3 = false;
                do
                {
                    Console.WriteLine("\nVeuillez entrer la quantité du médicament (obligatoire) :");
                    qteSaisie = Console.ReadLine();
                    int nombreSaisie = 0;
                    if (qteSaisie != "")
                        success3 = Int32.TryParse(qteSaisie, out nombreSaisie);
                    if (success3)
                        med.Quantite = nombreSaisie;
                } while (!success3);

                db.Insert(med);
                Console.WriteLine("\t__________________________________________");
                Console.WriteLine("\n\tMedicament n°" + med.IdMedicaments + " ajouté !");
            }
            else
            {
                Console.WriteLine("\t__________________________________________");
                Console.WriteLine("\n\tMedicament n°" + med.IdMedicaments + " est déja présent dans la table !");
            }
            
        }
        public static void SupprMedicamentBDD()
        {
            DAOMedicament db = new DAOMedicament();

            string idMedicamentSaisie;
            int idMedicament = 0;
            bool success = false;
            do
            {
                Console.WriteLine("\nVeuillez entrer le numéro du médicament à supprimer : ");
                idMedicamentSaisie = Console.ReadLine();
                int nombreSaisie = 0;
                if (idMedicamentSaisie != "")
                    success = Int32.TryParse(idMedicamentSaisie, out nombreSaisie);
                if (success)
                    idMedicament = nombreSaisie;
            } while (!success && idMedicamentSaisie != "");

            if(db.SelectById(idMedicament) != null)
            {
                db.Delete(idMedicament);
                Console.WriteLine("\t__________________________________________");
                Console.WriteLine("\n\tMedicament n°" + idMedicament + " supprimé !");
            }
            else
            {
                Console.WriteLine("\t__________________________________________");
                Console.WriteLine("\n\tMedicament n°" + idMedicament + " absent de la base de donées !");
            }
        }
        public static Authentification LoginMenu()
        {
            Authentification utilisateur = new Authentification();
            utilisateur = null;
            bool exitConfirmation = false;
            string reponse = "";

            Console.Clear();
            Console.WriteLine("\n\t  ********************************");
            Console.WriteLine("\t  *  BIENVENUE DANS HOPITAL HN ! *");
            Console.WriteLine("\t  ********************************\n");
            Console.WriteLine("\t\t******************");
            Console.WriteLine("\t\t* MENU PRINCIPAL *");
            Console.WriteLine("\t\t******************\n");

            while (!exitConfirmation)
            {
                Console.Write("\n\tVeuillez entrer votre identifiant: ");
                string loginSaisie = Console.ReadLine();//insensible a la casse
                utilisateur = new DAOAuthentification().SelectByLogin(loginSaisie);

                if (utilisateur != null)
                {
                    Console.Write("\n\tVeuillez entrer votre mot de passe: ");
                    string passwordSaisie = Console.ReadLine();//sensible a la casse
                    if (passwordSaisie == utilisateur.Password)
                    {
                        Console.WriteLine("\n\t\tBienvenue " + utilisateur.Nom + " ! ");
                        exitConfirmation = true;
                    }
                    else
                    {
                        Console.WriteLine("\n\tMot de passe incorrecte, fermeture de l'application.\n");
                        exitConfirmation = true;
                        utilisateur = null;
                    }
                }
                else
                {
                    Console.Write("\n\tIdentifiant inconnu, voulez vous réessayer ? (O/N) ");
                    while (reponse != "O" && reponse != "N")
                    {
                        reponse = Console.ReadLine().ToUpper();
                        switch (reponse)
                        {
                            case "O":
                                break;
                            case "N":
                                exitConfirmation = true;
                                break;
                            default:
                                Console.Write("\n\tCommande inconnue, voulez vous réessayer ? (O/N) ");
                                break;
                        }
                    }
                    reponse = "";
                }
            }
            return utilisateur;
        }
        public static void AjouterPatientAFile()
        {
            Patient p = new Patient();
            DAOPatient db = new DAOPatient();
            Hopital h = Hopital.Instance;
            bool dejaPresent = false;

            string numSecuSaisie;
            int numSecu = 0;
            bool success1 = false;
            do
            {
                Console.WriteLine("\nVeuillez entrer le numero de sécurité social du patient (13 chiffres maximum, obligatoire) : ");
                numSecuSaisie = Console.ReadLine();
                int nombreSaisie1 = 0;
                if (numSecuSaisie != "")
                    success1 = Int32.TryParse(numSecuSaisie, out nombreSaisie1);
                if (success1)
                    numSecu = nombreSaisie1;
            } while (!success1);

            foreach(Patient pat in h.FileAttente)
            {
                if (pat.Id == numSecu)
                {
                    Console.WriteLine("\t__________________________________________");
                    Console.WriteLine("\n\tPatient n° " + numSecu + " deja present dans la file !");
                    dejaPresent = true;
                    break;
                }
            }

            if (!dejaPresent)
            {
                if (db.SelectById(numSecu) != null)
                {
                    h.AddPatient(db.SelectById(numSecu));
                    Console.WriteLine("\t__________________________________________");
                    Console.WriteLine("\n\tPatient n° " + numSecu + " ajouté a la file !");
                    h.AjoutArriveePatientDansFichierTxt(numSecu);
                }
                else
                {
                    p.Id = numSecu;

                    string nom;
                    do
                    {
                        Console.WriteLine("\nVeuillez entrer le nom du patient (20 lettres maximum, obligatoire) : ");
                        nom = Console.ReadLine();
                    } while (nom == "");
                    p.Nom = nom;

                    string prenom;
                    do
                    {
                        Console.WriteLine("\nVeuillez entrer le prénom du patient (20 lettres maximum, obligatoire) : ");
                        prenom = Console.ReadLine();
                    } while (prenom == "");
                    p.Prenom = prenom;

                    string ageSaisie;
                    bool success = false;
                    do
                    {
                        Console.WriteLine("\nVeuillez entrer l'âge du patient (obligatoire) :");
                        ageSaisie = Console.ReadLine();
                        int nombreSaisie = 0;
                        if (ageSaisie != "")
                            success = Int32.TryParse(ageSaisie, out nombreSaisie);
                        if (success)
                            p.Age = nombreSaisie;
                    } while (!success);

                    Console.WriteLine("\nVeuillez entrer l'adresse du patient (20 caractères maximum, facultatif) : ");
                    string adresse = Console.ReadLine();
                    p.Adresse = adresse;

                    Console.WriteLine("\nVeuillez entrer le numéro de téléphone du patient (ex: 00.11.22.33.44, facultatif) : ");
                    string telephone = Console.ReadLine();
                    p.Telephone = telephone;

                    h.AddPatient(p);
                    new DAOPatient().Insert(p);
                    Console.WriteLine("\t__________________________________________");
                    Console.WriteLine("\n\tPatient n° " + numSecu + " ajouté a la base de données !");
                    Console.WriteLine("\n\tPatient n° " + numSecu + " ajouté a la file !");
                    h.AjoutArriveePatientDansFichierTxt(numSecu);
                }
            } 
        }
        public static void MAJPatient()
        {
            Patient p = new Patient();
            DAOPatient db = new DAOPatient();

            string numSecuSaisie;
            int numSecu = 0;
            bool success1 = false;
            do
            {
                Console.WriteLine("\nVeuillez entrer le numero de sécurité social du patient (13 chiffres maximum, obligatoire) : ");
                numSecuSaisie = Console.ReadLine();
                int nombreSaisie1 = 0;
                if (numSecuSaisie != "")
                    success1 = Int32.TryParse(numSecuSaisie, out nombreSaisie1);
                if (success1)
                    numSecu = nombreSaisie1;
            } while (!success1);

            if (db.SelectById(numSecu) != null)
            {
                p = db.SelectById(numSecu);

                Console.WriteLine("\nVeuillez entrer l'adresse du patient (20 caractères maximum) : ");
                string adresse = Console.ReadLine();
                p.Adresse = adresse;

                Console.WriteLine("\nVeuillez entrer le numéro de téléphone du patient (ex: 00.11.22.33.44) : ");
                string telephone = Console.ReadLine();
                p.Telephone = telephone;

                db.Update(p);
                Console.WriteLine("\t__________________________________________");
                Console.WriteLine("\n\tPatient n° " + numSecu + " mise à jour !");
            }
            else
            {
                Console.WriteLine("\t__________________________________________");
                Console.WriteLine("\n\tIdentifiant n°" + numSecu + " inconnu.");
            }
        }
        public static Ordonnance SaisieOrdonnance()
        {
            DAOMedicament db = new DAOMedicament();
            Ordonnance ordo = new Ordonnance();
            bool exitOrdo = false;
            string reponse = "";

            while (!exitOrdo)
            {
                string numSaisie;
                bool success1 = false;
                int idMedicament = 0;
                do
                {
                    Console.WriteLine("\nVeuillez entrer un numéro de médicament : ");
                    numSaisie = Console.ReadLine();
                    int nombreSaisie = 0;
                    if (numSaisie != "")
                        success1 = Int32.TryParse(numSaisie, out nombreSaisie);
                    if (success1)
                        idMedicament = nombreSaisie;
                } while (!success1);

                Medicament medSelect = db.SelectById(idMedicament);

                string quantiteSaisie;
                bool quantiteCorrecte = false;
                int quantite = 0;
                bool success2 = false;
                while (!quantiteCorrecte)
                {
                    Console.WriteLine("\nVeuillez entrer la quantité souhaitée : ");
                    quantiteSaisie=Console.ReadLine();
                    int qteSaisie = 0;
                    if(quantiteSaisie !="")
                        success2 = Int32.TryParse(quantiteSaisie, out qteSaisie);
                    if (success2)
                    {
                        quantite = qteSaisie;
                        if (quantite <= medSelect.Quantite)
                        {
                            medSelect.Quantite -= quantite;
                            db.UpdateStock(medSelect);
                            quantiteCorrecte = true;
                        }
                        else
                        {
                            Console.WriteLine("\nQuantité saisie supérieure au stock. ");
                            success2 = false;
                        }
                    }
                }

                int prixLigne = quantite * medSelect.Prix;
                Ligne l = new Ligne(quantite, idMedicament, medSelect.Nom, prixLigne);
                ordo.AjouterLigne(l);

                Console.WriteLine("\nVoulez vous ajouter un autre médicament ? (O/N) ");
                while (reponse != "O" && reponse != "N")
                {
                    reponse = Console.ReadLine().ToUpper();
                    switch (reponse)
                    {
                        case "O":
                            break;
                        case "N":
                            exitOrdo = true;
                            break;
                        default:
                            Console.WriteLine("\nCommande inconnue, voulez vous réessayer ? (O/N) ");
                            break;
                    }
                }
                reponse = "";
            }
            Console.WriteLine(ordo);
            Console.WriteLine("\n\tOrdonnance ajouté au patient.");
            return ordo;
        }
    }
}
