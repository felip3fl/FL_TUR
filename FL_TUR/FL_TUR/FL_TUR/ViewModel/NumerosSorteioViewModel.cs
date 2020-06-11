using FL_TUR.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms.Core;
using Xamarin.Forms;
using System.Windows.Input;
using FL_TUR.Data;

namespace FL_TUR.ViewModel
{
    public class NumerosSorteioViewModel : INotifyPropertyChanged
    {

        private List<string> _Numeros { get; set; }
        public List<string> Numeros { get { return _Numeros; } set { _Numeros = value; OnPropertyChanged("Numeros"); } }
        private Style[] _StyleBotoesSorteio = new Style[25];
        public Style[] StyleBotoesSorteio { get { return _StyleBotoesSorteio; } set { _StyleBotoesSorteio = value; OnPropertyChanged("StyleBotoesSorteio"); } }
        public ICommand CommandMarcaNumero 
        { 
            get 
            {
                return new Command<string>((x) => MarcaNumero(x));
            }
        }

        private NumerosExluidosClass numerosExluidos = new NumerosExluidosClass();

        public NumerosSorteioViewModel()
        {
            ResetStyleTodosBotoes();
        }

        public NumerosSorteioViewModel(NumerosSorteadosClass numerosSorteadosClass)
        {
        }

        private void ResetStyleTodosBotoes()
        {
            for (int i = 0; i < StyleBotoesSorteio.Length; i++)
            {
                StyleBotoesSorteio[i] = (Style)Application.Current.Resources["BotoesSorteioDesmarcado"];
            }
            OnPropertyChanged("StyleBotoesSorteio");
        }

        private void MarcaNumero(string posicaoBotao)
        {
            var indexBotaoSelecionado = Convert.ToByte(posicaoBotao);
            var numeroExibicaoBotaoSelecionado = indexBotaoSelecionado + 1;

            try
            {
                if (!numerosExluidos.NumerosExcluidosDoSorteio.Contains(numeroExibicaoBotaoSelecionado))
                {
                    numerosExluidos.AdicionarNumeroExcluido(numeroExibicaoBotaoSelecionado);
                    StyleBotoesSorteio[indexBotaoSelecionado] = (Style)Application.Current.Resources["BotoesSorteioExluido"];
                }
                else
                {
                    numerosExluidos.ExluirNumeroExcluido(numeroExibicaoBotaoSelecionado);
                    StyleBotoesSorteio[indexBotaoSelecionado] = (Style)Application.Current.Resources["BotoesSorteioDesmarcado"];
                }

            //    AtualizaQuantidadeNumeros(this, null);
            }
            catch (LimiteNumerosExluidosException)
            {
                App.Current.MainPage.DisplayAlert("Linmite de núemros excluidos", "Você selecionou o limite máximo de números que podem ser excluído.", "OK");
            }

            OnPropertyChanged("StyleBotoesSorteio");
        }

        //private void AtualizarNumerosSorteados(NumerosSorteadosClass numerosSorteadosClass)
        //{
        //    var botoesSelecionados = grid.Children.Cast<Button>().Where(c => numerosSorteadosClass.NumerosSorteados.Contains(Convert.ToInt32(c.Text)));
        //    foreach (var item in botoesSelecionados)
        //    {
        //        item.BackgroundColor = (Color)Application.Current.Resources["CorBotaoSorteioMarcado"];
        //        item.TextColor = (Color)Application.Current.Resources["CorTextoBotaoSorteioMarcado"];
        //    }
        //}

            //private void AtualizarNumerosExcluidos(NumerosExluidosClass numerosExluidos)
            //{
            //    var botoesExcluidos = grid.Children.Cast<Button>().Where(c => numerosExluidos.NumerosExcluidosDoSorteio.Contains(Convert.ToInt32(c.Text)));
            //    foreach (var item in botoesExcluidos)
            //    {
            //        item.BackgroundColor = (Color)Application.Current.Resources["CorBotaoSorteioExcluido"];
            //        item.TextColor = (Color)Application.Current.Resources["CorTextoBotaoSorteioExcluido"];
            //    }
            //}

            //public void Atualizar(NumerosSorteadosClass numerosSorteadosClass = null)
            //{
            //    ResetBotoes();

            //    if (numerosSorteadosClass != null)
            //        AtualizarNumerosExcluidos(numerosExluidos);

            //    if (numerosExluidos != null)
            //        AtualizarNumerosSorteados(numerosSorteadosClass);
            //}



            //private void OnButtonClicked(object sender, EventArgs args)
            //{
            //    Button botao = (Button)sender;

            //    try
            //    {
            //        var numeroSelecionado = Convert.ToInt32(botao.Text);

            //        if (!numerosExluidos.NumerosExcluidosDoSorteio.Contains(numeroSelecionado))
            //        {
            //            numerosExluidos.AdicionarNumeroExcluido(numeroSelecionado);
            //            botao.BackgroundColor = (Color)Application.Current.Resources["CorBotaoSorteioExcluido"];
            //            botao.TextColor = (Color)Application.Current.Resources["CorTextoBotaoSorteioExcluido"];
            //        }
            //        else
            //        {
            //            numerosExluidos.ExluirNumeroExcluido(numeroSelecionado);
            //            botao.BackgroundColor = (Color)Application.Current.Resources["CorBotaoSorteio"];
            //            botao.TextColor = (Color)Application.Current.Resources["CorTextoBotaoSorteio"];
            //        }

            //        AtualizaQuantidadeNumeros(this, null);
            //    }
            //    catch (LimiteNumerosExluidosException)
            //    {
            //        App.Current.MainPage.DisplayAlert("Linmite de núemros excluidos", "Você selecionou o limite máximo de números que podem ser excluído.", "OK");
            //    }

            //}

            //public List<int> getNumerosExluidos()
            //{
            //    return numerosExluidos.NumerosExcluidosDoSorteio;
            //}

            //public int QuantidadeDeNumerosRestante()
            //{
            //    return numerosExluidos.QuantidadeDeNumerosRestante();
            //}

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


//private void ResetBotoes()
//{
//    foreach (var item in StyleBotoesSorteio)
//    {
//        item = (Style)Application.Current.Resources["BotoesSorteioDesmarcado"];
//    }


//    var resetBotoes = grid.Children.Cast<Button>();

//    foreach (var item in resetBotoes)
//    {
//        item.BackgroundColor = (Color)Application.Current.Resources["CorBotaoSorteio"];
//        item.TextColor = (Color)Application.Current.Resources["CorTextoBotaoSorteio"];
//    }
//}