using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Soleful.Models;

namespace Soleful.Repositories
{
    public interface IUserSneakerRepository
    {
        List<UserSneaker> GetUserSneakerByUserId(int id);
        List<UserSneaker> GetAllUserSneaker();
        void Add(UserSneaker sneaker);
        void Delete(int id);
    }
}
