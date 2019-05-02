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
                Console.WriteLine("Menu principal:");
                Console.WriteLine("\t ajouter un vehicule (1)");
                Console.WriteLine("\t supprimer un vehicule (2)");
                Console.WriteLine("\t ajouter un client (3)");
                Console.WriteLine("\t supprimer un client (4)");
                Console.WriteLine("\t ajouter un trajet (5)");
                Console.WriteLine("\t supprimer un trajet (6)");
                Console.WriteLine("\t Exit (e)\n");
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
                        this.ajouter_client();
                        break;

                    case "4":
                        this.supprimer_client();
                        break;

                    case "5":
                        this.ajouter_trajet();
                        break;

                    case "6":
                        this.supprimer_trajet();
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
            Console.WriteLine("Formulaire d'ajout client:");
            Console.Write("Nom client: ");
            String nom = Console.ReadLine();

            Console.Write("Prénom client: ");
            String prenom = Console.ReadLine();

            a.ajouter_client(nom, prenom);
            Console.WriteLine("Client créé avec succés!");
        }
        public void ajouter_vehicule()
        {
            Console.WriteLine("Formulaire d'ajout Vehicule:");
            Console.Write("Quel type de vehicule souhaiter vous ajouter? : \n Voiture(1) \n moto(2) \n camion (3)\n votre choix: ");
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
        }
        public void ajouter_trajet()
        {
            Console.WriteLine("Formulaire de création d'un trajet:");
            this.fiche_vehicule();

            Console.WriteLine("Indiquer l'immatriculation du véhicule effectuant le trajet: ");
            string immat = Console.ReadLine();

            this.fiche_client();
            Console.WriteLine("Indiquer le code client du client effectuant le trajet: ");
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
        }

        public void supprimer_client()
        {
            if (a.List_client.Count == 0)
            {
                Console.WriteLine("Il n'y a aucun client à supprimer");
            }
            else
            {
                this.fiche_client();
                Console.Write("Indiquer le code client du client à supprimer: ");
                string code = Console.ReadLine();
                Client c = a.List_client.Find(client => client.CodeC == int.Parse(code));
                if (c == null)
                    Console.WriteLine("Le code client que vous avait tapé n'existe pas");
                else
                {
                    a.supprimer_client(c);
                    Console.WriteLine("Client supprimé");
                }
            }
        }

        public void supprimer_vehicule()
        {
            if (a.List_vehicule.Count == 0)
            {
                Console.WriteLine("Il n'y a aucun vehicule à supprimer");
            }
            else
            {
                this.fiche_vehicule();
                Console.Write("Indiquer l'immatriculation du vehicule à supprimer: ");
                string immat = Console.ReadLine();
                Vehicule v = a.List_vehicule.Find(vehicule => vehicule.immatriculation == immat);
                if (v == null)
                    Console.WriteLine("L'immatriculation du vehicule que vous avait tapé n'existe pas");
                else
                {
                    a.supprimer_vehicule(v);
                    Console.WriteLine("Vehicule supprimé");
                }
            }
        }
        public void supprimer_trajet()
        {
            if (a.List_trajet.Count == 0)
            {
                Console.WriteLine("Il n'y a aucun trajet à supprimer");
            }
            else
            {
                this.trajet();
                Console.Write("Indiquer le code trajet du trajet à supprimer: ");
                string codeT = Console.ReadLine();
                Trajet t = a.List_trajet.Find(trajet => trajet.CodeT == int.Parse(codeT));
                if (t == null)
                    Console.WriteLine("Le code du trajet que vous avait tapé n'existe pas");
                else
                {
                    a.supprimer_trajet(t);
                    Console.WriteLine("Trajet supprimé");
                }
            }
        }


        // fonctions d'affichage
        public void fiche_vehicule()
        {
            Console.WriteLine("Fiche véhicule");
            Console.WriteLine("Tous les vehicules existants:");
            a.List_vehicule.ForEach(v =>
            {
                Console.WriteLine(v.toString());
            });
        }
        public void fiche_client()
        {
            Console.WriteLine("Tous les clients existants:");
            a.List_client.ForEach(client =>
            {
                Console.WriteLine(client.toString());
            });
        }
        public void trajet()
        {
            Console.WriteLine("Tous les trajets existants:");
            a.List_trajet.ForEach(trajet =>
            {
                Console.WriteLine(trajet.toString());
            });
        }
    }
}
