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
    public class TrackRepository: ITrackRepository
    {
        private readonly MusicContext _context;
        private readonly IAlbumRepository _albumrepos;

        public TrackRepository (MusicContext context, IAlbumRepository albumrepos)
        {
            _context = context;
            _albumrepos = albumrepos;
        }

        public async Task<List<TrackDto>> GetAllTrack()
        {
            return TrackConverter.Convert(await _context.Tracks.ToListAsync());
        }

        public async Task<TrackDto> GetById(Guid id)
        {
            return TrackConverter.Convert(await _context.Tracks.FindAsync(id));
        }

        public async Task<TrackDto> CreatAsync(TrackDto item)
        {
            var result = _context.Tracks.Add(
                TrackConverter.Convert(item));
            await _context.SaveChangesAsync();

            return TrackConverter.Convert(result.Entity);

        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var track = await _context.Tracks.FindAsync(id);

            if (track == null) return false;

            _context.Tracks.Remove(track);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(TrackDto item)
        {
            if (item == null) return false;
            _context.Tracks.Update(TrackConverter.Convert(item));
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
