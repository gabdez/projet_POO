namespace projet_POO
{
    public class Admin : Utilisateur
    {
        public Admin():base("admin", "admin", "logicieldelocation@gmail.com", "admin", "admin"){}
        public override string getType()
        {
            return "admin";
        }
    }
}
