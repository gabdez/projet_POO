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
        public Camion(String immat, string marque, float prix_achat, float conso_km, int volume, Tcarburant carb) : base(immat, marque, prix_achat, conso_km, carb)
        {
            this.volume = volume;
            this.nbr_roues = 6;
            this.typeV = TVehicule.camion;
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
