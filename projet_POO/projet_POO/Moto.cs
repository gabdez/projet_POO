using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_POO
{
    class Moto : Vehicule
    {
        public Moto() { }
        public Moto(string immat, string marque, float prix_achat, float conso_km, Tcarburant carb) : base(immat, marque, prix_achat, conso_km, carb)
        {
            this.nbr_roues = 2;
            this.typeV = TVehicule.moto;
        }

        public override string getData()
        {
            return base.getData();
        }

        public override void loadData(string s)
        {
            base.loadData(s);
        }
    }
}
