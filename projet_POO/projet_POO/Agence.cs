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
                    v = new Voiture(immat, marque, nbr_km_parcouru,conso,Vehicule.Tcarburant.sansPlomb95);
                    break;

                case "2":
                    v = new Moto(immat, marque, nbr_km_parcouru, conso, Vehicule.Tcarburant.sansPlomb95);
                    break;

                case "3":
                    Console.Write("Le volume de chargement de votre camion: ");
                    int volume = int.Parse(Console.ReadLine());
                    v = new Camion(immat, marque, nbr_km_parcouru, conso, volume, Vehicule.Tcarburant.sansPlomb95);
                    break;

                default:
                    v = new Voiture(immat, marque, nbr_km_parcouru, conso, Vehicule.Tcarburant.sansPlomb95);
                    break;
            }
            this.list_vehicule.Add(v);
        }
        public void ajouter_trajet(string immat, string codeC, string ville_dep, string ville_arr, int km_trajet, float carburantPrix)
        {
            Vehicule v = this.list_vehicule.Find(vehicule => vehicule.immatriculation == immat);
            Client c = this.list_client.Find(client => client.CodeC == int.Parse(codeC));
            this.list_trajet.Add(new Trajet(v, c, ville_dep, ville_arr, km_trajet, carburantPrix));
            v.nbr_km_parcouru += km_trajet;
            c.nbr_km_parcouru += km_trajet;
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

        //public List<Vehicule> getKmParcouruParVehicule(string marque)
        //{
        //    this.list_vehicule.ForEach(v => {

        //    });
        //}

        public void addData()
        {
            this.list_client.Add(new Client("Fernandez casa", "Gabriel"));
            this.list_client.Add(new Client("Valentin", "Fernandez casa"));
            this.list_client.Add(new Client("Lucy", "VANG"));
            this.list_client.Add(new Client("Au", "LEE"));
            this.list_client.Add(new Client("raph", "Gabriel"));
            this.list_client.Add(new Client("Valentin", "gabriel"));
            this.list_client.Add(new Client("Lucy", "VANGgggg"));
            this.list_client.Add(new Client("Augustin", "gabriel"));


            this.list_vehicule.Add(new Camion("123", "Renault", 200000, 8, 10, Vehicule.Tcarburant.diesel));
            this.list_vehicule.Add(new Moto("456", "BMW", 200000, 9, Vehicule.Tcarburant.sansPlomb95));
            this.list_vehicule.Add(new Voiture("789", "Audi", 200000, 4, Vehicule.Tcarburant.sansPlomb95));
            this.list_vehicule.Add(new Camion("1273", "Renault", 200000, 8, 10, Vehicule.Tcarburant.diesel));
            this.list_vehicule.Add(new Moto("4576", "BMW", 200000, 9, Vehicule.Tcarburant.sansPlomb95));
            this.list_vehicule.Add(new Voiture("7789", "audi", 200000, 4, Vehicule.Tcarburant.sansPlomb95));
            this.list_vehicule.Add(new Camion("1243", "Renault", 200000, 8, 10, Vehicule.Tcarburant.diesel));
            this.list_vehicule.Add(new Moto("4516", "BMW", 200000, 9, Vehicule.Tcarburant.sansPlomb95));
            this.list_vehicule.Add(new Voiture("7289", "audi", 200000, 4, Vehicule.Tcarburant.sansPlomb95));

            this.ajouter_trajet("123", "4", "HR", "Cergy", 100, 6);
            this.ajouter_trajet("456", "3", "Cergy", "paris", 500, 6);
            this.ajouter_trajet("789", "1", "Paris", "HR", 80, 6);
            this.ajouter_trajet("789", "5", "paris", "Cergy", 80, 6);
            this.ajouter_trajet("1273", "2", "marseille", "Lyon", 400, 6);
            this.ajouter_trajet("4576", "6", "avranche", "brest", 350, 6);
            this.ajouter_trajet("1243", "7", "Lyon", "HR", 600, 6);
            this.ajouter_trajet("7289", "1", "bordeau", "Nice", 300, 6);
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
