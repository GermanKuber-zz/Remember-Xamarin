using System;
using Xamarin.Forms;

namespace Remember.BehaviorCustoms
{
    public class EntryNotNullBehavior : BaseBehavior<Entry>
    {


        private void OnTextChanged(object sender, TextChangedEventArgs args)
        {
            var entry = (Entry)sender;
            IsValid = !string.IsNullOrEmpty(args.NewTextValue);
            entry.BackgroundColor = IsValid ? Color.Green : Color.Red;
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += OnTextChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= OnTextChanged;
            bindable.BindingContextChanged -= OnBindingContextChanged;
        }

        private void OnBindingContextChanged(object sender, EventArgs eventArgs)
        {
            BindingContext = ((BindableObject)sender).BindingContext;
        }
    }
}