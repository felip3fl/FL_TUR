using System;
using System.Collections.Generic;
using System.Text;

namespace FL_TUR.Model
{
    public enum TipoJogo
    {
        Livre = 0,
        MegaSena = 1,
        Quina = 2,
        Lotofacil = 3
    }

    public class Jogo : BaseClass
    {
        List<int> Dezenas { get; set; }
        public TipoJogo Tipo { get; set; }
        public bool GravarNumeros { get; set; }
    }
}
