using StreamingDienst.Commands;
using StreamingDienst.Services;
using StreamingDienst.View;
using System.Security;
using System.Windows;
using System.Windows.Input;

namespace StreamingDienst.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        #region Constructor

        public LoginViewModel()
        {
            _authService = new AuthService();
            PasswordChangedCommand = new RelayCommand<SecureString>(ExecutePasswordChanged);
            LoginCommand = new RelayCommand(async _ => await ExecuteLogin(), CanExecuteLogin);
            CloseCommand = new RelayCommand(ExecuteCloseWindow);
            //RegistrationCommand = new RelayCommand()

        }

        #endregion

        #region Fields

        private readonly IAuthService _authService;

        private string _email = string.Empty;
        #endregion

        #region Properties
        public string Email
        {
            get => _email;
            set
            {
                if (_email == value)
                    return;

                _email = value;
                OnPropertyChanged();
                (LoginCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }

        private SecureString _securePassword;

        public SecureString SecurePassword
        {
            get => _securePassword;
            set
            {
                if (SetProperty(ref _securePassword, value))
                    (LoginCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }

        public bool LoginSuccesful { get; private set; }

        public ICommand LoginCommand { get; }

        public ICommand CloseCommand { get; }

        public ICommand PasswordChangedCommand { get; }

        public ICommand RegistrationCommand {  get; }

        #endregion

        #region Methods

        private async Task ExecuteLogin()
        {
            var success = await _authService.LoginAsync(Email, SecurePassword);

            if (success)
            {
                new UserData().Show();
                Application.Current.Windows[0]?.Close();
            }
        }

        private bool CanExecuteLogin(object? parameter)
        {
            var canExecute = !string.IsNullOrWhiteSpace(Email) && SecurePassword != null && SecurePassword.Length > 0;
            return canExecute;
        }

        private void ExecuteCloseWindow(object? parameter)
        {
            if (parameter is Window window)
            {
                window.Close();
            }
        }

        private void ExecutePasswordChanged(SecureString secPassword)
        {
            SecurePassword = secPassword;
        }
    
        private void ExecuteRegistration(object? parameter)
        {

        }
        #endregion
    }
}
