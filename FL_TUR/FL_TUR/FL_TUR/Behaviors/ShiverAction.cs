using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FL_TUR.Behaviors
{
    public class ShiverAction : TriggerAction<VisualElement>
    {
        public ShiverAction()
        {
            Length = 1000;
            Angle = 15;
            Vibrations = 10;
        }

        public int Length { set; get; }

        public double Angle { set; get; }

        public int Vibrations { set; get; }

        protected override async void Invoke(VisualElement visual)
        {
            visual.ScaleTo(1.1,100);
            await Task.Delay(100);
            visual.ScaleTo(1.0, 100);
            //visual.AnchorX = 0.5;
            //visual.AnchorY = 0.5;
            //visual.Rotation = 0;
            //visual.RotateTo(Angle, (uint)Length,
            //    new Easing(t => Math.Sin(Math.PI * t) *
            //                    Math.Sin(Math.PI * 2 * Vibrations * t)));
        }
    }
}
