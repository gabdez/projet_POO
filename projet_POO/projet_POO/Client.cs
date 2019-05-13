using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace projet_POO
{
    public class Client : Utilisateur
    {
        public float nbr_km_parcouru;
        private double montant_location;

        public Client() { }

        public Client(string nom, string prenom,string email, string identifiant, string mdp):base(mdp, identifiant, email, nom, prenom){}

        public override string ToString()
        {
            return "Identifiant: " + this.identifiant + " ; Nom : " + this.nom + " ; Prenom : " + this.prenom +
                " ; Nombre de kilomètre parcouru : " + this.nbr_km_parcouru + " ; Catégorie client : " + this.categorie();
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
        public override string getData()
        {
            string sep = "--;--";
            string montant = this.montant_location + sep;
            string km_parcouru = this.nbr_km_parcouru + sep;
            return base.getData() + montant + km_parcouru;
        }

        public override void loadData(string s)
        {
            base.loadData(s);
            string[] tokens = s.Split(new string[] { "--;--" }, StringSplitOptions.None);
            this.montant_location = double.Parse(tokens[5]);
            this.nbr_km_parcouru = int.Parse(tokens[6]);
        }
    }
}
