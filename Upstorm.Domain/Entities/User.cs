using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upstorm.Domain.Commons;
using Upstorm.Domain.Enums;

namespace Upstorm.Domain.Entities
{
    public class User : Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public string LookingCity { get; set; }
        public string? LookingWeekDay { get; set; }
    }
}
