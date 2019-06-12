using FiapCoin.CustomRender;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace FiapCoin.Behavior
{
    public class EmailValidationBehavior : Behavior<ExtendedEntry>
    {
        const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-\._-|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

        ExtendedEntry control;
        string _placeHolder;
        Xamarin.Forms.Color _placeHolderColor;

        // Creating BindableProperties with Limited write access: http://iosapi.xamarin.com/index.aspx?link=M%3AXamarin.Forms.BindableObject.SetValue(Xamarin.Forms.BindablePropertyKey%2CSystem.Object) 

        static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty.CreateReadOnly("IsValid", typeof(bool), typeof(EmailValidationBehavior), false);

        public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

        public bool IsValid
        {
            get { return (bool)base.GetValue(IsValidProperty); }
            private set { base.SetValue(IsValidPropertyKey, value); }
        }

        protected override void OnAttachedTo(ExtendedEntry bindable)
        {
            bindable.Unfocused += HandleTextUnfocused;
            control = bindable;
            _placeHolder = bindable.Placeholder;
            _placeHolderColor = bindable.PlaceholderColor;
        }


        void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (ExtendedEntry)sender;

            if(!string.IsNullOrEmpty(e.NewTextValue) && !string.IsNullOrEmpty(entry.Placeholder) && !entry.Placeholder.Equals(e.NewTextValue))
            {

                IsValid = (Regex.IsMatch(e.NewTextValue, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));


                if(IsValid)
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
                    ((ExtendedEntry)sender).Placeholder = "E-mail inválido";
                    ((ExtendedEntry)sender).PlaceholderColor = Color.Red;
                }
            }
            else
            {
                ((ExtendedEntry)sender).IsBorderErrorVisible = true;
                ((ExtendedEntry)sender).BorderErrorColor = Color.Red;
                ((ExtendedEntry)sender).Placeholder = "E-mail inválido";
                ((ExtendedEntry)sender).PlaceholderColor = Color.Red;
            }
        }

        protected override void OnDetachingFrom(ExtendedEntry bindable)
        {
            bindable.Unfocused -= HandleTextUnfocused;
        }

        private void HandleTextUnfocused(object sender, FocusEventArgs e)
        {
            var entry = (ExtendedEntry)sender;

            if(!string.IsNullOrEmpty(entry.Text) && !string.IsNullOrEmpty(entry.Placeholder) && !entry.Placeholder.Equals(entry.Text))
            {

                IsValid = (Regex.IsMatch(entry.Text, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));

                if(IsValid)
                {
                    ((ExtendedEntry)sender).IsBorderErrorVisible = false;
                    ((ExtendedEntry)sender).BorderErrorColor = Color.Transparent;
                    ((ExtendedEntry)sender).Placeholder = _placeHolder;
                    ((ExtendedEntry)sender).PlaceholderColor = _placeHolderColor;
                }
                else
                {
                    ((ExtendedEntry)sender).IsBorderErrorVisible = true;
                    ((ExtendedEntry)sender).BorderErrorColor = Color.Red;
                    ((ExtendedEntry)sender).Placeholder = "E-mail inválido";
                    ((ExtendedEntry)sender).PlaceholderColor = Color.Red;
                }
            }
            else
            {
                ((ExtendedEntry)sender).IsBorderErrorVisible = true;
                ((ExtendedEntry)sender).BorderErrorColor = Color.Red;
                ((ExtendedEntry)sender).Placeholder = "E-mail inválido";
                ((ExtendedEntry)sender).PlaceholderColor = Color.Red;
            }
        }
    }
}
