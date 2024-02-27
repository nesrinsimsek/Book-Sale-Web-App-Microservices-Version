using AuthenticationDataAccess.Abstract;
using AuthenticationDataAccess.Context;
using AuthenticationEntity.Entities;
using EFRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationDataAccess.Concrete
{
    public class UserDal : EntityRepository<User, UserDbContext>, IUserDal
    {
    }
}
