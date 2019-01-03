using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace NumberOne.API.Models
{
    public class UserData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public static explicit operator UserData(EntityEntry<UserData> v)
        {
            throw new NotImplementedException();
        }
    }
}
