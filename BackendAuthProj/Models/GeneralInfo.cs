
using BackendAuthProj.Data;

namespace BackEndAuthProj.Models
{
    public class GeneralInfo
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public string IdUserDb { get; set; }
    }
}
