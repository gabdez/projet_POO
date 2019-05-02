using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_POO
{
    class Trajet
    {
        public static int counter = 0;
        private int codeT;
        private Vehicule v;
        private Client c;
        private string depart;
        private string arrivé;
        private float nbr_km;
        private float prix_carburant;

        public Trajet(Vehicule v, Client c,string depart, string arrivé, float nbr_km, float prixCarburantKm)
        {
            this.codeT = ++counter;
            this.v = v;
            this.c = c;
            this.depart = depart;
            this.arrivé = arrivé;
            this.nbr_km = nbr_km;
            this.prix_carburant = prixCarburantKm;
        }

        //nombre de kilomètres x consommation moyenne du véhicule L/100km x prix d'un litre de carburant en euro
        public float cout_total()
        {
            return this.nbr_km * v.conso_km * this.prix_carburant;
        }
        public string toString()
        {
            return "Code trajet: " + this.codeT + " ; Depart: " + this.depart + " ; Arrivée: " + this.arrivé + " ; Cout total: " + this.cout_total() + " euros";
        }

        public int CodeT
        {
            get
            {
                return this.codeT;
            }
        }
    }
}
