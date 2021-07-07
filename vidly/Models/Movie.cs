using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using Microsoft.CodeAnalysis;

namespace vidly.Models
{
    public class Movie
    {
        [Required]
        public string Name { get; set; }
        
        public int Id { get; set; }
        
        public Genre Genre { get; set; }
        
        [Required(ErrorMessage = "Pick the Genre, please.")]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }
        
        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }
        
        [Required]
        [Display(Name = "Added Date")]
        public DateTime? AddedDate { get; set; }
        [DefaultValue(0)]
        
        [Display(Name = "Number in Stock")]
        [Range(1, 20, ErrorMessage="Number in Stock should be between 1 and 20.")]
        public int NumberInStock { get; set; }
    }
}
