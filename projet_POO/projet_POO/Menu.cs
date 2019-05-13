using System;
using System.Collections.Generic;
using System.Linq;

namespace projet_POO
{
    class Menu
    {
        /**
         * Class entièrement dédié à l'affichage
         */
        private Agence a;
        private Utilisateur utilisateur; // utilisateur connecté

        public Menu(Agence a)
        {
            this.a = a;
        }
        public void start()
        {
            bool play = true;
            while (play) {
                this.connexion(ref play);
                if (play == true)
                {
                    if (this.utilisateur.getType() == "admin") this.menu_admin();
                    else if (this.utilisateur.getType() == "client") this.menu_client();
                    else this.menu_controleur();
                }
            }
        }
        public void connexion(ref bool play)
        {
            Console.Clear();
            bool connected = true;
            while (connected)
            {
                Console.Clear();
                Console.WriteLine("Bienvenue dans votre logiciel de location \n");
                Console.WriteLine("Connexion client (1)");
                Console.WriteLine("Connexion administrateur (2)");
                Console.WriteLine("Connexion controleur (3)");
                Console.WriteLine("Créer un compte client(4)");
                Console.WriteLine("Exit application (e)");
                Console.Write("\nVotre choix: ");
                string choix = Console.ReadLine();
                switch (choix)
                {
                    case "1":
                    case "2":
                    case "3":
                        Console.Clear();
                        Console.Write("Identifiant: ");
                        string ident = Console.ReadLine();
                        Console.Write("Mot de passe: ");
                        string mdp = Console.ReadLine();
                        this.utilisateur = a.checkUtilisateur(ident, mdp, int.Parse(choix));
                        if (this.utilisateur == null)
                            Console.WriteLine("identifiant ou mot de passe incorrect !");
                        else
                        {
                            Console.WriteLine("\nConnexion réussi ! Bienvenue " + ident + " !");
                            connected = false;
                        }

                        System.Threading.Thread.Sleep(1000);
                        break;

                    case "4":
                        this.créer_compte();
                        connected = false;
                        break;

                    case "e":
                        play = false;
                        connected = false;
                        return;

                    default:
                        break;
                }
            }
        }
        public void menu_admin()
        {
            bool play = true;
            while (play)
            {
                Console.Clear();
                Console.WriteLine("MENU PRINCIPAL\n");
                Console.WriteLine("\t Gérer les vehicules (1)");
                Console.WriteLine("\t Gérer les clients (2)");
                Console.WriteLine("\t Gérer les commandes (3)");
                Console.WriteLine("\t Déconnexion (e)\n");
                Console.Write("Votre choix: ");
                string menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        this.gerer_vehicule();
                        break;

                    case "2":
                        this.gerer_client();
                        break;

                    case "3":
                        this.gerer_commande();
                        break;

                    case "e":
                        play = false;
                        break;
                }
            }
        }
        public void menu_client()
        {
            bool play = true;
            while (play)
            {
                Console.Clear();
                Console.WriteLine("MENU PRINCIPAL\n");
                Console.WriteLine("\t Louer un vehicule (1)");
                Console.WriteLine("\t Mes Commandes (2)");
                Console.WriteLine("\t Voir vehicule disponible (3)");
                Console.WriteLine("\t Deconnexion (e)\n");
                Console.Write("Votre choix: ");
                string menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        this.louer_vehicule();
                        break;

                    case "2":
                        this.affichage_list("Mes Commandes", a.List_commande.FindAll(c => c.Client.Identifiant == this.utilisateur.Identifiant));
                        Console.ReadLine();
                        break;

                    case "3":
                        this.affichage_list("Visualiser tous les vehicules dispo", a.List_vehicule.FindAll(v => v.Dispo == Dispo.disponible));
                        Console.ReadLine();
                        break;
                        
                    case "e":
                        play = false;
                        break;
                }
            }
        }
        public void menu_controleur()
        {
            bool play = true;
            while (play)
            {
                Console.Clear();
                Console.WriteLine("MENU PRINCIPAL\n");
                Console.WriteLine("\t Visualiser mes véhicules affectés (1)");
                Console.WriteLine("\t Vérifier un véhicule (2)");
                Console.WriteLine("\t Déplacer un véhicule (3)");
                Console.WriteLine("\t Remise en service des véhicules indisponibles (4)");
                Console.WriteLine("\t Deconnexion (e)\n");
                Console.Write("Votre choix: ");
                string menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        this.affichage_list("Mes véhicules affectés", a.getListVehiculeControleur(this.utilisateur.Identifiant));
                        Console.ReadLine();
                        break;

                    case "2":
                        this.verification_vehicule();
                        Console.ReadLine();
                        break;

                    case "3":
                        this.deplacer_vehicule();
                        Console.ReadLine();
                        break;

                    case "4":
                        this.remise_en_service();
                        Console.ReadLine();
                        break;

                    case "e":
                        play = false;
                        break;
                }
            }
        }
        // Les menus d'affichages
        public void gerer_client()
        {
            bool play = true;
            while (play)
            {
                Console.Clear();
                Console.WriteLine("MENU PRINCIPAL > MENU CLIENT \n");
                Console.WriteLine("\t Supprimer client (1)");
                Console.WriteLine("\t Visualiser tous les clients (2)");
                Console.WriteLine("\t\t - Afficher nombre de kilomètre parcouru par client (21)");
                Console.WriteLine("\t\t - Afficher clients trié par leurs nombres de km parcouru (22)");
                Console.WriteLine("\t\t - Afficher clients trié selon leurs noms (ASC) (23)");
                Console.WriteLine("\t\t - Afficher clients trié selon leurs noms (DESC) (24)");
                Console.WriteLine("\t\t - Chercher client par nom ou prenom (25)");
                Console.WriteLine("\t Retourner au menu principal (e)\n");
                Console.Write("Votre choix: ");
                string menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        this.supprimer_client();
                        break;

                    case "2":
                        this.affichage_list("Visualiser tous les clients", a.List_client);
                        Console.ReadLine();
                        break;

                    case "21":
                        a.List_client.ForEach(c => Console.WriteLine("Client: " + c.Nom + " " + c.Prenom + " => " + c.nbr_km_parcouru + " Km parcourus"));
                        Console.ReadLine();
                        break;

                    case "22":
                        a.List_client.Sort(delegate(Client a, Client b)
                        {
                            return -1 * a.nbr_km_parcouru.CompareTo(b.nbr_km_parcouru);
                        });
                        this.affichage_list("Listes des clients classés par leurs nombres de kilometre parcouru", a.List_client);
                        Console.ReadLine();
                        break;

                    case "23":
                        a.List_client.Sort(delegate (Client a, Client b)
                        {
                            return a.Nom.CompareTo(b.Nom);
                        });
                        this.affichage_list("Listes des clients selon leurs Noms (ASC)", a.List_client);
                        Console.ReadLine();
                        break;

                    case "24":
                        a.List_client.Sort(delegate (Client a, Client b)
                        {
                            return -1 * a.Nom.CompareTo(b.Nom);
                        });
                        this.affichage_list("Listes des clients selon leurs Noms (DESC)", a.List_client);
                        Console.ReadLine();
                        break;

                    case "25":
                        Console.Write("\nNom ou prenom client recherché: ");
                        String nom = Console.ReadLine();
                        this.affichage_list("Liste de client trouvé :", a.List_client.FindAll(v => v.Nom.ToLower() == nom.ToLower() || v.Prenom.ToLower() == nom.ToLower()));
                        Console.ReadLine();
                        break;

                    case "e":
                    default:
                        play = false;
                        break;
                }
            }
        }
        public void gerer_vehicule()
        {
            bool play = true;
            while (play)
            {
                Console.Clear();
                Console.WriteLine("MENU PRINCIPAL > MENU VEHICULE \n");
                Console.WriteLine("\t Ajouter vehicule (1)");
                Console.WriteLine("\t Supprimer vehicule (2)");
                Console.WriteLine("\t retour d'un vehicule de location (3)");
                Console.WriteLine("\t Visualiser tous les vehicules (4)");
                Console.WriteLine("\t\t - Rechercher vehicules par marque (41)");
                Console.WriteLine("\t\t - Afficher nombre de kilomètre parcouru par véhicule (42)");
                Console.WriteLine("\t\t - Afficher vehicule trié par leurs nombres de km parcouru (43)");
                Console.WriteLine("\t\t - Afficher vehicule trié par leurs conso au 100 km (44)");
                Console.WriteLine("\t\t - Afficher vehicule par marque (45)");
                Console.WriteLine("\t\t - Afficher vehicule disponible (46)");
                Console.WriteLine("\t\t - Afficher vehicule loué (47)");
                Console.WriteLine("\t\t - Afficher vehicule en cours de vérification (48)");
                Console.WriteLine("\t Visualiser tous les parkings (5)");
                Console.WriteLine("\t Retourner au menu principal (e)\n");
                Console.Write("Votre choix: ");
                string menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        this.ajouter_vehicule();
                        break;

                    case "2":
                        this.supprimer_vehicule();
                        break;

                    case "3":
                        this.retourner_vehicule();
                        break;

                    case "4":
                        this.affichage_list("Visualiser tous les vehicules", a.List_vehicule);
                        Console.ReadLine();
                        break;

                    case "41":
                        Console.Write("\nmarque recherchée: ");
                        String marque = Console.ReadLine();
                        this.affichage_list("Liste de vehicule de la marque " + marque + ":", a.List_vehicule.FindAll(v => v.Marque.ToLower() == marque.ToLower()));
                        Console.ReadLine();
                        break;

                    case "42":
                        a.List_vehicule.ForEach(v => Console.WriteLine("Immatriculation: " + v.Immat + " - marque: " + v.Marque + " => " + v.Nbr_km_parcouru + " Km parcourus"));
                        Console.ReadLine();
                        break;

                    case "43":
                        a.List_vehicule.Sort(delegate (Vehicule a, Vehicule b)
                        {
                            return -1 * a.Nbr_km_parcouru.CompareTo(b.Nbr_km_parcouru);
                        });
                        this.affichage_list("Vehicule classé par nombre de km parcourus: ", a.List_vehicule);
                        Console.ReadLine();
                        break;

                    case "44":
                        a.List_vehicule.Sort(delegate (Vehicule a, Vehicule b)
                        {
                            return -1 * a.Conso_km.CompareTo(b.Conso_km);
                        });
                        this.affichage_list("Vehicule classé par consommation au 100 km: ", a.List_vehicule);
                        Console.ReadLine();
                        break;

                    case "45":
                        a.List_vehicule.Sort(delegate (Vehicule a, Vehicule b)
                        {
                            return a.Marque.CompareTo(b.Marque);
                        });
                        this.affichage_list("Vehicule classé par marque: ", a.List_vehicule);
                        Console.ReadLine();
                        break;

                    case "46":
                        this.affichage_list("Vehicule disponible: ", a.List_vehicule.FindAll(v => v.Dispo == Dispo.disponible));
                        Console.ReadLine();
                        break;

                    case "47":
                        this.affichage_list("Vehicule loué: ", a.List_vehicule.FindAll(v => v.Dispo == Dispo.loué));
                        Console.ReadLine();
                        break;

                    case "48":
                        this.affichage_list("Vehicule à vérifier par les controleurs: ", a.List_vehicule.FindAll(v => v.Dispo == Dispo.nonVérifié));
                        Console.ReadLine();
                        break;

                    case "5":
                        this.affichage_list("Liste des parkings: ", a.List_parkings);
                        Console.ReadLine();
                        break;

                    default:
                        play = false;
                        break;
                }
            }
        }
        public void gerer_commande()
        {
            bool play = true;
            while (play)
            {
                Console.Clear();
                Console.WriteLine("MENU PRINCIPAL > MENU COMMANDE \n");
                Console.WriteLine("\t Visualiser toutes les commandes (1)");
                Console.WriteLine("\t\t - Affiché toutes les commandes triés selon leur parking depart (11)");
                Console.WriteLine("\t\t - Affiché toutes les commandes triés selon leur parking retour (12)");
                Console.WriteLine("\t\t - Rechercher un parking de départ (13)");
                Console.WriteLine("\t\t - Rechercher un parking retour (14)");
                Console.WriteLine("\t Retourner au menu principal (e)\n");
                Console.Write("Votre choix: ");
                string menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        this.affichage_list("Visualiser toutes les commandes", a.List_commande);
                        Console.ReadLine();
                        break;

                    case "11":
                        a.List_commande.Sort(delegate (Commande a, Commande b)
                        {
                            return a.Trajet.Park_depart.CompareTo(b.Trajet.Park_depart);
                        });
                        this.affichage_list("Affiché toutes commandes triés selon leur parking retour", a.List_commande);
                        Console.ReadLine();
                        break;

                    case "12":
                        a.List_commande.Sort(delegate (Commande a, Commande b)
                        {
                            return a.Trajet.Park_retour.CompareTo(b.Trajet.Park_retour);
                        });
                        this.affichage_list("Affiché tous les trajets triés selon leur parking retour", a.List_commande);
                        Console.ReadLine();
                        break;

                    case "13":
                        this.affichage_list("Tous les parkings", a.List_parkings);
                        Console.Write("\nParking de départ recherchée (1 à 23): ");
                        int park_dep = int.Parse(Console.ReadLine());
                        this.affichage_list("", a.List_commande.FindAll(c => c.Trajet.Park_depart == park_dep));
                        Console.ReadLine();
                        break;

                    case "14":
                        this.affichage_list("Tous les parkings", a.List_parkings);
                        Console.Write("\nParking retour recherchée (1 à 23): ");
                        int park_arr = int.Parse(Console.ReadLine());
                        this.affichage_list("", a.List_commande.FindAll(t => t.Trajet.Park_retour == park_arr));
                        Console.ReadLine();
                        break;

                    case "e":
                    default:
                        play = false;
                        break;
                }
            }
        }
        // creation_compte
        public void créer_compte()
        {
            Console.Clear();
            Console.Write("Nom client: ");
            String nom = Console.ReadLine();
            Console.Write("Prénom client: ");
            String prenom = Console.ReadLine();
            Console.Write("adresse email (Renseignez une adresse email valide et réelle): ");
            String email = Console.ReadLine();
            Console.Write("Identifiant: ");
            String identifiant = Console.ReadLine();
            Console.Write("Mot de passe: ");
            String mdp = Console.ReadLine();
            a.ajouter_client(nom, prenom, email, identifiant, mdp);
            this.utilisateur = a.checkUtilisateur(identifiant, mdp, 1);
            Console.WriteLine("compte créé avec succés! Un mail d'inscription vous a été envoyé.");
            string body = Email.bodyInscription(this.utilisateur);
            Email.sendEmail(this.utilisateur.Email, "Bienvenue " + this.utilisateur.Prenom + " !", body);
            Console.WriteLine("appuyer sur entrée pour revenir au menu principal");
            Console.ReadLine();
        }
        // fonctions d'ajout
        public void ajouter_vehicule()
        {
            Console.Clear();
            Console.WriteLine("MENU PRINCIPAL > MENU VEHICULE > Formulaire d'ajout vehicule \n");
            Console.Write("Quel type de vehicule souhaiter vous ajouter? : \n Voiture(1) \n moto(2) \n camion (3)\nvotre choix: ");
            String typeVehicule = Console.ReadLine();
            Console.Write("Immatriculation: ");
            String immat = Console.ReadLine();
            Console.Write("marque: ");
            String marque = Console.ReadLine();
            Console.Write("prix du vehicule à l'achat: ");
            float prix_achat = float.Parse(Console.ReadLine());
            Console.Write("Consommation L/100km : ");
            float conso = float.Parse(Console.ReadLine());
            int volume = 0;
            if (typeVehicule == "3")
            {
                Console.Write("Le volume de chargement de votre camion: ");
                volume = int.Parse(Console.ReadLine());
            }
            this.affichage_list("", a.List_parkings);
            Console.Write("Renseignez le code du parking où le véhicule sera stationné : ");
            int codeP = int.Parse(Console.ReadLine());
            if (a.List_parkings.Find(p => p.CodeP == codeP).nbrVehicule() == 9)
            {
                Console.WriteLine("Ce parking est complet");
                System.Threading.Thread.Sleep(1000);
                return;
            }
            Console.Write("Renseignez le type de carburant de vehicule: Diesel (1), Sans Plomb 95 (2) ou Sans Plomb 98 (3) ");
            int codeCarburant = int.Parse(Console.ReadLine());
            Vehicule v = null;
            switch (Vehicule.getTVehicule(typeVehicule))
            {
                case TVehicule.voiture:
                    v = new Voiture(immat, marque, prix_achat, conso, (Tcarburant)Enum.Parse(typeof(Tcarburant), (codeCarburant-1).ToString()));
                    break;

                case TVehicule.moto:
                    v = new Moto(immat, marque, prix_achat, conso, (Tcarburant)Enum.Parse(typeof(Tcarburant), (codeCarburant - 1).ToString()));
                    break;

                case TVehicule.camion:
                    v = new Camion(immat, marque, prix_achat, conso, volume, (Tcarburant)Enum.Parse(typeof(Tcarburant), (codeCarburant - 1).ToString()));
                    break;

                default:
                    v = new Voiture(immat, marque, prix_achat, conso, (Tcarburant)Enum.Parse(typeof(Tcarburant), (codeCarburant - 1).ToString()));
                    break;
            }
            a.ajouter_vehicule(v, codeP);
            Console.WriteLine("vehicule créé avec succés!");
            System.Threading.Thread.Sleep(1000);
        }

        public void louer_vehicule()
        {
            if (!a.List_vehicule.Exists(v => v.Dispo == Dispo.disponible))
            {
                Console.WriteLine("Il n'y a pas de véhicule à louer ! Demander aux admninistrateurs d'en rajouter");
                Console.ReadLine();
                return;
            }
            Console.Clear();
            Console.WriteLine("Formulaire de location véhicule");
            Console.Write("\nChoisissez votre type de vehicule: voiture(1), moto (2), camion(3): ");
            string type = Console.ReadLine();
            if(a.List_vehicule.Find(v => v.TypeV == Vehicule.getTVehicule(type) && v.Dispo == Dispo.disponible) == null)
            {
                Console.WriteLine("Ce type de véhicule n'est pas disponible actuellement");
                System.Threading.Thread.Sleep(2000);
                return;
            }
            List<Parking> list_p = a.getAllParkingAvailable(Vehicule.getTVehicule(type));
            if(list_p.Count == 0)
            {
                Console.WriteLine("Ce type de véhicule n'est actuellement pas disponible dans aucun parking");
                System.Threading.Thread.Sleep(2000);
                return;
            }
            else
            {
                this.affichage_list("Liste des parkings où un(e) " + Vehicule.getTVehicule(type) + " est disponible: ", list_p);
            }
            Console.Write("Indiquer le code du parking de départ du trajet parmi les parkings affichés: ");
            int park_dep = int.Parse(Console.ReadLine());
            if (list_p.Find(p => p.CodeP == park_dep) == null)
            {
                Console.WriteLine("Ce parking ne contient aucun véhicule de type: " + Vehicule.getTVehicule(type));
                System.Threading.Thread.Sleep(2000);
                return;
            }
            Console.Write("Indiquer le parking retour du trajet (de 1 à 23): ");
            int park_arr = int.Parse(Console.ReadLine());


            string emplacementParking1 = a.List_parkings.Find(p => p.CodeP == park_dep).emplacement;
            string emplacementParking2 = a.List_parkings.Find(p => p.CodeP == park_arr).emplacement;
            Console.Write("Indiquer la ville de destination de votre trajet: ");
            string destination = Console.ReadLine();
            Console.Write("Calcul du trajet en cours avec Google Maps....\n");
            int[] Ar = Trajet.calculer_distance_trajet(destination, emplacementParking1, emplacementParking2);
            int km_trajet = Ar[0] + Ar[1];
            if (km_trajet == 0)
            {
                Console.Write("Calcul du trajet impossible.\n");
                Console.Write("Indiquer manuellement le nombre de kilomètre du trajet que vous allez réaliser: ");
                km_trajet = int.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine(emplacementParking1 + " -> " + destination + " : " + Ar[0] + " km");
                Console.WriteLine(destination + " -> " + emplacementParking2 + " : " + Ar[1] + " km pour ramener le vehicule au bon parking");
                Console.WriteLine("Trajet total : " + (Ar[0] + Ar[1]) + " km selon google maps");
            }
            Vehicule veh = a.List_vehicule.Find(v => v.Dispo == Dispo.disponible && v.TypeV == Vehicule.getTVehicule(type));
            Client c = a.List_client.Find(client => client.Identifiant == this.utilisateur.Identifiant);
            Trajet t = new Trajet(park_dep, park_arr, destination, km_trajet);
            if (veh == null || c == null || t == null)
            {
                Console.WriteLine("Location impossible, le type de véhicule n'est plus disponible sur ce parking!. (appuyer sur entrée pour revenir au menu principal)");
                Console.ReadLine();
                return;
            }
            int [] emplacement = a.enlever_vehicule_parking(veh);
            Commande commande = a.ajouter_commande(veh, c,t);
            string body = Email.bodyLocation(this.utilisateur, Vehicule.getTVehicule(type), emplacement, commande.CreationDevis());
            Email.sendEmail(this.utilisateur.Email, "Nouvelle location !", body);
            Console.WriteLine("Location effectuée avec succès! \nVotre devis à été envoyé par mail à l'adresse " + this.utilisateur.Email +  ". (appuyer sur entrée pour revenir au menu principal)");
            Console.ReadLine();
        }

        public void verification_vehicule()
        {
            List<Vehicule> VehiculeNonVerifié = a.getListVehiculeControleur(this.utilisateur.Identifiant).FindAll(x => x.Dispo == Dispo.nonVérifié);
            Console.Clear();
            if(VehiculeNonVerifié.Count == 0)
            {
                Console.WriteLine("Vous n'avez aucun véhicule à vérifier");
                System.Threading.Thread.Sleep(2000);
                return ;
            }
            this.affichage_list("Mes véhicules a vérifier", VehiculeNonVerifié);
            Console.WriteLine("Indiquer l'immatriculation du vehicule à verifier: ");
            string immat = Console.ReadLine();
            Vehicule v = VehiculeNonVerifié.Find(x => x.Immat == immat);
            if(v == null)
            {
                Console.WriteLine("Ce véhicule ne vous est pas affecté ou n'existe pas!");
                System.Threading.Thread.Sleep(1000);
                return;
            }
            Console.WriteLine("Intervention précédente: " + (v.Intervention == "" ? "aucune intervention" : v.Intervention));
            Console.Write("Reportez toutes les interventions faites sur ce véhicule: ");
            string intervention = Console.ReadLine();
            Console.Write("Remettre ce véhicule disponible pour la location? oui(1) non(2): ");
            int dispo = int.Parse(Console.ReadLine());
            string motif = null;
            if(dispo != 1)
            {
                Console.WriteLine("Motif de l'indisponibilité: ");
                motif = Console.ReadLine();
            }
            a.verification_vehicule(v, intervention, dispo, motif);
            Console.Write("véhicule vérifié avec succés, le véhicule" + (dispo == 1 ? " est à nouveau disponible à la location" : " est indisponible pour le moment") );
            System.Threading.Thread.Sleep(1000);
        }
        public void deplacer_vehicule()
        {
            this.affichage_list("Liste de mes vehicules affectés et disponibles", a.getListVehiculeControleur(this.utilisateur.Identifiant).FindAll(v => v.Dispo == Dispo.disponible));
            Console.Write("Indiquez le code du vehicule à déplacer: ");
            string immatV = Console.ReadLine();
            this.affichage_list("Liste des parkings:", a.List_parkings);
            Console.Write("Indiquez l'id du parking où déplacer le véhicule: ");
            int idParking = int.Parse(Console.ReadLine());
            Console.Write("Indiquez la place de parking où déplacer le véhicule (de 0 à 9): ");
            int placeParking = int.Parse(Console.ReadLine());
            Controleur c = a.getControleurById(this.utilisateur.Identifiant);
            Vehicule vehicule = a.List_vehicule.Find(v => v.Immat == immatV);
            Parking pArrivé = a.List_parkings.Find(p => p.CodeP == idParking);
            Parking pDepart = a.List_parkings.Find(p1 => p1.Places.Contains(vehicule));
            if (c == null || vehicule == null || pArrivé == null || pDepart == null)
            {
                Console.Write("Le Vehicule n'a pas pu être déplacé!");
            }
            else
            {
                c.deplacerVehicule(pArrivé, pDepart, vehicule, placeParking);
                Console.Write("Le véhicule à été déplacé avec succés au parking numéro " + idParking + " à la place A" + placeParking);
            }
            System.Threading.Thread.Sleep(2000);
        }
        public void remise_en_service()
        {
            List<Vehicule> listIndisponible = a.getListVehiculeControleur(this.utilisateur.Identifiant).FindAll(ve => ve.Dispo == Dispo.indisponible);
            this.affichage_list("Liste de mes vehicules affectés et indisponibles", listIndisponible);
            if (listIndisponible.Count == 0)
            {
                Console.WriteLine("Il n'y a aucun véhicule indisponible.");
                System.Threading.Thread.Sleep(2000);
                return;
            }
            Console.WriteLine("Indiquez le code du vehicule à remettre en service: ");
            string immatV = Console.ReadLine();
            Vehicule v = listIndisponible.Find(veh => veh.Immat == immatV);
            if (v == null)
            {
                Console.Write("L'immatriculation renseigné n'existe pas.");
                System.Threading.Thread.Sleep(2000);
                return;
            }
            else
            {
                v.Dispo = Dispo.disponible;
                v.MotifIndisponibilité = "";
            }
            Console.WriteLine("Véhicule remis en service avec succès!");
            System.Threading.Thread.Sleep(2000);
        }
        // fonctions de suppression
        public void supprimer_client()
        {
            Console.Clear();
            Console.WriteLine("MENU PRINCIPAL > MENU CLIENT > Formulaire suppression client \n");
            if (a.List_client.Count == 0)
            {
                Console.WriteLine("Il n'y a aucun client à supprimer");
                Console.Write("\n(tapez sur entrée pour revenir au menu précédent)");
                Console.ReadLine();
            }
            else
            {
                this.affichage_list("", a.List_client);
                Console.Write("Indiquer l'identifiant du client à supprimer: ");
                string code = Console.ReadLine();
                Client c = a.List_client.Find(client => client.Identifiant == code);
                if (c == null)
                    Console.WriteLine("L'identifiant que vous avait tapé n'existe pas");
                else
                {
                    a.supprimer_client(c);
                    Console.WriteLine("Client supprimé avec succés");
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }
        public void supprimer_vehicule()
        {
            Console.Clear();
            Console.WriteLine("MENU PRINCIPAL > MENU TRAJET > Formulaire suppression vehicule \n");
            if (a.List_vehicule.FindAll(v => v.Dispo == Dispo.disponible).Count == 0)
            {
                Console.WriteLine("Il n'y a aucun vehicule à supprimer, tous les véhicules sont soit loué soit en cours de vérification par nos controleurs");
                Console.Write("\n(tapez sur entrée pour revenir au menu précédent)");
                Console.ReadLine();
            }
            else
            {
                this.affichage_list("", a.List_vehicule.FindAll(veh => veh.Dispo == Dispo.disponible));
                Console.Write("Indiquer l'immatriculation du vehicule à supprimer: ");
                string immat = Console.ReadLine();
                Vehicule v = a.List_vehicule.Find(vehicule => vehicule.Immat == immat);
                if (v == null)
                {
                    Console.WriteLine("L'immatriculation du vehicule que vous avait tapé n'existe pas");
                    System.Threading.Thread.Sleep(1000);
                }
                else
                {
                    a.supprimer_vehicule(v);
                    Console.WriteLine("Vehicule supprimé avec succés");
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }
        public void retourner_vehicule()
        {
            Console.Clear();
            if (a.List_vehicule.FindAll(x => x.Dispo == Dispo.loué) == null) {
                Console.WriteLine("Aucun véhicule ne peut être retourné car aucun véhicule n'est loué");
                System.Threading.Thread.Sleep(2000);
                return;
            }
            this.affichage_list("Véhicules loués :", a.List_vehicule.FindAll(x => x.Dispo == Dispo.loué));
            Console.Write("Indiquer l'immatriculation du vehicule qui à été retourner: ");
            string immat = Console.ReadLine();
            Vehicule v = a.List_vehicule.Find(x => x.Immat == immat);
            if (v == null)
            {
                Console.WriteLine("Ce véhicule ne vous est pas affecté ou n'existe pas!");
                System.Threading.Thread.Sleep(1000);
                return;
            }
            Console.Write("\nIndiquer le numéro du parking ou le vehicule a été retourné (de 1 à 23): ");
            int cParking = int.Parse(Console.ReadLine());
            Console.Write("\nIndiquer le numéro de la place de parking (de 0 à 9): ");
            int cPlace = int.Parse(Console.ReadLine());
            if(!a.retour_vehicule(v, cParking, cPlace))
            {
                Console.WriteLine("Le véhicule n'a pas pu être retourné, la place référencé est déja prise ou le parking est plein");
                System.Threading.Thread.Sleep(3000);
                return;
            }
            Console.WriteLine("Vehicule retourné avec succés");
            System.Threading.Thread.Sleep(1000);
        }
        public void affichage_list<T>(string titre, List<T> list)
        {
            Console.WriteLine("\n" + titre);
            list.ForEach(obj => Console.WriteLine( "- " + ((T)obj).ToString()));
            if (list.Count == 0)
                Console.WriteLine("Aucune donnée !");
        }
    }
}
