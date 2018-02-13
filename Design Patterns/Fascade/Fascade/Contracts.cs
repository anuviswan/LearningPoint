using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fascade
{
    public interface IUser
    {
        void StartRunning();
        void StopRunning(int UserID);

    }

    public interface IGPSTracking
    {
        void Start();
        void Stop();
        void InitiatizeGPSTracker();
        void TroubleShoot();
    }

    public interface IMusicPlayer
    {
        void Start(string AlbumName, string Song);
        void Stop();
        void SearchAlbum(string Song);
        bool Loop { get; set; }
        void Next();
        void Previous();
    }
}
