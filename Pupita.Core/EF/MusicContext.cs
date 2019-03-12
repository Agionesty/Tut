using Microsoft.EntityFrameworkCore;
using Pupita.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pupita.Core.EF
{
    public class MusicContext:DbContext
    {
       public  DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
       public DbSet<Track> Tracks { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<PlayList> PlayLists { get; set; }


        public MusicContext(DbContextOptions<MusicContext> options) : base(options)
        {

            Database.EnsureCreated();

        }
    

    }
   
}
