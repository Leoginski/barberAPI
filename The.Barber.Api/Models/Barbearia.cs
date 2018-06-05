using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace The.Barber.Api.Models
{
    public partial class Barbearia
    {
        public Barbearia()
        {
            Funcionarios = new HashSet<Funcionarios>();
        }
        [Required]
        public int IdBarbearia { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Logradouro { get; set; }
        [Required]
        public int? Numero { get; set; }
        [Required]
        public int CidadesIdCidade { get; set; }
        public string Complemento { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public string Cnpj { get; set; }

        public Cidade CidadesIdCidadeNavigation { get; set; }
        public ICollection<Funcionarios> Funcionarios { get; set; }
    }
}
