using FL_TUR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
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
            //OnContentViewSizeChanged(StackLayoutPadrao, lblNumerosSorteados);
        } 

        private void Button_Clicked(object sender, EventArgs e)
        {
            var numerosSorteados = new NumerosSorteadosClass();
            numerosSorteados.NovoSorterio(NumerosLotofacil.getNumerosExluidos());

            StringBuilder temp = new StringBuilder();
            var texto = numerosSorteados.getNumerosSorteadosOrdeado();

            //var linha1 = texto.Substring(0,14) + " ";
            //var linha2 = texto.Substring(15, 14) + " ";
            //var linha3 = texto.Substring(30, 14);

            //var linha1 = temp.Insert(tamanho, "\n");
            //temp = temp.Insert((tamanho*2)+2, "\n");

            //REMOVIDO
            //lblNumerosSorteados.Text = linha1 + linha2 + linha3;
            //OnContentViewSizeChanged(StackLayoutPadrao, lblNumerosSorteados);

            NumerosLotofacil.Atualizar(numerosSorteados);
            ResultadoLotoFacil.ExibirResultadoTela(numerosSorteados);

            //NumerosLotofacil.Atualizar();
        }

        public void OnContentViewSizeChanged(View view, Label lblNumerosSorteados)
        {
            string text = lblNumerosSorteados.Text;

            // Get View whose size is changing.
            //View view = (View)sender;

            // Define two values as multiples of font size.
            double lineHeight = Device.RuntimePlatform == Device.iOS ||
                                Device.RuntimePlatform == Device.Android ? 1.2 : 1.3;

            double charWidth = 0.5;

            // Format the text and get its character length.
            //text = String.Format(text, lineHeight, charWidth, lblNumerosSorteados.Width, lblNumerosSorteados.Height);

            int charCount = text.Length;
            
            // Because:
            //   lineCount = view.Height / (lineHeight * fontSize)
            //   charsPerLine = view.Width / (charWidth * fontSize)
            //   charCount = lineCount * charsPerLine
            // Hence, solving for fontSize:
            int fontSize = (int)Math.Sqrt(lblNumerosSorteados.Width * lblNumerosSorteados.Height /
                            (charCount * lineHeight * charWidth));

            // Set the Label properties.
            lblNumerosSorteados.Text = text;
            lblNumerosSorteados.FontSize = fontSize;
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
    }
}