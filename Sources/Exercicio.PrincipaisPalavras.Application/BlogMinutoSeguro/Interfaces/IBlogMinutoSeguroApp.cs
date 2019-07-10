using Exercicio.PrincipaisPalavras.Service.BlogMinutoSeguro;
using Exercicio.PrincipaisPalavras.Service.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio.PrincipaisPalavras.Application.BlogMinutoSeguro.Interfaces
{
    public interface IBlogMinutoSeguroApp
    {
        Task<Response<FeedNoticia>> ObterPrincipaisPalavrasAsync();
    }
}
