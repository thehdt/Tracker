using System.Windows;
using System.Windows.Media;

namespace Tracker.Styles
{
    public static class StyleProperties
    {
        public static readonly DependencyProperty IconImageProperty;

        static StyleProperties()
        {
            var metadata = new FrameworkPropertyMetadata((ImageSource)null);
            IconImageProperty = DependencyProperty.RegisterAttached("IconImage", typeof(ImageSource), typeof(StyleProperties), metadata);
        }

        public static ImageSource GetIconImage(DependencyObject obj)
        {
            return (ImageSource)obj.GetValue(IconImageProperty);
        }

        public static void SetIconImage(DependencyObject obj, ImageSource value)
        {
            obj.SetValue(IconImageProperty, value);
        }
    }
}
