namespace TierheimDhiliUndJustus.Pages
{
    using Microsoft.AspNetCore.Components;
    using TierheimDhiliUndJustus.BLL;
    using TierheimDhiliUndJustus.DAL;


    public partial class Fundtiere : ComponentBase
    {
        public static int counter_formatting = 0;
        public static int counter_tierrassen = 0;

        public string geschlechtsource = "";

        public List<int> lstcheckbox_tierart = new List<int>();
        public List<int> lstcheckbox_tierrassen = new List<int>();
        public List<Tierart> lst_tierarten = Tierart_DA.GetTierarten();
        public static List<Tier> lst_filtertiere = new List<Tier>();

        BLL_WichtigeMethoden WichtigeMethoden_BLL = new BLL_WichtigeMethoden();
        PL_WichtigeMethoden WichtigeMethoden_PL = new PL_WichtigeMethoden();
    }
}
