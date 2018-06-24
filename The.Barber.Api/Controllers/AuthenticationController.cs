using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using The.Barber.Api.Auth;
using The.Barber.Api.Data;
using The.Barber.Api.Helpers;
using The.Barber.Api.Models;
using The.Barber.Api.ViewModels;

namespace The.Barber.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Authentication")]
    public class AuthenticationController : Controller
    {
        private readonly mydbContext _mydbContext;
        private readonly UserManager<Usuario> _userManager;
        private readonly IJwtFactory _jwtFactory;
        private readonly JwtIssuerOptions _jwtOptions;

        public AuthenticationController(UserManager<Usuario> userManager, IJwtFactory jwtFactory, IOptions<JwtIssuerOptions> jwtOptions, mydbContext mydbContext)
        {
            _userManager = userManager;
            _jwtFactory = jwtFactory;
            _jwtOptions = jwtOptions.Value;
            _mydbContext = mydbContext;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody]LoginViewModel credentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var identity = await GetClaimsIdentity(credentials.UserName, credentials.Password);
            if (identity == null)
            {
                return BadRequest(Errors.AddErrorToModelState("login falhou!", "senha ou nome de usuario errados.", ModelState));
            }

            var jwt = await Tokens.GenerateJwt(identity, _jwtFactory, credentials.UserName, _jwtOptions, new JsonSerializerSettings { Formatting = Formatting.Indented });
            return new OkObjectResult(jwt);
        }

        private async Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                return await Task.FromResult<ClaimsIdentity>(null);

            // verficar usuario no banco
            var userToVerify = _mydbContext
                                .Users
                                    .Include(u => u.Barbeiro)
                                    .Include(u => u.Cliente)
                                    .Single(u => u.UserName == userName);
            //var userToVerify = await _userManager.FindByNameAsync(userName)

            if (userToVerify == null) return await Task.FromResult<ClaimsIdentity>(null);


            var perfil = userToVerify.Cliente != null ? "C" : "B";

            // verficar credenciais
            if (await _userManager.CheckPasswordAsync(userToVerify, password))
            {
                return await Task.FromResult(_jwtFactory.GenerateClaimsIdentity(userName, userToVerify.Id, perfil));
            }

            // caso as credenciais ou o usuario seja invalido
            return await Task.FromResult<ClaimsIdentity>(null);
        }
    }
}