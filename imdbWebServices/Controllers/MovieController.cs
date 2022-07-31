using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using imdbDBFirstDataAccessLayer;
using imdbDBFirstDataAccessLayer.Models;

namespace imdbWebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        imdbRepository repository;
        public MovieController()
        {
            repository = new imdbRepository();
        }

        [HttpGet]
        public JsonResult GetAllMovies()
        {
            List<Movie> movie = new List<Movie>();
            try
            {
                movie = repository.GetAllMovies();
            }
            catch
            {
                movie = null;
            }
            return Json(movie);
        }

        [HttpPost]
        public JsonResult AddMoviesUsingParams(string movieId, string movieName, DateTime releaseDate, string genreId, string actorId, string producerId)
        {
            bool status = false;
            string message;
            try
            {
                status = repository.AddMovie(movieId, movieName, releaseDate, genreId, actorId, producerId);
                if (status) message = "Movie Addition was Successful";
                else message = "Unsuccessful addition operation!";
            }
            catch(Exception ex)
            {
                message = "Some error occurred, Error Message - "+ex.Message;
            }
            return Json(message);
        }

        [HttpPut]
        public JsonResult EditMoviesUsingParams(string movieId, string movieName, DateTime releaseDate, string genreId, string actorId, string producerId)
        {
            bool status = false;
            string message;
            try
            {
                status = repository.EditMovie(movieId, movieName, releaseDate, genreId, actorId, producerId);
                if (status) message = "Movie details edited Successful";
                else message = "Unsuccessful edition operation!";
            }
            catch (Exception ex)
            {
                message = "Some error occurred, Error Message - " + ex.Message;
            }
            return Json(message);
        }

        [HttpDelete]
        public JsonResult DeleteMovie(string movieId)
        {
            bool status = false;
            try
            {
                status = repository.DeleteMovie(movieId);
            }
            catch(Exception ex)
            {
                status = false;
            }
            return Json(status);
        }
    }
}
