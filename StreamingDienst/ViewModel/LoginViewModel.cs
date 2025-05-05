using StreamingDienst.Commands;
using StreamingDienst.Controls;
using StreamingDienst.StandardFenster;
using StreamingDienst.View;
using System.Net.Http;
using System.Security;
using System.Windows.Input;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;

namespace StreamingDienst.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        #region Constructor

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(async _ => await ExecuteLogin(), CanExecuteLogin);
            CloseCommand = new RelayCommand(ExecuteCloseWindow);
        }

        #endregion

        #region Fields

        private string _email= string.Empty;
        #endregion

        #region Properties
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
                (LoginCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }
        public SecureString SecurePassword { get; set; } = new SecureString();

        public bool LoginSuccesful { get; private set; }
        public ICommand LoginCommand { get; }

        public ICommand CloseCommand { get; }

        #endregion

        #region Methods

        private async Task ExecuteLogin()
        {

            var passwordFrombox = SecurePasswordBoxControl.SecureStringToString(SecurePassword);
            var loginUserdata = new
            {
                email = Email,
                password = passwordFrombox
            };

            var json = JsonSerializer.Serialize(loginUserdata);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using var client = new HttpClient();

            try
            {
                var response = await client.PostAsync("https:localhost:7016/api/auth/login", content);

                if (response.IsSuccessStatusCode)
                {
                    // Login erfolgreich
                    MessageBox.Show("Login erfolgreich", "Erfolg", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Nächstes Fenster öffnen
                    new UserData().Show();

                    // Loginfenster schließen
                    Application.Current.Windows[0]?.Close();
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Fehler: {error}", "Login fehlgeschlagen", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Verbindungsfehler: {ex.Message}", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private bool CanExecuteLogin(object parameter)
        {
            var canExecute = !string.IsNullOrWhiteSpace(Email) && SecurePassword != null && SecurePassword.Length > 0;
            return canExecute;
        }


        private void ExecuteCloseWindow(object parameter)
        {
            if (parameter is Window window)
            {
                window.Close();
            }
        }


        #endregion
    }
}
