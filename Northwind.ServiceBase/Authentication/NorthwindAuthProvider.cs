using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.Web;
using System.Web.Security;
using ServiceStack;
using ServiceStack.Auth;
using Northwind.Common;
using Northwind.Data;
using Northwind.Data.Model;
using Northwind.Data.Repositories;

namespace Northwind.ServiceBase.Authentication
{
    /// <summary>
    /// Clase de servicio de autenticación
    /// </summary>
    public class NorthwindAuthProvider : BasicAuthProvider 
    {
        private string _fullName = String.Empty;        

        /// <summary>
        /// Verificación de credenciales
        /// </summary>
        /// <param name="authService">Servicio que solicita la autenticación</param>
        /// <param name="userName">Usuario</param>
        /// <param name="password">Password</param>
        /// <returns>true si la verificación es correcta. En caso contrario, false.</returns>
        public override bool TryAuthenticate(IServiceBase authService, string userName, string password)
        {
            var userRepo = HostContext.TryResolve<IUserEntityRepository>();

            if (userRepo != null)
            {
                var user = userRepo.Get(userName, password);

                if (user != null)
                {
                    _fullName = user.FullName;
                    return true;
                }                
            }

            return false;
        }

        /// <summary>
        /// Método que se ejecuta cuando se ha autenticado con éxito
        /// </summary>
        /// <param name="authService">Servicio que solicita la autenticación</param>
        /// <param name="session">Información de sesión</param>
        /// <param name="tokens">Tokets</param>
        /// <param name="authInfo">Información de autenticación</param>
        /// <returns></returns>
        public override IHttpResult OnAuthenticated(IServiceBase authService, IAuthSession session, IAuthTokens tokens, Dictionary<string, string> authInfo)
        {
            session.FirstName = _fullName;

            authService.SaveSession(session);

            return null;
        }
        
    }
}
