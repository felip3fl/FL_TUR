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
        public event EventHandler AtualizaQuantidadeNumeros;

        Grid grid = new Grid();
        NumerosExluidos numerosExluidos = new NumerosExluidos();

        public NumerosLotofacil()
        {
            InitializeComponent();
            InitializeComponentGridSorteio();
        }

        private void ResetBotoes()
        {
            var resetBotoes = grid.Children.Cast<Button>();

            foreach (var item in resetBotoes)
            {
                item.BackgroundColor = (Color)Application.Current.Resources["CorBotaoSorteio"];
                item.TextColor = (Color)Application.Current.Resources["CorTextoBotaoSorteio"];
            }
        }

        private void AtualizarNumerosSorteados(NumerosSorteadosClass numerosSorteadosClass)
        {
            var botoesSelecionados = grid.Children.Cast<Button>().Where(c => numerosSorteadosClass.NumerosSorteados.Contains(Convert.ToInt32(c.Text)));
            foreach (var item in botoesSelecionados)
            {
                item.BackgroundColor = (Color)Application.Current.Resources["CorBotaoSorteioMarcado"];
                item.TextColor = (Color)Application.Current.Resources["CorTextoBotaoSorteioMarcado"];
            }
        }

        private void AtualizarNumerosExcluidos(NumerosExluidos numerosExluidos)
        {
            var botoesExcluidos = grid.Children.Cast<Button>().Where(c => numerosExluidos.NumerosExcluidosDoSorteio.Contains(Convert.ToInt32(c.Text)));
            foreach (var item in botoesExcluidos)
            {
                item.BackgroundColor = (Color)Application.Current.Resources["CorBotaoSorteioExcluido"];
                item.TextColor = (Color)Application.Current.Resources["CorTextoBotaoSorteioExcluido"];
            }
        }

        public void Atualizar(NumerosSorteadosClass numerosSorteadosClass = null)
        {
            ResetBotoes();

            if (numerosSorteadosClass != null)
                AtualizarNumerosExcluidos(numerosExluidos);

            if (numerosExluidos != null)
                AtualizarNumerosSorteados(numerosSorteadosClass);
        }

        public void InitializeComponentGridSorteio()
        {
            var contador = 1;

            grid.Style = (Style)Application.Current.Resources["ControlNumeros"];

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
                    botao.BackgroundColor = (Color)Application.Current.Resources["CorBotaoSorteioExcluido"]; 
                    botao.TextColor = (Color)Application.Current.Resources["CorTextoBotaoSorteioExcluido"];
                }
                else
                {
                    numerosExluidos.ExluirNumeroExcluido(numeroSelecionado);
                    botao.BackgroundColor = (Color)Application.Current.Resources["CorBotaoSorteio"];
                    botao.TextColor = (Color)Application.Current.Resources["CorTextoBotaoSorteio"];
                }

                AtualizaQuantidadeNumeros(this, null);
            }
            catch (LimiteNumerosExluidosException)
            {
                App.Current.MainPage.DisplayAlert("Linmite de núemros excluidos", "Você selecionou o limite máximo de números que podem ser excluído.", "OK");
            }

        }

        public List<int> getNumerosExluidos()
        {
            return numerosExluidos.NumerosExcluidosDoSorteio;
        }

        public int QuantidadeDeNumerosRestante()
        {
            return numerosExluidos.QuantidadeDeNumerosRestante();
        }
    }
}