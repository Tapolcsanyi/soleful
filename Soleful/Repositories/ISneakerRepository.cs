using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Soleful.Models;

namespace Soleful.Repositories
{
    public interface ISneakerRepository
    {
        List<Sneaker> GetAll();
        Sneaker GetSneakerById(int id);
    }
}
