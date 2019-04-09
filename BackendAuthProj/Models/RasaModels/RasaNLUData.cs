using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAuthProj.Models.RasaModels
{
    public class RasaNLUData
    {
        [Display(Name = "common_examples")]
        public List<CommonExample> CommonExamples { get; set; }
    }
}
