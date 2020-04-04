using FL_TUR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FL_TUR
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstContentPage : ContentPage
    {
        public FirstContentPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Random rnd = new Random();

            var numerosSorteados = new NumerosSorteadosClass();
            numerosSorteados.NovoSorterio();

            //StringBuilder numerosSorteados = new StringBuilder();

            StringBuilder temp = new StringBuilder();
            var texto = numerosSorteados.getNumerosSorteadosOrdeado();

            var linha1 = texto.Substring(0,14) + "\n";
            var linha2 = texto.Substring(15, 14) + "\n";
            var linha3 = texto.Substring(30, 14);

            //var linha1 = temp.Insert(tamanho, "\n");
            //temp = temp.Insert((tamanho*2)+2, "\n");

            lblNumerosSorteados.Text = linha1 + linha2 + linha3;

            NumerosLotofacil.Atualizar();
        }
    }
}