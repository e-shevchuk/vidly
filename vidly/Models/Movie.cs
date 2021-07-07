using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace vidly.Models
{
    public class Movie
    {
        public string Name { get; set; }
        
        public int Id { get; set; }
        
        public Genre Genre { get; set; }
        
        public int GenreId { get; set; }
        
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }
        
        [Display(Name = "Added Date")]
        public DateTime? AddedDate { get; set; }
        [DefaultValue(0)]
        
        [Display(Name = "Number in Stock")]
        public int NumberInStock { get; set; }
    }
}
