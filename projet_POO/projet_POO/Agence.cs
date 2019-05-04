using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace projet_POO
{
    class Agence
    {
        private List<Vehicule> list_vehicule = new List<Vehicule>();
        private List<Client> list_client = new List<Client>();
        private List<Trajet> list_trajet = new List<Trajet>();
        private List<Parking> list_parkings = new List<Parking>();
        private Controleur[] array_controleurs = new Controleur[3];
        private Admin admin = new Admin();
        private static Agence instance = null;

        private Agence()
        {
            // initialisation controleur et parking
            this.array_controleurs = new Controleur[3]
            {
                new Controleur("c1", "controleur"),
                new Controleur("c2", "controleur"),
                new Controleur("c3", "controleur"),
            };
            for(int i = 0; i <= 20; i++)
            {
                this.list_parkings.Add(new Parking("Arrondissement " + i));
            }
            this.list_parkings.Add(new Parking("Roissy"));
            this.list_parkings.Add(new Parking("Orly"));
        }

        public void ajouter_client(string nom, string prenom, string email, string identifiant, string mdp)
        {
            this.list_client.Add(new Client(nom, prenom, email, identifiant, mdp));
        }

        public void ajouter_vehicule(Vehicule v, int cParking)
        {
            this.list_vehicule.Add(v);
            this.affecterVehiculeControleur(v);
            this.affecterVehiculeParking(v, cParking);
        }

        private void affecterVehiculeControleur(Vehicule v)
        {
            int index = 0;
            for (int i = 0; i <= 2; i++)
            {
                if (this.array_controleurs[i].List_VMaintenance.Count < this.array_controleurs[index].List_VMaintenance.Count)
                    index = i;
            }
            this.array_controleurs[index].List_VMaintenance.Add(v);
        }
        private void affecterVehiculeParking(Vehicule v, int cParking)
        {
            this.list_parkings[cParking - 1].addVehicule(v);
        }

        public void ajouter_trajet(Vehicule.TVehicule tVehicule, string identifiant, string ville_dep, string ville_arr, int km_trajet)
        {
            Vehicule veh = this.list_vehicule.Find(v => v.dispo == Vehicule.Dispo.disponible && v.typeV == tVehicule);
            Client c = this.list_client.Find(client => client.Identifiant == identifiant);
            Trajet t = new Trajet(veh, c, ville_dep, ville_arr, km_trajet, Vehicule.getPrixCarburant(veh.Carb));
            this.list_trajet.Add(t);
            veh.dispo = Vehicule.Dispo.loué;
            veh.nbr_km_parcouru += km_trajet;
            c.nbr_km_parcouru += km_trajet;
            c.Montant_location += t.cout_total();
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

        public Utilisateur checkClient(string ident, string clear_mdp)
        {
            return this.list_client.Find(c => c.checkConnexion(ident, clear_mdp));
        }
        public Utilisateur checkAdmin(string ident, string clear_mdp)
        {
            return this.admin.checkConnexion(ident, clear_mdp) ? this.admin : null; ;
        }

        public void addData()
        {
            this.ajouter_client("Fernandez casa", "Gabriel", "email", "1" , "demo");
            this.ajouter_client("Valentin", "Fernandez casa", "email", "2", "demo");
            this.ajouter_client("Lucy", "VANG", "email", "3", "demo");
            this.ajouter_client("Au", "LEE", "email", "4", "demo");
            this.ajouter_client("raph", "Gabriel", "email", "5", "demo");
            this.ajouter_client("Valentin", "gabriel", "email", "6", "demo");
            this.ajouter_client("Lucy", "VANGgggg", "email", "7", "demo");
            this.ajouter_client("Augustin", "gabriel", "email", "8", "demo");


            this.ajouter_vehicule(new Voiture("123", "Renault", 200000, 8, Vehicule.Tcarburant.sansPlomb95), 1);
            this.ajouter_vehicule(new Moto( "456", "BMW", 200000, 9, Vehicule.Tcarburant.gazole), 2);
            this.ajouter_vehicule(new Camion("789", "Audi", 200000, 4,10, Vehicule.Tcarburant.sansPlomb95),3);
            this.ajouter_vehicule(new Camion("1273", "Renault", 200000, 8, 0, Vehicule.Tcarburant.sansPlomb95), 4);
            this.ajouter_vehicule(new Moto("4576", "BMW", 200000, 9,0), 8);
            this.ajouter_vehicule(new Voiture("7789", "audi", 200000, 4, Vehicule.Tcarburant.sansPlomb98), 9);
            this.ajouter_vehicule(new Voiture("1243", "Renault", 200000, 8,Vehicule.Tcarburant.sansPlomb98), 5);
            this.ajouter_vehicule(new Camion("4516", "BMW", 200000, 9,25,Vehicule.Tcarburant.sansPlomb98), 1);
            this.ajouter_vehicule(new Moto("7289", "audi", 200000, 4,0), 1);

            this.ajouter_trajet(Vehicule.TVehicule.camion, "4", "HR", "Cergy", 100);
            this.ajouter_trajet(Vehicule.TVehicule.moto, "3", "Cergy", "paris", 500);
            this.ajouter_trajet(Vehicule.TVehicule.voiture, "1", "Paris", "HR", 80);
            this.ajouter_trajet(Vehicule.TVehicule.voiture, "5", "paris", "Cergy", 80);
            this.ajouter_trajet(Vehicule.TVehicule.voiture, "2", "marseille", "Lyon", 400);
            this.ajouter_trajet(Vehicule.TVehicule.camion, "6", "avranche", "brest", 350);
            this.ajouter_trajet(Vehicule.TVehicule.camion, "6", "brest", "avranche", 400);
            this.ajouter_trajet(Vehicule.TVehicule.moto, "7", "Lyon", "HR", 700);
            this.ajouter_trajet(Vehicule.TVehicule.moto, "1", "bordeau", "Nice", 300);
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
        public List<Parking> List_parkings
        {
            get
            {
                return this.list_parkings;
            }
        }
        public static Agence Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Agence();
                }
                return instance;
            }
        }
    }
}
