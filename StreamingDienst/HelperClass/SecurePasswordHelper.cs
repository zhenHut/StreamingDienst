using System.Security;
using System.Windows;
using System.Windows.Controls;

namespace StreamingDienst.HelperClass
{
    internal static class SecurePasswordHelper
    {
        public static readonly DependencyProperty BoundPasswordProperty =
            DependencyProperty.RegisterAttached(
                "BoundPassword",
                typeof(SecureString),
                typeof(SecurePasswordHelper),
                new PropertyMetadata(null, OnBoundPasswordChanged));

        public static SecureString GetBoundPassword(DependencyObject obj)
        {
            return (SecureString)obj.GetValue(BoundPasswordProperty);
        }

        public static void SetBoundPassword(DependencyObject obj, SecureString value)
        {
            obj.SetValue(BoundPasswordProperty, value);
        }
        public static void OnBoundPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if( d is PasswordBox passwordBox)
            {
                passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;
                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }
        }

        private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox passwordBox) 
            {
                SetBoundPassword(passwordBox, passwordBox.SecurePassword);
            }
        }
    }
}
