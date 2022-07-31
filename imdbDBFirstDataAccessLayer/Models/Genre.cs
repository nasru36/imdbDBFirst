using System;
using System.Collections.Generic;

namespace imdbDBFirstDataAccessLayer.Models
{
    public partial class Genre
    {
        public Genre()
        {
            Movies = new HashSet<Movie>();
        }

        public string GenreId { get; set; } = null!;
        public string GenreType { get; set; } = null!;

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
