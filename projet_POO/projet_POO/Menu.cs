using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_POO
{
    class Menu
    {
        /**
         * Class entièrement dédié à l'affichage
         */
        private Agence a;

        public Menu(Agence a)
        {
            this.a = a;
        }

        public void start()
        {
            bool play = true;
            a.addData();

            while (play)
            {
                Console.Clear();
                Console.WriteLine("MENU PRINCIPAL");
                Console.WriteLine("\t Menu vehicule (1)");
                Console.WriteLine("\t Menu client (2)");
                Console.WriteLine("\t Menu trajet (3)");
                Console.WriteLine("\t Exit (e)\n");
                Console.Write("Votre choix: ");

                string menu = Console.ReadLine();

                switch (menu)
                {
                    case "1":
                        this.menu_vehicule();
                        break;

                    case "2":
                        this.menu_client();
                        break;

                    case "3":
                        this.menu_trajet();
                        break;

                    case "e":
                    default:
                        play = false;
                        break;
                }
            }
        }

        // Les menus d'affichage
        public void menu_client()
        {
            bool play = true;

            while (play)
            {
                Console.Clear();
                Console.WriteLine("MENU PRINCIPAL > MENU CLIENT \n");
                Console.WriteLine("\t Ajouter client (1)");
                Console.WriteLine("\t Supprimer client (2)");
                Console.WriteLine("\t Visualiser clients (3)");
                Console.WriteLine("\t Retourner au menu principal (e)\n");
                Console.Write("Votre choix: ");

                string menu = Console.ReadLine();

                switch (menu)
                {
                    case "1":
                        this.ajouter_client();
                        break;

                    case "2":
                        this.supprimer_client();
                        break;

                    case "3":
                        this.visualisation_client();
                        break;

                    case "e":
                    default:
                        play = false;
                        break;
                }
            }
        }

        public void menu_vehicule()
        {
            bool play = true;

            while (play)
            {
                Console.Clear();
                Console.WriteLine("MENU PRINCIPAL > MENU VEHICULE \n");
                Console.WriteLine("\t Ajouter vehicule (1)");
                Console.WriteLine("\t Supprimer vehicule (2)");
                Console.WriteLine("\t Visualiser vehicules (3)");
                Console.WriteLine("\t\t - Visualiser vehicules par marque (31)");
                Console.WriteLine("\t Retourner au menu principal (e)\n");
                Console.Write("Votre choix: ");

                string menu = Console.ReadLine();

                switch (menu)
                {
                    case "1":
                        this.ajouter_vehicule();
                        break;

                    case "2":
                        this.supprimer_vehicule();
                        break;

                    case "3":
                        this.visualisation_vehicule();
                        break;

                    case "31":
                        a.getVehiculeParMarque("Audi");
                        break;
                    case "e":
                    default:
                        play = false;
                        break;
                }
            }
        }

        public void menu_trajet()
        {
            bool play = true;

            while (play)
            {
                Console.Clear();
                Console.WriteLine("MENU PRINCIPAL > MENU TRAJET \n");
                Console.WriteLine("\t Ajouter trajet (1)");
                Console.WriteLine("\t Supprimer trajet (2)");
                Console.WriteLine("\t Visualiser trajets (3)");
                Console.WriteLine("\t Retourner au menu principal (e)\n");
                Console.Write("Votre choix: ");

                string menu = Console.ReadLine();

                switch (menu)
                {
                    case "1":
                        this.ajouter_trajet();
                        break;

                    case "2":
                        this.supprimer_trajet();
                        break;

                    case "3":
                        this.visualisation_trajet();
                        break;

                    case "e":
                    default:
                        play = false;
                        break;
                }
            }
        }

        // fonctions d'ajout
        public void ajouter_client()
        {
            Console.Clear();
            Console.WriteLine("MENU PRINCIPAL > MENU CLIENT > Formulaire d'ajout client \n");
            Console.Write("Nom client: ");
            String nom = Console.ReadLine();

            Console.Write("Prénom client: ");
            String prenom = Console.ReadLine();

            a.ajouter_client(nom, prenom);
            Console.WriteLine("Client créé avec succés!");
            System.Threading.Thread.Sleep(1000);
        }
        public void ajouter_vehicule()
        {
            Console.Clear();
            Console.WriteLine("MENU PRINCIPAL > MENU VEHICULE > Formulaire d'ajout vehicule \n");
            Console.Write("Quel type de vehicule souhaiter vous ajouter? : \n Voiture(1) \n moto(2) \n camion (3)\nvotre choix: ");
            String typeVehicule = Console.ReadLine();

            Console.Write("Immatriculation: ");
            String immat = Console.ReadLine();

            Console.Write("marque: ");
            String marque = Console.ReadLine();

            Console.Write("nombre de kilomètre parcouru: ");
            int nbr_km_parcouru = int.Parse(Console.ReadLine());

            Console.Write("Consommation L/100km : ");
            float conso = float.Parse(Console.ReadLine());

            a.ajouter_vehicule(typeVehicule, immat, marque, nbr_km_parcouru, conso);
            Console.WriteLine("vehicule créé avec succés!");
            System.Threading.Thread.Sleep(1000);
        }
        public void ajouter_trajet()
        {
            Console.Clear();
            Console.WriteLine("MENU PRINCIPAL > MENU TRAJET > Formulaire d'ajout trajet \n");
            this.affichage_vehicule();

            Console.Write("Indiquer l'immatriculation du véhicule effectuant le trajet: ");
            string immat = Console.ReadLine();

            this.affichage_client();
            Console.Write("Indiquer le code client du client effectuant le trajet: ");
            string codeC = Console.ReadLine();

            Console.WriteLine("Indiquer la ville de départ du trajet: ");
            string ville_dep = Console.ReadLine();

            Console.WriteLine("Indiquer la ville d'arrivée du trajet: ");
            string ville_arr = Console.ReadLine();

            Console.WriteLine("Indiquer le nombre de km du trajet: ");
            int km_trajet = int.Parse(Console.ReadLine());

            Console.WriteLine("Indiquer le prix du carburant pour 1L: ");
            float carburantPrix = float.Parse(Console.ReadLine());

            a.ajouter_trajet(immat, codeC, ville_dep, ville_arr, km_trajet, carburantPrix);
            Console.WriteLine("trajet créé avec succés!");
            System.Threading.Thread.Sleep(1000);
        }

        // fonctions de suppression
        public void supprimer_client()
        {
            Console.Clear();
            Console.WriteLine("MENU PRINCIPAL > MENU CLIENT > Formulaire supression client \n");
            if (a.List_client.Count == 0)
            {
                Console.WriteLine("Il n'y a aucun client à supprimer");
                Console.Write("\n(tapez sur entrée pour revenir au menu précédent)");
                Console.ReadLine();
            }
            else
            {
                this.affichage_client();
                Console.Write("Indiquer le code client du client à supprimer: ");
                string code = Console.ReadLine();
                Client c = a.List_client.Find(client => client.CodeC == int.Parse(code));
                if (c == null)
                    Console.WriteLine("Le code client que vous avait tapé n'existe pas");
                else
                {
                    a.supprimer_client(c);
                    Console.WriteLine("Client supprimé avec succés");
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }

        public void supprimer_vehicule()
        {
            Console.Clear();
            Console.WriteLine("MENU PRINCIPAL > MENU TRAJET > Formulaire suppression vehicule \n");

            if (a.List_vehicule.Count == 0)
            {
                Console.WriteLine("Il n'y a aucun vehicule à supprimer");
                Console.Write("\n(tapez sur entrée pour revenir au menu précédent)");
                Console.ReadLine();
            }
            else
            {
                this.affichage_vehicule();
                Console.Write("Indiquer l'immatriculation du vehicule à supprimer: ");
                string immat = Console.ReadLine();
                Vehicule v = a.List_vehicule.Find(vehicule => vehicule.immatriculation == immat);
                if (v == null)
                    Console.WriteLine("L'immatriculation du vehicule que vous avait tapé n'existe pas");
                else
                {
                    a.supprimer_vehicule(v);
                    Console.WriteLine("Vehicule supprimé avec succés");
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }
        public void supprimer_trajet()
        {
            Console.Clear();
            Console.WriteLine("MENU PRINCIPAL > MENU TRAJET > Formulaire suppression trajet \n");
            if (a.List_trajet.Count == 0)
            {
                Console.WriteLine("Il n'y a aucun trajet à supprimer");
                Console.Write("\n(tapez sur entrée pour revenir au menu précédent)");
                Console.ReadLine();
            }
            else
            {
                this.affichage_trajet();
                Console.Write("Indiquer le code trajet du trajet à supprimer: ");
                string codeT = Console.ReadLine();
                Trajet t = a.List_trajet.Find(trajet => trajet.CodeT == int.Parse(codeT));
                if (t == null)
                    Console.WriteLine("Le code du trajet que vous avait tapé n'existe pas");
                else
                {
                    a.supprimer_trajet(t);
                    Console.WriteLine("Trajet supprimé avec succés");
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }


        // fonctions de visualisation
        public void visualisation_vehicule()
        {
            Console.Clear();
            Console.WriteLine("MENU PRINCIPAL > MENU TRAJET > Visualisation de tous vehicules \n");
            a.List_vehicule.ForEach(v =>
            {
                Console.WriteLine(v.toString());
            });
            if (a.List_vehicule.Count == 0)
                Console.WriteLine("Aucun vehicule !");
            Console.Write("\n(tapez sur entrée pour revenir au menu précédent)");
            Console.ReadLine();
        }
        public void visualisation_client()
        {
            Console.Clear();
            Console.WriteLine("MENU PRINCIPAL > MENU TRAJET > Visualisation de tous les clients \n");
            a.List_client.ForEach(client =>
            {
                Console.WriteLine(client.toString());
            });
            if (a.List_client.Count == 0)
                Console.WriteLine("Aucun client !");
            Console.Write("\n(tapez sur entrée pour revenir au menu précédent)");
            Console.ReadLine();
        }
        public void visualisation_trajet()
        {
            Console.Clear();
            Console.WriteLine("MENU PRINCIPAL > MENU TRAJET > Visualisation de tous les trajets \n");
            a.List_trajet.ForEach(trajet =>
            {
                Console.WriteLine(trajet.toString());
            });
            if (a.List_trajet.Count == 0)
                Console.WriteLine("Aucun trajet !");

            Console.Write("\n(tapez sur entrée pour revenir au menu précédent)");
            Console.ReadLine();
        }

        // fonctions d'affichage
        public void affichage_vehicule()
        {
            a.List_vehicule.ForEach(v =>
            {
                Console.WriteLine(v.toString());
            });
            if (a.List_vehicule.Count == 0)
                Console.WriteLine("Aucun vehicule !");
        }
        public void affichage_client()
        {
            a.List_client.ForEach(client =>
            {
                Console.WriteLine(client.toString());
            });
            if (a.List_client.Count == 0)
                Console.WriteLine("Aucun client !");
        }
        public void affichage_trajet()
        {
            a.List_trajet.ForEach(trajet =>
            {
                Console.WriteLine(trajet.toString());
            });
            if (a.List_trajet.Count == 0)
                Console.WriteLine("Aucun trajet !");
        }
    }
}
