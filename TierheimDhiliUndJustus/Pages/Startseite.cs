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

        
        //protected override async Task OnInitializedAsync()
        //{
        
        //}

        public string GetGeschlecht(int tierid)
        {
            Tier tier = Tier_DA.GetOneTier(tierid);
           
            if (tier.Geschlecht == "w")
            {
                geschlechtsource= "img/weiblich.png";
            }
            else
            {
                geschlechtsource = "img/männlich.png";
            }             
            
            return geschlechtsource;
        }

        public void ClickOnTier(string tierid)
        {
            UriHelper.NavigateTo($"/unseretiere/tierdetail/{tierid}");
        }


    }
}
