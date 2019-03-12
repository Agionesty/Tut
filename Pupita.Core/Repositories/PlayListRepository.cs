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
   public class PlayListRepository:IPlayListRepository
    {
        private readonly MusicContext _context;

        public PlayListRepository (MusicContext context)
        {
            _context = context;
        }

        public async Task<List<PlayListDto>> GetAllPlayList()
        {
            return PlayListConverter.Convert(await _context.PlayLists.ToListAsync());
        }

        public async Task<PlayListDto> GetById (Guid id)
        {
                return PlayListConverter.Convert(await _context.PlayLists.FindAsync(id));
        }

        public async Task<PlayListDto> CreatAsync(PlayListDto item)
        {
            var result = _context.PlayLists.Add(
                PlayListConverter.Convert(item));
            await _context.SaveChangesAsync();

            return PlayListConverter.Convert(result.Entity);
        }

        public async Task<bool> DeleteAsync (Guid id)
        {
            var play = await _context.PlayLists.FindAsync(id);

            if (play == null) return false;

            _context.PlayLists.Remove(play);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(PlayListDto item)
        {
            if (item == null) return false;
            _context.PlayLists.Update(PlayListConverter.Convert(item));
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
