using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace vidly.Dtos
{
    public class MovieDto
    {
        [Required]
        public string Name { get; set; }
        
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Pick the Genre, please.")]
        public int GenreId { get; set; }
        
        [Required]
        public DateTime? ReleaseDate { get; set; }
        
        [Required]
        public DateTime? AddedDate { get; set; }
        [DefaultValue(0)]
        
        [Range(1, 20, ErrorMessage="Number in Stock should be between 1 and 20.")]
        public int NumberInStock { get; set; }
    }
}