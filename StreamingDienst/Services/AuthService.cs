using StreamingDienst.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using StreamingDienst.Shared.Dtos;
using Shared;
using System.Text.Json;
using System.Net.Http;
using System.Windows;

namespace StreamingDienst.Services
{
    public class AuthService : IAuthService
    {
        #region Constructor

        public AuthService() 
        {
            _httpClient = new HttpClient();
        }

        #endregion

        #region Fields

        private readonly HttpClient _httpClient;
        #endregion

        #region Methods

        public async Task<bool> LoginAsync(string email, SecureString securePassword)
        {
            var password = SecurePasswordBoxControl.SecureStringToString(securePassword);

            var loginData = new LoginDto()
            {
                Email = email,
                Password = password
            };

            var json = JsonSerializer.Serialize(loginData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync("https://localhost:7016/api/auth/login", content);

                if (response.IsSuccessStatusCode)
                    return true;

                var error = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Fehler: {error}", "Login fehlgeschlagen", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Verbindungsfehler: {ex.Message}", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);   
                return false;
            }

        }

        #endregion
    }
}
