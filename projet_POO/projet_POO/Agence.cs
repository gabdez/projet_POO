using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_POO
{
    class Agence
    {
        private List<Vehicule> list_vehicule = new List<Vehicule>();
        private List<Client> list_client = new List<Client>();

        public Agence(){}

        public void fiche_vehicule()
        {
            Console.WriteLine("Fiche véhicule");
        }
        public void fiche_client()
        {
            Console.WriteLine("Fiche client");
        }
        public void trajet()
        {
            Console.WriteLine("Trajet");
        }
        public void cout_total()
        {
            Console.WriteLine("Cout total");
        }
    }
}
