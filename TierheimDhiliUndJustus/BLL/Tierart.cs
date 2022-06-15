namespace TierheimDhiliUndJustus.BLL
{
    public class Tierart
    {
        public int ID_Tierart { get; set; }

        public string Tierartname { get; set; }

        public Tierart()
        {

        }

        public Tierart(int id, string tiername)
        {
            ID_Tierart = id;
            Tierartname = tiername; 
        }

        public Tierart(string tiername)
        {
            Tierartname = tiername;
        }
    }
}
