using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectModels
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Project name is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Project name should be more than 3 characters")]
        public string ProjectName { get; set; }
       

    }
}
