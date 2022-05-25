namespace TierheimDhiliUndJustus.Pages
{
    using Microsoft.AspNetCore.Components;
    using TierheimDhiliUndJustus.BLL;
    using TierheimDhiliUndJustus.DAL;
  
    
    public partial class Startseite : ComponentBase
    {
        public int counter = 0;
        public string geschlechtsource = "";
        

        public static List<Tier> lsttier = Tier_DA.GetTier();
        public WichtigeMethoden WichtigeMethoden = new WichtigeMethoden();


        //protected override async Task OnInitializedAsync()
        //{

        //}
    }
}
