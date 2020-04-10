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
    public partial class ResultadoLotoFacil : ContentView
    {
        Grid grid = new Grid();

        public ResultadoLotoFacil()
        {
            InitializeComponent();
            CriarComponentes();
        }

        private void CriarComponentes()
        {
            var contador = 1;

            grid.Style = (Style)Application.Current.Resources["ControlGridResultadoLotoFacil"];

            for (int i = 0; i < 3; i++) //3 Linhas
            {
                for (int j = 0; j < 5; j++) //5 Números por linhas
                {
                    grid.Children.Add(new Label
                    {
                        Text = "-",
                        ClassId = contador++.ToString(),
                        Style = (Style)Application.Current.Resources["ControlLabelResultadoLotoFacil"]
                }, j, i); ;
                }
            };

            this.Content = grid;
        }

        public void ExibirResultadoTela(NumerosSorteadosClass numerosSorteadosClass)
        {
            var contador = 1;

            foreach (var numeroSorteado in numerosSorteadosClass.getListNumerosSorteadosOrdeado())
            {
                var label = grid.Children.Cast<Label>().Where(a => a.ClassId == contador.ToString()).FirstOrDefault();
                label.Text = numeroSorteado.ToString("00");
                contador++;
            }
        }
    }
}