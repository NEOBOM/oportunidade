using Exercicio.PrincipaisPalavras.Service.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicio.PrincipaisPalavras.WebApi.Core
{
    public class WebApiControllerBase : ControllerBase
    {
        public ActionResult Reply<T>(Response<T> response)
        {
            if (response.IsValid)
                return Ok(response);

            return BadRequest(response.RasonPhrase);
        }
    }
}
