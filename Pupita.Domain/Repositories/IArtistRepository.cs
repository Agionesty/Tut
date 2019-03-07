using Pupita.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pupita.Domain.Repositories
{
   public interface IArtistRepository
    {
        Task<List<ArtistDto>> GetAllArtist();
        Task<ArtistDto> GetById(Guid Id);
        Task<ArtistDto> CreatAsync(ArtistDto item);
        Task<bool> UpdateAsync(ArtistDto item);
        Task<bool> DeleteAsync(Guid Id);

    }
}
