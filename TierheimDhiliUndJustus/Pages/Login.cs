namespace TierheimDhiliUndJustus.Pages
{
    using Microsoft.AspNetCore.Components;
    using TierheimDhiliUndJustus.Authentication;
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

            var customAuthStateProvider = (CustomAuthenticationStateProvider)authStateProvider;


            foreach (Kunde kunde in lstkunde)
            {
                if (kunde.Email == evalue && kunde.Passwort == pwvalue)
                {
                    Angemeldet = true;
                    eingeloggterKunde = kunde;
                    fehlermeldung = "";
                    await customAuthStateProvider.UpdateAuthenticationState(new UserSession
                    {
                        Email = eingeloggterKunde.Email,
                        Rolle = eingeloggterKunde.Rolle
                    });
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
