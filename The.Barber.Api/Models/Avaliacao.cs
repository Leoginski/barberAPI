using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace The.Barber.Api.Models
{
    public partial class Avaliacao
    {
        public int IdAvaliacao { get; set; }
        public int? NotaCliente { get; set; }
        public int? NotaBarbeiro { get; set; }
        public int AgendamentoClienteIdCliente { get; set; }
        public int AgendamentoBarbeiroIdBarbeiro { get; set; }

        public Agendamento Agendamento { get; set; }
    }
}
