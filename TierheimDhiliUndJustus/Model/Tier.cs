using System;
using System.Collections.Generic;

namespace TierheimDhiliUndJustus.Model
{
    public partial class Tier
    {
        public Tier()
        {
            Termins = new HashSet<Termin>();
        }

        public int IdTier { get; set; }
        public string Tiername { get; set; } = null!;
        public DateOnly? Geburtsdatum { get; set; }
        public string Geschlecht { get; set; } = null!;
        public string Beschreibung { get; set; } = null!;
        public byte[] Bild { get; set; } = null!;
        public sbyte Fundtier { get; set; }
        public int FkTierrasseTier { get; set; }

        public virtual Tierrasse FkTierrasseTierNavigation { get; set; } = null!;
        public virtual ICollection<Termin> Termins { get; set; }
    }
}
