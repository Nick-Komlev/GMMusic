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

        static DBController()
        {
            using (var db = new MyDBContext())
            {
                for (int i = 0; i < 10; i++)
                {
                    db.Tracks.Add(new Track
                    {
                        Name = $"Track{i}",
                        Duration = new TimeSpan(0, i, 37),
                        SourcePath = "c:",
                        IsAmbience = false
                    });
                }

                for (int i = 0; i < 10; i++)
                {
                    db.Tags.Add(new Tag
                    {
                        Name = $"Tag{i}"
                    });
                }

                Playlist pl1 = new Playlist{ Name = "Playlist1", Description = "Playlist 1"};
                Playlist pl2 = new Playlist{ Name = "Playlist2", Description = "Playlist 2" };

                db.Playlists.AddRange(new List<Playlist> { pl1, pl2 });
            }

        }
    }
}
