using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieApp.Business.Services;
using MovieApp.Entity;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieShowtimeController : ControllerBase
    {
        MovieShowtimeService _movieShowtimeService;

        public MovieShowtimeController(MovieShowtimeService movieShowtimeService)
        {
            _movieShowtimeService = movieShowtimeService;
        }

        [HttpPost("RegisterMovieShowtime")]
        public IActionResult RegisterMovieShowime(MovieShowtimeModel movieShowtimeModel)
        {
            return Ok(_movieShowtimeService.RegisterMovieShowtime(movieShowtimeModel));
        }

        [HttpGet("GetAllMovieShowtimes")]
        public IActionResult GetAllMovieShowtimes()
        {
            return Ok(_movieShowtimeService.GetAllMovieShowtimes());
        }

        [HttpDelete("DeleteMovieShowtimeById")]
        public IActionResult DeleteMovieShowtimeById(int showId)
        {
            return Ok(_movieShowtimeService.DeleteMovieShowtime(showId));
        }

        [HttpPut("UpdateMovieShowtimeById")]
        public IActionResult UpdateMovieShowtime(MovieShowtimeModel movieShowtimeModel)
        {
            return Ok(_movieShowtimeService.UpdateMovieShowtime(movieShowtimeModel));
        }

        [HttpGet("GetMovieShowtimeById")]
        public IActionResult GetMovieShowtimeById(int showId)
        {
            return Ok(_movieShowtimeService.GetMovieShowimeById(showId));
        }

        [HttpGet("GetShowTimesAndDateForSpecificTheatreAndMovie")]
        public IActionResult GetShowTimesAndDateForSpecificTheatreAndMovie(int movieId)
        {
            return Ok(_movieShowtimeService.GetShowtimeForSpecificMovieAndTheatre(movieId));
        }
    }
}
