using System;
using System.Collections.Generic;

namespace TierheimDhiliUndJustus.Model
{
    public partial class Spende
    {
        public int IdSpende { get; set; }
        public decimal Betrag { get; set; }
        public int FkKundeSpende { get; set; }

        public virtual Kunde FkKundeSpendeNavigation { get; set; } = null!;
    }
}
