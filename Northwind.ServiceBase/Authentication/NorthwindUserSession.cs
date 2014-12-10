using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack;
using ServiceStack.Auth;

namespace Northwind.ServiceBase.Authentication
{
    /// <summary>
    /// Clase que representa una sesión de usuario
    /// </summary>
    public class NorthwindUserSession : AuthUserSession
    {
        /// <summary>
        /// Método que se ejecuta cuando se ha autenticado con éxito
        /// </summary>
        /// <param name="authService">Servicio que solicita la autenticación</param>
        /// <param name="session">Información de sesión</param>
        /// <param name="tokens">Tokets</param>
        /// <param name="authInfo">Información de autenticación</param>
        /// <returns></returns>
        public override void OnAuthenticated(IServiceBase authService, IAuthSession session, IAuthTokens tokens, Dictionary<string, string> authInfo)
        {            
            authService.SaveSession(session);
        }
    }
}
