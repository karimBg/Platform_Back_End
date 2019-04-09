using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAuthProj.Models.RasaModels
{
    public class CommonExample
    {
        [Display(Name = "text")]
        public string Text { get; set; }

        [Display(Name = "intent")]
        public string Intent { get; set; }

        [Display(Name = "entities")]
        public List<Entity> Entities { get; set; }
    }
}
