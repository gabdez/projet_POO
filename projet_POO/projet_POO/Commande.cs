using System;
namespace projet_POO
{
    class Commande : IDataRW
    {
        private Client c;
        private Trajet t;
        private Vehicule v;
        private string codeCommande;
        private DateTime dateCommande;

        public Commande() { }
        public Commande(Client c, Trajet t, Vehicule v)
        {
            this.codeCommande = this.generateID().Substring(0, 4);
            this.c = c;
            this.t = t;
            this.v = v;
            this.dateCommande = DateTime.Today;
        }

        //nombre de kilomètres x consommation moyenne du véhicule L/100km x prix d'un litre de carburant en euro + taxe d'entretien x la catégorie
        public double cout_total()
        {
            return Math.Round(this.t.Nbr_km * (this.v.Conso_km/100) * Vehicule.getPrixCarburant(this.v.TCarb) + this.taxeDentretien(),2);
        }
        private double taxeDentretien()
        {
            return this.c.categorie() * 10;
        }
        public string generateID()
        {
            return Guid.NewGuid().ToString("N");
        }
        
        public override string ToString()
        {
            return "Code commande: " + this.codeCommande 
                + " ; Date commande: " + this.dateCommande.ToString("D")
                + " ; Nom client: " + this.c.Nom 
                + " ; Type vehicule: " + this.v.TypeV
                + " ; Parking départ: " + this.t.Park_depart + " ; Parking arrivé: " + this.t.Park_retour
                + " ; Destination: " + this.t.Destination
                + " ; Nombre de KM estimés: " + this.t.Nbr_km
                + " ; Cout total de la commande: " + this.cout_total() + "€";
        }
        public string CreationDevis()
        {
            return "\n\n\n\n-------------------DEVIS ---------------------------\n"
                + "Logiciel De Location Parisient \t\t\t\t\n"
                + "12 Avenue Léonard de Vinci,\n"
                + "92400 Courbevoie,\n"
                + "06 52 44 56 78 98\n"
                + "logicieldelocation@gmail.com\n"
                + "---- INFO COMMANDE ----"
                + "Code commande: " + this.codeCommande + "\n"
                + "Date commande: " + this.dateCommande.ToString("D") + "\t\t\t\t" + this.c.Email + "\n"
                + "---- INFO CLIENT ----\n"
                + "Nom client: " + this.c.Nom + "\nPrénom client: " + this.c.Prenom + "\n"
                + "Categorie client (1 à 3): " + this.c.categorie() + "\n"
                + "---- DETAILS COMMANDE ----\n"
                + "Intitulé: Location du vehicule " + this.v.Immat + " de type " + this.v.TypeV + "\n"
                + "Quantité: 1\n" 
                + "Désignation: " + this.v.TypeV + " - " + this.v.Marque + " - " + this.v.Immat +"\n"
                + "Prix Total: " + this.cout_total() + "€\n"
                + " |----------------------------------\n"
                + " |Total Hors Taxe ->\t " + (this.cout_total() - this.taxeDentretien()) + " euros\n"
                + " |Taxe d'entretient ->\t " + this.taxeDentretien() + "€\n"
                + " |Total TTC en euros ->\t" + this.cout_total() + "€\n"
                + "------------------------------------------------"
                ;
        }

        public string getData()
        {
            string sep = "--;--";
            string codeCommande = this.codeCommande + sep;
            string dateCommande = this.dateCommande + sep;
            string identC = this.c.Identifiant + sep;
            string immat = this.v.Immat + sep;
            string departT = this.t.Park_depart + sep;
            string retourT = this.t.Park_retour + sep;
            string nbr_kmT = this.t.Nbr_km + sep;
            string ville_arr = this.t.Destination + sep;
            return codeCommande + dateCommande + identC + immat + departT + retourT + nbr_kmT + ville_arr;
        }

        public void loadData(string s)
        {
            string[] tokens = s.Split(new string[] { "--;--" }, StringSplitOptions.None);
            this.codeCommande = tokens[0];
            this.dateCommande = DateTime.Parse(tokens[1]);

            Console.WriteLine("ga");
            this.t = new Trajet(int.Parse(tokens[4]), int.Parse(tokens[5]), tokens[7], int.Parse(tokens[6]));
            Console.WriteLine("ga");
        }

        public string CodeCommande
        {
            get
            {
                return this.codeCommande;
            }
        }
        public Client Client
        {
            get
            {
                return this.c;
            }
            set
            {
                this.c = value;
            }
        }
        public Vehicule Vehicule
        {
            set
            {
                this.v = value;
            }
        }
        public Trajet Trajet
        {
            get
            {
                return this.t;
            }
            set
            {
                this.t = value;
            }
        }
    }
}
