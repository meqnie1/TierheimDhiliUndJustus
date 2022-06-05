namespace TierheimDhiliUndJustus.BLL
{
    public class Zahlungsart
    {
        public int ID_Zahlungsart { get; set; }

        public string Zahlungsartname { get; set; }

        public Zahlungsart(int id, string name)
        {
            ID_Zahlungsart = id;
            Zahlungsartname = name;
        }
    }
}
