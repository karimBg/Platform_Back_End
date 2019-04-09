using BackendAuthProj.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndAuthProj.Models
{
    public class Internship
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Department Department { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Degree Degree { get; set; }
        public int Period { get; set; }
        public string Description { get; set; }

        public string IdUserDb { get; set; }
    }
}
