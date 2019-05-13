using System;

namespace projet_POO
{
    public class Parking : IDataRW
    {
        private Vehicule[] places = new Vehicule[10];
        public string emplacement;
        private int codeP;

        public Parking() { }

        public int nbrVehicule()
        {
            int nbr = 0;
            for(int i = 0; i < this.places.Length; i++)
            {
                if (this.places[i] != null) nbr++;
            }
            return nbr;
        }

        public void addVehicule(int cPlace, Vehicule v)
        {
            if(cPlace == -1) 
                this.places[this.nbrVehicule()] = v;
            else
                this.places[cPlace] = v;
        }
        /**
         * @ return is old place in parking
         */ 
        public int removeVehicule(Vehicule v)
        {
            for (int i = 0; i < this.places.Length; i++)
            {
                if (this.places[i] == v) { this.places[i] = null; return i; };
            }
            return -1;
        }
        public bool containTypeV(TVehicule typeVehicule)
        {
            return Array.Find(this.places, p => p != null && p.Dispo == Dispo.disponible && p.TypeV == typeVehicule) == null ? false : true ;
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
            return "Code parking: " + this.codeP + " ; Emplacement: " + this.emplacement + " ; nombre de place libre: " + (10 -this.nbrVehicule());
        }

        public string getData()
        {
            string sep = "--;--";
            string codeP = this.codeP + sep;
            string emplacement = this.emplacement + sep;
            //string  = this.places + sep;
            string str = "";
            foreach (Vehicule v in this.places)
            {
                str = str + ( v!=null ? v.Immat : "") + ",!";
            }
            return codeP + emplacement + str + sep;
        }

        public void loadData(string s)
        {
            string[] tokens = s.Split(new string[] { "--;--" }, StringSplitOptions.None);
            this.codeP = int.Parse(tokens[0]);
            this.emplacement = tokens[1];
        }
    }
}
