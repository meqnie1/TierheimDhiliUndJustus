namespace TierheimDhiliUndJustus.Pages
{
    using Microsoft.AspNetCore.Components;
    using TierheimDhiliUndJustus.BLL;
    using TierheimDhiliUndJustus.DAL;


    public partial class Startseite : ComponentBase
    {
        public int counter = 0;
        public string geschlechtsource = "";
        public List<Tier> lst_tiere = Tier_DA.GetAllTiere(0);

        BLL_WichtigeMethoden WichtigeMethoden_BLL = new BLL_WichtigeMethoden();
        PL_WichtigeMethoden WichtigeMethoden_PL = new PL_WichtigeMethoden();

    }
}
