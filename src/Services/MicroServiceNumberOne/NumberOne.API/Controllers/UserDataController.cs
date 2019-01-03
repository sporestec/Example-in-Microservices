using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NumberOne.API.Models;

namespace NumberOne.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]

    public class UserDataController : Controller
    {
        private readonly UserDataContext _userDataContext;

        public UserDataController(UserDataContext context)
        {
            _userDataContext = context ?? throw new ArgumentNullException(nameof(context));
            ((DbContext)context).ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (_userDataContext.Users.ToList().Count == 0)
            {
                List<UserData> udata = new List<UserData>();
                udata.Add(new UserData { Email = "ahmet@gmail.com", Name = "Ahmet", Password = "sifre" });
                udata.Add(new UserData { Email = "tarik@gmail.com", Name = "Tarik", Password = "sifre" });
                udata.Add(new UserData { Email = "veli@gmail.com", Name = "Veli", Password = "sifre" });
                udata.Add(new UserData { Email = "ali@gmail.com", Name = "Ali", Password = "sifre" });
                _userDataContext.Users.AddRange(udata);
                _userDataContext.SaveChanges();
            }
            var usersData = _userDataContext.Users.ToList();
            return Ok(usersData);
        }


        [HttpPost]
        public IActionResult Post([FromBody] UserData udata)
        {
            var userData = _userDataContext.Add(udata).Entity;
            _userDataContext.SaveChanges();
            if (userData != null && userData.Id > 0)
            {
                return Ok(userData.Id);
            }
            return BadRequest();
        }

    }
}