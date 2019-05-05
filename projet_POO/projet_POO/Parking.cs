using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace projet_POO
{
    [Serializable]
    public class Parking : IXmlSerializable
    {
        public static int counter = 0;
        private Vehicule[] places = new Vehicule[10];
        public string emplacement;
        private int codeP;
        private int nbrVehicule = 0; // nombre de vehicule sur le parking

        public Parking() { }
        public Parking(string emplacement)
        {
            this.codeP = ++Parking.counter;
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
        public bool removeVehicule(Vehicule v)
        {
            for (int i = 0; i < this.places.Length; i++)
            {
                if (this.places[i] == v) { this.places[i] = null; this.nbrVehicule -= 1; return true; };
            }
            return false;
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

        public void WriteXml(XmlWriter writer)
        {
            //writer.WriteStartElement("Parking");
            writer.WriteElementString("codeP" , codeP.ToString());
            writer.WriteElementString("emplacement" ,emplacement);
            //writer.WriteEndElement();
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            
        }

        public XmlSchema GetSchema()
        {
            return (null);
        }
    }
}
