using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace The.Barber.Api.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Agendamento = new HashSet<Agendamento>();
        }

        public string UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        [Required]
        public int IdCliente { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Logradouro { get; set; }
        [Required]
        public string Numero { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public string Cep { get; set; }
        public int CidadesIdCidade { get; set; }
        [Required]
        public string Cpf { get; set; }

        public Cidade CidadesIdCidadeNavigation { get; set; }
        public ICollection<Agendamento> Agendamento { get; set; }
    }
}
