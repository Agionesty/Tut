using System;
using System.Collections.Generic;
using System.Text;

namespace Pupita.Domain.Entities
{
    public class Track
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid IdAlbum { get; set; }
        public Guid IdGenre { get; set; }
    }
}
