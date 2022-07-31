using System;
using System.Collections.Generic;

namespace imdbDBFirstDataAccessLayer.Models
{
    public partial class Actor
    {
        public Actor()
        {
            Movies = new HashSet<Movie>();
        }

        public string ActorId { get; set; } = null!;
        public string ActorName { get; set; } = null!;

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
