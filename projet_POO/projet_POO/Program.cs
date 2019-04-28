using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_POO
{
    class Program
    {
        static void Main(string[] args)
        {
            Agence a = new Agence();
            a.fiche_vehicule();
            a.fiche_client();
            a.trajet();
            a.cout_total();
            Console.ReadLine();
        }
    }
}