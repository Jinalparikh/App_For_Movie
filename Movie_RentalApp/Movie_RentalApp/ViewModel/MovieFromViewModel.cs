using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Movie_RentalApp.Models;

namespace Movie_RentalApp.ViewModel
{
    public class MovieFromViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movies movies { get; set; }
        public string Title 
        {
            get
            {
                if(movies != null && movies.Id != 0)
                {
                    return "Edit Movie";
                }
                return "New Movie";
            } 
        }
    }
}