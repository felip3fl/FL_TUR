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
    public partial class NumerosSorteioView : ContentView
    {
        public event EventHandler AtualizaQuantidadeNumeros;

        Grid grid = new Grid();
        NumerosExluidosClass numerosExluidos = new NumerosExluidosClass();

        public NumerosSorteioView()
        {
            InitializeComponent();
            BindingContext = new ViewModel.NumerosSorteioViewModel();
        }

    }
}

//public void InitializeComponentGridSorteio()
//{
//    var contador = 1;

//    grid.Style = (Style)Application.Current.Resources["ControlNumeros"];

//    for (int i = 0; i < 5; i++)
//    {
//        for (int j = 0; j < 5; j++)
//        {
//            grid.Children.Add(new Button
//            {
//                Text = contador++.ToString(),
//                Style= (Style)Application.Current.Resources["BotoesSorteio"]
//        }, j, i);
//        }
//    }

//    foreach (var item in grid.Children.Cast<Button>())
//        item.Clicked += OnButtonClicked;

//    this.Content = grid;
//}