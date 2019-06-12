using UIKit;
using System;
using Xamarin.Forms;
using FiapCoin.CustomRender;
using FiapCoin.iOS.CustomRender;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ExtendedEntry), typeof(ExtendedEntryRenderer))]
namespace FiapCoin.iOS.CustomRender
{
    public class ExtendedEntryRenderer : EntryRenderer
    {
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if(Control == null || this.Element == null) return;

            if(e.PropertyName == ExtendedEntry.IsBorderErrorVisibleProperty.PropertyName)
            {
                if(((ExtendedEntry)this.Element).IsBorderErrorVisible)
                {
                    this.Control.Layer.BorderColor = ((ExtendedEntry)this.Element).BorderErrorColor.ToCGColor();
                    this.Control.Layer.BorderWidth = new nfloat(0.8);
                    this.Control.Layer.CornerRadius = 5;
                }
                else
                {
                    this.Control.Layer.BorderColor = UIColor.LightGray.CGColor;
                    this.Control.Layer.CornerRadius = 5;
                    this.Control.Layer.BorderWidth = new nfloat(0.8);
                }

            }
        }

    }
}