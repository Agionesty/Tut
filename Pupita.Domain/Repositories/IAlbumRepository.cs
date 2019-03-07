using Pupita.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pupita.Domain.Repositories
{
    public interface IAlbumRepository
    {
        Task<List<AlbumDto>> GetAllAlbum();
        Task<AlbumDto> GetById(Guid Id);
        Task<AlbumDto> CreatAsync(AlbumDto item);
        Task<bool> UpdateAsync(AlbumDto item);
        Task<bool> DeleteAsync(Guid Id);

    }
}
