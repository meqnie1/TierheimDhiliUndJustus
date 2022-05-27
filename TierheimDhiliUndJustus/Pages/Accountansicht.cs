
using TierheimDhiliUndJustus.DAL;
using TierheimDhiliUndJustus.BLL;
using TierheimDhiliUndJustus.Pages;



namespace TierheimDhiliUndJustus.Pages
{
    public partial class Accountansicht
    {
        
        int counter = 0;
        string pwvalue = Kunde_DA.GetoneKunde(LoginConfig.Angemeldet).Passwort;
        string evalue = Kunde_DA.GetoneKunde(LoginConfig.Angemeldet).Email;
        string fehlermeldung = "";
        public static string account_augenart = "/img/closedeye.png";
        public static string account_inputtype = "password";
        bool enabled = false;
        //static Kunde eingeloggterkunde;
        List<Kunde> lstkunde = Kunde_DA.GetKunde();
        List<Termin> lstkundentermine = Termin_DA.GetTermineWithKunde(LoginConfig.Angemeldet);
        WichtigeMethoden WichtigeMethoden = new WichtigeMethoden();
        

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
            Termin_DA.RemoveKundefromTermin(terminid);                   
        }
    }
}
