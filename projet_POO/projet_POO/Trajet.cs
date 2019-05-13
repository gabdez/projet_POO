using System;
using System.Data;
using System.IO;
using System.Net;
using System.Text;

namespace projet_POO
{
    public class Trajet
    {
        private int park_depart;
        private int park_retour;
        private string destination;
        private float nbr_km;

        public Trajet(int park_depart, int park_retour, string destination, float nbr_km)
        {
            this.park_depart = park_depart;
            this.park_retour = park_retour;
            this.destination = destination;
            this.nbr_km = nbr_km;
        }

        public static int[] calculer_distance_trajet(string destination, string emplacement_depart, string emplacement_arr)
        {
            string origin = emplacement_arr + " paris";
            string url1 = "https://maps.googleapis.com/maps/api/distancematrix/xml?origins=" + origin + "&destinations=" + destination + "&departure_time=now&key=AIzaSyDZz50z1npCQ2Jci1aX-E1sF-BqeBHjvoE";
            string url2 = "https://maps.googleapis.com/maps/api/distancematrix/xml?origins=" + destination + "&destinations=" + emplacement_arr + "&departure_time=now&key=AIzaSyDZz50z1npCQ2Jci1aX-E1sF-BqeBHjvoE";
            int distance1 = getDistance(url1);
            int distance2 = getDistance(url2);
            return new int[] { distance1, distance2 };
        }

        private static int getDistance(string url)
        {
            string distance = "0";
            WebRequest request = WebRequest.Create(url);
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        DataSet dsResult = new DataSet();
                        dsResult.ReadXml(reader);
                        distance = dsResult.Tables["distance"].Rows[0]["value"].ToString();
                    }
                }
            }
            catch (Exception e)
            {
            }
            return int.Parse(distance)/1000;
        }

        public override string ToString()
        {
            return " ; Depart: " + this.park_depart + " ; Destination: " + this.Destination + " ; Arrivée: " + this.park_retour;
        }
        public int Park_depart
        {
            get
            {
                return this.park_depart;
            }
        }
        public int Park_retour
        {
            get
            {
                return this.park_retour;
            }
        }

        public float Nbr_km
        {
            get
            {
                return this.nbr_km;
            }
        }
        public string Destination
        {
            get
            {
                return this.destination;
            }
        }
    }
}
