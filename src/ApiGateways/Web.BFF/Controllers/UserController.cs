using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NumberOne.API.Models;
using Web.BFF.Services;

namespace Web.BFF.Controllers
{
    [Route("api/v1/[controller]")]
    public class UserController : Controller
    {
        private readonly INumberOne _numberOne;

        public UserController(INumberOne numberOne)
        {
            _numberOne = numberOne;
        }


        // GET api/v1/user
        [HttpGet]
        public async Task<IEnumerable<UserData>> Get()
        {
            return await _numberOne.GetAll();
        }
    }
}