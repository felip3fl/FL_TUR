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

        public void ExluirNumeroExcluido(int numero)
        {
            _numerosSorteados.Remove(numero);
        }

        public void NovoSorterio(List<int> numerosExluidos = null)
        {
            var rnd = new Random();
            var numeroSorteado = 1;
            var quantidadeNumeroSorteado = 0;
            _numerosSorteados.Clear();

            do
            {
                numeroSorteado = rnd.Next(1, 26);
                if (numeroValido(numeroSorteado, numerosExluidos)) 
                {
                    _numerosSorteados.Add(numeroSorteado);
                    quantidadeNumeroSorteado++;
                }
                    
            } while (quantidadeNumeroSorteado < 15);
        }

        private bool numeroValido(int numeroSorteado, List<int> numerosExluidos)
        {
            if (numerosExluidos == null)
                return !_numerosSorteados.Contains(numeroSorteado);
            
            return !numerosExluidos.Contains(numeroSorteado) && !_numerosSorteados.Contains(numeroSorteado);
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

        public List<int> getListNumerosSorteadosOrdeado()
        {
            return _numerosSorteados.OrderBy(x => x).ToList();
        }

    }
}
