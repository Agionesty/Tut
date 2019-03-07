using Pupita.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pupita.Domain.Repositories
{
    public interface ITrackRepository
    {
        Task<List<TrackDto>> GetAllTrack();
        Task<TrackDto> GetById(Guid Id);
        Task<TrackDto> CreatAsync(TrackDto item);
        Task<bool> UpdateAsync(TrackDto item);
        Task<bool> DeleteAsync(Guid Id);
    }
}
