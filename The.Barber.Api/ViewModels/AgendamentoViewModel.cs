using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The.Barber.Api.Models;

namespace The.Barber.Api.ViewModels
{
    public class AgendamentoViewModel
    {
        public int ClienteIdCliente { get; set; }
        public int BarbeiroIdBarbeiro { get; set; }
        public DateTime? Horario { get; set; }

        public string NomeCliente { get; set; }
        public string NomeBarbeiro { get; set; }


        public string IdUsuarioBarbeiro { get; set; }
        public string IdUsuarioCliente { get; set; }

        public ICollection<Avaliacao> Avaliacao { get; set; }
    }
}
