using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSAudioPlayer
{
    public delegate void FirePlayBackChanged();
    public delegate void SongFinished();
    public interface Song
    {
        event FirePlayBackChanged firePlayBackChanged;
        event SongFinished songFinished;
        string FileName { get; set; }
        string FileType { get; set; }
        string Genry { get; set; }
        double Length { get; set; }
        string Singer { get; set; }
        string SongName { get; set; }
        string SongPath { get; set; }
        float Vol { get; set; }
        long Position { get; set; } // position 
        TimeSpan Time { get; set; } // Holds current time.
        long TotalLenght { get; set; }// totsl lenght of track in samples
        void play();
        void stop();
        void pause();
        void unpause();
        string playbackState();
      
    }
}
