namespace TierheimDhiliUndJustus.Pages
{
    using Microsoft.AspNetCore.Components;
    using TierheimDhiliUndJustus.BLL;
    using TierheimDhiliUndJustus.DAL;


    public partial class Spenden : ComponentBase
    {
        BLL_WichtigeMethoden WichtigeMethoden_BLL = new BLL_WichtigeMethoden();
        PL_WichtigeMethoden WichtigeMethoden_PL = new PL_WichtigeMethoden();

        public List<Zahlungsart> lst_zahlungsarten = Zahlungsart_DA.GetAllZahlungsarten();
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
