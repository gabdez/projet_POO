using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_POO
{
    [Serializable]
    public abstract class Vehicule
    {
        public enum Dispo { disponible, indisponible, loué, nonVérifié };
        public enum Tcarburant { gazole, sansPlomb95, sansPlomb98 };
        public enum TVehicule { voiture, moto, camion };

        public string immatriculation;
        public string marque;
        public int prix_achat;
        public float conso_km;
        public int nbr_roues;
        public TVehicule typeV;
        public int nbr_km_parcouru;
        public Dispo dispo = Dispo.disponible;
        public Tcarburant Carb;
        public string intervention = "";
        public string motifIndisponibilité = "";

        public override string ToString()
        {
            return "Immatriculation: " + this.immatriculation + " ; Type vehicule: " + this.typeV + 
                " ; marque: " + this.marque + 
                " ; Consommation au 100 km: " + this.conso_km + " ; nombre de Km parcourus: " + this.nbr_km_parcouru + " ; " + this.motif();
        }

        public string motif()
        {
            if (this.dispo == Dispo.disponible) return "Véhicule disponible à la location";
            else if (this.dispo == Dispo.loué) return "Véhicule déjà loué";
            else if (this.dispo == Dispo.indisponible) return "Indisponible - motif :" + this.motifIndisponibilité;
            else return "Véhicule pas encore vérifié par nos équipes";
        }

        public static double getPrixCarburant(Tcarburant carb)
        {
            switch (carb)
            {
                case Tcarburant.gazole:
                    return 1.479;
                case Tcarburant.sansPlomb95:
                    return 1.599;
                case Tcarburant.sansPlomb98:
                    return 1.635;
                default:
                    return 1.479;
            }
        }
        public static TVehicule getTVehicule(string s)
        {
            if (s == "2") return TVehicule.moto;
            else if (s == "3") return TVehicule.camion;
            return TVehicule.voiture;
        }
    }
}
