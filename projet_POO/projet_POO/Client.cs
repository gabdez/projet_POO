using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace projet_POO
{
    class Client : Utilisateur
    {
        public string nom;
        public string prenom;
        public int nbr_km_parcouru;
        private string email;
        private double montant_location;

        public Client(string nom, string prenom,string email, string identifiant, string clear_mdp)
        {
            this.identifiant = identifiant;
            this.nom = nom;
            this.prenom = prenom;
            this.email = email;
            this.mdp = clear_mdp;
        }

        public override string ToString()
        {
            return "Code client: " + this.identifiant + " ; Nom : " + this.nom + " ; Prenom : " + this.prenom +
                " ; Nombre de kilomètre parcouru : " + this.nbr_km_parcouru;
        }

        public int categorie()
        {
            if (this.montant_location > 10000) return 1;
            else if (this.montant_location > 3000) return 2;
            return 3;
        }
        public override string getType()
        {
            return "client";
        }

        public double Montant_location
        {
            get{
                return this.montant_location;
            }
            set{
                this.montant_location = value;
            }
        }
        //public string Mdp
        //{
        //    get
        //    {
        //        return this.mdp;
        //    }
        //}
    }
}
