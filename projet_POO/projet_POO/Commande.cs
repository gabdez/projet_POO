using System;
namespace projet_POO
{
    class Commande : IDataRW
    {
        private Client c;
        private Trajet t;
        private Vehicule v;
        private string codeCommande;

        public Commande() { }
        public Commande(Client c, Trajet t, Vehicule v)
        {
            this.codeCommande = this.generateID().Substring(0, 4);
            this.c = c;
            this.t = t;
            this.v = v;
        }

        //nombre de kilomètres x consommation moyenne du véhicule L/100km x prix d'un litre de carburant en euro
        public double cout_total()
        {
            return this.t.Nbr_km * this.v.Conso_km * Vehicule.getPrixCarburant(this.v.TCarb);
        }
        public string generateID()
        {
            return Guid.NewGuid().ToString("N");
        }
        
        public override string ToString()
        {
            return "Code commande: " + this.codeCommande + " ; Nom client: " + this.c.Nom + " ; Type vehicule: " + this.v.TypeV
                + " ; Parking départ: " + this.t.Depart + " ; Parking arrivé: " + this.t.Retour
                + " ; Nombre de KM estimés: " + this.t.Nbr_km
                + " ; Cout total de la commande: " + this.cout_total();
        }

        public string getData()
        {
            string sep = "--;--";
            string codeCommande = this.codeCommande + sep;
            string identC = this.c.Identifiant + sep;
            string immat = this.v.Immat + sep;
            string departT = this.t.Depart + sep;
            string retourT = this.t.Retour + sep;
            string nbr_kmT = this.t.Nbr_km + sep;
            return codeCommande + identC + immat + departT + retourT + nbr_kmT;
        }

        public void loadData(string s)
        {
            string[] tokens = s.Split(new string[] { "--;--" }, StringSplitOptions.None);
            this.codeCommande = tokens[0];
            this.t = new Trajet(tokens[3], tokens[4], int.Parse(tokens[5]));
        }

        public string CodeCommande
        {
            get
            {
                return this.codeCommande;
            }
        }
        public Client Client
        {
            get
            {
                return this.c;
            }
            set
            {
                this.c = value;
            }
        }
        public Vehicule Vehicule
        {
            set
            {
                this.v = value;
            }
        }
        public Trajet Trajet
        {
            get
            {
                return this.t;
            }
            set
            {
                this.t = value;
            }
        }
    }
}
