
using TierheimDhiliUndJustus.DAL;
using TierheimDhiliUndJustus.BLL;
using TierheimDhiliUndJustus.Shared;

namespace TierheimDhiliUndJustus.Pages
{
    public partial class Accountansicht
    {
        
        int counter_termine = 0;
        int counter_spenden = 0;
        string pwvalue = Kunde_DA.GetOneKunde(LoginConfig.Angemeldet).Passwort;
        string evalue = Kunde_DA.GetOneKunde(LoginConfig.Angemeldet).Email;

        string pwinput = "";
        string fehlermeldung = "";
        public static string löschenfehlermeldung = "";
        bool enabled = false;
        public static bool accountloeschen = false;

        public static string account_augenart = "/img/closedeye.png";
        public static string account_inputtype = "password";
        public static string accountloeschen_augenart = "/img/closedeye.png";
        public static string accountloeschen_inputtype = "password";

        public static string pfeilarttermine = "/img/dropdownzu.png";
        public static string pfeilartspende = "/img/dropdownzu.png";
        


        List<Kunde> lst_kunden = Kunde_DA.GetKunden();
        List<Termin> lst_kundentermine = Termin_DA.GetTermineWithKunde(LoginConfig.Angemeldet);

        protected override async Task OnInitializedAsync()
        {
            accountloeschen = false;
            pfeilarttermine = "/img/dropdownzu.png";
            pfeilartspende = "/img/dropdownzu.png";
        }

        public void ChangePasswortVisibilityOfAccount()
        {
            if (account_inputtype == "password")
            {
                account_inputtype = "text";
                account_augenart = "/img/openedeye.png";
            }
            else
            {
                account_inputtype = "password";
                account_augenart = "/img/closedeye.png";
            }
        }

        public void ChangePasswortVisibilityOfDelete()
        {
            if (accountloeschen_inputtype == "password")
            {
                accountloeschen_inputtype = "text";
                accountloeschen_augenart = "/img/openedeye.png";
            }
            else
            {
                accountloeschen_inputtype = "password";
                accountloeschen_augenart = "/img/closedeye.png";
            }
        }

        public void EnorDisable()
        {
            if (enabled)
            {
                enabled = false;
            }
            else
            {
                enabled = true;
            }
            
        }
        
        public void Datenaendern()
        {
            fehlermeldung = "";
            foreach (Kunde kunde in lst_kunden)
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
                Kunde_DA.UpdateKunde(LoginConfig.Angemeldet, evalue, pwvalue);
                enabled = false;         
                counter_termine = 0;
                
            }
                     
        }


        public void Terminentfernen(int terminid)
        {
            Termin_DA.RemoveKundefromSpecificTermin(terminid);                   
        }

        public void Accountentfernen()
        {
            Termin_DA.RemoveKundefromTermin(Kunde_DA.GetOneKunde(LoginConfig.Angemeldet).ID_Kunde);
            Kunde_DA.DeleteKunde(Kunde_DA.GetOneKunde(LoginConfig.Angemeldet).ID_Kunde);
        }

        public void Abmelden()
        {
            NavMenu.Abmelden();
            UriHelper.NavigateTo("/", true);
           
        }

        public void Accountloeschen()
        {
            if (pwinput == Kunde_DA.GetOneKunde(LoginConfig.Angemeldet).Passwort)
            {              
                accountloeschen = false;
                löschenfehlermeldung = "";
                Termin_DA.RemoveKundefromTermin(Kunde_DA.GetOneKunde(LoginConfig.Angemeldet).ID_Kunde);
                Kunde_DA.DeleteKunde(Kunde_DA.GetOneKunde(LoginConfig.Angemeldet).ID_Kunde);
                Abmelden();
            }
            else
            {
                löschenfehlermeldung = "Geben Sie das richtige Passwort ein";
            }
            
            
        }

        public void Accountloeschenabbrechenoderausfuehren()
        {
            if (accountloeschen == false)
            {
                accountloeschen = true;
            }
            else
            {
                accountloeschen = false;
            }

        }

        public void Changepfeiltermine()
        {
            if (pfeilarttermine == "/img/dropdownzu.png")
            {
                pfeilarttermine = "/img/dropdownoffen.png";
            }
            else
            {
                pfeilarttermine = "/img/dropdownzu.png";
            }
        }

        public void Changepfeilspende()
        {
            if (pfeilartspende == "/img/dropdownzu.png")
            {
                pfeilartspende = "/img/dropdownoffen.png";
            }
            else
            {
                pfeilartspende = "/img/dropdownzu.png";
            }
        }




    }
}
