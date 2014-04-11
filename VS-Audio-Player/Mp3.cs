using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace VSAudioPlayer
{
    public delegate void SongFinished();
    public class Mp3 : Song
    {
        public event SongFinished songFinished;// implement even devined in the Song interface
        private string songPath, fileType, genry, singer, fileName, songName;
        private double length; // in seconds
        private NAudio.Wave.BlockAlignReductionStream stream = null;
        private NAudio.Wave.DirectSoundOut output = null;
        private NAudio.Wave.VolumeWaveProvider16 volProvider = null;
        private TimeSpan dur;
        private float vol = 0.5f;//default vol
        public Mp3(FileInfo info)
        {
            TagLib.File tagFile = TagLib.File.Create(info.FullName);
            this.genry = tagFile.Tag.FirstGenre;
            this.singer = tagFile.Tag.FirstPerformer;
            this.songName = tagFile.Tag.Title;
            this.songPath = info.FullName;       
            this.fileName = info.Name;
            this.fileType = info.Extension;
            //Geting duration of the mp3 file with the help of TagLib-sharp 
            dur = tagFile.Properties.Duration;
            length = dur.TotalSeconds; Console.WriteLine(this.length + "");  
        }
        //--------------------controls----------------------------------------
        public void play()
        {
            try
            {
                //Call a helper method (look in the botom) to reset the playback
            
                    stop();
                    // open uncompresed strem pcm from mp3 file reader compresed stream.
                    NAudio.Wave.WaveStream pcm = NAudio.Wave.WaveFormatConversionStream.CreatePcmStream(new NAudio.Wave.Mp3FileReader(this.songPath));
                    stream = new NAudio.Wave.BlockAlignReductionStream(pcm);
                    volProvider = new VolumeWaveProvider16(stream);
                    volProvider.Volume = vol;
                    output = new NAudio.Wave.DirectSoundOut();
                    output.PlaybackStopped += output_PlaybackStopped;
                    output.Init(volProvider);
                    output.Play();           
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
        // Fires event when playback stopped. Litener is in PlayerInerface
        void output_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (songFinished != null && output != null)
            {
                    this.songFinished(); Console.WriteLine("event fired");   //event
            }
        }      
        public void stop()
        {
            try
            {
                if (output != null)
                {
                    if (output.PlaybackState == NAudio.Wave.PlaybackState.Playing) output.Stop();
                    output.Dispose();
                    output = null;
                }
                if (stream != null)
                {
                    stream.Dispose();
                    stream = null;
                }
            }
            catch (Exception )
            {
                
                stream = null;
            }
        }
        public void pause()
        {
                output.Pause();
        }
        public void unpause()
        {
            output.Play();
        }
        //---------------------accessors/mutators------------------------------
        public string SongName
        {
            get { return songName; }
            set { songName = value; }
        }

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public string Singer
        {
            get { return singer; }
            set { singer = value; }
        }

        public string Genry
        {
            get { return genry; }
            set { genry = value; }
        }

        public string FileType
        {
            get { return fileType; }
            set { fileType = value; }
        }

        public string SongPath
        {
            get { return songPath; }
            set { songPath = value; }
        }
        
        public double Length
        {
            get { return length; }
            set { length = value; }
        }
        public float Vol
        {
            get { return vol; }
            set
            {
                vol = value;
                volProvider.Volume = vol;
            }
        }
        //---------------------helpers----------------- implemented interface Song method-----------
        public string playbackState()
        {
            if (output != null)
            {
                return output.PlaybackState + "";
            }
            else
            {
                return null;
            }
        }
    }
}
