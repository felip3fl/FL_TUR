using FL_TUR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FL_TUR.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lotofacil : ContentPage
    {
        public Lotofacil()
        {
            InitializeComponent();
        } 

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //await ResultadoSorteioView.ScaleTo(1.05, 50);
            RealizarSorteioAleatorio();
            //await ResultadoSorteioView.ScaleTo(1, 200);
        }

        public void OnContentViewSizeChanged2(Label lblNumerosSorteados)
        {
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

            string text = lblNumerosSorteados.Text;

            // Get View whose size is changing.
            //View view = (View)sender;

            // Define two values as multiples of font size.
            double lineHeight = Device.RuntimePlatform == Device.iOS ||
                                Device.RuntimePlatform == Device.Android ? 1.2 : 1.3;

            double charWidth = 3.5;

            // Format the text and get its character length.
            text = String.Format(text, lineHeight, charWidth, mainDisplayInfo.Width, mainDisplayInfo.Height);

            int charCount = text.Length;

            // Because:
            //   lineCount = view.Height / (lineHeight * fontSize)
            //   charsPerLine = view.Width / (charWidth * fontSize)
            //   charCount = lineCount * charsPerLine
            // Hence, solving for fontSize:
            int fontSize = (int)Math.Sqrt(mainDisplayInfo.Width * mainDisplayInfo.Height /
                            (charCount * lineHeight * charWidth));

            // Set the Label properties.
            lblNumerosSorteados.Text = text;
            lblNumerosSorteados.FontSize = fontSize;
        }

        private void StackLayoutPadrao_SizeChanged(object sender, EventArgs e)
        {
            //REMOVIDO
            //OnContentViewSizeChanged(StackLayoutPadrao, lblNumerosSorteados);
        }

        private void AtualizaDescricaoPrimaria()
        {
            var quantidadeNumeros = NumerosSorteioView.QuantidadeDeNumerosRestante();

            if (quantidadeNumeros == 1)
                lblDescricaoPrimaria.Text = $"Marque mais 1 número para remover do sorteio";
            else if (quantidadeNumeros < 1)
                lblDescricaoPrimaria.Text = $"Você não pode remover mais números do sorteio";
            else
                lblDescricaoPrimaria.Text = $"Marque até {quantidadeNumeros} números para remover do sorteio";
        }

        private void NumerosLotofacil_AtualizaQuantidadeNumeros(object sender, EventArgs e)
        {
            AtualizaDescricaoPrimaria();
        }

        private void RealizarSorteioAleatorio()
        {
            var numerosSorteados = new NumerosSorteadosClass();
            numerosSorteados.NovoSorterio(NumerosSorteioView.getNumerosExluidos());

            StringBuilder temp = new StringBuilder();
            var texto = numerosSorteados.getNumerosSorteadosOrdeado();

            NumerosSorteioView.Atualizar(numerosSorteados);
            //ResultadoSorteioView.ExibirResultadoTela(numerosSorteados);
        }
    }
}