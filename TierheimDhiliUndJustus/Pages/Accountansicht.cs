
using TierheimDhiliUndJustus.DAL;
using TierheimDhiliUndJustus.BLL;
using TierheimDhiliUndJustus.Pages;
using TierheimDhiliUndJustus.Shared;

namespace TierheimDhiliUndJustus.Pages
{
    public partial class Accountansicht
    {
        
        int counter = 0;
        string pwvalue = Kunde_DA.GetoneKunde(LoginConfig.Angemeldet).Passwort;
        string evalue = Kunde_DA.GetoneKunde(LoginConfig.Angemeldet).Email;
        string pwinput = "";
        string fehlermeldung = "";
        string augenart = "/img/closedeye.png";
        string inputtype = "password";
        static bool enabled = false;
        static bool accountloeschen = false;
        //static Kunde eingeloggterkunde;
        List<Kunde> lstkunde = Kunde_DA.GetKunde();
        List<Termin> lstkundentermine = Termin_DA.GetTermineWithKunde(LoginConfig.Angemeldet);
        


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
                Kunde_DA.UpdateKunde(Kunde_DA.GetoneKunde(LoginConfig.Angemeldet).ID_Kunde, evalue, pwvalue);
                enabled = false;
                Kunde_DA.GetoneKunde(LoginConfig.Angemeldet).Email = evalue;
                Kunde_DA.GetoneKunde(LoginConfig.Angemeldet).Passwort = pwvalue;
                counter = 0;
                
            }
                     
        }

        public void Terminentfernen(int terminid)
        {
            Termin_DA.RemoveKundefromspecificTermin(terminid);                   
        }

        public void Accountenfernen()
        {
            Termin_DA.RemoveKundefromTermin(Kunde_DA.GetoneKunde(LoginConfig.Angemeldet).ID_Kunde);
            Kunde_DA.DeleteKunde(Kunde_DA.GetoneKunde(LoginConfig.Angemeldet).ID_Kunde);
        }

        public void Abmelden()
        {

            NavMenu.Abmelden();
            UriHelper.NavigateTo("/", true);
           
        }

        public void Accountloeschen()
        {
            Abmelden();
            accountloeschen = true;
            Termin_DA.RemoveKundefromTermin(Kunde_DA.GetoneKunde(LoginConfig.Angemeldet).ID_Kunde);
            Kunde_DA.DeleteKunde(Kunde_DA.GetoneKunde(LoginConfig.Angemeldet).ID_Kunde);
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



    }
}
