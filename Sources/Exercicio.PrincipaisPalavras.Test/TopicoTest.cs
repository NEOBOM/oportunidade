using Exercicio.PrincipaisPalavras.Service.BlogMinutoSeguro;
using Exercicio.PrincipaisPalavras.Service.BlogMinutoSeguro.Interfaces;
using Exercicio.PrincipaisPalavras.Test.Extensions;
using Moq;
using System.Linq;
using Xunit;

namespace Exercicio.PrincipaisPalavras.Test
{
    public class TopicoTest
    {
        private readonly Mock<IBlogMinutoSeguroService> _blogMinutoSeguroService = null;

        public TopicoTest()
        {
            _blogMinutoSeguroService = new Mock<IBlogMinutoSeguroService>().ObterConteudoFeed_Topico();
        }

        [Fact]
        public void Verificar_Conteudo_Titulo()
        {
            var html = _blogMinutoSeguroService.Object.ObterConteudoFeedAsync().Result;

            var topico = new Topico(html);

            Assert.NotEmpty(topico.Titulo);
            Assert.True(!topico.Titulo.Contains("<") || !topico.Titulo.Contains(">"));
        }

        [Fact]
        public void Verificar_Remocao_de_Tags_Titulo()
        {
            var html = _blogMinutoSeguroService.Object.ObterConteudoFeedAsync().Result;

            var strHtml = new Topico(html).ObterStrHtml();

            Assert.NotEmpty(strHtml);
            Assert.True(!strHtml.Contains("link"));
            Assert.True(!strHtml.Contains("lastBuildDate"));
            Assert.True(!strHtml.Contains("language"));
            Assert.True(!strHtml.Contains("sy:"));
            Assert.True(!strHtml.Contains("generator"));
        }

        [Fact]
        public void Verificar_Palavras_Artigo()
        {
            var html = _blogMinutoSeguroService.Object.ObterConteudoFeedAsync().Result;

            var strHtml = new Topico(html).ObterStrHtml();

            Assert.NotEmpty(strHtml);
            Assert.DoesNotMatch(TopicoPattern.ObterPatternArtigos(), strHtml);
        }

        [Fact]
        public void Verificar_Palavras_Preposicoes()
        {
            var html = _blogMinutoSeguroService.Object.ObterConteudoFeedAsync().Result;

            var strHtml = new Topico(html).ObterStrHtml();

            Assert.NotEmpty(strHtml);
            Assert.DoesNotMatch(TopicoPattern.ObterPatternPreposicoes(), strHtml);
        }

        [Fact]
        public void Verificar_Qtd_Palavras()
        {
            var html = _blogMinutoSeguroService.Object.ObterConteudoFeedAsync().Result;

            var obj = new Topico(html);
            obj.CarregarInformacoesTopico();

            Assert.True(obj.QtdPalavras > 0);
        }

        [Fact]
        public void Verificar_Palavras_Principais()
        {
            var html = _blogMinutoSeguroService.Object.ObterConteudoFeedAsync().Result;

            var obj = new Topico(html);
            obj.CarregarInformacoesTopico();

            Assert.NotNull(obj.PalavraPrincipals);
            Assert.True(obj.PalavraPrincipals.Any());
            Assert.True(obj.PalavraPrincipals.Count == 10);
        }
    }
}
