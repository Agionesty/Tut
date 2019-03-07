using Pupita.Domain.Dto;
using Pupita.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pupita.Domain.Converters
{
    public static class AlbumConverter
    {
        public static Album Convert(AlbumDto album)
        {
            return new Album
            {
                Title = album.Title,
                Id = album.Id,
                IdArtist = album.IdArtist
            };
        }



        public static AlbumDto Convert(Album album)
        {
            return new AlbumDto
            {
                Title = album.Title,
                Id = album.Id,
                IdArtist = album.IdArtist
            };
        }




        public static List<Album> Convert(
            List<AlbumDto> albums)
        {
            return albums.Select(a => Convert(a)).ToList();
        }

        public static List<AlbumDto> Convert(
          List<Album> albums)
        {
            return albums.Select(a => Convert(a)).ToList();
        }
    }
}
