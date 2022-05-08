namespace TierheimDhiliUndJustus.BLL
{
    public class Termin
    {
        public int ID_Termin { get; set; }

        public DateOnly Datum { get; set; }

        public TimeOnly Uhrzeit { get; set; }

        public bool Gebucht { get; set; }

        public int FK_Kunde_Termin { get; set; }

        public int FK_Terminart_Art { get; set; }

        public int FK_Tier_Termin { get; set; }

        public Termin(int id, DateOnly datum, TimeOnly uhrzeit, bool gebucht, int fkkunde, int fkterminart, int fktier)
        {
            ID_Termin = id;
            Datum = datum;
            Uhrzeit = uhrzeit;
            Gebucht = gebucht;
            FK_Kunde_Termin = fkterminart;
            FK_Terminart_Art = fktier;
            FK_Tier_Termin = fktier;

        }
    }
}
