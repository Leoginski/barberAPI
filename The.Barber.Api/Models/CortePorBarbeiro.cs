using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace The.Barber.Api.Models
{
    public partial class CortePorBarbeiro
    {
        [Required]
        public int CorteIdCorte { get; set; }
        [Required]
        public int BarbeiroIdBarbeiro { get; set; }

        public Barbeiro BarbeiroIdBarbeiroNavigation { get; set; }
        public Corte CorteIdCorteNavigation { get; set; }
    }
}
