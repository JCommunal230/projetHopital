using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetHopital
{
    //Classe du programme contenant la logique de l'application, notamment la gestion des users, du menu principal et des sous-menus.
    class Program
    {
        static void Main(string[] args)
        {
            bool exitApp = false;
            Hopital h = Hopital.Instance;
            string choix;

            while (!exitApp)
            {
                Authentification user = new Authentification();
                user = Traitement.LoginMenu();
                if (user == null)
                    break;
                choix = "";
                switch (user.Metier)
                {
                    case -1:
                        while (choix != "5")
                        {
                            Traitement.AffichageMenuAdmin();
                            choix = Console.ReadLine();
                            switch (choix)
                            {
                                case "1":
                                    Traitement.AjouterMedicamentBDD();                                    
                                    break;
                                case "2":
                                    Traitement.MAJMedicamentBDD();
                                    break;
                                case "3":
                                    Traitement.SupprMedicamentBDD();                                    
                                    break;
                                case "4":
                                    Traitement.AfficherMedicaments();
                                    break;
                                case "5":
                                    break;
                                default:
                                    Console.WriteLine("\t__________________________________________");
                                    Console.WriteLine("\n\tNuméro d'option " + choix + "  inconnu.");
                                    break;
                            }
                        }
                        break;
                    case 0:
                        while (choix != "11")
                        {
                            Traitement.AffichageMenuSecretaire();
                            choix = Console.ReadLine();
                            switch (choix)
                            {
                                case "1":
                                    Traitement.AjouterPatientAFile();
                                    break;
                                case "2":
                                    h.SerialiserFileAttente();
                                    Console.WriteLine("\t__________________________________________");
                                    Console.WriteLine("\n\tFile d'attente sauvegardée !");
                                    break;
                                case "3":
                                    h.DeserialiserFileAttente();
                                    Console.WriteLine("\t__________________________________________");
                                    Console.WriteLine("\n\tFile d'attente chargée !");
                                    break;
                                case "4":
                                    h.ClearQueue();
                                    Console.WriteLine("\t__________________________________________");
                                    Console.WriteLine("\n\tNouvelle journée! File d'attente vide.\n");
                                    break;
                                case "5":
                                    Traitement.AfficherFileAttente(h.FileAttente);
                                    break;
                                case "6":
                                    Traitement.AfficherToutesVisites();
                                    break;
                                case "7":
                                    Traitement.AfficherVisiteDePatient();
                                    break;
                                case "8":
                                    Traitement.AfficherVisiteDeMedecin();
                                    break;
                                case "9":
                                    Traitement.AfficherProchainPatient(h.ProchainPatient);
                                    break;
                                case "10":
                                    Traitement.MAJPatient();
                                    break;
                                case "11":
                                    break;
                                default:
                                    Console.WriteLine("\t__________________________________________");
                                    Console.WriteLine("\n\tNuméro d'option " + choix + "  inconnu.");
                                    break;
                            }
                        }
                        break;
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5://nombres de salles pour medecin (1-5), rajout possible
                        Medecin medecin = new Medecin(user.Metier, user.Nom);
                        medecin.setHopital(h);
                        h.Attach(medecin);
                        while (choix != "5")
                        {
                            Traitement.AffichageMenuMedecin();
                            choix = Console.ReadLine();
                            switch (choix)
                            {
                                case "1":
                                    Traitement.AfficherFileAttente(h.FileAttente);
                                    break;
                                case "2":
                                    if(medecin.PatientActuel != null)
                                    {
                                        Traitement.AfficherMedicaments();
                                        medecin.AjoutOrdonnance(Traitement.SaisieOrdonnance());                                        
                                    }
                                    else
                                    {
                                        Console.WriteLine("\t__________________________________________");
                                        Console.WriteLine("\n\tPas de patient actuellement.");
                                    }                                    
                                    break;
                                case "3":
                                    medecin.EnregistrerVisites();
                                    Console.WriteLine("\t__________________________________________");
                                    Console.WriteLine("\n\tVisites enregistrées.");
                                    break;
                                case "4":
                                    medecin.RendreSalleDispo();
                                    Console.WriteLine("\t__________________________________________");
                                    Console.WriteLine("\n\tSalle disponible !");
                                    if (medecin.PatientActuel != null)
                                    {
                                        Traitement.AfficherNouveauPatient(medecin.PatientActuel);
                                    }
                                    break;
                                case "5":
                                    break;
                                default:
                                    Console.WriteLine("\t__________________________________________");
                                    Console.WriteLine("\n\tNuméro d'option " + choix + "  inconnu.");
                                    break;
                            }
                        }
                        h.Detacher(medecin);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}      


