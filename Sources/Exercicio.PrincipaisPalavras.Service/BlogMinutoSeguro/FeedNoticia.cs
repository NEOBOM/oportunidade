using Exercicio.PrincipaisPalavras.Service.BlogMinutoSeguro.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Exercicio.PrincipaisPalavras.Service.BlogMinutoSeguro
{
    public class FeedNoticia
    {
        public List<Topico> Topicos { get; private set; }
        public string HtmlContent { get; private set; }

        public FeedNoticia(string htmlContent)
        {
            CarregarInformacoesTopico(htmlContent);
        }

        public void CarregarInformacoesTopico(string html)
        {
            var htmlTopicos = html.Split("<item>");

            if (htmlTopicos.Any())
            {
                Topicos = new List<Topico>(htmlTopicos.Count() - 1);

                for (int i = 0; i < htmlTopicos.Length; i++)
                {
                    if (i > 0)
                    {
                        var obj = new Topico(htmlTopicos[i]);
                        obj.CarregarInformacoesTopico();

                        Topicos.Add(obj);
                    }
                }
            }
        }
    }
}
