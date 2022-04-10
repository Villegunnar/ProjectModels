using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectModels
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "First name is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "First name should be more than 3 characters")]
        public string FName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Last name should be more than 3 characters")]
        public string LName { get; set; }
        [Required(ErrorMessage = "Titel is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Titel should be more than 3 characters")]
        public string Titel { get; set; }

        

    }
}
