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

        [Required, MinLength(5)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime ExpirationDate { get; set; }
        public Department Department { get; set; }

        public string IdUserDb { get; set; }
    }
}
