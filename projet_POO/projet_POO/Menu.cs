using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
            a.addData();
            this.connexion();
            if (this.utilisateur.getType() == "admin") this.menu_admin();
            else this.menu_client();
        }

        public void connexion()
        {
            Console.Clear();
            bool connected = true;
            while (connected)
            {
                Console.Clear();
                Console.WriteLine("Bienvenue dans votre logiciel de location \n");
                Console.WriteLine("Se connecter (1)");
                Console.WriteLine("Créer un compte client(2)");
                Console.WriteLine("Connexion controleur (3)");
                Console.WriteLine("Connexion administrateur (4)");
                Console.Write("\nVotre choix: ");
                string choix = Console.ReadLine();
                switch (choix)
                {
                    case "1":
                        Console.Clear();
                        Console.Write("Identifiant: ");
                        string ident = Console.ReadLine();
                        Console.Write("Mot de passe: ");
                        string mdp = Console.ReadLine();
                        this.utilisateur = a.checkClient(ident, mdp);
                        if (this.utilisateur == null)
                            Console.WriteLine("identifiant ou mot de pass incorrect !");
                        else
                        {
                            Console.WriteLine("\nConnexion réussi ! Bienvenue " + ident + " !");
                            connected = false;
                        }

                        System.Threading.Thread.Sleep(1000);
                        break;

                    case "2":
                        this.créer_compte();
                        connected = false;
                        break;

                    case "3":
                        Console.Clear();
                        Console.Write("Identifiant administrateur: ");
                        string ident_controleur = Console.ReadLine();
                        Console.Write("Mot de passe admin: ");
                        string mdp_controleur = Console.ReadLine();
                        this.utilisateur = a.checkAdmin(ident_controleur, mdp_controleur);
                        if (this.utilisateur != null)
                        {
                            Console.WriteLine("\nConnexion en mode controleur réussi !");
                            connected = false;
                        }
                        else Console.WriteLine("identifiant ou mot de pass incorrect !");

                        System.Threading.Thread.Sleep(1000);
                        break;

                    case "4":
                        Console.Clear();
                        Console.Write("Identifiant administrateur: ");
                        string ident_admin = Console.ReadLine();
                        Console.Write("Mot de passe admin: ");
                        string mdp_admin = Console.ReadLine();
                        this.utilisateur = a.checkAdmin(ident_admin, mdp_admin);
                        if (this.utilisateur != null)
                        {
                            Console.WriteLine("\nConnexion en mode admin réussi !");
                            connected = false;
                        }
                        else Console.WriteLine("identifiant ou mot de pass incorrect !");

                        System.Threading.Thread.Sleep(1000);
                        break;

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
                Console.WriteLine("\t Gérer les trajets (3)");
                Console.WriteLine("\t Exit application (e)\n");
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
                        this.gerer_trajet();
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
                Console.WriteLine("\t Mes trajets (2)");
                Console.WriteLine("\t voir vehicule dispo (3)");
                Console.WriteLine("\t Exit application (e)\n");
                Console.Write("Votre choix: ");

                string menu = Console.ReadLine();

                switch (menu)
                {
                    case "1":
                        this.louer_vehicule();
                        break;

                    case "2":
                        this.gerer_client();
                        break;

                    case "3":
                        this.affichage_list("Visualiser tous les vehicules dispo", a.List_vehicule.FindAll(v => v.dispo == Vehicule.Dispo.disponible));
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
                        a.List_client.ForEach(c => Console.WriteLine("Client: " + c.nom + " " + c.prenom + " => " + c.nbr_km_parcouru + " Km parcourus"));
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
                            return a.nom.CompareTo(b.nom);
                        });
                        this.affichage_list("Listes des clients selon leurs noms (ASC)", a.List_client);
                        Console.ReadLine();
                        break;

                    case "24":
                        a.List_client.Sort(delegate (Client a, Client b)
                        {
                            return -1 * a.nom.CompareTo(b.nom);
                        });
                        this.affichage_list("Listes des clients selon leurs noms (DESC)", a.List_client);
                        Console.ReadLine();
                        break;

                    case "25":
                        Console.Write("\nNom ou prenom client recherché: ");
                        String nom = Console.ReadLine();
                        this.affichage_list("Liste de client trouvé :", a.List_client.FindAll(v => v.nom.ToLower() == nom.ToLower() || v.prenom.ToLower() == nom.ToLower()));
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
                Console.WriteLine("\t Visualiser tous les vehicules (3)");
                Console.WriteLine("\t\t - Rechercher vehicules par marque (31)");
                Console.WriteLine("\t\t - Afficher nombre de kilomètre parcouru par véhicule (32)");
                Console.WriteLine("\t\t - Afficher vehicule trié par leurs nombres de km parcouru (33)");
                Console.WriteLine("\t\t - Afficher vehicule trié par leurs conso au 100 km (34)");
                Console.WriteLine("\t\t - Afficher vehicule par marque (35)");
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
                        this.affichage_list("Visualiser tous les vehicules", a.List_vehicule);
                        Console.ReadLine();
                        break;

                    case "31":
                        Console.Write("\nmarque recherchée: ");
                        String marque = Console.ReadLine();
                        this.affichage_list("Liste de vehicule de la marque " + marque + ":", a.List_vehicule.FindAll(v => v.marque.ToLower() == marque.ToLower()));
                        Console.ReadLine();
                        break;

                    case "32":
                        a.List_vehicule.ForEach(v => Console.WriteLine("Immatriculation: " + v.immatriculation + " - marque: " + v.marque + " => " + v.nbr_km_parcouru + " Km parcourus"));
                        Console.ReadLine();
                        break;

                    case "33":
                        a.List_vehicule.Sort(delegate (Vehicule a, Vehicule b)
                        {
                            return -1 * a.nbr_km_parcouru.CompareTo(b.nbr_km_parcouru);
                        });
                        this.affichage_list("Voiture classé par nombre de km parcourus: ", a.List_vehicule);
                        Console.ReadLine();
                        break;

                    case "34":
                        a.List_vehicule.Sort(delegate (Vehicule a, Vehicule b)
                        {
                            return -1 * a.conso_km.CompareTo(b.conso_km);
                        });
                        this.affichage_list("Voiture classé par consommation au 100 km: ", a.List_vehicule);
                        Console.ReadLine();
                        break;

                    case "35":
                        a.List_vehicule.Sort(delegate (Vehicule a, Vehicule b)
                        {
                            return a.marque.CompareTo(b.marque);
                        });
                        this.affichage_list("Voiture classé par marque: ", a.List_vehicule);
                        Console.ReadLine();
                        break;

                    default:
                        play = false;
                        break;
                }
            }
        }

        public void gerer_trajet()
        {
            bool play = true;

            while (play)
            {
                Console.Clear();
                Console.WriteLine("MENU PRINCIPAL > MENU TRAJET \n");
                //Console.WriteLine("\t Ajouter trajet (1)");
                Console.WriteLine("\t Supprimer trajet (2)");
                Console.WriteLine("\t Visualiser tous les trajets (3)");
                Console.WriteLine("\t\t - Affiché tous les trajets triés selon leur ville depart (31)");
                Console.WriteLine("\t\t - Affiché tous les trajets triés selon leur ville arrive (32)");
                Console.WriteLine("\t\t - Rechercher une ville de départ (33)");
                Console.WriteLine("\t\t - Rechercher une ville d'arrivée (34)");
                Console.WriteLine("\t Retourner au menu principal (e)\n");
                Console.Write("Votre choix: ");

                string menu = Console.ReadLine();

                switch (menu)
                {
                    //case "1":
                    //    this.ajouter_trajet();
                    //    break;

                    case "2":
                        this.supprimer_trajet();
                        break;

                    case "3":
                        this.affichage_list("Visualiser tous les trajets", a.List_trajet);
                        Console.ReadLine();
                        break;

                    case "31":
                        a.List_trajet.Sort(delegate (Trajet a, Trajet b)
                        {
                            return a.Depart.CompareTo(b.Depart);
                        });
                        this.affichage_list("Affiché tous les trajets triés selon leur ville depart", a.List_trajet);
                        Console.ReadLine();
                        break;

                    case "32":
                        a.List_trajet.Sort(delegate (Trajet a, Trajet b)
                        {
                            return a.Arrivee.CompareTo(b.Arrivee);
                        });
                        this.affichage_list("Affiché tous les trajets triés selon leur ville d'arrivé", a.List_trajet);
                        Console.ReadLine();
                        break;

                    case "33":
                        Console.Write("\nVille de départ recherchée: ");
                        String ville_dep = Console.ReadLine();
                        this.affichage_list("", a.List_trajet.FindAll(t => t.Depart.ToLower() == ville_dep.ToLower()));
                        Console.ReadLine();
                        break;

                    case "34":
                        Console.Write("\nVille d'arrivée recherchée: ");
                        String ville_arr = Console.ReadLine();
                        this.affichage_list("", a.List_trajet.FindAll(t => t.Arrivee.ToLower() == ville_arr.ToLower()));
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

            Console.Write("adresse email: ");
            String email = Console.ReadLine();

            Console.Write("Identifiant: ");
            String identifiant = Console.ReadLine();

            Console.Write("Mot de passe: ");
            String mdp = Console.ReadLine();

            a.ajouter_client(nom, prenom, email, identifiant, mdp);
            this.utilisateur = a.checkClient(identifiant, mdp);
            Console.WriteLine("Client créé avec succés!");
            System.Threading.Thread.Sleep(1000);
        }

        // fonctions d'ajout
        public void ajouter_client()
        {
            //Console.Clear();
            //Console.WriteLine("MENU PRINCIPAL > MENU CLIENT > Formulaire d'ajout client \n");
            //Console.Write("Nom client: ");
            //String nom = Console.ReadLine();

            //Console.Write("Prénom client: ");
            //String prenom = Console.ReadLine();

            //a.ajouter_client(nom, prenom);
            //Console.WriteLine("Client créé avec succés!");
            //System.Threading.Thread.Sleep(1000);
        }
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

            Console.Write("prix de la voiture à l'achat: ");
            int prix_achat = int.Parse(Console.ReadLine());

            Console.Write("Consommation L/100km : ");
            float conso = float.Parse(Console.ReadLine());

            int volume = 0;
            if (typeVehicule == "3")
            {
                Console.Write("Le volume de chargement de votre camion: ");
                volume = int.Parse(Console.ReadLine());
            }
            
            this.affichage_list("", a.List_parkings);
            Console.Write("Renseignez le code du parking du vehicule : ");
            int codeP = int.Parse(Console.ReadLine());
            if (a.List_parkings.Find(p => p.CodeP == codeP).estComplet())
            {
                Console.WriteLine("Ce parking est complet");
                System.Threading.Thread.Sleep(1000);
                return;
            }
                

            Vehicule v = null;

            switch (Vehicule.getTVehicule(typeVehicule))
            {
                case Vehicule.TVehicule.voiture:
                    v = new Voiture(immat, marque, prix_achat, conso, Vehicule.Tcarburant.sansPlomb95);
                    break;

                case Vehicule.TVehicule.moto:
                    v = new Moto(immat, marque, prix_achat, conso, Vehicule.Tcarburant.sansPlomb95);
                    break;

                case Vehicule.TVehicule.camion:
                    v = new Camion(immat, marque, prix_achat, conso, volume, Vehicule.Tcarburant.sansPlomb95);
                    break;

                default:
                    v = new Voiture(immat, marque, prix_achat, conso, Vehicule.Tcarburant.sansPlomb95);
                    break;
            }

            a.ajouter_vehicule(v, codeP);
            Console.WriteLine("vehicule créé avec succés!");
            System.Threading.Thread.Sleep(1000);
        }
        public void ajouter_trajet()
        {
            Console.Clear();
            Console.WriteLine("Formulaire d'ajout trajet");
            this.affichage_list("", a.List_vehicule);

            Console.Write("\nChoisissez votre type de vehicule: voiture(1), moto (2), camion(3)");
            string type = Console.ReadLine();

            Console.Write("Indiquer la ville de départ du trajet: ");
            string ville_dep = Console.ReadLine();

            Console.Write("Indiquer la ville d'arrivée du trajet: ");
            string ville_arr = Console.ReadLine();

            Console.Write("Indiquer le nombre de km du trajet: ");
            int km_trajet = int.Parse(Console.ReadLine());

            Console.Write("Indiquer le prix du carburant pour 1L: ");
            float carburantPrix = float.Parse(Console.ReadLine());

            a.ajouter_trajet(Vehicule.getTVehicule(type), this.utilisateur.Identifiant, ville_dep, ville_arr, km_trajet);
            Console.WriteLine("trajet créé avec succés!");
            System.Threading.Thread.Sleep(1000);
        }

        public void louer_vehicule()
        {
            if (!a.List_vehicule.Exists(v => v.dispo == Vehicule.Dispo.disponible))
            {
                Console.WriteLine("Il n'y a pas de véhicule à louer ! Demander aux admninistrateurs d'en rajouter");
                Console.ReadLine();
                return;
            }
            Console.Clear();
            Console.WriteLine("Formulaire de location véhicule");
            Console.Write("\nChoisissez votre type de vehicule: voiture(1), moto (2), camion(3): ");
            string type = Console.ReadLine();

            Console.Write("Indiquer la ville de départ du trajet: ");
            string ville_dep = Console.ReadLine();

            Console.Write("Indiquer la ville d'arrivée du trajet: ");
            string ville_arr = Console.ReadLine();

            Console.Write("Indiquer le nombre de km du trajet: ");
            int km_trajet = int.Parse(Console.ReadLine());

            a.ajouter_trajet(Vehicule.getTVehicule(type), this.utilisateur.Identifiant, ville_dep, ville_arr, km_trajet);
            Console.WriteLine("trajet créé avec succés!");
            System.Threading.Thread.Sleep(1000);
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
                Console.Write("Indiquer le code client du client à supprimer: ");
                string code = Console.ReadLine();
                Client c = a.List_client.Find(client => client.Identifiant == code);
                if (c == null)
                    Console.WriteLine("Le code client que vous avait tapé n'existe pas");
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

            if (a.List_vehicule.Count == 0)
            {
                Console.WriteLine("Il n'y a aucun vehicule à supprimer");
                Console.Write("\n(tapez sur entrée pour revenir au menu précédent)");
                Console.ReadLine();
            }
            else
            {
                this.affichage_list("", a.List_vehicule);
                Console.Write("Indiquer l'immatriculation du vehicule à supprimer: ");
                string immat = Console.ReadLine();
                Vehicule v = a.List_vehicule.Find(vehicule => vehicule.immatriculation == immat);
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
        public void supprimer_trajet()
        {
            Console.Clear();
            Console.WriteLine("MENU PRINCIPAL > MENU TRAJET > Formulaire suppression trajet \n");
            if (a.List_trajet.Count == 0)
            {
                Console.WriteLine("Il n'y a aucun trajet à supprimer");
                Console.Write("\n(tapez sur entrée pour revenir au menu précédent)");
                Console.ReadLine();
            }
            else
            {
                this.affichage_list("", a.List_trajet);
                Console.Write("Indiquer le code trajet du trajet à supprimer: ");
                string codeT = Console.ReadLine();
                Trajet t = a.List_trajet.Find(trajet => trajet.CodeT == int.Parse(codeT));
                if (t == null)
                    Console.WriteLine("Le code du trajet que vous avait tapé n'existe pas");
                else
                {
                    a.supprimer_trajet(t);
                    Console.WriteLine("Trajet supprimé avec succés");
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }

        public void affichage_list<T>(string titre, List<T> list)
        {
            Console.WriteLine("\n" + titre);
            list.ForEach(obj => Console.WriteLine(((T)obj).ToString()));
            if (list.Count == 0)
                Console.WriteLine("Aucune donnée !");
        }

    }
}
