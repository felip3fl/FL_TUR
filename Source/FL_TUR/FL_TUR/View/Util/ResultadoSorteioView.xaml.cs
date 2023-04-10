using FL_TUR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FL_TUR.Control
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultadoSorteioView : ContentView
    {
        Grid gridResultado;
        public string Numeros = "";
        ViewModel.ResultadoSorteioViewModel resultadoSorteio = new ViewModel.ResultadoSorteioViewModel();

        public ResultadoSorteioView()
        {
            InitializeComponent();
            BindingContext = resultadoSorteio;
        }

        public void ExibirResultadoTela(NumerosSorteadosClass resultado)
        {
            resultadoSorteio.ExibirResultadoTela(resultado);
        }
    }
}