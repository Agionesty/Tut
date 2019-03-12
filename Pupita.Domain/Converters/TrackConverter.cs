using Pupita.Domain.Dto;
using Pupita.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pupita.Domain.Converters
{
    public static class TrackConverter
    {
        public static Track Convert(TrackDto track)
        {
            return new Track
            {
                Id = track.Id,
                Title = track.Title,
                IdAlbum = track.IdAlbum,
                
            };
        }

        public static TrackDto Convert (Track track)
        {
            return new TrackDto
            {
                Id = track.Id,
                Title = track.Title,
                IdAlbum = track.IdAlbum
            };
        }

        public static List<Track> Convert(
            List<TrackDto> tracks)
        {
            return tracks.Select(a => Convert(a)).ToList();

        }

        public static List<TrackDto> Convert(
           List<Track> tracks)
        {
            return tracks.Select(b => Convert(b)).ToList();

        }
    }
}
