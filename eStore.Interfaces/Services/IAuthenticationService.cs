using System;
using eStore.Domain.Security;

namespace eStore.Interfaces.Services
{
    public interface IAuthenticationService
    {
        bool LogOn(string user, string password, bool rememberMe);
        void LogOff();

        void Register(string user, string password, string role);
    }
}
