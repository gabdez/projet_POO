using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_POO
{
    class Agence
    {
        private List<Vehicule> list_vehicule = new List<Vehicule>();
        private List<Client> list_client = new List<Client>();
        private List<Trajet> list_trajet = new List<Trajet>();

        public Agence(){}

        public void ajouter_client()
        {
            Console.WriteLine("Formulaire d'ajout client:");
            Console.Write("Nom client: ");
            String nom = Console.ReadLine();
            Console.Write("Prénom client: ");
            String prenom = Console.ReadLine();

            this.list_client.Add(new Client(nom, prenom));
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

            Vehicule v = null;

            switch (typeVehicule)
            {
                case "1":
                    v = new Voiture(immat, marque, nbr_km_parcouru,conso);
                    break;

                case "2":
                    v = new Moto(immat, marque, nbr_km_parcouru, conso);
                    break;

                case "3":
                    Console.Write("Le volume de chargement de votre camion: ");
                    int volume = int.Parse(Console.ReadLine());
                    v = new Camion(immat, marque, nbr_km_parcouru, conso, volume);
                    break;
            }
            this.list_vehicule.Add(v);
            Console.WriteLine("vehicule créé avec succés!");
        }
        public void ajouter_trajet()
        {
            Console.WriteLine("Formulaire de création d'un trajet:");
            this.fiche_vehicule();
            Console.WriteLine("Indiquer l'immatriculation du véhicule effectuant le trajet: ");
            string immat = Console.ReadLine();
            Vehicule v = this.list_vehicule.Find(vehicule => vehicule.immatriculation == immat);
            this.fiche_client();
            Console.WriteLine("Indiquer le code client du client effectuant le trajet: ");
            string code = Console.ReadLine();
            Client c = this.list_client.Find(client => client.CodeC == int.Parse(code));
            Console.WriteLine("Indiquer la ville de départ du trajet: ");
            string ville_dep = Console.ReadLine();
            Console.WriteLine("Indiquer la ville d'arrivée du trajet: ");
            string ville_arr = Console.ReadLine();
            Console.WriteLine("Indiquer le nombre de km du trajet: ");
            int km_trajet = int.Parse(Console.ReadLine());
            Console.WriteLine("Indiquer le prix du carburant pour 1L: ");
            float carburantPrix = float.Parse(Console.ReadLine());

            this.list_trajet.Add(new Trajet(v, c,ville_dep, ville_arr, km_trajet, carburantPrix));
            Console.WriteLine("trajet créé avec succés!");
        }

        public void supprimer_client()
        {
            if(this.list_client.Count == 0)
            {
                Console.WriteLine("Il n'y a aucun client à supprimer");
            }
            else
            {
                this.fiche_client();
                Console.Write("Indiquer le code client du client à supprimer: ");
                string code = Console.ReadLine();
                Client c = this.list_client.Find(client => client.CodeC == int.Parse(code));
                if(c == null)
                    Console.WriteLine("Le code client que vous avait tapé n'existe pas");
                else
                {
                    this.list_client.Remove(c);
                    Console.WriteLine("Client supprimé");
                }
            }
        }

        public void supprimer_vehicule()
        {
            if (this.list_vehicule.Count == 0)
            {
                Console.WriteLine("Il n'y a aucun vehicule à supprimer");
            }
            else
            {
                this.fiche_vehicule();
                Console.Write("Indiquer l'immatriculation du vehicule à supprimer: ");
                string immat = Console.ReadLine();
                Vehicule v = this.list_vehicule.Find(vehicule => vehicule.immatriculation == immat);
                if (v == null)
                    Console.WriteLine("L'immatriculation du vehicule que vous avait tapé n'existe pas");
                else
                {
                    this.list_vehicule.Remove(v);
                    Console.WriteLine("Vehicule supprimé");
                }
            }
        }
        public void supprimer_trajet()
        {
            if (this.list_trajet.Count == 0)
            {
                Console.WriteLine("Il n'y a aucun trajet à supprimer");
            }
            else
            {
                this.trajet();
                Console.Write("Indiquer le code trajet du trajet à supprimer: ");
                string codeT = Console.ReadLine();
                Trajet t = this.list_trajet.Find(trajet => trajet.CodeT == int.Parse(codeT));
                if (t == null)
                    Console.WriteLine("Le code du trajet que vous avait tapé n'existe pas");
                else
                {
                    this.list_trajet.Remove(t);
                    Console.WriteLine("Trajet supprimé");
                }
            }
        }


        public void fiche_vehicule()
        {
            Console.WriteLine("Fiche véhicule");
            Console.WriteLine("Tous les vehicules existants:");
            this.list_vehicule.ForEach(v =>
            {
                Console.WriteLine(v.toString());
            });
        }
        public void fiche_client()
        {
            Console.WriteLine("Tous les clients existants:");
            this.list_client.ForEach(client =>
            {
                Console.WriteLine(client.toString());
            });
        }
        public void trajet()
        {
            Console.WriteLine("Tous les trajets existants:");
            this.list_trajet.ForEach(trajet =>
            {
                Console.WriteLine(trajet.toString());
            });
        }


        public void addData()
        {
            this.list_client.Add(new Client("Fernandez casa", "Gabriel"));
            this.list_client.Add(new Client("Valentin", "Fernandez casa"));
            this.list_client.Add(new Client("Lucy", "VANG"));
            this.list_client.Add(new Client("Augustin", "LEEEEEEE"));


            this.list_vehicule.Add(new Camion("123", "Renault", 200000, 8, 10));
            this.list_vehicule.Add(new Moto("456", "BMW", 200000, 9));
            this.list_vehicule.Add(new Voiture("789", "Audi", 200000, 4));
        }
    }
}
