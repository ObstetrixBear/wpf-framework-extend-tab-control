using System.Windows;
using System.Windows.Controls;

namespace WpfTestExtendedTabControl
{
    public class MyCustomTabControl : TabControl
    {
        // Register the dependency property
        public static readonly DependencyProperty YourExtraControlProperty = DependencyProperty.Register(
            "YourExtraControl",
            typeof(UIElement),
            typeof(MyCustomTabControl),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange)
        );

        // Property wrapper
        public UIElement YourExtraControl
        {
            get { return (UIElement)GetValue(YourExtraControlProperty); }
            set { SetValue(YourExtraControlProperty, value); }
        }

        // Rest of your custom tab control code...
    }
}
