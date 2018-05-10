﻿using System;
using System.Collections.Generic;

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
        public string Nome { get; set; }
        public string Logradouro { get; set; }
        public int? Numero { get; set; }

        public ICollection<Agendamento> Agendamento { get; set; }
        public ICollection<CortePorBarbeiro> CortePorBarbeiro { get; set; }
        public ICollection<Funcionarios> Funcionarios { get; set; }
    }
}
