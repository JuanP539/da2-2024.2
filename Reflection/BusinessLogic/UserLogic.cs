using Domain;
using IBusinessLogic;
using IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    class UserLogic : IUserLogic
    {
        private IUserRepository _userRepository;
        public UserLogic(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool IsTheCorrectUser(Guid userToken)
        {
            return _userRepository.ExistUserByToken(userToken);
        }
    }
}
