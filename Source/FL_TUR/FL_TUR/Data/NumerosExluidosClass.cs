﻿using FL_TUR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FL_TUR.Data
{
    public class NumerosExluidosClass
    {
        private int _limiteNumerosExluidos = 9;

        private List<int> _numerosExcluidosDoSorteio = new List<int>();

        public List<int> NumerosExcluidosDoSorteio { get => _numerosExcluidosDoSorteio; }

        public void AdicionarNumeroExcluido(int numero)
        {
            if ((_numerosExcluidosDoSorteio.Count()) < _limiteNumerosExluidos)
                _numerosExcluidosDoSorteio.Add(numero);
            else
                throw new LimiteNumerosExluidosException("Não é possível adicionar mais números");
        }

        public void ExluirNumeroExcluido(int numero)
        {
            _numerosExcluidosDoSorteio.Remove(numero);
        }

        public int QuantidadeDeNumerosRestante()
        {
            return _limiteNumerosExluidos - _numerosExcluidosDoSorteio.Count();
        }
    }


}
