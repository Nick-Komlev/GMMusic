using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMMusic.Models;

namespace GMMusic.Infrastructure
{
    internal class MyDBContext : DbContext
    {
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
    }
}
