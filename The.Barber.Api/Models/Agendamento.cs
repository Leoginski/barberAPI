using System;
using System.Collections.Generic;

namespace The.Barber.Api.Models
{
    public partial class Agendamento
    {
        public Agendamento()
        {
            Avaliacao = new HashSet<Avaliacao>();
        }

        public int ClienteIdCliente { get; set; }
        public int BarbeiroIdBarbeiro { get; set; }
        public DateTime? Horario { get; set; }

        public Barbeiro BarbeiroIdBarbeiroNavigation { get; set; }
        public Cliente ClienteIdClienteNavigation { get; set; }
        public ICollection<Avaliacao> Avaliacao { get; set; }
    }
}
