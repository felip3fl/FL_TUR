using FL_TUR.Control;
using FL_TUR.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace FL_TUR.ViewModel
{
    public class ResultadoSorteioViewModel : INotifyPropertyChanged
    {
        private List<string> _Numeros { get; set; }
        public List<string> Numeros { get { return _Numeros; } set { _Numeros = value; OnPropertyChanged("Numeros"); } }

        #region Construtores
        public ResultadoSorteioViewModel(NumerosSorteadosClass numerosSorteadosClass)
        {
            AtualizarResultadoTela(numerosSorteadosClass);
        }

        public ResultadoSorteioViewModel()
        {
            AtualizarResultadoEmBrancoTela();
        }
        #endregion

        public void AtualizarResultadoTela(NumerosSorteadosClass numerosSorteadosClass)
        {
            Numeros.Clear();
            Numeros = (from o in numerosSorteadosClass.getListNumerosSorteadosOrdeado()
                       select o.ToString()).ToList();
        }

        public void AtualizarResultadoEmBrancoTela()
        {
            Numeros = new List<string>();
            for (int i = 0; i < 15; i++)
            {
                Numeros.Add("-");
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string NameProperty)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(NameProperty));
            }
        }
        #endregion

    }
}
