namespace TierheimDhiliUndJustus.BLL
{
    public class Spende
    {
        public int ID_Spende { get; set; }

        public decimal Betrag { get; set; }

        public int FK_Kunde_Spende { get; set; }
        public int FK_Zahlungsart_Spende { get; set; }

        public Spende(int id, decimal betrag,int fkkunde, int fkzahlung)
        {
            ID_Spende = id;
            Betrag = betrag;
            FK_Kunde_Spende = fkkunde;
            FK_Zahlungsart_Spende = fkzahlung;
        }
    }
}
