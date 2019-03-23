using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAuthProj.Models.RasaModels
{
    public class NLUData
    {
        [Display(Name = "rasa_nlu_data")]
        public RasaNLUData rasaNLUData { get; set; }
    }
}
