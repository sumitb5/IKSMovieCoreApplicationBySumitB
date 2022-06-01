using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.UI.Controllers
{
    public class MovieShowtimeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
