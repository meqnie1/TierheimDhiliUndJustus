namespace TierheimDhiliUndJustus.BLL
{
    public class Termin
    {
        public int ID_Termin { get; set; }

        public DateTime TerminDatum { get; set; }

        public SByte Gebucht { get; set; }

        public int FK_Kunde_Termin { get; set; }

        public int FK_Terminart_Art { get; set; }

        public int FK_Tier_Termin { get; set; }

        public Termin(int id, DateTime termin, SByte gebucht, int fkterminart)
        {
            ID_Termin = id;
            TerminDatum = termin;
            Gebucht = gebucht;
            FK_Terminart_Art = fkterminart;

        }
    }
}
