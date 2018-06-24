using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The.Barber.Api.Models;

namespace The.Barber.Api.ViewModels
{
    public class CadastroViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public Barbeiro Barbeiro { get; set; }
        public Cliente Cliente { get; set; }
    }
}
