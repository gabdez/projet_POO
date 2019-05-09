using System;
using System.IO;

namespace projet_POO
{
    class DataLoader
    {
        private Agence a;
        public DataLoader(Agence a){
            this.a = a;
        }

        public void loadData()
        {
            loadDataClients();
            loadDataVehicules();
            loadDataControleurs();
            loadDataParkings();
            loadDataCommandes();
        }

        public void saveData()
        {
            saveDataClients();
            saveDataVehicules();
            saveDataControleurs();
            saveDataParkings();
            saveDataCommandes();
        }

        // vehicules
        private void saveDataVehicules()
        {
            StreamWriter sw = new StreamWriter("vehicules.txt");
            this.a.List_vehicule.ForEach(v => {
                sw.WriteLine(v.getData());
            });
            sw.Close();
            Console.ReadLine();
        }
        private void loadDataVehicules()
        {
            string line;
            try
            {
                StreamReader sr = new StreamReader("Vehicules.txt");
                line = sr.ReadLine();
                while (line != null)
                {
                    string[] tokens = line.Split(new string[] { "--;--" }, StringSplitOptions.None);
                    Vehicule v = null;
                    if (tokens[4].Equals("voiture")) v = new Voiture();
                    else if (tokens[4].Equals("camion")) v = new Camion();
                    else if (tokens[4].Equals("moto")) v = new Moto();
                    if (v != null)
                    {
                        v.loadData(line);
                        a.List_vehicule.Add(v);
                    }
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        // clients
        private void saveDataClients()
        {
            StreamWriter sw = new StreamWriter("clients.txt");
            this.a.List_client.ForEach(c => {
                sw.WriteLine(c.getData());
            });
            sw.Close();
        }
        private void loadDataClients()
        {
            string line;
            try
            {
                StreamReader sr = new StreamReader("clients.txt");
                line = sr.ReadLine();
                while (line != null)
                {
                    Client c = new Client();
                    c.loadData(line);
                    this.a.List_client.Add(c);
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                Console.ReadLine();
            }
        }

        // controleurs 
        private void saveDataControleurs()
        {
            StreamWriter sw = new StreamWriter("controleurs.txt");
            for (int i = 0; i < this.a.Array_controleurs.Length; i++)
            {
                sw.WriteLine(this.a.Array_controleurs[i].getData());
            }
            sw.Close();
        }
        private void loadDataControleurs()
        {
            string line;
            try
            {
                StreamReader sr = new StreamReader("controleurs.txt");
                line = sr.ReadLine();
                int index = 0;
                while (line != null)
                {
                    Controleur c = new Controleur();
                    c.loadData(line);
                    this.a.Array_controleurs[index] = c;
                    string[] tokens = line.Split(new string[] { "--;--" }, StringSplitOptions.None);
                    // on reprend les ids des vehicules dans la liste des vehicules des controleurs
                    string[] arr = tokens[5].Split(new string[] { ",!" }, StringSplitOptions.None);
                    // ajouter les vehicules au bon controleur
                    for (int i = 0; i < arr.Length; i++)
                    {
                        Vehicule v = a.List_vehicule.Find(x => x.Immat == arr[i]);
                        if (v != null)
                        {
                            a.Array_controleurs[index].List_VMaintenance.Add(v);
                        }
                    }
                    line = sr.ReadLine();
                    index++;
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                Console.ReadLine();
            }
        }

        // Parkings
        private void saveDataParkings()
        {
            StreamWriter sw = new StreamWriter("parkings.txt");
            a.List_parkings.ForEach(p => sw.WriteLine(p.getData()));
            sw.Close();
        }
        private void loadDataParkings()
        {
            string line;
            try
            {
                StreamReader sr = new StreamReader("parkings.txt");
                line = sr.ReadLine();
                int index = 0;
                while (line != null)
                {
                    Parking p = new Parking();
                    p.loadData(line);
                    string[] tokens = line.Split(new string[] { "--;--" }, StringSplitOptions.None);
                    // on reprend les ids des vehicules et on les mets sur les places de parkings
                    string[] arr = tokens[3].Split(new string[] { ",!" }, StringSplitOptions.None);
                    // ajouter les vehicules au bon controleur
                    for (int i = 0; i < arr.Length; i++)
                    {
                        Vehicule v = a.List_vehicule.Find(x => x.Immat == arr[i]);
                        if (v != null)
                        {
                            p.Places[i] = v;
                        }
                    }
                    this.a.List_parkings.Add(p);
                    line = sr.ReadLine();
                    index++;
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                Console.ReadLine();
            }
        }


        // commandes
        private void saveDataCommandes()
        {
            StreamWriter sw = new StreamWriter("commandes.txt");
            a.List_commande.ForEach(c => sw.WriteLine(c.getData()));
            sw.Close();
        }
        private void loadDataCommandes()
        {
            string line;
            try
            {
                StreamReader sr = new StreamReader("commandes.txt");
                line = sr.ReadLine();
                while (line != null)
                {
                    Commande c = new Commande();
                    c.loadData(line);
                    string[] tokens = line.Split(new string[] { "--;--" }, StringSplitOptions.None);
                    // on reprend les ids du vehicule, du client et du trajet et les mettre dans la commande
                    Vehicule v = a.List_vehicule.Find(x => x.Immat == tokens[2]);
                    Client cli = a.List_client.Find(client => client.Identifiant == tokens[1]);
                    if (v != null && cli != null)
                    {
                        c.Client = cli;
                        c.Vehicule = v;
                    }
                    this.a.List_commande.Add(c);
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                Console.ReadLine();
            }
        }
    }
}
