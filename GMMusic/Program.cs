using System;
using GMMusic.Infrastructure;

namespace GMMusic
{
    class Program
    {
        [STAThread]
        public static void Main()
        {
            GMMusic.App app = new GMMusic.App();
            app.InitializeComponent();
            app.Run();
        }
    }
}
