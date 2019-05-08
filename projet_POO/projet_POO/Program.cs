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
            Menu m = new Menu(Agence.Instance);
            DataLoader dl = new DataLoader(Agence.Instance);
            dl.loadData();
            m.start();
            dl.saveData();
        }
    }
}