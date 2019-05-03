using System;
using System.Collections.Generic;
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
        public int nbr_km_parcouru;

        public Client(string nom, string prenom)
        {
            this.codeC = ++counter;
            this.nom = nom;
            this.prenom = prenom;
        }

        public override string ToString()
        {
            return "Code client: " + this.codeC + " ; Nom : " + this.nom + " ; Prenom : " + this.prenom +
                " ; Nombre de kilomètre parcouru : " + this.nbr_km_parcouru;
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
