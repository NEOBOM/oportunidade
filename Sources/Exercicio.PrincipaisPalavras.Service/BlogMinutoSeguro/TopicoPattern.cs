using Exercicio.PrincipaisPalavras.Service.BlogMinutoSeguro.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicio.PrincipaisPalavras.Service.BlogMinutoSeguro
{
    public class TopicoPattern
    {
        private static string _patternConteudo;
        private static string _patternTags;
        private static string _patternLinks;
        private static string _patternWords;
        private static string _patternArtigos;
        private static string _patternPreposicoes;

        private static string _patternNumerico;

        public static string ObterPatternConteudo()
        {
            if (!string.IsNullOrEmpty(_patternConteudo)) return _patternConteudo;

            _patternConteudo = RegexPatternHelper.TagsWithContent(ObterTags());

            return _patternConteudo;
        }

        public static string ObterPatternTags()
        {
            if (!string.IsNullOrEmpty(_patternTags)) return _patternTags;

            _patternTags = RegexPatternHelper.Tags();

            return _patternTags;
        }
        
        public static string ObterPatternLinks()
        {
            if (!string.IsNullOrEmpty(_patternLinks)) return _patternLinks;

            _patternLinks = RegexPatternHelper.Links();

            return _patternLinks;
        }
        
        public static string ObterPatternWords()
        {
            if (!string.IsNullOrEmpty(_patternWords)) return _patternWords;

            _patternWords = RegexPatternHelper.Words("4", string.Empty);

            return _patternWords;
        }

        public static string ObterPatternArtigos()
        {
            if (!string.IsNullOrEmpty(_patternArtigos)) return _patternArtigos;

            _patternArtigos = RegexPatternHelper.BeetweenSpace(ObterArtigos());

            return _patternArtigos;
        }

        public static string ObterPatternPreposicoes()
        {
            if (!string.IsNullOrEmpty(_patternPreposicoes)) return _patternPreposicoes;

            _patternPreposicoes = RegexPatternHelper.BeetweenSpace(ObterPreposicoes());

            return _patternPreposicoes;
        }

        public static string ObterPatternNumerico()
        {
            if (!string.IsNullOrEmpty(_patternNumerico)) return _patternNumerico;

            _patternNumerico = RegexPatternHelper.Number();

            return _patternNumerico;
        }

        public static string [] ObterArtigos()
        {
            string[] artigos = { "a", "o", "as", "os", "um", "uns", "uma", "uma" };

            return artigos;
        }

        public static string [] ObterPreposicoes()
        {
            string [] preposicoes = { "ao", "aos", "aonde", "àquele", "ante", "após", "até", "com", "como", "conforme", "contra", "da", "das", "de", "do", "dos"
                , "desde", "em", "entre", "para", "por", "perante", "sem", "sob", "sobre", "trás", "duma", "disto", "nas", "num", "nessa", "pelo", "pelos", "pela","pelas", "durante", "exceto"
                , "feito", "fora", "senão", "visto" };

            return preposicoes;
        }

        public static string[] ObterTags()
        {
            string[] _tagsContent = { "link", "lastBuildDate", "lastBuildDate", "language", "link", "sy:updatePeriod", "sy:updateFrequency", "generator" };

            return _tagsContent;
        }
    }
}
