using DataAccess.Context;
using Domain;
using IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MovieContext _moviesContext;

        public UserRepository(MovieContext moviesContext)
        {
            _moviesContext = moviesContext;
        }
        public bool ExistUserByToken(Guid userToken)
        {
            return _moviesContext.Users.Any(u => u.Token == userToken);
        }
    }
}
