using System;
using imdbDBFirstDataAccessLayer;

namespace imdbConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            imdbRepository repository = new imdbRepository();
            ////1. List all movies
            //var movies = repository.GetAllMovies();
            //Console.WriteLine("-------------------------");
            //Console.WriteLine("MovieID\tMovieTitle\tReleaseDate");
            //Console.WriteLine("-------------------------");
            //foreach (var movie in movies)
            //{
            //    Console.WriteLine("{0}\t{1}\t{2}", movie.MovieId, movie.MovieTitle, movie.ReleaseDate);
            //}

            ////2. Add movie
            //bool result = repository.AddMovie("M04", "Ek tha Tiger", Convert.ToDateTime("2012/08/15"), "G01", "A01", "P02");
            //if (result) Console.WriteLine("New Movie Added Successfully");
            //else Console.WriteLine("Something went wrong. Try again!!");

            //3. Edit Movie
            //bool result = repository.EditMovie("M04", "Ek Tha Tiger", Convert.ToDateTime("2012/07/15"), "G01", "A01", "P02");
            //if (result) Console.WriteLine("Movie Edited Successfully");
            //else Console.WriteLine("Something went wrong. Try again!!");

            //4. Add actor
            //bool result = repository.AddActor("A04", "Hrithik Roshan");
            //if (result) Console.WriteLine("Actor Added Successfully");
            //else Console.WriteLine("Something went wrong. Try again!!");

            //5. Add Producer
            //bool result = repository.AddProducer("P04", "Red Chillies Entertainment");
            //if (result) Console.WriteLine("Producer Added Successfully");
            //else Console.WriteLine("Something went wrong. Try again!!");

            //6. Delete Movie
            bool result = repository.DeleteMovie("M03");
            if (result) Console.WriteLine("Movie Deleted Successfully");
            else Console.WriteLine("Something went wrong. Try again!!");
        }
    }
}
