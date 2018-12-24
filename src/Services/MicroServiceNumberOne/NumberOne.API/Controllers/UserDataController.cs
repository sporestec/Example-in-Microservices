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
    [Route("api/v1/[controller]")]

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
            var items = _userDataContext.Users.ToList();
            return Ok(items);
        }
    }
}