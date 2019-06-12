using Xamarin.Forms;
using FiapCoin.CustomRender;

namespace FiapCoin.Behavior
{
    public class CampoObrigadorioBehavior : Behavior<ExtendedEntry>
    {
        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create<ExtendedEntry, string>(w => w.Placeholder, default(string));
        ExtendedEntry control;
        string _placeHolder;
        Xamarin.Forms.Color _placeHolderColor;

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        protected override void OnAttachedTo(ExtendedEntry bindable)
        {
            bindable.Unfocused += HandleTextUnfocused;
            control = bindable;
            _placeHolder = bindable.Placeholder;
            _placeHolderColor = bindable.PlaceholderColor;
        }

        private void HandleTextUnfocused(object sender, FocusEventArgs e)
        {
            var entry = (ExtendedEntry)sender;

            if(!string.IsNullOrEmpty(entry.Text) && entry.Text.Trim().Length > 0)
            {
                ((ExtendedEntry)sender).IsBorderErrorVisible = false;
                ((ExtendedEntry)sender).BorderErrorColor = Color.Transparent;
                ((ExtendedEntry)sender).ErrorText = null;
                ((ExtendedEntry)sender).Placeholder = _placeHolder;
                ((ExtendedEntry)sender).PlaceholderColor = _placeHolderColor;

            }
            else
            {
                ((ExtendedEntry)sender).IsBorderErrorVisible = true;
                ((ExtendedEntry)sender).BorderErrorColor = Color.Red;
                ((ExtendedEntry)sender).ErrorText = "Campo obrigatório";
                ((ExtendedEntry)sender).Placeholder = "Campo obrigatório";
                ((ExtendedEntry)sender).PlaceholderColor = Color.Red;
            }
        }

        protected override void OnDetachingFrom(ExtendedEntry entry)
        {
            entry.Unfocused -= HandleTextUnfocused;
        }

    }
}