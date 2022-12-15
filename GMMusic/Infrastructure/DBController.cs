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
        private static MyDBContext DBContext { get; set; }
        public static ICollection<Track> Tracks { get; set; }
        public static ICollection<Tag> Tags { get; set; }
        public static ICollection<Playlist> Playlists { get; set; }

        static DBController()
        {
            
        }

        public static void UploadData()
        {
            using (DBContext = new MyDBContext())
            {
                Tracks = DBContext.Tracks?.ToList();
                Tags = DBContext.Tags?.ToList();
                Playlists = DBContext.Playlists?.ToList();
            }
        }

        public static void SaveChanges()
        {

        }

        public static void SaveTrackChanges(List<Track> delTracks)
        {
            using (DBContext = new MyDBContext())
            {
                foreach (Track track in Tracks)
                {
                    if (track.Id == -1)
                    {
                        DBContext.Tracks.Add(track);
                    }
                    else
                    {
                        var t = (DBContext.Tracks.Find(track.Id));
                        t.Copy(track);
                    }
                }
                if (delTracks.Count > 0)
                {
                    foreach (Track track in delTracks)
                    {
                        DBContext.Tracks.Remove(DBContext.Tracks.Find(track.Id));
                    }
                        
                }
                DBContext.SaveChanges();
            }
        }

        public static void SaveTagChanges()
        {

        }

        public static void SavePlaylistChanges()
        {

        }
    }
}
