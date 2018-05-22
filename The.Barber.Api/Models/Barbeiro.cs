﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace The.Barber.Api.Models
{
    public partial class Barbeiro
    {
        public Barbeiro()
        {
            Agendamento = new HashSet<Agendamento>();
            CortePorBarbeiro = new HashSet<CortePorBarbeiro>();
            Funcionarios = new HashSet<Funcionarios>();
        }

        public int IdBarbeiro { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Logradouro { get; set; }

        public int? Numero { get; set; }

        public string Complemento { get; set; }

        [Required]
        public string Bairro { get; set; }

        [Required]
        public string Cpf { get; set; }
        public string Barbeirocol { get; set; }

        public ICollection<Agendamento> Agendamento { get; set; }
        public ICollection<CortePorBarbeiro> CortePorBarbeiro { get; set; }
        public ICollection<Funcionarios> Funcionarios { get; set; }
    }
}
