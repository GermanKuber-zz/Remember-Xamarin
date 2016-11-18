using Xamarin.Forms;

namespace Remember.BehaviorCustoms
{
    public static class ValidationErrorColors
    {
        public static Color Validate(bool isValid)
        {
            if (!isValid)
                return Color.FromHex("F48178");
            else
                return Color.Transparent;

        }
    }
}