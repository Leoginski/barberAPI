using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace The.Barber.Api.Models
{
    public partial class Cidade
    {
        public Cidade()
        {
            Barbearia = new HashSet<Barbearia>();
            Cliente = new HashSet<Cliente>();
        }

        [Required]
        public int IdCidade { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int EstadosIdEstado { get; set; }

        public Estado EstadosIdEstadoNavigation { get; set; }
        public ICollection<Barbearia> Barbearia { get; set; }
        public ICollection<Cliente> Cliente { get; set; }
    }
}
