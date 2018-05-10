using System;
using System.Collections.Generic;

namespace The.Barber.Api.Models
{
    public partial class Funcionarios
    {
        public int BarbeariaIdBarbearia { get; set; }
        public int BarbeiroIdBarbeiro { get; set; }

        public Barbearia BarbeariaIdBarbeariaNavigation { get; set; }
        public Barbeiro BarbeiroIdBarbeiroNavigation { get; set; }
    }
}
