using Xamarin.Forms;
using FiapCoin.CustomRender;
using Android.Graphics.Drawables;
using FiapCoin.Droid.CustomRender;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ExtendedEntry), typeof(ExtendedEntryRenderer))]
namespace FiapCoin.Droid.CustomRender
{
#pragma warning disable CS0618 // O tipo ou membro é obsoleto
    public class ExtendedEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if(Control == null || e.NewElement == null) return;

            UpdateBorders();
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if(Control == null) return;

            if(e.PropertyName == ExtendedEntry.IsBorderErrorVisibleProperty.PropertyName)
                UpdateBorders();
        }

        void UpdateBorders()
        {
            GradientDrawable shape = new GradientDrawable();
            shape.SetShape(ShapeType.Rectangle);
            shape.SetCornerRadius(0);

            if(((ExtendedEntry)this.Element).IsBorderErrorVisible)
            {
                shape.SetStroke(3, Android.Graphics.Color.Red);
                this.Control.SetBackground(shape);
                //shape.SetStroke(3, ((ExtendedEntry)this.Element).BorderErrorColor.ToAndroid());
            }
            else
            {
                shape.SetStroke(3, Android.Graphics.Color.LightGray);
                this.Control.SetBackground(shape);
            }

            this.Control.SetBackground(shape);
        }

    }
#pragma warning restore CS0618 // O tipo ou membro é obsoleto
}