using System;
using System.Collections.Generic;

namespace The.Barber.Api.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Agendamento = new HashSet<Agendamento>();
        }

        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public int CidadesIdCidade { get; set; }
        public string Cpf { get; set; }

        public Cidade CidadesIdCidadeNavigation { get; set; }
        public ICollection<Agendamento> Agendamento { get; set; }
    }
}
