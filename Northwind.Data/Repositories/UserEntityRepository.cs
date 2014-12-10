#region Licencia
/*
   Copyright 2013 Juan Diego Martinez

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

     http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.

*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.OrmLite;
using Northwind.Data.Model;
using ServiceStack.Data;

namespace Northwind.Data.Repositories
{
    /// <summary>
    /// Clase que representa un repositorio de entidades <see cref="CategoryEntity"/>
    /// </summary>
    public class UserEntityRepository : Repository<UsersEntity>, IUserEntityRepository
    {
        public UserEntityRepository(IDbConnectionFactory dbFactory)
            : base(dbFactory)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UsersEntity Get(string userName, string password)
        {
            using (var db = dbFactory.OpenDbConnection())
            {
                return db.Single<UsersEntity>(u => u.UserName == userName && u.Password == password);
            }
        }
    }
}
