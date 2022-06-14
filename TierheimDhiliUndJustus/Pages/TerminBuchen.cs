namespace TierheimDhiliUndJustus.Pages
{
    using Microsoft.AspNetCore.Components;
    using TierheimDhiliUndJustus.BLL;
    using TierheimDhiliUndJustus.DAL;
    using System.Drawing;
    using System.Data.SqlClient;
    using System.IO;
    using TierheimDhiliUndJustus.Pages;


    public partial class TerminBuchen : ComponentBase
    {
        static int currentdateid = 0;
        bool gebucht = false;
        string srcimg = "";
        string srcgeschlecht = "";
        Startseite startseite = new Startseite();
        Termin selectedTermin = Termin_DA.GetTermin(currentdateid);
        WichtigeMethoden WichtigeMethoden = new WichtigeMethoden();

        void ChangeCurrentSelectedDate(object checkedValue)
        {
            currentdateid = Convert.ToInt32(checkedValue);
        }
    }
}
