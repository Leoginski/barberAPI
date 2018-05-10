using System;
using System.Collections.Generic;

namespace The.Barber.Api.Models
{
    public partial class Barbearia
    {
        public Barbearia()
        {
            Funcionarios = new HashSet<Funcionarios>();
        }

        public int IdBarbearia { get; set; }
        public string Nome { get; set; }
        public string Logradouro { get; set; }
        public int? Numero { get; set; }
        public int CidadesIdCidade { get; set; }

        public Cidade CidadesIdCidadeNavigation { get; set; }
        public ICollection<Funcionarios> Funcionarios { get; set; }
    }
}
