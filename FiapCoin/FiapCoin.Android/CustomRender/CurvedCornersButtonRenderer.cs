using System;
using Android.Util;
using Xamarin.Forms;
using Android.Content;
using System.ComponentModel;
using FiapCoin.CustomRender;
using Android.Graphics.Drawables;
using FiapCoin.Droid.CustomRender;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomButton), typeof(CurvedCornersButtonRenderer))]
namespace FiapCoin.Droid.CustomRender
{
    public class CurvedCornersButtonRenderer : ButtonRenderer
    {
        private GradientDrawable _gradientBackground;
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            var view = (CustomButton)Element;
            if(view == null) return;
            Paint(view);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if(e.PropertyName == CustomButton.CustomBorderColorProperty.PropertyName ||
                 e.PropertyName == CustomButton.CustomBorderRadiusProperty.PropertyName ||
                 e.PropertyName == CustomButton.CustomBorderWidthProperty.PropertyName)
            {
                if(Element != null)
                {
                    Paint((CustomButton)Element);
                }
            }
        }
        private void Paint(CustomButton view)
        {
            _gradientBackground = new GradientDrawable();
            _gradientBackground.SetShape(ShapeType.Rectangle);
            _gradientBackground.SetColor(view.CustomBackgroundColor.ToAndroid());
            // Thickness of the stroke line  
            _gradientBackground.SetStroke((int)view.CustomBorderWidth, view.CustomBorderColor.ToAndroid());
            // Radius for the curves  
            _gradientBackground.SetCornerRadius(
                DpToPixels(this.Context, Convert.ToSingle(view.CustomBorderRadius)));
            // set the background of the label  
            Control.SetBackground(_gradientBackground);
        }

        public static float DpToPixels(Context context, float valueInDp)
        {
            DisplayMetrics metrics = context.Resources.DisplayMetrics;
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
        }
    }
}