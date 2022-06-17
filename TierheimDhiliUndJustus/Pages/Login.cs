namespace TierheimDhiliUndJustus.Pages
{
    using Microsoft.AspNetCore.Components;
    using TierheimDhiliUndJustus.BLL;
    using TierheimDhiliUndJustus.DAL;


    public partial class Login
    {

        public static bool Angemeldet { get; set; } = false;

        string pwvalue;
        string evalue;
        public static string anmelden_augenart = "/img/closedeye.png";
        public static string anmelden_inputtype = "password";
        string fehlermeldung = "";
        public static bool screenclosed = true;
        Kunde eingeloggterKunde;
        WichtigeMethoden WichtigeMethoden = new WichtigeMethoden();

        public static List<Kunde> lstkunde = Kunde_DA.GetKunden();

        private async Task Anmelden()
        {
            //Es werden auf alle Anforderungen bezüglich Email (ob Email bereits vorhanden) und Passwort geprüft  
            foreach (Kunde kunde in lstkunde)
            {
                if (kunde.Email == evalue && kunde.Passwort == pwvalue)
                {
                    Angemeldet = true;
                    eingeloggterKunde = kunde;
                    fehlermeldung = "";
                    LoginConfig.Angemeldet = eingeloggterKunde.ID_Kunde;

                    navManager.NavigateTo("/", true);

                    break;
                }
                if (kunde.Email != evalue || kunde.Passwort != pwvalue)
                {
                    fehlermeldung = "Fehleingabe, versuchen Sie es nocheinmal";

                }
            }

        }
    }
}
