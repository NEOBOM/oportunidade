using Exercicio.PrincipaisPalavras.Service.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Exercicio.PrincipaisPalavras.Service.BlogMinutoSeguro
{
    public class Topico
    {
        private string _strHtml = string.Empty;
        public string Titulo { get; set; }
        public int QtdPalavras { get; set; }
        public List<PalavraPrincipal> PalavraPrincipals { get; set; }

        public Topico(string htmlTopico)
        {
            _strHtml = htmlTopico;

            ObterTítulo();
            RemoverConteudoTags();
            RemoverTags();
            RemoverLinks();

            RemoverArtigos();
            RemoverPreposicoes();

            //RemoverNumeros();
        }

        public string ObterStrHtml()
        {
            return _strHtml;
        }

        private void ObterTítulo()
        {
            Titulo = _strHtml.Beetween("<title>", "</title>");
        }

        public void CarregarInformacoesTopico()
        {
            var matches = Regex.Matches(_strHtml, TopicoPattern.ObterPatternWords(), RegexOptions.Compiled);

            QtdPalavras = matches.Count;

            PalavraPrincipals = matches.GroupBy(x => x.Value).Select(grp => 
                new PalavraPrincipal(grp.Key, grp.Count())).OrderByDescending(p => p.Qtd).Take(10).ToList();
        }

        #region PrivateMethods

        private void RemoverArtigos()
        {
            _strHtml = Regex.Replace(_strHtml, TopicoPattern.ObterPatternArtigos(), " ", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }

        private void RemoverPreposicoes()
        {
            _strHtml = Regex.Replace(_strHtml, TopicoPattern.ObterPatternPreposicoes(), " ", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }

        private void RemoverConteudoTags()
        {
            _strHtml = Regex.Replace(_strHtml, TopicoPattern.ObterPatternConteudo(), " ", RegexOptions.Compiled);
        }

        private void RemoverTags()
        {
            _strHtml = Regex.Replace(_strHtml, TopicoPattern.ObterPatternTags(), " ", RegexOptions.Compiled);
        }

        private void RemoverLinks()
        {
            _strHtml = Regex.Replace(_strHtml, TopicoPattern.ObterPatternLinks(), " ", RegexOptions.Compiled);
        }

        private void RemoverNumeros()
        {
            _strHtml = Regex.Replace(_strHtml, TopicoPattern.ObterPatternNumerico(), "", RegexOptions.Compiled);
        }

        #endregion
    }
}
