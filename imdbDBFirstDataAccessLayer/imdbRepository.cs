using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using imdbDBFirstDataAccessLayer.Models;

namespace imdbDBFirstDataAccessLayer
{
    public class imdbRepository
    {
        imdbContext context;
        public imdbRepository()
        {
            context = new imdbContext();
        }

        //1. List all movies
        public List<Movie> GetAllMovies()
        {
            var movieList = (from movie
                             in context.Movies
                             orderby movie.MovieId
                             select movie).ToList();
            return movieList;
        }

        //2. Add movie
        public bool AddMovie(string movieId, string movieName, DateTime releaseDate, string genreId, string actorId, string producerId)
        {
            bool status = false;
            Movie movie = new Movie();
            movie.MovieId = movieId;
            movie.MovieTitle = movieName;
            movie.ReleaseDate = releaseDate;
            movie.GenereId = genreId;
            movie.ActorId = actorId;
            movie.ProducerId = producerId;
            try
            {
                context.Add<Movie>(movie);
                context.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        //3. Edit Movie

        public bool EditMovie(string movieId, string movieName, DateTime releaseDate, string genreId, string actorId, string producerId)
        {
            bool status = false;
            Movie movie = context.Movies.Find(movieId);
            try
            {
                if (movie != null)
                {
                    movie.MovieTitle = movieName;
                    movie.ReleaseDate = releaseDate;
                    movie.GenereId = genreId;
                    movie.ActorId = actorId;
                    movie.ProducerId = producerId;

                    context.SaveChanges();
                    status = true;
                }
                else status = false;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        //4. Add Actor
        public bool AddActor(string actorId, string actorName)
        {
            bool status = false;
            Actor actor = new Actor();
            actor.ActorId= actorId;
            actor.ActorName = actorName;            
            try
            {
                context.Add<Actor>(actor);
                context.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        //4. Add Producer
        public bool AddProducer(string producerId, string producerName)
        {
            bool status = false;
            Producer producer = new Producer();
            producer.ProducerId = producerId;
            producer.ProducerName = producerName;
            try
            {
                context.Add<Producer>(producer);
                context.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        //5. Delete Movie
        public bool DeleteMovie(string movieId)
        {
            Movie movie = null;
            bool status = false;
            try
            {
                movie = context.Movies.Find(movieId);
                if (movie != null)
                {
                    context.Movies.Remove(movie);
                    context.SaveChanges();
                    status = true;
                }
                else status = false;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
    }
}
