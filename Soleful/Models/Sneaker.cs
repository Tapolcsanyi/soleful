using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soleful.Models
{
    public class Sneaker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Gender { get; set; }
        public string Colorway { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int RetailPrice { get; set; }
        public string Shoe { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Image { get; set; }
    }
}
