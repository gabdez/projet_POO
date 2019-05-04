using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_POO
{
    abstract class Utilisateur
    {
        protected string identifiant;
        protected string mdp;

        public bool checkConnexion(string identifiant, string mdp)
        {
            return this.identifiant == identifiant && this.mdp == mdp;
        }
        public abstract string getType();

        public String Identifiant
        {
            get
            {
                return this.identifiant;
            }
        }
    }
}
