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
        public string ProjectName { get; set; }

    }
}
