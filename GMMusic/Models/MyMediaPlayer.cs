using System.Windows.Media;

namespace GMMusic.Models
{
    public class MyMediaPlayer : MediaPlayer
    {
        public int Id { get; set; }

        public MyMediaPlayer(int id) : base()
        {
            Id = id;
        }
    }
}
