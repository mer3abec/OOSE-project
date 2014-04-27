using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace VSAudioPlayer
{

    public class Mp3 : Song
    {
        public event FirePlayBackChanged firePlayBackChanged;
        public event SongFinished songFinished;// implement even devined in the Song interface
        private string songPath, fileType, genry, singer, fileName, songName;
        private double length; // in seconds
        private NAudio.Wave.BlockAlignReductionStream stream = null;
        private NAudio.Wave.WaveOut output = null;
        private NAudio.Wave.VolumeWaveProvider16 volProvider = null;
        private TimeSpan time;
        private float vol = 0.5f;//default vol
        private long position;
        private long totalLenght;

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
            TimeSpan dur = tagFile.Properties.Duration;
            length = dur.TotalSeconds; 
        }
        
        //--------------------controls----------------------------------------
        /// <summary>
        /// Starts to play a file
        /// </summary>
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
                output = new NAudio.Wave.WaveOut();//new NAudio.Wave.DirectSoundOut();
                output.PlaybackStopped += output_PlaybackStopped;
                output.Init(volProvider);
                output.Play();
                checkPlayback();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// Fires event when playback stopped. Listener is in PlayerInerface
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void output_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (songFinished != null && output != null)
            {
                this.songFinished(); Console.WriteLine("event fired");   //event
            }
        }
        /// <summary>
        /// Stops play back and relise all resorces.
        /// </summary>
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
            catch (Exception)
            {

                stream = null;
            }
        }
        /// <summary>
        /// Sets on pause
        /// </summary>
        public void pause()
        {
            output.Pause();
        }
        /// <summary>
        /// Continue play.
        /// </summary>
        public void unpause()
        {
            output.Play();
            checkPlayback();//updates playback values to ui
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

                try
                {
                    volProvider.Volume = vol;
                }
                catch (Exception )
                {
                    stop();// if exception
                    songFinished();// then fire even to start a new song.
                   
                }
            }
        }

        public TimeSpan Time
        {
            get { return time; }
            set { time = value; }
        }
        
        public long Position
        {
            get { return position; }
            set
            { position = value;
            if (stream != null)
                {   // 16 bits audio has minimum block size of 2 bytes per chanel. If we seek along , we need to move new position on the begining of that block.
                    // distance from block boundary (may be 0) (tx to http://stackoverflow.com/questions/20982914/how-do-i-create-a-seekbar-in-c-naudio-music-player)
                    long adj = this.Position % stream.WaveFormat.BlockAlign; 
                    // adjust position to boundary and clamp to valid range
                    long newPos = Math.Max(0, Math.Min(stream.Length, this.Position - adj));
                    // set playback position
                    stream.Position = newPos;   
                } 
            }
        }

        public long TotalLenght
        {
            get { return totalLenght; }
            set { totalLenght = value; }
        }
        //---------------------helpers----------------- implemented interface Song method-----------
        /// <summary>
        /// Checks play back state
        /// </summary>
        /// <returns>"Playing, Stoped or Paused"</returns>
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
        //----------------------------Method which runs in separeted thread to check changing playback state and sends events to interface-----------------------------
        // Method which starts the event - firePlayBackPositionChanged to use playback values to update slider and info screen.
        private void checkPlayback()
        {
            if (output != null && stream != null)
            {
                this.Time = stream.CurrentTime;
                this.TotalLenght = stream.Length; 
                System.Threading.Thread t = new System.Threading.Thread(delegate()
                {
                    try
                    {
                        while (output.PlaybackState == PlaybackState.Playing)
                        {
                            
                            TimeSpan newT = stream.CurrentTime;

                            if (this.Time != newT)
                            {
                                this.Time = newT;
                                this.Position = stream.Position;
                                if (firePlayBackChanged != null)
                                {
                                    this.firePlayBackChanged();
                                }
                            }
                            System.Threading.Thread.Sleep(50);
                        }
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }
                });
                t.Start();
            }

        }
    }
}
