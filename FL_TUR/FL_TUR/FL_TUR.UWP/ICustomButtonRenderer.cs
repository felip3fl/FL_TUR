using FL_TUR.UWP;
using System;
using System.Globalization;
using Windows.UI;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Button), typeof(ICustomButtonRenderer))]
namespace FL_TUR.UWP
{
    public class ICustomButtonRenderer : ButtonRenderer
    {
        //protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        //{
        //    //base.OnElementChanged(e);
        //    //base.UpdateBackgroundColor();

        //    //if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.UI.Xaml.Media.AcrylicBrush"))
        //    //{
        //    //    Windows.UI.Xaml.Media.AcrylicBrush myBrush = new Windows.UI.Xaml.Media.AcrylicBrush();

        //    //    Windows.UI.Color c = HexColor("#9C27B0");

        //    //    myBrush.BackgroundSource = Windows.UI.Xaml.Media.AcrylicBackgroundSource.HostBackdrop;
        //    //    myBrush.TintColor = c;
        //    //    myBrush.FallbackColor = Windows.UI.Colors.White;
        //    //    myBrush.TintOpacity = 0.6;

        //    //    //this.Background = myBrush;


                
        //    //}

        //}

        public Windows.UI.Color HexColor(String hex)
        {
            //remove the # at the front
            hex = hex.Replace("#", "");

            byte a = 255;
            byte r = 255;
            byte g = 255;
            byte b = 255;

            int start = 0;

            //handle ARGB strings (8 characters long)
            if (hex.Length == 8)
            {
                a = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                start = 2;
            }

            //convert RGB characters to bytes
            r = byte.Parse(hex.Substring(start, 2), System.Globalization.NumberStyles.HexNumber);
            g = byte.Parse(hex.Substring(start + 2, 2), System.Globalization.NumberStyles.HexNumber);
            b = byte.Parse(hex.Substring(start + 4, 2), System.Globalization.NumberStyles.HexNumber);

            return Windows.UI.Color.FromArgb(a, r, g, b);
        }

    }
}
