using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace RESTAPIMovieLab
{
    public class MovieDAL
    {
        public List<Movie> GetMovies()
        {
            using(var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = "select * from moviesAPI";
                connect.Open();
                List<Movie> listOfMovies = connect.Query<Movie>(sql).ToList();
                connect.Close();
                return listOfMovies;
            }
        }
    }
}
