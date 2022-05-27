namespace TierheimDhiliUndJustus.BLL
{
    public class Kunde
    {
        public int ID_Kunde { get; set; }

        public string Email { get; set; }

        public string Passwort { get; set; }

        public string Rolle { get; set; }

        public Kunde(int id, string email, string passwort, string rolle)
        {
            ID_Kunde = id;
            Email = email;
            Passwort = passwort;
            Rolle = rolle;
        }

        public Kunde()
        {

        }
    }
}
