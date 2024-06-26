using System;
using System.Collections.Generic;
using System.Text;

namespace LoginApp.Models
{
    public class Usuario
    {
		private string _nome;

		public string Nome
		{
			get { return _nome; }
			set { _nome = value; }
		}

		private string _login;

		public string Login
		{
			get { return _login; }
			set { _login = value; }
		}

		private string _senha;

		public string Senha
		{
			get { return _senha; }
			set { _senha = value; }
		}

		private TipoUsuario _tipo;

		public TipoUsuario Tipo
		{
			get { return _tipo; }
			set { _tipo = value; }
		}


	}

	public enum TipoUsuario
	{
		Comum = 0,
		Intermediario = 1,
		Admin = 2
	}
}
