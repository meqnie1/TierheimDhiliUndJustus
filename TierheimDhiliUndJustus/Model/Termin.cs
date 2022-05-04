using System;
using System.Collections.Generic;

namespace TierheimDhiliUndJustus.Model
{
    public partial class Termin
    {
        public int IdTermin { get; set; }
        public DateOnly Datum { get; set; }
        public TimeOnly Uhrzeit { get; set; }
        public sbyte Gebucht { get; set; }
        public int? FkKundeTermin { get; set; }
        public int? FkTerminartTermin { get; set; }
        public int? FkTierTermin { get; set; }

        public virtual Kunde? FkKundeTerminNavigation { get; set; }
        public virtual Terminart? FkTerminartTerminNavigation { get; set; }
        public virtual Tier? FkTierTerminNavigation { get; set; }
    }
}
