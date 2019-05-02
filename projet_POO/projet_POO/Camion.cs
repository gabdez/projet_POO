using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_POO
{
    class Camion : Vehicule
    {
        public int volume = 0;
        public Camion(String immat, string marque, int nbr_km_parcouru, float conso_km, int volume)
        {
            this.immatriculation = immat;
            this.marque = marque;
            this.nbr_km_parcouru = nbr_km_parcouru;
            this.conso_km = conso_km;
            this.volume = volume;
            this.nbr_roues = 6;
            this.typeV = "camion";
        }
    }
}
