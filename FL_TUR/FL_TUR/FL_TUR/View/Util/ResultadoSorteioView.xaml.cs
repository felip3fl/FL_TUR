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

        public ResultadoSorteioView()
        {
            InitializeComponent();
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            gridResultado = new Grid();
            gridResultado.Style = (Style)Application.Current.Resources["ControlGridResultadoLotoFacil"];

            var contadorClassId = 1;

            for (int linha = 0; linha < 3; linha++) //3 Linhas
            {
                for (int coluna = 0; coluna < 5; coluna++) //5 Números por linhas
                {
                    gridResultado.Children.Add(new Label
                    {
                        Text = "-",
                        ClassId = contadorClassId++.ToString(),
                        Style = (Style)Application.Current.Resources["ControlLabelResultadoLotoFacil"]
                }, coluna, linha); ;
                }
            };

            this.Content = gridResultado;
        }

        public void ExibirResultadoTela(NumerosSorteadosClass numerosSorteadosClass)
        {
            var contador = 1;

            foreach (var numeroSorteado in numerosSorteadosClass.getListNumerosSorteadosOrdeado())
            {
                var label = gridResultado.Children.Cast<Label>().Where(a => a.ClassId == contador.ToString()).FirstOrDefault();
                label.Text = numeroSorteado.ToString("00");
                contador++;
            }
        }
    }
}