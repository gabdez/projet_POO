﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_POO
{
    class Moto : Vehicule
    {
        public Moto(String immat, string marque, int prix_achat, float conso_km, Tcarburant carb)
        {
            this.immatriculation = immat;
            this.marque = marque;
            this.prix_achat = prix_achat;
            this.conso_km = conso_km;
            this.nbr_roues = 2;
            this.typeV = "moto";
            this.nbr_km_parcouru = 0;
            this.Carb = carb;
        }
    }
}
