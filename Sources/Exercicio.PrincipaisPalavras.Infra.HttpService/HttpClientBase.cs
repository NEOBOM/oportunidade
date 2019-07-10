using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exercicio.PrincipaisPalavras.Infra.HttpService
{
    public abstract class HttpClientBase
    {
        protected readonly HttpClient _httpClient;

        private readonly string _mediaTypeAccept;

        public HttpClientBase(string url) : this(url, "text/html")
        {
        }

        public HttpClientBase(string url, string mediaTypeAccept, Int64 timeOut = 3000, bool useDefaultCredentials = false)
        {
            _mediaTypeAccept = mediaTypeAccept;

            _httpClient = CreateHttpClienWithHandler(new Uri(url), timeOut, useDefaultCredentials);
        }

        public virtual HttpResponseMessage GetSync(string uri)
        {
            return GetAsync(uri).GetAwaiter().GetResult();
        }

        public virtual Task<HttpResponseMessage> GetAsync(string uri)
        {
            return _httpClient.GetAsync(uri);
        }

        public virtual Task<HttpResponseMessage> GetAsync(string uri, CancellationToken cancellationToken)
        {
            return _httpClient.GetAsync(uri, cancellationToken);
        }

        public virtual async Task<string> GetStringAsync(string uri)
        {
            var response = await _httpClient.GetAsync(uri);

            return await response.Content.ReadAsStringAsync();
        }

        public virtual HttpClient CreateHttpClienWithHandler(Uri baseAddress, Int64 timeOut, bool useDefaultCredentials)
        {
            var http = new HttpClient(CreateHttpClientHandler(useDefaultCredentials))
            {
                BaseAddress = baseAddress,
                Timeout = TimeSpan.FromMilliseconds(timeOut)
            };

            http.DefaultRequestHeaders.Add("Accept", _mediaTypeAccept);
            http.DefaultRequestHeaders.Add("Accept-Language", "pt-BR,pt;q=0.9,en-US;q=0.8,en;q=0.7");
            http.DefaultRequestHeaders.Add("Postman-Token", "92defd03-997e-4a76-8bf6-d4c27689e476");
            http.DefaultRequestHeaders.Add("User-Agent", "PostmanRuntime/7.15.0");

            return http;
        }

        protected virtual HttpClientHandler CreateHttpClientHandler(bool useDefaultCredentials)
        {
            var coockies = new CookieCollection();

            //coockies.Add(new Cookie("incap_ses_1239_1762536", "RY6beEc+lihW77u1ItAxEWXWJV0AAAAA/4NFHU9GK80fr01ssMIhiA==", "/", ".minutoseguros.com.br"));
            coockies.Add(new Cookie("incap_ses_789_1762536", "LWoDSNgCST0CoTOiTxjzCkgoJl0AAAAAzKQZySUBf72Km8CnA2FPdQ==", "/", ".minutoseguros.com.br"));
            coockies.Add(new Cookie("nlbi_1762536", "BvZVWkGzJQARObmQFqUGpAAAAADbKfc7jgu9TyKpDoCmRn9N", "/", ".minutoseguros.com.br"));
            coockies.Add(new Cookie("visid_incap_1762536", "0zVL0xC1TCyNtyOxkUAeqvvqJV0AAAAAQUIPAAAAAADgSdmxvVk57tSOLKmrglhv", "/", ".minutoseguros.com.br"));

            var coockieContaniner = new CookieContainer();
            coockieContaniner.Add(coockies);

            return new HttpClientHandler()
            {
                AllowAutoRedirect = true,
                UseDefaultCredentials = useDefaultCredentials,
                AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate,
                UseCookies = true,
                CookieContainer = coockieContaniner
            };
        }
    }
}
