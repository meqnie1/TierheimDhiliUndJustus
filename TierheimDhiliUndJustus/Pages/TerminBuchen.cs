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
        Termin selectedTermin = Termin_DA.GetTermin(currentdateid);

        BLL_WichtigeMethoden WichtigeMethoden_BLL = new BLL_WichtigeMethoden();
        PL_WichtigeMethoden WichtigeMethoden_PL = new PL_WichtigeMethoden();

        void ChangeCurrentSelectedDate(object checkedValue)
        {
            currentdateid = Convert.ToInt32(checkedValue);
        }
    }
}
