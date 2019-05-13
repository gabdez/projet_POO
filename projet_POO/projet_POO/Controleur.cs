using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_POO
{
    public class Controleur : Utilisateur
    {
        private List<Vehicule> list_VMaintenance = new List<Vehicule>();

        public Controleur() { }

        public override string getType()
        {
            return "controleur";
        }

        public void deplacerVehicule(Parking pArrivé, Parking pDepart, Vehicule vehicule , int placeParking)
        {
            pDepart.removeVehicule(vehicule);
            pArrivé.addVehicule(placeParking, vehicule);
        }

        public List<Vehicule> List_VMaintenance
        {
            get
            {
                return this.list_VMaintenance;
            }
        }

        /// <summary>
        /// Renvoie un boolean si le controleur possède bien la voiture v en paramètre
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public bool EstMaintenu(Vehicule v)
        {
            return this.list_VMaintenance.Find(veh => veh.Immat == v.Immat) == null ? false : true ;
        }

        public override string getData()
        {
            string sep = "--;--";
            string str = "";
            list_VMaintenance.ForEach(v => {
                str = str + v.Immat + ",!";
            });
            return base.getData() + str + sep;
        }

        public override void loadData(string s)
        {
            base.loadData(s);
        }
    }
}
