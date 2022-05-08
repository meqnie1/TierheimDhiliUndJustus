using System.Drawing;

namespace TierheimDhiliUndJustus.BLL
{
    public class Tier
    {
        public int ID_Tier { get; set; }

        public string Tiername { get; set; }

        public DateTime Geburtsdatum { get; set; }

        public string Geschlecht { get; set; }

        public string Beschreibung { get; set; }


        public SByte Fundtier { get; set; }

        public int FK_Tierrasse_Tier { get; set; }



        public Tier(int id, string tiername, DateTime geburtsdatum, string geschlecht, string beschreibung, sbyte fundtier, int fktierrasse)
        {
            ID_Tier = id;
            Tiername = tiername;
            Geburtsdatum = geburtsdatum;
            Geschlecht = geschlecht;
            Beschreibung = beschreibung;
            Fundtier = fundtier;
            FK_Tierrasse_Tier = fktierrasse;

        }
    }
}
