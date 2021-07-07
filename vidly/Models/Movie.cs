using System;
using System.ComponentModel;

namespace vidly.Models
{
    public class Movie
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime? AddedDate { get; set; }
        [DefaultValue(0)]
        public int NumberInStock { get; set; }
    }
}
