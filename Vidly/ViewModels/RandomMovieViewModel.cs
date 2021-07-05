using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class RandomMovieViewModel
    {
        public List<Customer> Customers { get; set; }
        public Movie Movie { get; set; }
    }
}