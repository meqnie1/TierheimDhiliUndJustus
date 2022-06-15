    namespace TierheimDhiliUndJustus.Pages
{
    using Microsoft.AspNetCore.Components;
    using TierheimDhiliUndJustus.BLL;
    using TierheimDhiliUndJustus.DAL;
    using System.Drawing;
    using System.Data.SqlClient;
    using System.IO;
    using TierheimDhiliUndJustus.Pages;

    public partial class TierDetail : ComponentBase
    {
        int counter = 0;
        bool enableAccountLöschen = false;
        string srcgeschlecht;
        static WichtigeMethoden WichtigeMethoden = new WichtigeMethoden();
    }
}
