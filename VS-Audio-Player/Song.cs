using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSAudioPlayer
{
    public interface Song
    {
        event SongFinished songFinished;
        string FileName { get; set; }
        string FileType { get; set; }
        string Genry { get; set; }
        double Length { get; set; }
        string Singer { get; set; }
        string SongName { get; set; }
        string SongPath { get; set; }
        float Vol { get; set; }
        void play();
        void stop();
        void pause();
        void unpause();
        string playbackState();
     
    }
}
