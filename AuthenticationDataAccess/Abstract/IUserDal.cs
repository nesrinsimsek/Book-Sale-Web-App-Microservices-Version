using AuthenticationEntity.Entities;
using EFRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationDataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
    }
}
