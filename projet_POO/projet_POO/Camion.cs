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

        public Camion() { }
        public Camion(String immat, string marque, int prix_achat, float conso_km, int volume, Tcarburant carb)
        {
            this.immatriculation = immat;
            this.marque = marque;
            this.prix_achat = prix_achat;
            this.conso_km = conso_km;
            this.volume = volume;
            this.nbr_roues = 6;
            this.typeV = TVehicule.camion;
            this.nbr_km_parcouru = 0;
            this.Carb = carb;
        }

        public override string getData()
        {
            return base.getData() + this.volume + "--;--";
        }

        public override void loadData(string s)
        {
            base.loadData(s);
        }
    }
}
