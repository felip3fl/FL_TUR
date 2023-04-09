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
        public List<string> numeros { get; set; }

        public ResultadoSorteioViewModel()
        {
            numeros = new List<string>();
            for (int i = 0; i < 15; i++)
            {
                numeros.Add(i.ToString("00"));
            }
        }

        public void ExibirResultadoTela(NumerosSorteadosClass numerosSorteadosClass)
        {
            var contador = 1;
            numeros.Clear();

            foreach (var numeroSorteado in numerosSorteadosClass.getListNumerosSorteadosOrdeado())
            {
                numeros.Add(numeroSorteado.ToString("00"));
            }
            OnPropertyChanged("numeros");
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
