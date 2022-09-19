using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMMusic.Models;

namespace GMMusic.Infrastructure
{
    public static class DBController
    {
        public static MyDBContext DBContext { get; set; }
        public static ICollection<Track> Tracks { get; set; }
        public static ICollection<Tag> Tags { get; set; }
        public static ICollection<Playlist> Playlists { get; set; }

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
