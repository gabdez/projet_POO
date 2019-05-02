using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_POO
{
    abstract class Vehicule
    {
        public string immatriculation;
        public string marque;
        public int nbr_km_parcouru;
        public float conso_km;
        public int nbr_roues;
        public string typeV;

        public string toString()
        {
            return "Immatriculation: " + this.immatriculation + " ; Type vehicule: " + this.typeV + 
                " ; marque: " + this.marque + " ; Nombre de km parcouru: " + this.nbr_km_parcouru + 
                " ; Consommation au 100 km: " + this.conso_km;
        }
    }
}
