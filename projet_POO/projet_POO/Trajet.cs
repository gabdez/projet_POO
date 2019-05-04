﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace projet_POO
{
    class Trajet
    {
        public static int counter = 0;
        private int codeT;
        private Vehicule v;
        private Client c;
        private string depart;
        private string arrivé;
        private float nbr_km;
        private double prix_carburant;

        public Trajet(Vehicule v, Client c,string depart, string arrivé, float nbr_km, double prixCarburantKm)
        {
            this.codeT = ++counter;
            this.v = v;
            this.c = c;
            this.depart = depart;
            this.arrivé = arrivé;
            this.nbr_km = nbr_km;
            this.prix_carburant = prixCarburantKm;
        }

        //nombre de kilomètres x consommation moyenne du véhicule L/100km x prix d'un litre de carburant en euro
        public double cout_total()
        {
            return this.nbr_km * v.conso_km * this.prix_carburant;
        }
        public override string ToString()
        {
            return "Code trajet: " + this.codeT + " ; Depart: " + this.depart + " ; Arrivée: " + this.arrivé + " ; Cout total: " + this.cout_total() + " euros";
        }

        public int CodeT
        {
            get
            {
                return this.codeT;
            }
        }
        public string Depart
        {
            get
            {
                return this.depart;
            }
        }
        public string Arrivee
        {
            get
            {
                return this.arrivé;
            }
        }
    }
}
