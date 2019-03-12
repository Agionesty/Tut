using System;
using System.Collections.Generic;
using System.Text;

namespace Pupita.Domain.Dto
{
    public class PlayListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<TrackDto> Tracks { get; set; } = new List<TrackDto>();
    }
}
