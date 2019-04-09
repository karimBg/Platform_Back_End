using BackendAuthProj.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndAuthProj.Models
{
    public class Job
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Title is Required")]
        [Display(Name = "Job Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Specify a Job Description")]
        [Display(Name = "Job Description")]
        [MinLength(25)]
        public string Description { get; set; }

        [Display(Name = "Job Responsibilities")]
        public string Responsibilities { get; set; }

        [Display(Name = "Required Qualifications")]
        public string Qualification { get; set; }

        [Required(ErrorMessage = "Specify an Application Procedure")]
        [Display(Name = "Application Procedures")]
        public string ApplicationProcedure { get; set; }

        [Required(ErrorMessage = "Specify an Opening Date")]
        [Display(Name = "Opening Date")]
        [DataType(DataType.Date)]
        public DateTime OpeningDate { get; set; }

        [Required(ErrorMessage = "Specify an Application Deadline")]
        [Display(Name = "Application Deadline")]
        [DataType(DataType.Date)]
        public DateTime ApplicationDeadline { get; set; }

        public string IdUserDb { get; set; }
    }
}
