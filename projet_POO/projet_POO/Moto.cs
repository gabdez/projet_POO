using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_POO
{
    class Moto : Vehicule
    {
        public Moto(String immat, string marque, int nbr_km_parcouru, float conso_km)
        {
            this.immatriculation = immat;
            this.marque = marque;
            this.nbr_km_parcouru = nbr_km_parcouru;
            this.conso_km = conso_km;
            this.nbr_roues = 2;
            this.typeV = "moto";
        }
    }
}
