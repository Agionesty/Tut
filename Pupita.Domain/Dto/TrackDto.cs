using System;
using System.Collections.Generic;
using System.Text;

namespace Pupita.Domain.Dto
{
    public class TrackDto
    { 
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid IdAlbum { get; set; }
        public string AlbumTitle { get; set; }
    }
}
