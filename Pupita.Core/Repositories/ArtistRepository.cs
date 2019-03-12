using Microsoft.EntityFrameworkCore;
using Pupita.Core.EF;
using Pupita.Domain.Converters;
using Pupita.Domain.Dto;
using Pupita.Domain.Entities;
using Pupita.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pupita.Core.Repositories
{
    public class ArtistRepository:IArtistRepository
    {
        private readonly MusicContext _context;
      

        public ArtistRepository (MusicContext context)
        {
            _context = context;
        }

        public async Task<List<ArtistDto>> GetAllArtist()
        {
            return ArtistConverter.Convert(await _context.Artists.ToListAsync());
        }


        public async Task <ArtistDto> GetById(Guid id)
        {
            return ArtistConverter.Convert(await _context.Artists.FindAsync(id));
        }

        public async Task<ArtistDto> CreatAsync (ArtistDto item)
        {
            var result = _context.Artists.Add(
                ArtistConverter.Convert(item));
            await _context.SaveChangesAsync();

            return ArtistConverter.Convert(result.Entity);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var artist = await _context.Artists.FindAsync(id);

            if (artist == null) return false;

            _context.Artists.Remove(artist);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(ArtistDto item)
        {
            if (item == null) return false;
            _context.Artists.Update(ArtistConverter.Convert(item));
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
