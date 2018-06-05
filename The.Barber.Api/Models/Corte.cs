using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace The.Barber.Api.Models
{
    public partial class Corte
    {
        public Corte()
        {
            CortePorBarbeiro = new HashSet<CortePorBarbeiro>();
        }
        [Required]
        public int IdCorte { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Foto { get; set; }
        [Required]
        public float? Valor { get; set; }
        public string Cortecol { get; set; }

        public ICollection<CortePorBarbeiro> CortePorBarbeiro { get; set; }
    }
}
