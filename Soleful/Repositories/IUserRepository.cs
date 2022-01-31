using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Soleful.Models;

namespace Soleful.Repositories
{
    public interface IUserRepository
    {
        void Add(User userProfile);
        User GetByFirebaseUserId(string firebaseUserId);
        List<User> GetAll();
        User GetUserById(int id);
    }
}
