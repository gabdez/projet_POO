using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_POO
{
    abstract class Vehicule
    {
        public enum Tcarburant { diesel, sansPlomb95, sansPlomb98 };

        public string immatriculation;
        public string marque;
        public int prix_achat;
        public float conso_km;
        public int nbr_roues;
        public string typeV;
        public int nbr_km_parcouru;
        public Tcarburant Carb;

        public override string ToString()
        {
            return "Immatriculation: " + this.immatriculation + " ; Type vehicule: " + this.typeV + 
                " ; marque: " + this.marque + 
                " ; Consommation au 100 km: " + this.conso_km + " ; nombre de Km parcourus: " + this.nbr_km_parcouru;
        }
    }
}
