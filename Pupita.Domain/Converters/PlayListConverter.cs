using Pupita.Domain.Dto;
using Pupita.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pupita.Domain.Converters
{
   public static class PlayListConverter
    {
        public static PlayList Convert(PlayListDto playList)
        {
            return new PlayList
            {
                Id = playList.Id,
                Name = playList.Name
            };
        }

        public static PlayListDto Convert(PlayList playList)
        {
            return new PlayListDto
            {
                Id = playList.Id,
                Name = playList.Name
            };
        }


        public static List<PlayList> Convert (
            List<PlayListDto> playLists)
        {
            return playLists.Select(a => Convert(a)).ToList();
        }

        public static List<PlayListDto> Convert(
            List<PlayList> playLists)
        {
            return playLists.Select(a => Convert(a)).ToList();
        }
    }
}
