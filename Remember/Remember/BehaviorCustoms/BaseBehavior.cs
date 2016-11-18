using System;
using Xamarin.Forms;

namespace Remember.BehaviorCustoms
{
    public class BaseBehavior<T> : Behavior<T> where T : BindableObject
    {
        public static readonly BindableProperty IsValidProperty = BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(EntryNotNullBehavior), true, BindingMode.TwoWay);

        public bool IsValid
        {
            get { return (bool)GetValue(IsValidProperty); }
            set { SetValue(IsValidProperty, value); }
        }


        protected override void OnAttachedTo(T bindable)
        {

            bindable.BindingContextChanged += OnBindingContextChanged;
        }
        private void OnBindingContextChanged(object sender, EventArgs eventArgs)
        {
            BindingContext = ((BindableObject)sender).BindingContext;
        }
    }
}