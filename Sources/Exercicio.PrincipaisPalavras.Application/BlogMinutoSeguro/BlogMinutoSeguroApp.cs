using Exercicio.PrincipaisPalavras.Application.BlogMinutoSeguro.Interfaces;
using Exercicio.PrincipaisPalavras.Service.BlogMinutoSeguro;
using Exercicio.PrincipaisPalavras.Service.BlogMinutoSeguro.Interfaces;
using Exercicio.PrincipaisPalavras.Service.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio.PrincipaisPalavras.Application.BlogMinutoSeguro
{
    public class BlogMinutoSeguroApp : IBlogMinutoSeguroApp
    {
        private readonly IBlogMinutoSeguroService _blogMinutoSeguroService = null;

        public BlogMinutoSeguroApp(IBlogMinutoSeguroService blogMinutoSeguroService)
        {
            _blogMinutoSeguroService = blogMinutoSeguroService;
        }

        public async Task<Response<FeedNoticia>> ObterPrincipaisPalavrasAsync()
        {
            var response = new Response<FeedNoticia>();

            var conteudo = await _blogMinutoSeguroService.ObterConteudoFeedAsync();

            if (string.IsNullOrEmpty(conteudo))
            { 
                response.RasonPhrase = "Conteudo da página não encontrado";
                return response;
            }

            response.AddContent(new FeedNoticia(conteudo));

            return response;
        }
    }
}
