using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name {get; set;}
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Stock { get; set; }
        public string ReleaseDate { get; set; }
        public string DateAdded { get; set; }
    }
}
