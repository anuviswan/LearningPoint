using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fascade
{
    class FascadeClass
    {
        IUser _uInstance;
        IGPSTracking _gInstance;
        IMusicPlayer _mInstance;

        string _Song;
        string _album;

        
        public FascadeClass(IUser uInstance,IGPSTracking gInstance, IMusicPlayer mInstance)
        {
            _uInstance = uInstance;
            _gInstance = gInstance;
            _mInstance = mInstance;

        }

        public void SetSong(string Album, string Song) { _Song = Song; _album = Album; }

        public void StartRunning()
        {
            _uInstance.StartRunning();
            _gInstance.Start();
            _mInstance.Start(_album, _Song);
        }

        public void StopRunning() { }
    }
}
