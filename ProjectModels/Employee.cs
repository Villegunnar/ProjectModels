using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectModels
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Titel { get; set; }

    }
}
