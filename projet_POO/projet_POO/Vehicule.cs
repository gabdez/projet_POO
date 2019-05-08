using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_POO
{
    public enum Dispo { disponible, indisponible, loué, nonVérifié };
    public enum Tcarburant { gazole, sansPlomb95, sansPlomb98 };
    public enum TVehicule { voiture, moto, camion };
    public abstract class Vehicule : IDataRW
    {

        protected string immatriculation;
        protected string marque;
        protected float prix_achat;
        protected float conso_km;
        protected int nbr_roues;
        protected TVehicule typeV;
        protected float nbr_km_parcouru;
        protected Dispo dispo = Dispo.disponible;
        protected Tcarburant Carb;
        protected string intervention = "";
        protected string motifIndisponibilité = "";

        public Vehicule() { }

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

        public virtual string getData()
        {
            string sep = "--;--";
            string immat = this.immatriculation + sep;
            string marque = this.marque + sep;
            string prix_achat = this.prix_achat + sep;
            string conso_km = this.conso_km + sep;
            string typeV = this.typeV + sep;
            string nbr_km_parcouru = this.nbr_km_parcouru + sep;
            string dispo = this.dispo + sep;
            string Carb = this.Carb + sep;
            string intervention = this.intervention + sep;
            string motifIndisponibilité = this.motifIndisponibilité + sep;
            return immat + marque + prix_achat + conso_km + typeV + nbr_km_parcouru
                + dispo + Carb + intervention + motifIndisponibilité;
        }

        public virtual void loadData(string s)
        {
            string[] tokens = s.Split(new string[] { "--;--" }, StringSplitOptions.None);
            immatriculation = tokens[0];
            marque = tokens[1];
            prix_achat = float.Parse(tokens[2]);
            conso_km = int.Parse(tokens[3]);
            typeV = (TVehicule) Enum.Parse(typeof(TVehicule), tokens[4]);
            nbr_km_parcouru = float.Parse(tokens[5]);
            dispo = (Dispo)Enum.Parse(typeof(Dispo), tokens[6]);
            Carb = (Tcarburant)Enum.Parse(typeof(Tcarburant), tokens[7]);
            intervention = tokens[8];
            motifIndisponibilité = tokens[9];
        }

        // getters and setters

        public string Immat
        {
            get
            {
                return this.immatriculation;
            }
        }
        public string Marque
        {
            get
            {
                return this.marque;
            }
        }
        public float Conso_km
        {
            get
            {
                return this.conso_km;
            }
        }
        public TVehicule TypeV
        {
            get
            {
                return this.typeV;
            }
        }
        public float Nbr_km_parcouru
        {
            get
            {
                return this.nbr_km_parcouru;
            }
            set
            {
                this.nbr_km_parcouru = value;
            }
        }
        public Dispo Dispo
        {
            get
            {
                return this.dispo;
            }
            set
            {
                this.dispo = value;
            }
        }
        public Tcarburant TCarb
        {
            get
            {
                return this.Carb;
            }
        }
        public string MotifIndisponibilité
        {
            get
            {
                return this.motifIndisponibilité;
            }
            set
            {
                this.motifIndisponibilité = value;
            }
        }
        public string Intervention
        {
            get
            {
                return this.intervention;
            }
            set
            {
                this.intervention = value;
            }
        }
    }
}
