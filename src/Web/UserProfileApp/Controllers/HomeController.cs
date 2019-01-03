using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NumberOne.API.Models;
using NumberTwo.API.Models;
using UserProfileApp.Models;
using UserProfileApp.ViewModels;

namespace UserProfileApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            MultiModel multiModel = new MultiModel();
            multiModel.userData = getUsersData();
            multiModel.usersImages = getUsersImages();
            return View(multiModel);
        }


        private List<UserData> getUsersData()
        {
            List<UserData> ulist = new List<UserData>();
            try
            {
                string URL = "http://172.29.0.6:80/userdata";
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(URL);
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("").Result;
                if (response.IsSuccessStatusCode)
                {
                    ulist = response.Content.ReadAsAsync<IEnumerable<UserData>>().Result.ToList();
                }
                client.Dispose();
            }
            catch (Exception ex)
            {
                //ex.message
            }
            return ulist;
        }

        private List<UserImage> getUsersImages()
        {
            List<UserImage> imageList = new List<UserImage>();
            try
            {
                string URL = "http://172.29.0.7:80/userimage";
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(URL);
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("").Result;
                if (response.IsSuccessStatusCode)
                {
                    imageList = response.Content.ReadAsAsync<IEnumerable<UserImage>>().Result.ToList();
                }
                client.Dispose();
            }
            catch (Exception)
            {
                //ex
            }
            return imageList;
        }

        public IActionResult AddUser()
        {
            return View();
        }


        public async Task<int> postUserData(UserData userData)
        {
            //send user data
            string URL = "http://172.29.0.6:80/userdata";
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PostAsync<UserData>(URL
                , userData
            , new JsonMediaTypeFormatter());
            var contents = await response.Content.ReadAsStringAsync();
            return Convert.ToInt32(contents);
        }


        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel model)
        {
            int userId = await postUserData(new UserData
            {
                Name = model.Name,
                Email = model.Email,
                Password = model.Password
            });

            //send the image
            string URL = "http://172.29.0.7:80/userimage";
            var client = new HttpClient();
            var content = new MultipartFormDataContent();
            content.Add(new StreamContent(model.Image.OpenReadStream())
            {
                Headers =
                    {
                        ContentLength = model.Image.Length,
                        ContentType = new MediaTypeHeaderValue(model.Image.ContentType)
                    }
            }, "File", model.Image.FileName);

            var response = await client.PostAsync($"{URL}?userId={userId}", content);
            var fileName = ContentDispositionHeaderValue.Parse(model.Image.ContentDisposition).FileName.Trim('"');
            client.Dispose();
            return RedirectToAction("Index", "Home");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
}
