using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soleful.Models
{
    public class UserSneaker
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SneakerId { get; set; }
        public Sneaker sneaker { get; set; }
        public User user { get; set; }
    }
}
