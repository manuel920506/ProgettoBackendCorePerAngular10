using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace provaBackEnd.DTO
{
    public class ChangePasswordDTO
    {
        public string lastPassword { get; set; }
        public string newPassword { get; set; }
    }
}
