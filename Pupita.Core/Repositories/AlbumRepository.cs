using Microsoft.EntityFrameworkCore;
using Pupita.Core.EF;
using Pupita.Domain.Converters;
using Pupita.Domain.Dto;
using Pupita.Domain.Entities;
using Pupita.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pupita.Core.Repositories
{
   public class AlbumRepository:IAlbumRepository
    {
        private readonly MusicContext _context;
        private readonly IArtistRepository _artistrepo;

        public AlbumRepository(MusicContext context, IArtistRepository artistrepo)
        {
            _context = context;
            _artistrepo = artistrepo;

        }

        public async Task<List<AlbumDto>> GetAllAlbum()
        {
            return AlbumConverter.Convert( await _context.Albums.ToListAsync());
        }

        public async Task<AlbumDto> GetById(Guid id)
        {
            var album =  AlbumConverter.Convert(await _context.Albums.FindAsync(id));

            return album;
            
        }


        public async Task<AlbumDto> CreatAsync (AlbumDto item)
        {
            var result = _context.Albums.Add(
                AlbumConverter.Convert(item));
            await _context.SaveChangesAsync();

            return AlbumConverter.Convert(result.Entity);

        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var album = await _context.Albums.FindAsync(id);

            if (album == null) return false;
            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();
            return true;
                
        }

        public async Task<bool> UpdateAsync(AlbumDto item)
        {
            if (item == null) return false;
            _context.Albums.Update(AlbumConverter.Convert(item));
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<AlbumDto> GetBySearch(string artistname)
        {
            var albums = AlbumConverter.Convert( await _context.Albums.FindAsync(artistname));
            return albums;
        }

    }
}
