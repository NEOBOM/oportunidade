using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicio.PrincipaisPalavras.Service.BlogMinutoSeguro
{
    public class PalavraPrincipal
    {
        public PalavraPrincipal(string nome, int qtd)
        {
            Nome = nome;
            Qtd = qtd;
        }

        public string Nome { get; private set; }

        public int Qtd { get; private set; }

        public void AdicionarQtd()
        {
            Qtd++;
        }
    }
}
