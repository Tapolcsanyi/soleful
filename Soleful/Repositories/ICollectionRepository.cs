using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Soleful.Models;

namespace Soleful.Repositories
{
    public interface ICollectionRepository
    {
        List<Collection> GetAll();
        Collection GetCollectionById(int id);
        List<Collection> GetCollectionByUserId(int id);
        void Add(Collection collection);
        void Delete(int id);
        void Update(Collection collection);
    }
}
