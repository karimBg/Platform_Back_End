using System.ComponentModel.DataAnnotations;

namespace BackEndAuthProj.Models
{
    public enum Department
    {
        [Display(Name = "Software Development")]
        SoftwareDevelopment,
        Design,
        Marketing,
        HR,
        [Display(Name = "Business Development")]
        BusinessDevelopment,
        [Display(Name = "Server & Security")]
        ServerSecurity
    }
}
