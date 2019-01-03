using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NumberTwo.API.Models;

namespace NumberTwo.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserImageController : ControllerBase
    {
        private readonly ImagesContext _userImageContext;

        public UserImageController(ImagesContext context)
        {
            _userImageContext = context ?? throw new ArgumentNullException(nameof(context));
            ((DbContext)context).ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            if (_userImageContext.UsersImages.ToList().Count == 0)
            {
                List<UserImage> uimages = new List<UserImage>();
                uimages.Add(new UserImage { Path = "C:\\Photo.jpg" });
                uimages.Add(new UserImage { Path = "C:\\Photo.jpg" });
                uimages.Add(new UserImage { Path = "C:\\Photo.jpg" });
                _userImageContext.UsersImages.AddRange(uimages);
                _userImageContext.SaveChanges();
            }
            var usersImages = _userImageContext.UsersImages.ToList();
            return Ok(usersImages);
        }


        [HttpPost]
        public async Task<IActionResult> Post(int userId, IFormFile file)
        {
            UserImage usersImages;
            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                string fileName = Guid.NewGuid().ToString() + extension; //Create a new Name for the file due to security reasons.
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageFiles", fileName);
                using (var bits = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(bits);
                    usersImages = _userImageContext.Add(new UserImage { Path = path, UserId = userId }).Entity;
                    _userImageContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(usersImages);
        }

        [HttpGet("file")]
        public HttpResponseMessage Generate()
        {
            var stream = new MemoryStream();
            // processing the stream.

            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(stream.ToArray())
            };
            result.Content.Headers.ContentDisposition =
                new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                {
                    FileName = "qwe.jpg"
                };
            result.Content.Headers.ContentType =
                new MediaTypeHeaderValue("application/octet-stream");

            return result;
        }


        [HttpGet("image")]
        public IActionResult GetImage(string path)
        {
            if (!String.IsNullOrEmpty(path))
            {
                return File(System.IO.File.ReadAllBytes(path), "image/jpeg");
            }
            return BadRequest();
        }

    }
}