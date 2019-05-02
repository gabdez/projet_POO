using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_POO
{
    class Client
    {
        public static int counter = 0;
        private int codeC;
        public string nom;
        public string prenom;

        public Client(string nom, string prenom)
        {
            this.codeC = ++counter;
            this.nom = nom;
            this.prenom = prenom;
        }

        public string toString()
        {
            return "Code client: " + this.codeC + " ; Nom client: " + this.nom + " ; Prenom client: " + this.prenom;
        }

        public int CodeC
        {
            get
            {
                return this.codeC;
            }
        }
    }
}
