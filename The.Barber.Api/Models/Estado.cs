using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace The.Barber.Api.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Cidade = new HashSet<Cidade>();
        }
        [Required]
        public int IdEstado { get; set; }
        [Required]
        public string Uf { get; set; }
        [Required]
        public string Nome { get; set; }

        public ICollection<Cidade> Cidade { get; set; }
    }
}
