using StreamingDienst.ViewModel;
using System.Security;

namespace StreamingDienst.Tests
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void Login_Succesful_When_Username_and_Password_Proviced()
        {
            // Arrange
            var vm = new LoginViewModel
            {
                Email = "TestUser",
                SecurePassword = CreateSecureString("123456")
            };


            // Act
            vm.LoginCommand.Execute(null);

            // Assert
            Assert.IsTrue(vm.LoginSuccesful);
        }

        private SecureString CreateSecureString(string plain)
        {
            var secure = new SecureString();
            foreach(char c in plain) secure.AppendChar(c);
            secure.MakeReadOnly();
            return secure;
        }
    }
}
