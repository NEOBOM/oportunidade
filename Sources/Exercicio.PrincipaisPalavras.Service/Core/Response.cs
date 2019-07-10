using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicio.PrincipaisPalavras.Service.Core
{
    public class Response<T>
    {
        public T Content { get; private set; }

        public string RasonPhrase { get; set; }

        public bool IsValid => string.IsNullOrEmpty(RasonPhrase);

        public void AddContent(T input)
        {
            Content = input;
        }
    }
}
