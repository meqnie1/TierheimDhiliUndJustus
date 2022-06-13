namespace TierheimDhiliUndJustus.BLL
{
    public class Tierrasse
    {
        public int ID_Tierrasse { get; set; }

        public string Tierrassennamen { get; set; }

        public int FK_Tierart_Tierrasse { get; set; }

        public Tierrasse(int id, string tierrassenamen, int fktierart)
        {
            ID_Tierrasse = id;
            Tierrassennamen = tierrassenamen;
            FK_Tierart_Tierrasse = fktierart;
        }

        public Tierrasse(string tierrassnamen, int fktierart)
        {
            Tierrassennamen = tierrassnamen;
            FK_Tierart_Tierrasse = fktierart;
        }
    }
}
