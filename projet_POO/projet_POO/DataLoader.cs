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
        }

        public void saveData()
        {
            saveDataClients();
            saveDataVehicules();
            saveDataControleurs();
            saveDataParkings();
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
                    Vehicule v = a.List_vehicule.Find(x => x.Immat == arr[0]);
                    if(v != null)
                    {
                        a.Array_controleurs[index].List_VMaintenance.Add(v);
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
                    this.a.List_parkings.Add(p);
                    //string[] tokens = line.Split(new string[] { "--;--" }, StringSplitOptions.None);
                    //// on reprend les ids des vehicules dans la liste des vehicules des controleurs
                    //string[] arr = tokens[5].Split(new string[] { "," }, StringSplitOptions.None);
                    //// ajouter les vehicules au bon controleur
                    //Vehicule v = a.List_vehicule.Find(x => x.Immat == arr[0]);
                    //if (v != null)
                    //{
                    //    a.Array_controleurs[index].List_VMaintenance.Add(v);
                    //}
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
    }
}
