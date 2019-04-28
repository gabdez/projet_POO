using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_POO
{
    class Trajet
    {
        //nombre de kilomètres x consommation du véhicule au kilomètre x prix du carburant au kilomètre
        private Vehicule v;
        private float nbr_km;
        private float prix_carburant_km;

        public Trajet(Vehicule v, float nbr_km, float prixCarburantKm)
        {
            this.v = v;
            this.nbr_km = nbr_km;
            this.prix_carburant_km = prixCarburantKm;
        }

        public float cout_total()
        {
            return this.nbr_km * v.conso_km * this.prix_carburant_km;
        }
    }
}
