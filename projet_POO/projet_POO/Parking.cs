using System;

namespace projet_POO
{
    public class Parking : IDataRW
    {
        private Vehicule[] places = new Vehicule[10];
        public string emplacement;
        private int codeP;
        private int nbrVehicule = 0; // nombre de vehicule sur le parking

        public Parking() { }
        public Parking(int codeP, string emplacement)
        {
            this.codeP = codeP;
            this.emplacement = emplacement;
        }
        public void addVehicule(int cPlace, Vehicule v)
        {
            if(cPlace == -1) 
                this.places[this.nbrVehicule] = v;
            else
                this.places[cPlace] = v;
            this.nbrVehicule++;
        }
        /**
         * @ return is old place in parking
         */ 
        public int removeVehicule(Vehicule v)
        {
            for (int i = 0; i < this.places.Length; i++)
            {
                if (this.places[i] == v) { this.places[i] = null; this.nbrVehicule -= 1; return i; };
            }
            return -1;
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
            return "Code parking: " + this.codeP + " ; Emplacement: " + this.emplacement + " ; nombre de place libre: " + (9 -this.nbrVehicule);
        }

        public string getData()
        {
            string sep = "--;--";
            string codeP = this.codeP + sep;
            string emplacement = this.emplacement + sep;
            string nbrVehicule = this.nbrVehicule + sep;
            //string  = this.places + sep;
            string str = "";
            foreach (Vehicule v in this.places)
            {
                str = str + ( v!=null ? v.Immat : "") + ",!";
            }
            return codeP + emplacement + nbrVehicule + str + sep;
        }

        public void loadData(string s)
        {
            string[] tokens = s.Split(new string[] { "--;--" }, StringSplitOptions.None);
            this.codeP = int.Parse(tokens[0]);
            this.emplacement = tokens[1];
            this.nbrVehicule = int.Parse(tokens[2]);
        }
    }
}
