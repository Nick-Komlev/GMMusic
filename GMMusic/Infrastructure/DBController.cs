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
                        var t = DBContext.Tracks.Find(track.Id);
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

        public static void SaveTagChanges(List<Tag> delTags)
        {
            using (DBContext = new MyDBContext())
            {
                foreach (Tag tag in Tags)
                {
                    if (tag.Id == -1)
                    {
                        DBContext.Tags.Add(tag);
                    }
                    else
                    {
                        var t = DBContext.Tags.Find(tag.Id);
                        t.Copy(tag);
                    }
                }
                if (delTags.Count > 0)
                {
                    foreach (Tag tag in delTags)
                    {
                        DBContext.Tags.Remove(DBContext.Tags.Find(tag.Id));
                    }

                }
                DBContext.SaveChanges();
            }
        }

        public static void SavePlaylistChanges()
        {

        }
    }
}
