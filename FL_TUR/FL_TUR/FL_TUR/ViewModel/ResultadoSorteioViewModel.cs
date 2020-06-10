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
        private List<string> _numeros { get; set; }
        public List<string> numeros { get { return _numeros; } set { _numeros = value; OnPropertyChanged("numeros"); } }

        public ResultadoSorteioViewModel(NumerosSorteadosClass numerosSorteadosClass)
        {
            numeros = (from o in numerosSorteadosClass.getListNumerosSorteadosOrdeado()
                       select o.ToString()).ToList();
        }

        public ResultadoSorteioViewModel()
        {
            numeros = new List<string>();
            for (int i = 0; i < 15; i++)
            {
                numeros.Add("-");
            }
        }

        public void ExibirResultadoTela(NumerosSorteadosClass numerosSorteadosClass)
        {
            numeros.Clear();
            numeros = (from o in numerosSorteadosClass.getListNumerosSorteadosOrdeado()
                       select o.ToString()).ToList();

            //var contador = 1;

            //foreach (var numeroSorteado in numerosSorteadosClass.getListNumerosSorteadosOrdeado())
            //{

            //    grid.Children.Cast<Label>().Where(a => a.ClassId == contador.ToString()).FirstOrDefault();
            //    label.Text = numeroSorteado.ToString("00");
            //    contador++;
            //}
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
