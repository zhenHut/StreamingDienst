using System.Runtime.InteropServices;
using System.Security;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace StreamingDienst.UserControls
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

        public static readonly DependencyProperty SecurePasswordChangeCommandProperty =
            DependencyProperty.Register(nameof(SecurePasswordChangedCommand),
                typeof(ICommand),
                typeof(SecurePasswordBoxControl),
                new PropertyMetadata(null));
        #endregion

        #region Events
        //public static readonly RoutedEvent SecurePasswordChangedEvent =
        //    EventManager.RegisterRoutedEvent(nameof(SecurePasswordChanged),
        //        RoutingStrategy.Bubble,
        //        typeof(RoutedEventHandler), typeof(SecurePasswordBoxControl));

        #endregion

        #region EventHandler
        //public event RoutedEventHandler SecurePasswordChanged
        //{
        //    add => AddHandler(SecurePasswordChangedEvent, value);
        //    remove => RemoveHandler(SecurePasswordChangedEvent, value);
        //}

        #endregion

        #region Property

        public SecureString SecurePassword => PwdBox.SecurePassword.Copy();

        public ICommand SecurePasswordChangedCommand
        {
            get => (ICommand)GetValue(SecurePasswordChangeCommandProperty);
            set => SetValue(SecurePasswordChangeCommandProperty, value);
        }

        #endregion

        #region Methods

        public static string SecureStringToString(SecureString secure)
        {
            if (secure == null)
                return string.Empty;

            IntPtr bstr = IntPtr.Zero;

            try
            {
                bstr = Marshal.SecureStringToBSTR(secure);
                return Marshal.PtrToStringBSTR(bstr);
            }
            finally
            {
                if (bstr != IntPtr.Zero)
                    Marshal.ZeroFreeBSTR(bstr);
            }
        }

        #endregion


        #region Event Methods


        private void PwdBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!_isPasswordVisible)
            {
                TxtVisible.Text = SecureStringToString(PwdBox.SecurePassword);
            }

            if (SecurePasswordChangedCommand?.CanExecute(null) == true)
                SecurePasswordChangedCommand.Execute(SecurePassword);
        }

        #endregion

        /// <summary>
        /// Dient zur Anzeige des Passworts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region Button Methods
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
