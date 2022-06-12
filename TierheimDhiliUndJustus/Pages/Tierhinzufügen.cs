using Microsoft.AspNetCore.Components.Forms;
using TierheimDhiliUndJustus.BLL;
using TierheimDhiliUndJustus.DAL;

namespace TierheimDhiliUndJustus.Pages
{
    public partial class Tierhinzufügen
    {
        public string tierpicture = "";
        public string tiername = "";
        public DateTime geburtsdatum = DateTime.Today;
        public string tierartText = "";
        public string tierrasseText = "";
        public bool fundtier = false;
        public bool tierhinzugefügt = false;
        string hinzugefügtestier = "";
        public string beschreibung = "";
        string fehlermeldung;

        

        List<Tierart> lst_tierarten = Tierart_DA.GetTierarten();
        List<Tierrasse> lst_tierrassen = Tierrasse_DA.GetTierrassen();

        int currentTierrasse = 0;
        int currentTierart = 0;
        string currentgeschlecht = "männlich";

        void ChangeCurrentSelectedTierartAndTierrasse(object checkedValue, bool tierart)
        {
            //bei true (Tierart) bei false (Tierrasse)
            if (tierart)
            {
                currentTierart = Convert.ToInt32(checkedValue);
                lst_tierrassen.Clear();
                lst_tierrassen = Tierrasse_DA.GetTierrasseWithTierartID(currentTierart);
            }
            else
            {
                currentTierrasse = Convert.ToInt32(checkedValue);
            }
        }

        void ChangeCurrentSelectedGeschlecht(object checkedValue)
        {
            currentgeschlecht = Convert.ToString(checkedValue);
            if (currentgeschlecht == "weiblich")
            {
                currentgeschlecht = "w";
            }
            else
            {
                currentgeschlecht = "m";
            }
        }

        protected async Task Uploadtierpicture(InputFileChangeEventArgs e)
        {
               
            var path = Path.Combine("wwwroot/img/tiere/", e.File.Name);

            long _maxFileSize = 20000000;
                  
            await using (FileStream fs = new(path, FileMode.Create))
            {
                await e.File.OpenReadStream(_maxFileSize).CopyToAsync(fs);

            }

            tierpicture = "img/tiere/" + e.File.Name;
            
        }

        public void CreateTier()
        {
            if (tiername == "" || beschreibung == "" || tierpicture == "")
            {
                fehlermeldung = "Bitte füllen Sie alle Felder aus!";
            }
            else
            {
                if (currentgeschlecht == "weiblich")
                {
                    currentgeschlecht = "w";
                }
                else
                {
                    currentgeschlecht = "m";
                }
                tierhinzugefügt = true;
                Tier tier = new Tier(tiername, geburtsdatum, currentgeschlecht, beschreibung, Convert.ToSByte(fundtier), currentTierrasse);

                Tier_DA.CreateTier(tier);
                File.Move("wwwroot/img/tiere/" + tierpicture.Substring(10), "wwwroot/img/tiere/" + tier.Tiername + ".jpg");
            }
            

        }

        public void AddTierrassenandTierarten()
        {

        }
    }
}
