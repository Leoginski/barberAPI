using System;
using System.Collections.Generic;

namespace The.Barber.Api.Models
{
    public partial class CortePorBarbeiro
    {
        public int CorteIdCorte { get; set; }
        public int BarbeiroIdBarbeiro { get; set; }

        public Barbeiro BarbeiroIdBarbeiroNavigation { get; set; }
        public Corte CorteIdCorteNavigation { get; set; }
    }
}
