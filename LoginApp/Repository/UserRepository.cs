using LoginApp.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

public class UserRepository
{
    public ObservableCollection<Usuario> Usuarios = new ObservableCollection<Usuario> {
        new Usuario { Nome = "User Comum", Login = "comum", Senha = Md5Helper.Encrypt("senha123"), Tipo = TipoUsuario.Comum },
        new Usuario { Nome = "User Intermediario", Login = "intermediario", Senha = Md5Helper.Encrypt("senha123"), Tipo = TipoUsuario.Intermediario },
        new Usuario { Nome = "Admin", Login = "admin", Senha = Md5Helper.Encrypt("senha123"), Tipo = TipoUsuario.Admin }
    };
}