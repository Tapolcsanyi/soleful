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
    }
}
