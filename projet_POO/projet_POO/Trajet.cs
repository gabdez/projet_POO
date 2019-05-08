using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace projet_POO
{
    public class Trajet
    {
        public static int counter = 0;
        private int codeT;
        private string depart;
        private string retour;
        private double nbr_km;

        public Trajet(string depart, string retour, float nbr_km)
        {
            this.codeT = ++counter;
            this.depart = depart;
            this.retour = retour;
            this.nbr_km = nbr_km;
        }

        
        public override string ToString()
        {
            return "Code trajet: " + this.codeT + " ; Depart: " + this.depart + " ; Arrivée: " + this.retour;
        }

        public int CodeT
        {
            get
            {
                return this.codeT;
            }
        }
        public string Depart
        {
            get
            {
                return this.depart;
            }
        }
        public string Retour
        {
            get
            {
                return this.retour;
            }
        }

        public double Nbr_km
        {
            get
            {
                return this.nbr_km;
            }
        }
    }
}
