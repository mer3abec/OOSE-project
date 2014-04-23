using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSAudioPlayer
{
    public class PlayList
    {

        private List<Song> playlist;
        private List<int> queue; // keeps indexes of the current playlist, keep order songs to be played.
        private int current = 0; // Current song index in the queue
        private int index; // Current song index in play list
        public PlayList(FileInfo[] fInfor)
        {
            queue = new List<int>();
            playlist = initSongsList(fInfor);// InitSingsList returns complite playlist built from FileInfo and inits queue.
        }
        //Shufels queue 
        public void shufleQueue()
        {
            //lastPlayedBeforeShufle = getCurentSong();
            Shuffle(queue);
        }
        public void unShufle()
        {
           // lastPlayedBeforeShufle = getCurentSong();
            queue.Sort();
        }
        public Song getCurentSong()
        {
            //return playlist.ElementAt(queue.ElementAt(current));
            //index = queue.ElementAt<int>(current);
            return playlist.ElementAt(index);
        }
        public Song getNextSong()
        {
            if (current != queue.Count-1 )
            {
                index = queue.ElementAt<int>(++current);
                return playlist.ElementAt<Song>(index);//Getting next Song from palylist by index stored in the current+1.
            }   // ...if current not equal to the last index.
            else// ... else return first Song with index 0.
            {
                current = 0;
                index = queue.ElementAt<int>(current);
                return playlist.ElementAt(index);
            }

        }
        public Song getPrevSong()
        {
            if (current != 0)
            {
                index = queue.ElementAt<int>(--current);
                return playlist.ElementAt<Song>(index);//Getting previous Song from palylist by index stored current-1.
            }   // ...if current not equal to 0.
            else// ... else return last Song with index queue.Count-1.
            {
                current = queue.Count - 1;
                index = queue.ElementAt<int>(current);
                return playlist.ElementAt(index);
            }

        }
        // Helper method to help initialise playlist
        private List<Song> initSongsList(FileInfo[] info)
        {
            List<Song> list = new List<Song>();
            for (int i = 0; i < info.Length; i++)
            {
                Song song = new Mp3(info[i]);
                
                list.Add(song);
                
                queue.Add(i);
            }
            return list;
        }
       
        // Shufle  function
        private void Shuffle(List<int> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                int value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        // Accessor of Current property
        public int getPlayListSize()
        {
            return playlist.Count;
        }
        public Song getElementAt(int index){
            return playlist.ElementAt<Song>(index);
        }
        public int Current
        {
            get { return current; }
            set { current = value; }
        }
        public int Index
        {
            get { return index; }
            set { index = value; }
        }
        public List<Song> Playlist
        {
            get { return playlist; }
            set { playlist = value; }
        }
    }
   
}
