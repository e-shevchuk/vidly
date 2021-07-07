using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Enter the Customer Name, please.")]
        [MaxLength(255)]
        public string Name { get; set; }
        
        public bool IsSubscribedToNewsletter { get; set; }
        
        public MembershipType MembershipType { get; set; }
        
        [Display(Name = "Membership Type")]
        [Required]
        public byte MembershipTypeId { get; set; }
        
        [Display(Name = "Date of Birth")]
        public DateTime? BirthDate { get; set; }
    }
}
