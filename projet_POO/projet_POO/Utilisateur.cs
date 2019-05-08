using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projet_POO
{
    public abstract class Utilisateur : IDataRW
    {
        protected string identifiant;
        private string mdp;
        protected string email;
        protected string nom;
        protected string prenom;

        public Utilisateur() { }
        public Utilisateur(string mdp, string ident, string email, string nom, string prenom)
        {
            this.mdp = encrypt(mdp);
            this.identifiant = ident;
            this.email = email;
            this.nom = nom;
            this.prenom = prenom;
        }

        public bool checkConnexion(string identifiant, string mdp)
        {
            return this.identifiant == identifiant && decrypt(this.mdp) == mdp;
        }
        public abstract string getType();

        public String Identifiant
        {
            get
            {
                return this.identifiant;
            }
            set
            {
                this.identifiant = value;
            }
        }

        public String Mdp
        {
            get
            {
                return decrypt(this.mdp);
            }
            set
            {
                this.mdp = encrypt(value);
            }
        }
        public String Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }
        public String Nom
        {
            get
            {
                return this.nom;
            }
            set
            {
                this.nom = value;
            }
        }
        public String Prenom
        {
            get
            {
                return this.prenom;
            }
            set
            {
                this.prenom = value;
            }
        }

        private string encrypt(string str)
        {
            string _result = string.Empty;
            char[] temp = str.ToCharArray();
            foreach (var _singleChar in temp)
            {
                var i = (int)_singleChar;
                i = i - 2;
                _result += (char)i;
            }
            return _result;
        }
        private string decrypt(string str)
        {
            string _result = string.Empty;
            char[] temp = str.ToCharArray();
            foreach (var _singleChar in temp)
            {
                var i = (int)_singleChar;
                i = i + 2;
                _result += (char)i;
            }
            return _result;
        }

        public virtual string getData()
        {
            string sep = "--;--";
            string nom = this.nom + sep;
            string prenom = this.prenom + sep;
            string mdp = this.mdp + sep;
            string identifiant = this.identifiant + sep;
            string email = this.email + sep;
            return nom + prenom + mdp + identifiant + email;
        }

        public virtual void loadData(string s)
        {
            string[] tokens = s.Split(new string[] { "--;--" }, StringSplitOptions.None);
            this.nom = tokens[0];
            this.prenom = tokens[1];
            this.mdp = tokens[2];
            this.identifiant = tokens[3];
            this.email = tokens[4];
        }
    }
}
