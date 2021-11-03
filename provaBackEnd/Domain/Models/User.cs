using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace provaBackEnd.Domain.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName ="varchar(20)")]
        public string UserNAme { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Password { get; set; }
    }
}
