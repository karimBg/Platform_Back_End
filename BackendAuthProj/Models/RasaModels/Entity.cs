using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAuthProj.Models.RasaModels
{
    public class Entity
    {
        [Display(Name = "start")]
        public int Start { get; set; }

        [Display(Name = "end")]
        public int End { get; set; }

        [Display(Name = "value")]
        public string Value { get; set; }

        public string entity { get; set; }
    }
}
