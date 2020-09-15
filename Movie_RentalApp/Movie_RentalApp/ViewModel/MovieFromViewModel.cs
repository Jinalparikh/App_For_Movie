using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Movie_RentalApp.Models;
using System.ComponentModel.DataAnnotations;

namespace Movie_RentalApp.ViewModel
{
    public class MovieFromViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number In Stock")]
        [Range(1, 20)]
        [Required]
        public byte? NumberInStock { get; set; }
        public string Title 
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
                
            } 
        }

        public MovieFromViewModel()
        {
            Id = 0;
        }
        public MovieFromViewModel(Movies movies)
        {
            Id = movies.Id;
            Name = movies.Name;
            ReleaseDate = movies.ReleaseDate;
            NumberInStock = movies.NumberInStock;
            GenreId = movies.GenreId;
        }
    }
}