// <copyright file="Person.cs" company="Adam Miller">
// Copyright (c) Adam Miller. All rights reserved.
// </copyright>

namespace Directory.Repository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;

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
        public byte[] ConcurrencyToken { get; set; }

        [NotMapped]
        public int? Age
        {
            get
            {
                // calculate if date of birth is valid
                if (this.Dob.HasValue)
                {
                    DateTime today = DateTime.Today;
                    int age = today.Year - this.Dob.Value.Year;
                    if (this.Dob > today.AddYears(-age))
                    {
                        age--;
                    }

                    return age;
                }

                return null;
            }
        }
    }
}