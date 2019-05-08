using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_POO
{
    interface IDataRW
    {
        string getData(); // sert à avoir une ligne d'information de l'object
        void loadData(string s); // sert quand on doit implémenter l'object
    }
}
