using Cw6.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw6.Handlers
{
    public class RefreshTokenCreator
    {
        public static Guid CreateRefreshToken(IDbService dbService, string login)
        {
            var refreshToken = Guid.NewGuid();
            dbService.SaveToken(login, refreshToken.ToString());
            return refreshToken; 
        }

    }
}
