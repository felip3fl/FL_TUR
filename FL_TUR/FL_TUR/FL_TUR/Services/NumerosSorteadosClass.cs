using FL_TUR.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FL_TUR.Services
{
    public class NumerosSorteadosClass
    {
        private static List<int> _numerosSorteados = new List<int>();

        public List<int> NumerosSorteados { get => _numerosSorteados; }

        //public void AdicionarNumeroExcluido(int numero)
        //{
        //    _numerosSorteados.Add(numero);
        //}

        public void ExluirNumeroExcluido(int numero)
        {
            _numerosSorteados.Remove(numero);
        }

        public void NovoSorterio()
        {
            var rnd = new Random();
            var numeroSorteado = 1;
            var numerosExluidos = new NumerosExluidos();
            var quantidadeNumeroSorteado = 0;
            _numerosSorteados.Clear();

            do
            {
                numeroSorteado = rnd.Next(1, 26);
                if (!numerosExluidos.NumerosExcluidosDoSorteio.Contains(numeroSorteado) && !_numerosSorteados.Contains(numeroSorteado)) 
                {
                    _numerosSorteados.Add(numeroSorteado);
                    quantidadeNumeroSorteado++;
                }
                    
            } while (quantidadeNumeroSorteado < 15);
        }

        public string getNumerosSorteadosOrdeado()
        {
            var builder = new StringBuilder();
            var delimitador = "";

            foreach (var numero in _numerosSorteados.OrderBy(x => x))
            {
                builder.Append(delimitador);
                builder.Append(numero.ToString("00"));
                delimitador = " ";
            }

            return builder.ToString();
        }

    }
}
