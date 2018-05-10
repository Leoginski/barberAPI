using System;
using System.Collections.Generic;

namespace The.Barber.Api.Models
{
    public partial class Cidade
    {
        public Cidade()
        {
            Barbearia = new HashSet<Barbearia>();
            Cliente = new HashSet<Cliente>();
        }

        public int IdCidade { get; set; }
        public string Nome { get; set; }
        public int EstadosIdEstado { get; set; }

        public Estado EstadosIdEstadoNavigation { get; set; }
        public ICollection<Barbearia> Barbearia { get; set; }
        public ICollection<Cliente> Cliente { get; set; }
    }
}
