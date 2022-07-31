using System;
using System.Collections.Generic;

namespace imdbDBFirstDataAccessLayer.Models
{
    public partial class Movie
    {
        public string MovieId { get; set; } = null!;
        public string MovieTitle { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
        public string? GenereId { get; set; }
        public string? ActorId { get; set; }
        public string? ProducerId { get; set; }

        public virtual Actor? Actor { get; set; }
        public virtual Genre? Genere { get; set; }
        public virtual Producer? Producer { get; set; }
    }
}
