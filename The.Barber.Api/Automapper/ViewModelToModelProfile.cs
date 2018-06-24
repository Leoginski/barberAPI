using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The.Barber.Api.Models;
using The.Barber.Api.ViewModels;

namespace The.Barber.Api.Automapper
{
    public class ViewModelToModelProfile : Profile
    {
        public ViewModelToModelProfile()
        {
            CreateMap<CadastroViewModel, Usuario>().ReverseMap();
        }
    }
}
