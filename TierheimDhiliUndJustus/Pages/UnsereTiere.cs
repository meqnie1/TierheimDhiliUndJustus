namespace TierheimDhiliUndJustus.Pages
{
    using Microsoft.AspNetCore.Components;
    using TierheimDhiliUndJustus.BLL;
    using TierheimDhiliUndJustus.DAL;
    using MySqlConnector;
    using System.Drawing;
    using System.Data.SqlClient;
    using System.IO;
    using TierheimDhiliUndJustus.Pages;


    public partial class UnsereTiere : ComponentBase
    {
        //Für die Darstellung (das nur 2 bzw. 3 Elemente in einer Zeile dargestellt werden)
        public int counterForFormatting = 0;
        //Zählt die Tierrassen mit für den Filter
        public int counterTierrassen = 0;
        public string geschlechtsource = "";
        //Die Listen enthalten die ID's der jeweiligen Tierarten/Tierrassen, welche angezeigt werden sollen --> also die gerade gecheckt sind
        public List<int> lstcheckbox_tierart = new List<int>();
        public List<int> lstcheckbox_tierrassen = new List<int>();
        public List<Tierart> lst_tierarten = Tierart_DA.GetTierarten();

        public Startseite Startseite = new Startseite();
        public WichtigeMethoden WichtigeMethoden = new WichtigeMethoden();
    }
}
