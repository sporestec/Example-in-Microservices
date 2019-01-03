using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NumberTwo.API.Models
{
    public class UserImage
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string  Path { get; set; }
    }
}
