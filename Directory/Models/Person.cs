using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

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
        public DateTime Dob { get; set; }
        public string Interests { get; set; }
        public byte[] Photo { get; set; }
        [Timestamp]
        public Byte[] ConcurrencyToken { get; set; }
    }
}