using Pupita.Domain.Dto;
using Pupita.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pupita.Domain.Converters
{
   public static class GenreConverter
    {
        public static Genre Convert(GenreDto genre)
        {
            return new Genre
            {
                Id = genre.Id,
                Name = genre.Name

            };
        }

        public static GenreDto Convert(Genre genre)
        {
            return new GenreDto
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }

        public static List<Genre> Convert (
            List<GenreDto> genres)
        {
            return genres.Select(a => Convert(a)).ToList();
        }

        public static List<GenreDto> Convert (
            List<Genre> genres)
        {
            return genres.Select(a => Convert(a)).ToList();
        }

    }
}
