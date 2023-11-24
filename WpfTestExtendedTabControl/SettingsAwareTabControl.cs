using System.Windows;
using System.Windows.Controls;

namespace WpfTestExtendedTabControl
{
    public class SettingsAwareTabControl : TabControl
    {
        // Register the dependency property for the settings bar.
        public static readonly DependencyProperty SettingsControlProperty = 
            DependencyProperty.Register(
            nameof(SettingsControl),
            typeof(UIElement),
            typeof(SettingsAwareTabControl),
            new FrameworkPropertyMetadata(null, 
                FrameworkPropertyMetadataOptions.AffectsMeasure | 
                FrameworkPropertyMetadataOptions.AffectsArrange)
        );

        // Property wrapper
        public UIElement SettingsControl
        {
            get => (UIElement)GetValue(SettingsControlProperty);
            set => SetValue(SettingsControlProperty, value);
        }
    }
}
