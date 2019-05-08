using System;
namespace projet_POO
{
    class Commande
    {
        public static int Counter = 0;
        private Client c;
        private Trajet t;
        private Vehicule v;
        private int codeCommande;
        public Commande(Client c, Trajet t, Vehicule v)
        {
            this.codeCommande = ++Counter;
            this.c = c;
            this.t = t;
            this.v = v;
        }

        //nombre de kilomètres x consommation moyenne du véhicule L/100km x prix d'un litre de carburant en euro
        public double cout_total()
        {
            return this.t.Nbr_km * this.v.Conso_km * Vehicule.getPrixCarburant(this.v.TCarb);
        }

        public override string ToString()
        {
            return "Code commande: " + this.codeCommande + " ; Nom client: " + this.c.Nom + " ; Type vehicule: " + this.v.TypeV
                + " ; Parking départ: " + this.t.Depart + " ; Parking arrivé: " + this.t.Retour
                + " ; Nombre de KM estimés: " + this.t.Nbr_km
                + " ; Cout total de la commande: " + this.cout_total();
        }

        public int CodeCommande
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
        }
        public Trajet Trajet
        {
            get
            {
                return this.t;
            }
        }
    }
}
