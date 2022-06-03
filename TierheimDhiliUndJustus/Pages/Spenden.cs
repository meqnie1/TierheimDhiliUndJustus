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


    public partial class Spenden : ComponentBase
    {
        WichtigeMethoden WichtigeMethoden = new WichtigeMethoden();

        public List<Zahlungsart> lst_zahlungsarten = Zahlungsart_DA.GetZahlungsarten();
        int currentzahlungsart = 0;
        double currentbetrag = 0;

        void ChangeCurrentSelectedZahlungsart(object checkedValue)
        {
            currentzahlungsart = Convert.ToInt32(checkedValue);
        }
        void ChangeCurrentBetrag(object betrag)
        {
            currentbetrag = Math.Round(Convert.ToDouble(betrag), 2);
        }

        void ClickOnButtonSpenden()
        {
            Spende_DA.BookASpende(currentbetrag, LoginConfig.Angemeldet, currentzahlungsart);
        }
    }
}
