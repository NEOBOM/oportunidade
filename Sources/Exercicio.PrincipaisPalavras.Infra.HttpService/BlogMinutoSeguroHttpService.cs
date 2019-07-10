using Exercicio.PrincipaisPalavras.Service.BlogMinutoSeguro.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio.PrincipaisPalavras.Infra.HttpService
{
    public class BlogMinutoSeguroHttpService : HttpClientBase, IBlogMinutoSeguroService
    {
        private const string uriBlogFeed = "blog/feed";

        public BlogMinutoSeguroHttpService(): base("http://www.minutoseguros.com.br", "*/*")
        {
        }

        public Task<string> ObterConteudoFeedAsync()
        {
            return GetStringAsync(uriBlogFeed);
        }

        public HttpResponseMessage ObterConteudoFeedSync()
        {
            return GetSync(uriBlogFeed);
        }
    }
}
