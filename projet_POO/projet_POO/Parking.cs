using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_POO
{
    class Parking
    {
        public static int counter = 0;
        private Vehicule[] places = new Vehicule[10];
        public string emplacement;
        private int codeP;
        private int nbrVehicule = 0; // nombre de vehicule sur le parking

        public Parking(string emplacement)
        {
            this.codeP = ++Parking.counter;
            this.emplacement = emplacement;
        }
        public void addVehicule(Vehicule v)
        {
            this.places[this.nbrVehicule] = v;
        }
        public void removeVehicule(Vehicule v)
        {
            for (int i = 0; i < this.places.Length; i++)
            {
                if (this.places[i] == v) { this.places[i] = null; this.nbrVehicule -= 1; };
            }
        }
        public bool estComplet()
        {
            return this.nbrVehicule == 9;
        }

        public Vehicule[] Places
        {
            get
            {
                return this.places;
            }
        }

        public int CodeP
        {
            get
            {
                return this.codeP;
            }
        }

        public override string ToString()
        {
            return "Code parking: " + this.codeP + " ; Emplacement: " + this.emplacement + " ; Place libre: ";
        }
    }
}
