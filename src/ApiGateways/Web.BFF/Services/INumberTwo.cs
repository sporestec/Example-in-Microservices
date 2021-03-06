﻿using NumberOne.API.Models;
using NumberTwo.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.BFF.Services
{
    public interface INumberTwo
    {
        Task<UserImage> GetAll();
        Task<UserImage> AddUserImage(UserImage userImage);
    }
}
