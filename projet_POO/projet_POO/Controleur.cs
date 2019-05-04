using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_POO
{
    class Controleur : Utilisateur
    {
        private List<Vehicule> list_VMaintenance = new List<Vehicule>();

        public Controleur(string ident, string mdp)
        {
            this.identifiant = ident;
            this.mdp = mdp;
        }

        public override string getType()
        {
            return "controleur";
        }

        public List<Vehicule> List_VMaintenance
        {
            get
            {
                return this.list_VMaintenance;
            }
        }
    }
}
