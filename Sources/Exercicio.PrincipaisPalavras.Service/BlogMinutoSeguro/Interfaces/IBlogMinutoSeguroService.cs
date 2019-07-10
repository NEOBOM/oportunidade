using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio.PrincipaisPalavras.Service.BlogMinutoSeguro.Interfaces
{
    public interface IBlogMinutoSeguroService
    {
        Task<string> ObterConteudoFeedAsync();
    }
}
