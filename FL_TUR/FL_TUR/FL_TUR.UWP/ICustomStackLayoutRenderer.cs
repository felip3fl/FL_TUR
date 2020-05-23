using FL_TUR.UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Media;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(Xamarin.Forms.ContentPage), typeof(ICustomStackLayoutRenderer))]
namespace FL_TUR.UWP
{
    public class ICustomStackLayoutRenderer : PageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Page> e)
        {
            base.OnElementChanged(e);
            base.UpdateBackgroundColor();

            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.UI.Xaml.Media.AcrylicBrush"))
            {
                var brush = Windows.UI.Xaml.Application.Current.Resources["SystemControlAltHighAcrylicWindowBrush"] as AcrylicBrush;
                brush.TintColor = Colors.White;
                brush.TintOpacity = 0.8;
                var fallbackColor = brush.FallbackColor;
                var source = brush.BackgroundSource;
                this.Background = brush;
            }

            CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.ButtonBackgroundColor = Colors.Transparent;
            titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
        }
    }
}
