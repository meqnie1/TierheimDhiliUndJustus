namespace TierheimDhiliUndJustus.Pages
{
    using Microsoft.AspNetCore.Components;
    using TierheimDhiliUndJustus.BLL;
    using TierheimDhiliUndJustus.DAL;
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
        bool gespendet = false;
        bool betragIsNull = false;

        void ChangeCurrentSelectedZahlungsart(object checkedValue)
        {
            currentzahlungsart = Convert.ToInt32(checkedValue);
        }
        void ChangeCurrentBetrag(object value)
        {
            if(value != "")
            {
                string betrag = ((string)value).Replace(".", ",");
                currentbetrag = Math.Round(Convert.ToDouble(betrag), 2);
            }
            else
            {
                currentbetrag = 0;
            }
        }

        void ClickOnButtonSpenden()
        {
            if(currentbetrag <= 0)
            {
                betragIsNull = true;
            }
            else
            {
                Spende_DA.BookASpende(currentbetrag, currentzahlungsart);
                gespendet = true;
                betragIsNull = false;
            }
        }
    }
}
