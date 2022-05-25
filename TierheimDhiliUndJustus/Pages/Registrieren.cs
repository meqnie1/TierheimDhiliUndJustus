namespace TierheimDhiliUndJustus.Pages
{
    using TierheimDhiliUndJustus.Authentication;
    using TierheimDhiliUndJustus.BLL;
    using TierheimDhiliUndJustus.DAL;
    
   
    public partial class Registrieren 
    {
        string pwvalue;
        string evalue;
        string augenart="/img/closedeye.png";
        string inputtype="password";
        string fehlermeldung = "";
        public static bool screenclosed = true;
        bool eingeloggt;
        Kunde eingeloggterKunde;
        
        public static List<Kunde> lstkunde = Kunde_DA.GetKunde();

        public async Task Kundeerstellen()
        {
            var customAuthStateProvider = (CustomAuthenticationStateProvider)authStateProvider;
            fehlermeldung = "";
            foreach (Kunde kunde in lstkunde)
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
            if (fehlermeldung == "")
            {
                Kunde neuerKunde = new Kunde(8, evalue, pwvalue, "Kunde");
                Kunde_DA.InsertKunde(neuerKunde);

                await customAuthStateProvider.UpdateAuthenticationState(new UserSession
                {
                    Email = neuerKunde.Email,
                    Rolle = neuerKunde.Rolle
                });
                LoginConfig.Angemeldet = neuerKunde.ID_Kunde;


                navManager.NavigateTo("/", true);
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
