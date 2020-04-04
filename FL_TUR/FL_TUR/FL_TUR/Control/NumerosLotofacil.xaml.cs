using FL_TUR.Data;
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
    public partial class NumerosLotofacil : ContentView
    {
        Grid grid = new Grid();
        NumerosExluidos numerosExluidos = new NumerosExluidos();

        public NumerosLotofacil()
        {
            InitializeComponent();
            InitializeComponentGridSorteio();
        }

        public void Atualizar()
        {
            var numerosSorteadosClass = new NumerosSorteadosClass();

            var resetBotoes = grid.Children.Cast<Button>();
            foreach (var item in resetBotoes)
                item.BackgroundColor = (Color)Application.Current.Resources["CorBotao"];

            var botoesSelecionados = grid.Children.Cast<Button>().Where(c => numerosSorteadosClass.NumerosSorteados.Contains(Convert.ToInt32(c.Text)));
            foreach (var item in botoesSelecionados)
                item.BackgroundColor = Color.Black;

            var botoesExcluidos = grid.Children.Cast<Button>().Where(c => numerosExluidos.NumerosExcluidosDoSorteio.Contains(Convert.ToInt32(c.Text)));
            foreach (var item in botoesExcluidos)
                item.BackgroundColor = Color.Red;

        }

        public void InitializeComponentGridSorteio()
        {
            var contador = 1;

            //grid.Style = (Style)Application.Current.Resources["ControlNumeros"];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    grid.Children.Add(new Button
                    {
                        Text = contador++.ToString(),
                        Style= (Style)Application.Current.Resources["BotoesSorteio"]
                }, j, i);
                }
            }

            foreach (var item in grid.Children.Cast<Button>())
                item.Clicked += OnButtonClicked;

            this.Content = grid;
        }

        private void OnButtonClicked(object sender, EventArgs args)
        {
            Button botao = (Button)sender;

            try
            {
                var numeroSelecionado = Convert.ToInt32(botao.Text);

                if (!numerosExluidos.NumerosExcluidosDoSorteio.Contains(numeroSelecionado))
                {
                    numerosExluidos.AdicionarNumeroExcluido(numeroSelecionado);
                    botao.BackgroundColor = Color.Red;
                }
                else
                {
                    numerosExluidos.ExluirNumeroExcluido(numeroSelecionado);
                    botao.BackgroundColor = (Color)Application.Current.Resources["CorBotao"];
                }
            }
            catch (LimiteNumerosExluidosException)
            {
                App.Current.MainPage.DisplayAlert("Linmite de núemros excluidos", "Você selecionou o limite máximo de números que podem ser excluído.", "OK");
            }

        }
    }
}