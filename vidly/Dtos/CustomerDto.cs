using System;
using System.ComponentModel.DataAnnotations;
using vidly.Models;

namespace vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        
        [MaxLength(255)]
        [Required(ErrorMessage = "Enter the Customer Name, please.")]
        public string Name { get; set; }
        
        public bool IsSubscribedToNewsletter { get; set; }
        
        [Required]
        public byte MembershipTypeId { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}