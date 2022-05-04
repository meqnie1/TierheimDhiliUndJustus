using System;
using System.Collections.Generic;

namespace TierheimDhiliUndJustus.Model
{
    public partial class Tierart
    {
        public Tierart()
        {
            Tierrasses = new HashSet<Tierrasse>();
        }

        public int IdTierart { get; set; }
        public string Tierartname { get; set; } = null!;

        public virtual ICollection<Tierrasse> Tierrasses { get; set; }
    }
}
