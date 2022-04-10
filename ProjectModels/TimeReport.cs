using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectModels
{
    public class TimeReport
    {
        [Key]
        public int Id { get; set; }
        public double HoursWorked { get; set; }

        [Range(1, 52, ErrorMessage = "Week number be between 1 and 52")]
        public int WeekNumber { get; set; }

        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public  Project Project { get; set; }
        public int ProjectId { get; set; }



    }
}
