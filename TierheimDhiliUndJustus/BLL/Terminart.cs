namespace TierheimDhiliUndJustus.BLL
{
    public class Terminart
    {
        public int ID_Terminart { get; set; }

        public string Bezeichnung { get; set; }

        public Terminart(int id, string bezeichnung)
        {
            ID_Terminart = id;
            Bezeichnung = bezeichnung;
        }
    }
}
