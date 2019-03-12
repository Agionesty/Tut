using Pupita.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pupita.Domain.Repositories
{
   public interface IPlayListRepository
    {
        Task<List<PlayListDto>> GetAllPlayList();
        Task<PlayListDto> GetById(Guid Id);
        Task<PlayListDto> CreatAsync(PlayListDto item);
        Task<bool> UpdateAsync(PlayListDto item);
        Task<bool> DeleteAsync(Guid Id);
    }
}
