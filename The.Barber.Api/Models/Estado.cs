using System;
using System.Collections.Generic;

namespace The.Barber.Api.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Cidade = new HashSet<Cidade>();
        }

        public int IdEstado { get; set; }
        public string Uf { get; set; }
        public string Nome { get; set; }

        public ICollection<Cidade> Cidade { get; set; }
    }
}
