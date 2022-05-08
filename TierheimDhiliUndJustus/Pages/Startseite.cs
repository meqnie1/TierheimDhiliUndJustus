namespace TierheimDhiliUndJustus.Pages
{
    using TierheimDhiliUndJustus.BLL;
    using TierheimDhiliUndJustus.DAL;
    public partial class Startseite
    {
        public int counter = 0;

        public List<Tier> Kacke = Tier_DA.GetTier();
        protected override async Task OnInitializedAsync()
        {
        
        }

        

    }
}
