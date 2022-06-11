using Microsoft.AspNetCore.Components.Forms;
using TierheimDhiliUndJustus.BLL;
using TierheimDhiliUndJustus.DAL;

namespace TierheimDhiliUndJustus.Pages
{
    public partial class Tierhinzufügen
    {
        public string tierpicture = "img/insertpicture.png";
        public string tiername = "";
        public DateTime geburtsdatum = DateTime.Today;
        public string tierartText = "";
        public string tierrasseText = "";
        public bool fundtier = false;
        public string beschreibung = "";
        static string path = "img/tiere";

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
        }

        protected async Task Uploadtierpicture(InputFileChangeEventArgs e)
        {

            long _maxFileSize = 20000000;
      
            string path = "img/tiere/";

            await using (FileStream fs = new(path, FileMode.Create))
            {
                await e.File.OpenReadStream(_maxFileSize).CopyToAsync(fs);

            }


        }
    }
}
