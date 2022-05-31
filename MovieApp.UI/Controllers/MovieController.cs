using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MovieApp.Entity;
using System.Text;
using Newtonsoft.Json;

namespace MovieApp.UI.Controllers
{
    public class MovieController : Controller
    {
        IConfiguration _iConfiguration;

        public MovieController(IConfiguration configuration)
        {
            _iConfiguration = configuration;
        }
        public async Task<IActionResult> ShowMovieDetails()
        {
            using(HttpClient client = new HttpClient())
            {
                string endpoint = _iConfiguration["WebApiUrl"] + "User/GetMovies";
                using(var response= await client.GetAsync(endpoint))
                {
                    if(response.StatusCode== System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var movieModel = JsonConvert.DeserializeObject<List<MovieModel>>(result);
                        return View(movieModel);
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Cannot fetch any data";
                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> Register(MovieModel movieModel)
        {
            using(HttpClient client= new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(movieModel), Encoding.UTF8, "application/json");
                string endpoint = _iConfiguration["WebApiUrl"] + "Movie/RegisterMovie";
                using(var reponse= await client.PostAsync(endpoint,content))
                {
                    if(reponse.StatusCode== System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Registration Successful";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Registration Unsuccessful";
                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> UpdateMovie(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _iConfiguration["WebApiUrl"] + "Movie/GetMovieById?id=" + id;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var userModel = JsonConvert.DeserializeObject<MovieModel>(result);
                        return View(userModel);
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Cant fetch any data";
                    }
                }
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateMovie(MovieModel movieModel)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(movieModel), Encoding.UTF8, "application/json");
                string endpoint = _iConfiguration["WebApiUrl"] + "Movie/UpdateMovie";
                using (var response = await client.PutAsync(endpoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Updation Successful";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Updation Unsuccessful";
                    }
                }
            }
            return View();
        }


        public async Task<IActionResult> DeleteMovie(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _iConfiguration["WebApiUrl"] + "Movie/GetMovieById?id=" + id;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var userModel = JsonConvert.DeserializeObject<MovieModel>(result);
                        return View(userModel);
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Cant fetch any data";
                    }
                }
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> DeleteMovie(MovieModel movieModel)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(movieModel), Encoding.UTF8, "application/json");
                string endpoint = _iConfiguration["WebApiUrl"] + "Movie/DeleteMovie?id=" + movieModel.Id;
                using (var response = await client.PutAsync(endpoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Deletion Successful";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Deletion Unsuccessful";
                    }
                }
            }
            return View();
        }
    }
}
