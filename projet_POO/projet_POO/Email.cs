using System.Net.Mail;
using System.Net;
using System;

namespace projet_POO
{
    class Email
    {
        public static bool sendEmail(string email, string title, string body)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("logicielDeLocation@gmail.com", "Logicieldelocation14"),
                EnableSsl = true
            };
            try
            {
                client.Send("logicielDeLocation@gmail.com", email, title, body);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public static string bodyLocation(Utilisateur u, TVehicule tVehicule, int[] places)
        {
            return "Bonjour " + u.Prenom + ",\n\nVous avez réservé une véhicule de type " + tVehicule +
                ".\nvous pouvez dès à présent retrouver votre véhicule sur le parking numéro " + places[0]
                + ". Votre " + tVehicule + " sera situé sur la place numéro: a" + places[1] +
                "\n\nMerci à vous pour votre confiance envers nos service ! a bientôt !";
        }
        public static string bodyInscription(Utilisateur u)
        {
            return "Bonjour " + u.Prenom + ",\nBienvenue dans notre logiciel de location de véhicule !\nGrace à ce logiciel vous pouvez" +
                " louer des véhicules(moto, camion et voiture) dans des parkings parisiens pour vous déplacer.\n A bientôt " + u.Prenom;
        }

    }
}
