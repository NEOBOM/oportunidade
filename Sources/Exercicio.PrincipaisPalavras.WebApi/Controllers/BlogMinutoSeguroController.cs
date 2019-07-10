using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exercicio.PrincipaisPalavras.Application.BlogMinutoSeguro.Interfaces;
using Exercicio.PrincipaisPalavras.Service.BlogMinutoSeguro;
using Exercicio.PrincipaisPalavras.Service.Core;
using Exercicio.PrincipaisPalavras.WebApi.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exercicio.PrincipaisPalavras.WebApi.Controllers
{
    [Route("api/blogMinutoSeguro")]
    [ApiController]
    public class BlogMinutoSeguroController : WebApiControllerBase
    {
        private readonly IBlogMinutoSeguroApp _blogMinutoSeguroApp = null;

        public BlogMinutoSeguroController(IBlogMinutoSeguroApp blogMinutoSeguroApp)
        {
            _blogMinutoSeguroApp = blogMinutoSeguroApp;
        }

        [HttpGet]
        [Route("ObterPrincipaisPalavras")]
        public async Task<ActionResult> GetAsync()
        {
            return Reply(await _blogMinutoSeguroApp.ObterPrincipaisPalavrasAsync());
        }
    }
}