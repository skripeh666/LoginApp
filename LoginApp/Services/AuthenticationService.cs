using LoginApp.Models;
using System.Linq;

namespace LoginApp.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public Usuario Authenticate(string login, string senha)
        {
            
            var encryptedPassword = Md5Helper.Encrypt(senha);
            return new UserRepository().Usuarios.FirstOrDefault(u => u.Login == login && u.Senha == encryptedPassword);
        }
    }
}
