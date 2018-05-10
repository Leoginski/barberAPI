using System;
using System.Collections.Generic;

namespace The.Barber.Api.Models
{
    public partial class Corte
    {
        public Corte()
        {
            CortePorBarbeiro = new HashSet<CortePorBarbeiro>();
        }

        public int IdCorte { get; set; }
        public string Nome { get; set; }
        public string Foto { get; set; }
        public float? Valor { get; set; }
        public string Cortecol { get; set; }

        public ICollection<CortePorBarbeiro> CortePorBarbeiro { get; set; }
    }
}
