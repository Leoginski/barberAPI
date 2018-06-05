using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace The.Barber.Api.Models
{
    public partial class Avaliacao
    {
        [Required]
        public int IdAvaliacao { get; set; }
        [Required]
        public int? NotaCliente { get; set; }
        [Required]
        public int? NotaBarbeiro { get; set; }
        [Required]
        public int AgendamentoClienteIdCliente { get; set; }
        [Required]
        public int AgendamentoBarbeiroIdBarbeiro { get; set; }

        public Agendamento Agendamento { get; set; }
    }
}
