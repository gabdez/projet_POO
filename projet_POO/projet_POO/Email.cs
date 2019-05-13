using System.Net.Mail;
using System.Net;
using System;

namespace projet_POO
{
    class Email
    {
        public static void sendEmail(string email, string title, string body)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("logicielDeLocation@gmail.com", "Logicieldelocation14"),
                EnableSsl = true
            };
            try
            {
                client.SendMailAsync("logicielDeLocation@gmail.com", email, title, body);
            }
            catch (Exception e)
            {
            }
        }
        public static string bodyLocation(Utilisateur u, TVehicule tVehicule, int[] places, string devis)
        {
            string str =  "Bonjour " + u.Prenom + ",\n\nVous avez réservé un véhicule de type " + tVehicule +
                ".\nVous pouvez dès à présent retrouver votre véhicule sur le parking numéro " + places[0]
                + ". Votre " + tVehicule + " sera situé(e) sur la place numéro: a" + places[1];

            str += devis;

            str += "\n\nMerci à vous pour votre confiance envers nos services ! A bientôt !";

            return str;
        }
        public static string bodyInscription(Utilisateur u)
        {
            return "Bonjour " + u.Prenom + ",\nBienvenue dans notre logiciel de location de véhicule !\nGrâce à ce logiciel vous pouvez" +
                " louer des véhicules(moto, camion et voiture) dans des parkings parisiens pour vous déplacer.\n"
                + "Vous pouvez effectuer des trajets dans d'autre ville mais pensez bien que vous devez rendre votre véhicule sur un des parkings parisiens.\n"
                + "Lorsque vous louez un véhicule vous devez renseigné votre trajet (ville de départ et ville d'arrivé) ainsi que votre parking de départ et d'arrivé.\n"
                + "La distance du trajet sera calculé automatiquement avec Google Maps."
                + " A bientôt " + u.Prenom;
        }


    }
}
