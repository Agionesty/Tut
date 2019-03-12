using Pupita.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pupita.Domain.Repositories
{
   public  interface IGenreRepository
    {
        Task<List<GenreDto>> GetAllGenres();
        Task<GenreDto> GetById(Guid Id);
        Task<GenreDto> CreatAsync(GenreDto item);
        Task<bool> UpdateAsync(GenreDto item);
        Task<bool> DeleteAsync(Guid Id);
    }
}
