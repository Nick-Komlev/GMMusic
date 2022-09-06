using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMMusic.Models;

namespace GMMusic.Infrastructure
{
    public static class DBController
    {
        public static MyDBContext DBContext { get; set; }
        public static List<Track> Tracks { get; set; }
        public static List<Tag> Tags { get; set; }
        public static List<Playlist> Playlists { get; set; }

        static DBController()
        {
            DBContext = new MyDBContext();
        }

        public static void UploadData()
        {
            Tracks = DBContext.Tracks?.ToList();
            Tags = DBContext.Tags?.ToList();
            Playlists = DBContext.Playlists?.ToList();
        }

        public static void SaveChanges()
        {
            DBContext.SaveChanges();
        }
    }
}
