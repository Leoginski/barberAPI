using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using The.Barber.Api.Data;
using The.Barber.Api.Helpers;
using The.Barber.Api.Models;
using The.Barber.Api.ViewModels;

namespace The.Barber.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Usuario")]
    public class UsuarioController : Controller
    {
        private readonly mydbContext _mydbContext;
        private readonly UserManager<Usuario> _userManager;
        private readonly IMapper _mapper;

        public UsuarioController(UserManager<Usuario> userManager, IMapper mapper, mydbContext mydbContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _mydbContext = mydbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CadastroViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = _mapper.Map<Usuario>(model);

            var result = await _userManager.CreateAsync(userIdentity, model.Password);

            if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

            //await _mydbContext.Customers.AddAsync(new Customer { IdentityId = userIdentity.Id, Location = model.Location });
            await _mydbContext.SaveChangesAsync();

            return new OkObjectResult("Conta criada com sucesso");
        }
    }
}