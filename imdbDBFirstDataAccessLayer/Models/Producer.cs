using System;
using System.Collections.Generic;

namespace imdbDBFirstDataAccessLayer.Models
{
    public partial class Producer
    {
        public Producer()
        {
            Movies = new HashSet<Movie>();
        }

        public string ProducerId { get; set; } = null!;
        public string ProducerName { get; set; } = null!;

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
