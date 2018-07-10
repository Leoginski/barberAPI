using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The.Barber.Api.Models;
using The.Barber.Api.ViewModels;

namespace The.Barber.Api.Automapper
{
    public class ModelToViewModelProfile : Profile
    {
        public ModelToViewModelProfile()
        {
            CreateMap<Agendamento, AgendamentoViewModel>()
                .ForMember(x => x.NomeBarbeiro, opt => opt.MapFrom(y => y.BarbeiroIdBarbeiroNavigation != null ? y.BarbeiroIdBarbeiroNavigation.Nome : ""))
                .ForMember(x => x.NomeCliente, opt => opt.MapFrom(y => y.ClienteIdClienteNavigation!= null ? y.ClienteIdClienteNavigation.Nome : ""))
                .ForMember(x => x.IdUsuarioCliente, opt => opt.MapFrom(y => y.ClienteIdClienteNavigation != null ? y.ClienteIdClienteNavigation.UsuarioId : ""))
                .ForMember(x => x.IdUsuarioBarbeiro, opt => opt.MapFrom(y => y.BarbeiroIdBarbeiroNavigation != null ? y.BarbeiroIdBarbeiroNavigation.UsuarioId : ""))
                .ReverseMap();
        }
    }
}
