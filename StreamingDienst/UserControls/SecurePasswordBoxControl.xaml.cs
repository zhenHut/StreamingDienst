using System.Runtime.InteropServices;
using System.Security;
using System.Windows;
using System.Windows.Controls;

namespace StreamingDienst.Controls
{
    /// <summary>
    /// Interaktionslogik für PasswordBoxControl.xaml
    /// </summary>
    public partial class SecurePasswordBoxControl : UserControl
    {
        #region Constructor
        public SecurePasswordBoxControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Fields
        private bool _isPasswordVisible = false;

        #endregion

        #region Dependency Property
        public static readonly DependencyProperty SecurePasswordPropertyKey = 
            DependencyProperty.Register(nameof(SecurePassword),typeof(SecureString), typeof(SecurePasswordBoxControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        #endregion

        #region Property
        public SecureString SecurePassword
        {
            get { return (SecureString)GetValue(SecurePasswordPropertyKey); } 
            set { SetValue(SecurePasswordPropertyKey, value); }
        }

        #endregion

        #region Methods
        private void PwdBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            SecurePassword = PwdBox.SecurePassword;

            if (!_isPasswordVisible)
            {
                TxtVisible.Text = SecureStringToString(PwdBox.SecurePassword);
            }
        }

        public static string SecureStringToString(SecureString value)
        {
            IntPtr bstr = Marshal.SecureStringToBSTR(value);
            try
            {
                return Marshal.PtrToStringBSTR(bstr);
            }
            finally
            {
                Marshal.ZeroFreeBSTR(bstr);
            }
        }

        #endregion


        #region EventMethods
        private void BntToggleVisibility_Click(object sender, RoutedEventArgs e)
        {
            _isPasswordVisible = !_isPasswordVisible;

            if (_isPasswordVisible) 
            {
                TxtVisible.Text = SecureStringToString(PwdBox.SecurePassword);
                TxtVisible.Visibility = Visibility.Visible;
                PwdBox.Visibility = Visibility.Collapsed;
                BtnToggleVisibility.Content = "🙈";
            }
            else
            {
                PwdBox.Visibility = Visibility.Visible;
                TxtVisible.Visibility = Visibility.Collapsed;
                BtnToggleVisibility.Content = "👁️";
            }
        }

        #endregion

    }
}
