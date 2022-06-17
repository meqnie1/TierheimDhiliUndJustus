    namespace TierheimDhiliUndJustus.Pages
{
    using Microsoft.AspNetCore.Components;
    using TierheimDhiliUndJustus.BLL;
    using TierheimDhiliUndJustus.DAL;

    public partial class TierDetail : ComponentBase
    {
        int counter = 0;
        bool enableTierLöschen = false;
        string srcgeschlecht;

        BLL_WichtigeMethoden WichtigeMethoden_BLL = new BLL_WichtigeMethoden();
        PL_WichtigeMethoden WichtigeMethoden_PL = new PL_WichtigeMethoden();
    }
}
