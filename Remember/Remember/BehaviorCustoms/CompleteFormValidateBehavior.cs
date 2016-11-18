using System;
using System.Text.RegularExpressions;
using Remember.Behavior;
using Xamarin.Forms;

namespace Remember.BehaviorCustoms
{
    //Todo implementar este Behavior , debe de recibir todo un modelo como parametro y retornar true si el modelo es correcto
    public class CompleteFormValidateBehavior : BehaviorBase<Button>
    {
        const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                                  @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

        static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty.CreateReadOnly("IsValid", typeof(bool), typeof(CompleteFormValidateBehavior), false);

        public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

        public bool IsValid
        {
            get { return (bool)base.GetValue(IsValidProperty); }
            private set { base.SetValue(IsValidPropertyKey, value); }
        }

        protected override void OnAttachedTo(Button bindable)
        {

        }

        void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            IsValid = (Regex.IsMatch(e.NewTextValue, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
            ((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;
        }

        protected override void OnDetachingFrom(Button bindable)
        {


        }


        public static readonly BindableProperty CompareToEntryProperty = BindableProperty.Create("CompareToEntry",
            typeof(Binding), typeof(ConfirmPasswordBehavior), null);




        public Binding CheckModel
        {
            get
            {
                return (Binding)base.GetValue(CompareToEntryProperty);
            }
            set
            {
                base.SetValue(CompareToEntryProperty, value);
            }
        }
    }
}