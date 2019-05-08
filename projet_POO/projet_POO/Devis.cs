using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_POO
{
    class Devis
    {
        private string nom_client;
        private string prenom_client;
        private string marque;
        private string immat;
        private Tcarburant tCarburant;
        private double cout;
        public Devis(string nom, string prenom, string marque, string immat, Tcarburant carb, double cout)
        {
            this.nom_client = nom;
            this.prenom_client = prenom;
            this.marque = marque;
            this.immat = immat;
            this.tCarburant = carb;
            this.cout = cout;
        }
    }
}
