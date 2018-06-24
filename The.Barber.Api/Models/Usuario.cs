using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The.Barber.Api.Models
{
    public class Usuario : IdentityUser
    {
        public int? BarbeiroId { get; set; }
        public int? ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Barbeiro Barbeiro { get; set; }

    }
}
