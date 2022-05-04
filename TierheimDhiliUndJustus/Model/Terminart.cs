using System;
using System.Collections.Generic;

namespace TierheimDhiliUndJustus.Model
{
    public partial class Terminart
    {
        public Terminart()
        {
            Termins = new HashSet<Termin>();
        }

        public int IdTerminart { get; set; }
        public string Bezeichnung { get; set; } = null!;

        public virtual ICollection<Termin> Termins { get; set; }
    }
}
