using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMMusic.Models;

namespace GMMusic.Infrastructure
{
    public class MyDBContext : DbContext
    {
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Playlist> Playlists { get; set; }

        public MyDBContext() : base("DBConnection")
        {

        }
    }
}
