using System;
using System.Collections.Generic;

namespace TierheimDhiliUndJustus.Model
{
    public partial class Kunde
    {
        public Kunde()
        {
            Spendes = new HashSet<Spende>();
            Termins = new HashSet<Termin>();
        }

        public int IdKunde { get; set; }
        public string Email { get; set; } = null!;
        public string Passwort { get; set; } = null!;

        public virtual ICollection<Spende> Spendes { get; set; }
        public virtual ICollection<Termin> Termins { get; set; }
    }
}
