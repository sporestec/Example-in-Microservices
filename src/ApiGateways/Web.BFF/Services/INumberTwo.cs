using NumberOne.API.Models;
using NumberTwo.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.BFF.Services
{
    public interface INumberTwo
    {
        Task<UsersImages> GetAll();
        Task<UsersImages> AddUserImage(UsersImages userImage);
    }
}
