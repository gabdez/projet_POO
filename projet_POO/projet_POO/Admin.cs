using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_POO
{
    public class Admin : Utilisateur
    {
        public Admin()
        {
            this.identifiant = "admin";
            this.mdp = "admin";
        }
        public override string getType()
        {
            return "admin";
        }
    }
}
