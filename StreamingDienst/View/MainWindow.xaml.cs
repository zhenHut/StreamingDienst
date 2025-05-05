using StreamingDienst.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace StreamingDienst.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new LoginViewModel();
            DataContext = _viewModel;
        }

        #endregion

        #region Fields

        private readonly LoginViewModel _viewModel;

        #endregion

        #region Methods 

        //private void BtnAnmelden_Click(object sender, RoutedEventArgs e)
        //{
        //    _viewModel.SecurePassword = SecurePassWordBox.SecurePassword;
        //}

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton is MouseButtonState.Pressed )
                this.DragMove();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}