using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTAPIMovieLab.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieAPIController : ControllerBase
    {
        MovieDAL mDAL = new MovieDAL();
        public List<Movie> GetMovies()
        {
            return mDAL.GetMovies();
        }
        [HttpGet("MovieByCategory/{category}")]
        public List<Movie> MovieByCategory(string category)
        {
            List<Movie> listOfMovies = GetMovies();
            foreach (Movie m in listOfMovies)
            {
                if (m.Category.ToLower().Trim() == category);
                {
                    listOfMovies.Add(m);
                }
            }
            return listOfMovies;
        }
        [HttpGet("GetRandomMovieByCategory/{category}")]
        public Movie RandomMovieByCategory(string category)
        {
            Movie m = new Movie();
            List<Movie> listOfMovies = MovieByCategory(category);
            Random randomMovie = new Random();
            try
            {
                return listOfMovies[randomMovie.Next(0, listOfMovies.Count)];
            }
            catch (ArgumentOutOfRangeException)
            {
                return m;
            }
        }
        [HttpGet("RandomMovie")]
        public Movie RandomMovie()
        {
            List<Movie> listOfMovies = GetMovies();
            Random randomMovie = new Random();
            return listOfMovies[randomMovie.Next(0, listOfMovies.Count)];
        }
        
        
    }
}
