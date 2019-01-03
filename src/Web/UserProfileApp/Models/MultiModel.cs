using NumberOne.API.Models;
using NumberTwo.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserProfileApp.Models
{
    public class MultiModel
    {
        public List<UserData> userData { get; set; }
        public List<UserImage> usersImages { get; set; }
    }
}
