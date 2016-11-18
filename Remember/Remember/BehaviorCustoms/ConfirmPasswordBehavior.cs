using System;
using Xamarin.Forms;

namespace Remember.BehaviorCustoms
{



    class ConfirmPasswordBehavior : Behavior<Entry>
    {
        static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty.CreateReadOnly("IsValid", typeof(bool),
            typeof(ConfirmPasswordBehavior), false);

        public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

        public static readonly BindableProperty CompareToEntryProperty = BindableProperty.Create("CompareToEntry",
            typeof(Entry), typeof(ConfirmPasswordBehavior), null);

        public Entry CompareToEntry
        {
            get { return (Entry)base.GetValue(CompareToEntryProperty); }
            set { base.SetValue(CompareToEntryProperty, value); }
        }


        public bool IsValid
        {
            get { return (bool)base.GetValue(IsValidProperty); }
            private set
            { base.SetValue(IsValidPropertyKey, value); }
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += HandleTextChanged;
            //Este es el tema, hay que colocar en contexto el behavior
            bindable.BindingContextChanged += OnBindingContextChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;
            base.OnDetachingFrom(bindable);
        }

        void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            var password = CompareToEntry.Text;
            var confirmPassword = e.NewTextValue;
            IsValid = password.Equals(confirmPassword);


            ((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;
        }

        private void OnBindingContextChanged(object sender, EventArgs eventArgs)
        {
            BindingContext = ((BindableObject)sender).BindingContext;
        }
    }
}