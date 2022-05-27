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


    public partial class Startseite : ComponentBase
    {
        public int counter = 0;
        public string geschlechtsource = "";
        public List<Tier> lsttier = Tier_DA.GetTier();
        WichtigeMethoden WichtigeMethoden = new WichtigeMethoden();

    }
}
