﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Pupita.Domain.Entities
{
   public class Genre
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Track> Tracks { get; set; } = new List<Track>();

    }
}
