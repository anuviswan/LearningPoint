using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fascade
{
    class Program
    {
        static void Main(string[] args)
        {
            // Normal Execution
            Console.WriteLine("Normal Execution");
            IUser userInstance = new User(1);
            userInstance.StartRunning();

            IGPSTracking gpsInstance = new GPSTracking();
            gpsInstance.Start();

            IMusicPlayer mplayerInstance = new MusicPlayer();
            mplayerInstance.Start("MyAlbum","MySong");

            Console.WriteLine("Facade Execution");
            FascadeClass fInstance = new FascadeClass(new User(1), new GPSTracking(), new MusicPlayer());
            fInstance.SetSong("MyAlbum", "MySong");
            fInstance.StartRunning();

            Console.ReadLine();

        }
    }
}
