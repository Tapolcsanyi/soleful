using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Soleful.Models;

namespace Soleful.Repositories
{
    public interface IListSneakerRepository
    {
        List<ListSneaker> GetListSneakerByListId(int id);
        List<ListSneaker> GetAll();
        void Add(ListSneaker sneaker);
        void Delete(int id);
    }
}
