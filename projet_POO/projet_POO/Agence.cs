using System;
using System.Collections.Generic;
using System.Linq;

namespace projet_POO
{
    class Agence
    {
        private List<Vehicule> list_vehicule = new List<Vehicule>();
        private List<Client> list_client = new List<Client>();
        private List<Commande> list_commande = new List<Commande>();
        private List<Parking> list_parkings = new List<Parking>();
        private Controleur[] array_controleurs = new Controleur[3] { null, null, null};
        private Admin admin = new Admin();
        private static Agence instance = null;

        private Agence(){}

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

        /*
         * @Return son ancien emplacement oû le loueur doit aller chercher la voiture
         * un tableau int[2] -> int[0] = code parking ; int[1] = place dans le parking (0 à 9)
         */
        public Commande ajouter_commande(Vehicule veh, Client c, Trajet t)
        {
            int[] places = new int[2];
            Commande com = new Commande(c, t, veh);
            this.list_commande.Add(com);
            veh.Dispo = Dispo.loué;
            veh.Nbr_km_parcouru += t.Nbr_km;
            c.nbr_km_parcouru += t.Nbr_km;
            c.Montant_location += com.cout_total();
            return com;
        }

        /// <summary>
        /// Fonction qui permet de retirer un vehicule v d'un parking et de retourner son ancien emplacement
        /// </summary>
        /// <param name="v"></param>
        /// <returns>Son ancien emplacement</returns>
        public int[] enlever_vehicule_parking(Vehicule v)
        {
            int[] places = new int[2];
            foreach(Parking p in this.list_parkings){
                int i = p.removeVehicule(v);
                if(i != -1)
                {
                    places[0] = this.list_parkings.FindIndex(x => x.CodeP == p.CodeP);
                    places[1] = i;
                    break;
                }
            }
            return places;
        }

        public void supprimer_client(Client c)
        {
            this.list_client.Remove(c);
            this.list_commande = this.list_commande.Except(this.list_commande.FindAll(com => com.Client == c)).ToList();
        }

        public void supprimer_vehicule(Vehicule v)
        {
            this.list_vehicule.Remove(v);
            this.array_controleurs[Array.FindIndex(this.array_controleurs,c=>c.EstMaintenu(v))].List_VMaintenance.Remove(v);
            this.enlever_vehicule_parking(v);
        }
        public void supprimer_commande(Commande c)
        {
            this.list_commande.Remove(c);
        }

        public Utilisateur checkUtilisateur(string ident, string clear_mdp, int typeUtilisateur)
        {
            if (typeUtilisateur == 1) return this.list_client.Find(c => c.checkConnexion(ident, clear_mdp));
            else if (typeUtilisateur == 2) return this.admin.checkConnexion(ident, clear_mdp) ? this.admin : null;
            else {
                int i = Array.FindIndex(this.array_controleurs, c => c.checkConnexion(ident, clear_mdp));
                return i == -1 ? null : this.array_controleurs[i];
            }
        }
        
        public void verification_vehicule(Vehicule v, string intervention, int dispo, string motif)
        {
            if(v != null)
            {
                v.Intervention += intervention;
                if (dispo != 1)
                {
                    v.Dispo = Dispo.indisponible;
                    v.MotifIndisponibilité = motif;
                }
                else v.Dispo = Dispo.disponible;
            }
        }

        public bool retour_vehicule(Vehicule v,int cParking,int cPlace)
        {
            if (this.list_parkings.Find(p => p.CodeP == cParking).Places[cPlace] == null)
            {
                this.list_parkings.Find(p => p.CodeP == cParking).addVehicule(cPlace, v);
                v.Dispo = Dispo.nonVérifié;
                return true;
            }
            else return false;
        }
        // getters and setters
        public List<Vehicule> getListVehiculeControleur(string identifiant)
        {
            return this.array_controleurs[Array.FindIndex(this.array_controleurs, c => c.Identifiant == identifiant)].List_VMaintenance;
        }
        public Controleur getControleurById(string identifiant)
        {
            return Array_controleurs[Array.FindIndex(Array_controleurs, c => c.Identifiant == identifiant)];
        }
        public List<Parking> getAllParkingAvailable(TVehicule typeVehicule)
        {
            return this.list_parkings.FindAll(p => p.containTypeV(typeVehicule));
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
        public List<Commande> List_commande
        {
            get
            {
                return this.list_commande;
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
