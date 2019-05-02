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

        public void ajouter_client(string nom, string prenom)
        {
            this.list_client.Add(new Client(nom, prenom));
        }

        public void ajouter_vehicule(string typeVehicule, string immat, string marque, int nbr_km_parcouru, float conso)
        {
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

                default:
                    v = new Voiture(immat, marque, nbr_km_parcouru, conso);
                    break;
            }
            this.list_vehicule.Add(v);
        }
        public void ajouter_trajet(string immat, string codeC, string ville_dep, string ville_arr, int km_trajet, float carburantPrix)
        {
            Vehicule v = this.list_vehicule.Find(vehicule => vehicule.immatriculation == immat);
            Client c = this.list_client.Find(client => client.CodeC == int.Parse(codeC));
            this.list_trajet.Add(new Trajet(v, c, ville_dep, ville_arr, km_trajet, carburantPrix));
        }

        public void supprimer_client(Client c)
        {
            this.list_client.Remove(c);
        }

        public void supprimer_vehicule(Vehicule v)
        {
            this.list_vehicule.Remove(v);
        }
        public void supprimer_trajet(Trajet t)
        {
            this.list_trajet.Remove(t);
        }

        public List<Vehicule> getVehiculeParMarque(string marque)
        {
            Console.ReadLine();
            return this.list_vehicule.Select(v => v).ToList();
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

        public List<Vehicule> List_vehicule
        {
            get
            {
                return this.list_vehicule;
            }
        }
        public List<Client> List_client
        {
            get
            {
                return this.list_client;
            }
        }
        public List<Trajet> List_trajet
        {
            get
            {
                return this.list_trajet;
            }
        }
    }
}
