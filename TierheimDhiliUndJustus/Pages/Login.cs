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
        string augenart = "/img/closedeye.png";
        string inputtype = "password";
        string fehlermeldung = "";
        public static bool screenclosed = true;
        Kunde eingeloggterKunde;

        public static List<Kunde> lstkunde = Kunde_DA.GetKunde();

        private async Task Einloggen()
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

                    navManager.NavigateTo("/");

                    break;
                }
                if (kunde.Email != evalue || kunde.Passwort != pwvalue)
                {
                    fehlermeldung = "Fehleingabe, versuchen Sie es nocheinmal";

                }
            }

        }

        //Je nach Status wird der Inputtype geändert um das Passwort anzuzeigen
        public void ShowPasswort()
        {
            if (inputtype == "password")
            {
                inputtype = "text";
                augenart = "/img/openedeye.png";

            }
            else
            {
                inputtype = "password";
                augenart = "/img/closedeye.png";
            }

        }
    }
}
