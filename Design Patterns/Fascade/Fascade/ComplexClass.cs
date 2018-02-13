using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fascade
{
    public class User : IUser
    {
        int _uInstance;
        private bool _IsRunning = false;

        public User(int UserID) => _uInstance = UserID;
        public void StartRunning()
        {
            Console.WriteLine($"User {_uInstance} Running");
            _IsRunning = true;
        }
        public void StopRunning(int UserID) => _IsRunning = false;
        
    }

    public class GPSTracking : IGPSTracking
    {
        public void Start() => Console.WriteLine($"GPS started");
        public void Stop() { }
        public void InitiatizeGPSTracker() { }
        public void TroubleShoot() { }
    }

    public class MusicPlayer : IMusicPlayer
    {
        public void Start(string AlbumName,string Song) => Console.WriteLine($"Music Player - Song {Song} , Album {AlbumName}");
        public void Stop() { }
        public void SearchAlbum(string Song) { }
        public bool Loop { get; set; }
        public void Next() { }
        public void Previous() { }
    }

}
