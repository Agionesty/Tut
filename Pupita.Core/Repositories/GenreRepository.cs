using Microsoft.EntityFrameworkCore;
using Pupita.Core.EF;
using Pupita.Domain.Converters;
using Pupita.Domain.Dto;
using Pupita.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pupita.Core.Repositories
{
    public class GenreRepository:IGenreRepository
    {
        private readonly MusicContext _context;

        public GenreRepository (MusicContext context)
        {
            _context = context;
        }

        public async Task<List<GenreDto>> GetAllGenres()
        {
            return GenreConverter.Convert(await _context.Genres.ToListAsync());
        }

        public async Task<GenreDto> GetById(Guid id)
        {
            return GenreConverter.Convert(await _context.Genres.FindAsync(id));
        }

        public async Task<GenreDto> CreatAsync(GenreDto item)
        {
            var result = _context.Genres.Add(
                GenreConverter.Convert(item));
            await _context.SaveChangesAsync();

            return GenreConverter.Convert(result.Entity);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var genre = await _context.Genres.FindAsync(id);

            if (genre == null) return false;

            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(GenreDto item)
        {
            if (item == null) return false;
            _context.Genres.Update(GenreConverter.Convert(item));
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
