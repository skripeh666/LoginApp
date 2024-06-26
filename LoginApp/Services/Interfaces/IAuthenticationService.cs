using LoginApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoginApp.Services
{
    public interface IAuthenticationService
    {
        Usuario Authenticate(string username, string password);
    }
}
