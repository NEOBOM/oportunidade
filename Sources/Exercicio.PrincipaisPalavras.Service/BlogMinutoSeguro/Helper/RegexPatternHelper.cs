using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercicio.PrincipaisPalavras.Service.BlogMinutoSeguro.Helper
{
    public class RegexPatternHelper
    {
        public static string TagsWithContent(string [] content)
        {
            string strPattern = string.Empty;

            for (int i = 0; i < content.Length; i++)
            {
                if (i == 0)
                    strPattern = $"<{content[i]}>\\s*(.+?)\\s*</{content[i]}>";
                else
                    strPattern += $"|<{content[i]}>\\s*(.+?)\\s*</{content[i]}>";
            }

            return strPattern;
        }

        public static string BeetweenSpace(string[] content)
        {
            string strPattern = string.Empty;

            for (int i = 0; i < content.Length; i++)
            {
                if (i == 0)
                    strPattern = $"\\s{content[i]}\\s";
                else
                    strPattern += $"|\\s{content[i]}\\s";
            }

            return strPattern;
        }

        public static string Words(string initial, string length)
        {
            return "\\w{" + initial + "," + length + "}";
        }

        public static string Tags()
        {
            return @"<[^>]*>";
        }

        public static string Links()
        {
            return @"http[^\s]+";
        }

        public static string Number()
        {
            return @"\d+";
        }
    }
}
