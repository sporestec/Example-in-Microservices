using NumberOne.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.BFF.Services
{
    public interface INumberOne
    {
        Task<IEnumerable<UserData>> GetAll();
        Task<UserData> AddUser(UserData user);
    }
}
