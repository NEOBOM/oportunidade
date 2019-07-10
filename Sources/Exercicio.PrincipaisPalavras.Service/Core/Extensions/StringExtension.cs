using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicio.PrincipaisPalavras.Service.Core.Extensions
{
    public static class StringExtension
    {
        public static string Beetween(this string content, string startsWith, string endsWith)
        {
            var cropStart = content.IndexOf(startsWith, StringComparison.Ordinal);
            var cropped = content.Substring(cropStart);
            var cropEnd = cropped.IndexOf(endsWith, StringComparison.Ordinal);
            var cleaned = cropped.Substring(0, cropEnd).Substring(startsWith.Length);
            return cleaned;
        }
    }
}
