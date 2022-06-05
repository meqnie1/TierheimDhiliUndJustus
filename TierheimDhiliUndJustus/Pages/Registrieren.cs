namespace TierheimDhiliUndJustus.Pages
{
    using TierheimDhiliUndJustus.BLL;
    using TierheimDhiliUndJustus.DAL;
    
   
    public partial class Registrieren 
    {
        string pwvalue;
        string evalue;
        public static string registrieren_augenart = "/img/closedeye.png";
        public static string registrieren_inputtype = "password";
        string fehlermeldung = "";
        public static bool screenclosed = true;
        bool eingeloggt;
        Kunde eingeloggterKunde;
        WichtigeMethoden WichtigeMethoden = new WichtigeMethoden();

        public static List<Kunde> lstkunde = Kunde_DA.GetKunde();

        public async Task Kundeerstellen()
        {
            fehlermeldung = "";
            foreach (Kunde kunde in lstkunde)
            {
                if (kunde.Email != evalue)
                {
                    if (pwvalue != null && evalue != null)
                    {
                        if (kunde.Email == evalue)
                        {
                            fehlermeldung = "Email bereits vorhanden!";
                            break;
                        }
                        if (evalue.Contains("@") == false || evalue.Contains(".") == false)
                        {
                            fehlermeldung = "Bitte geben Sie eine gültige Email ein";
                            break;
                        }
                        if (pwvalue.Length > 45 || pwvalue.Length < 5)
                        {
                            fehlermeldung = "Passwort zu lang oder zu kurz";
                            break;
                        }
                    }
                    else
                    {
                        fehlermeldung = "Bitte füllen Sie alle Felder aus";
                    }
                }
                                    
            }
            if (fehlermeldung == "")
            {
                Kunde neuerKunde = new Kunde(8, evalue, pwvalue, "Kunde");
                Kunde_DA.InsertKunde(neuerKunde);
                LoginConfig.Angemeldet = neuerKunde.ID_Kunde;
                navManager.NavigateTo("/", true);
            }
            

        }
    }
}
