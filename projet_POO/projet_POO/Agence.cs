using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
            this.list_parkings[cParking - 1].addVehicule(-1, v);
        }

        public void ajouter_trajet(Vehicule.TVehicule tVehicule, string identifiant, string ville_dep, string ville_arr, int km_trajet)
        {
            Vehicule veh = this.list_vehicule.Find(v => v.dispo == Vehicule.Dispo.disponible && v.typeV == tVehicule);
            Client c = this.list_client.Find(client => client.Identifiant == identifiant);
            Trajet t = new Trajet(veh, c, ville_dep, ville_arr, km_trajet, Vehicule.getPrixCarburant(veh.Carb));
            this.list_trajet.Add(t);
            veh.dispo = Vehicule.Dispo.loué;
            this.enlever_vehicule_parking(veh);
            veh.nbr_km_parcouru += km_trajet;
            c.nbr_km_parcouru += km_trajet;
            c.Montant_location += t.cout_total();
        }

        public void enlever_vehicule_parking(Vehicule v)
        {
            foreach(Parking p in this.list_parkings){
                if (p.removeVehicule(v)) break;
            }
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

        public Utilisateur checkUtilisateur(string ident, string clear_mdp, int typeUtilisateur)
        {
            if (typeUtilisateur == 1) return this.list_client.Find(c => c.checkConnexion(ident, clear_mdp));
            else if (typeUtilisateur == 2) return this.admin.checkConnexion(ident, clear_mdp) ? this.admin : null;
            else {
                for(int i = 0; i < this.array_controleurs.Length; i++)
                {
                    if (this.array_controleurs[i].checkConnexion(ident, clear_mdp)) return this.array_controleurs[i];
                }
            }
            return null;
        }
        
        public void verification_vehicule(Vehicule v, string intervention, int dispo, string motif)
        {
            if(v != null)
            {
                v.intervention += intervention;
                if (dispo != 1)
                {
                    v.dispo = Vehicule.Dispo.indisponible;
                    v.motifIndisponibilité = motif;
                }
                else v.dispo = Vehicule.Dispo.disponible;
            }
        }

        public bool retour_vehicule(Vehicule v,int cParking,int cPlace)
        {
            if (this.list_parkings.Find(p => p.CodeP == cParking).Places[cPlace] == null)
            {
                this.list_parkings.Find(p => p.CodeP == cParking).addVehicule(cPlace, v);
                v.dispo = Vehicule.Dispo.nonVérifié;
                return true;
            }
            else return false;
        }

        //public void serialize()
        //{
        //    try
        //    {

        //        Stream fStream = new FileStream("parkingsCollection.xml", FileMode.Create, FileAccess.Write, FileShare.None);

        //        XmlSerializer xmlForamt = new XmlSerializer(typeof(List<Parking>));
        //        xmlForamt.Serialize(fStream, this.list_parkings);
        //        fStream.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Error " + e.Message);
        //        Console.ReadLine();
        //    }
        //}

        //public void deserialize()
        //{
        //    FileStream fs = new FileStream("parkingsCollection.xml", FileMode.Open);
        //    XmlSerializer serializer = new XmlSerializer(typeof(List<Parking>));
        //    List<Parking> dataParkings = null;
        //    dataParkings = (List<Parking>)serializer.Deserialize(fs);
        //    serializer.Serialize(Console.Out, dataParkings);
        //}

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

        public List<Vehicule> getListVehiculeControleur(string identifiant)
        {
            return this.array_controleurs[Array.FindIndex(this.array_controleurs, c => c.Identifiant == identifiant)].List_VMaintenance;
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
        public Controleur[] Array_controleurs
        {
            get
            {
                return this.array_controleurs;
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
