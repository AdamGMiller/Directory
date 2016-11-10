using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Directory.Repository
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        [Required]
        public bool ActiveFlag { get; set; }
        public DateTime? Dob { get; set; }
        public string Interests { get; set; }
        public byte[] Photo { get; set; }
        [Timestamp]
        public Byte[] ConcurrencyToken { get; set; }

        [NotMapped]
        public int? Age
        {
            get
            {
                // calculate if date of birth is valid
                if (Dob.HasValue)
                {
                    DateTime today = DateTime.Today;
                    int age = today.Year - Dob.Value.Year; 
                    if (Dob > today.AddYears(-age))
                        age--;
                    return age;
                }
                return null;
            }
        }
    }
}