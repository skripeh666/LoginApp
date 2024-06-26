using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Windows.Input;
using LoginApp.Models;

namespace LoginApp.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private string _nome;
        private string _login;
        private string _senha;
        private int _tipo;

        public string Nome
        {
            get => _nome;
            set => SetProperty(ref _nome, value);
        }

        public string Login
        {
            get => _login;
            set => SetProperty(ref _login, value);
        }

        public string Senha
        {
            get => _senha;
            set => SetProperty(ref _senha, value);
        }

        public int Tipo
        {
            get => _tipo;
            set => SetProperty(ref _tipo, value);
        }

        private ObservableCollection<Usuario> _usuarios;

        public ObservableCollection<Usuario> Usuarios
        {
            get => _usuarios;
            set => SetProperty(ref _usuarios, value);
        }

        public ICommand AddUsuarioCommand { get; }
        public ICommand RemoveUsuarioCommand { get; }

        public MainPageViewModel()
        {
            Usuarios = new UserRepository().Usuarios;
            AddUsuarioCommand = new DelegateCommand(AddUsuario);
            RemoveUsuarioCommand = new DelegateCommand<Usuario>(RemoveUsuario);
        }

        private void AddUsuario()
        {
            Usuarios.Add(new Usuario { Nome = Nome, Login = Login, Senha = Senha, Tipo = (TipoUsuario)Tipo });
        }

        private void RemoveUsuario(Usuario usuario)
        {
            if (Usuarios.Contains(usuario))
            {
                Usuarios.Remove(usuario);
            }
        }
    }
}
