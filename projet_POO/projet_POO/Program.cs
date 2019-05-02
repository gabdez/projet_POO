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
            bool play = true;
            a.addData();

            while (play)
            {
                Console.WriteLine("Menu principal:");
                Console.WriteLine("\t ajouter un vehicule (1)");
                Console.WriteLine("\t supprimer un vehicule (2)");
                Console.WriteLine("\t ajouter un client (3)");
                Console.WriteLine("\t supprimer un client (4)");
                Console.WriteLine("\t ajouter un trajet (5)");
                Console.WriteLine("\t supprimer un trajet (6)");
                Console.WriteLine("\t Exit (e)\n");
                Console.Write("Votre choix: ");

                string menu = Console.ReadLine();

                switch (menu)
                {
                    case "1":
                        a.ajouter_vehicule();
                        break;

                    case "2":
                        a.supprimer_vehicule();
                        break;

                    case "3":
                        a.ajouter_client();
                        break;

                    case "4":
                        a.supprimer_client();
                        break;

                    case "5":
                        a.ajouter_trajet();
                        break;

                    case "6":
                        a.supprimer_trajet();
                        break;

                    case "e":
                    default:
                        play = false;
                        break;
                }
            }
        }
    }
}