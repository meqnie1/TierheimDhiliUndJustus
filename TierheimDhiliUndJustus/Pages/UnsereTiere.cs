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
        public static int counterForFormatting = 0;
        public static int counterTierrassen = 0;
        public string geschlechtsource = "";
        public Startseite Startseite = new Startseite();
        public List<int> lstcheckbox_tierart = new List<int>();
        public List<int> lstcheckbox_tierrassen = new List<int>();
        public List<Tierart> lst_tierarten = Tierart_DA.GetTierarten();
        public WichtigeMethoden WichtigeMethoden = new WichtigeMethoden();
    }
}
