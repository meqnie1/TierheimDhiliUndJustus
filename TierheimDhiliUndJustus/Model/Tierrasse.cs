using System;
using System.Collections.Generic;

namespace TierheimDhiliUndJustus.Model
{
    public partial class Tierrasse
    {
        public Tierrasse()
        {
            Tiers = new HashSet<Tier>();
        }

        public int IdTierrasse { get; set; }
        public string Tierrassenamen { get; set; } = null!;
        public int FkTierartTierrasse { get; set; }

        public virtual Tierart FkTierartTierrasseNavigation { get; set; } = null!;
        public virtual ICollection<Tier> Tiers { get; set; }
    }
}
