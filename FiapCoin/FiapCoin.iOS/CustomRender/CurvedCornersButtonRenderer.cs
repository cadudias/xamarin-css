using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using FiapCoin.CustomRender;
using FiapCoin.iOS.CustomRender;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomButton), typeof(CurvedCornersButtonRenderer))]
namespace FiapCoin.iOS.CustomRender
{
    public class CurvedCornersButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            var view = (CustomButton)Element;
            if(view == null) return;
            Paint(view);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if(e.PropertyName == CustomButton.CustomBorderRadiusProperty.PropertyName ||
               e.PropertyName == CustomButton.CustomBorderColorProperty.PropertyName ||
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
            this.Layer.CornerRadius = (float)view.CustomBorderRadius;
            this.Layer.BorderColor = view.CustomBorderColor.ToCGColor();
            this.Layer.BackgroundColor = view.CustomBackgroundColor.ToCGColor();
            this.Layer.BorderWidth = (int)view.CustomBorderWidth;
        }
    }
}