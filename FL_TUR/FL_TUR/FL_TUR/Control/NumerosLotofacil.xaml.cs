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
        public NumerosLotofacil()
        {
            InitializeComponent();
            GridDemoPage();
        }

        public void GridDemoPage()
        {
            Grid grid = new Grid();
            var contador = 1;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    grid.Children.Add(new Button
                    {
                        Text = contador++.ToString()
                    }, j, i);
                }
            }

            // Accomodate iPhone status bar.
            //this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = grid;
        }

    }
}