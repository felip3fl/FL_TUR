using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FL_TUR
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            
            MainPage = new FL_TUR.FirstContentPage();
            MainPage.SetValue(NavigationPage.BarBackgroundColorProperty, Color.Black);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
