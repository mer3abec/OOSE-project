using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VSAudioPlayer
{
    public partial class PlayerInterface : Form
    {
        private float vol = 0.5f; // deffault vol 
        private PlayList currentPlayList = null; //current palylist loaded
        public PlayerInterface()
        {
            InitializeComponent();
            trackBar2.Value = (int)(trackBar2.Maximum * vol);//sets vol slider to def value          
        }
        //-------------------------------menu items events handlers----------------------------
        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {// Checking if there is playing a song from previous playlist
            if (currentPlayList != null && currentPlayList.getCurentSong().playbackState() == "Playing")
            {
                PlayList newPlayList = Browser.BuildPlayList(random.Checked);
                currentPlayList.getCurentSong().stop(); 
                currentPlayList = newPlayList;               
            }
            else
            {
                currentPlayList = Browser.BuildPlayList(random.Checked);
            }           
            if (currentPlayList != null)
            {              
                //Adding to each song a Player event hendler which will listen for end file event to turn next file on play
                for (int i = 0; i < currentPlayList.getPlayListSize(); i++)
                {
                    currentPlayList.getElementAt(i).songFinished += PlayerInterface_songFinished;
                    currentPlayList.getElementAt(i).firePlayBackChanged += PlayerInterface_firePlayBackChanged;
                }
                currentPlayList.getCurentSong().play();// start play
                play.Image = VSAudioPlayer.Properties.Resources.pause_icon;//change icon 
            }
        }

        void PlayerInterface_firePlayBackChanged()
        {
            this.Invoke((MethodInvoker)delegate
            {
                trackBar1.Value = (int)(trackBar1.Maximum * currentPlayList.getCurentSong().Position / currentPlayList.getCurentSong().TotalLenght);// runs on UI thread
            });
           

        }
        //Executes when songFinished event occured
        void PlayerInterface_songFinished()
        {
            currentPlayList.getNextSong().play();
            currentPlayList.getCurentSong().Vol = trackBar2.Value * 0.01f;//setting up vol
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openFileToPlayToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //--------------------------check-boxes event handlers---------------------------------
        private void random_CheckedChanged(object sender, EventArgs e)
        {
            if (random.Checked && currentPlayList != null )
            {
                
                    currentPlayList.shufleQueue();
                
            }
            else if (!random.Checked && currentPlayList != null)
            {
                currentPlayList.unShufle();
            }
        }

        private void repeat_CheckedChanged(object sender, EventArgs e)
        {

        }
        //--------------------------control buttons event handlers---------------------------------
        private void previous_Click(object sender, EventArgs e)
        {
            if (currentPlayList != null)
            {   // After shufle was trigered, songs queue has been changed. Need to remember last song played and stop it before next
                // ...taken from new queue will paly.
                if (currentPlayList.LastPlayed != null)
                {
                    currentPlayList.LastPlayed.stop();
                }
                else { currentPlayList.getCurentSong().stop(); }
                currentPlayList.getCurentSong().stop();
                currentPlayList.getPrevSong().play();
                currentPlayList.getCurentSong().Vol = trackBar2.Value * 0.01f;//setting up vol
                Console.WriteLine(currentPlayList.getCurentSong().FileName);
            }
        }

        private void stop_Click(object sender, EventArgs e)
        {
            if (currentPlayList != null)
            {
                currentPlayList.getCurentSong().stop();
                play.Image = VSAudioPlayer.Properties.Resources.play;
            }   
            
        }

        private void play_Click(object sender, EventArgs e)
        {

            if (currentPlayList != null)
            {
                
                if (currentPlayList.getCurentSong().playbackState() != null && currentPlayList.getCurentSong().playbackState() == "Playing")
                {
                    play.Image = VSAudioPlayer.Properties.Resources.play;
                    currentPlayList.getCurentSong().pause(); 
                }
                else if (currentPlayList.getCurentSong().playbackState() != null && currentPlayList.getCurentSong().playbackState() == "Paused")
                {
                    
                    play.Image = VSAudioPlayer.Properties.Resources.pause_icon;
                    currentPlayList.getCurentSong().unpause(); 
                }
                else
                {
                    play.Image = VSAudioPlayer.Properties.Resources.pause_icon;
                    currentPlayList.getCurentSong().play();
                    currentPlayList.getCurentSong().Vol = trackBar2.Value * 0.01f;//setting up vol
                }
            }
            
        }

        private void next_Click(object sender, EventArgs e)
        {
            if (currentPlayList != null)
            {   // After shufle was trigered, songs queue has been changed. Need to remember last song played and stop it before next
                // ...taken from new queue will paly.
                if (currentPlayList.LastPlayed != null)
                {
                    currentPlayList.LastPlayed.stop();
                }
                else
                { 
                    currentPlayList.getCurentSong().stop(); 
                }
                currentPlayList.getCurentSong().stop();
                currentPlayList.getNextSong().play();
                currentPlayList.getCurentSong().Vol = trackBar2.Value * 0.01f;//setting up vol
                Console.WriteLine(currentPlayList.getCurentSong().FileName);
            }
        }
        //--------------volum scroll event handler---------------------
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (currentPlayList != null)
            {
                if (currentPlayList.getCurentSong().playbackState() == "Playing")
                currentPlayList.getCurentSong().Vol = trackBar2.Value * 0.01f;//setting up vol
            }
        }
        //--------------proggress track scroll event handler---------------------
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            currentPlayList.getCurentSong().Position = (int)(trackBar1.Value * currentPlayList.getCurentSong().TotalLenght / trackBar1.Maximum);
            Console.WriteLine("siking by mistake");
        }

        //-----------------show panel update method------------------------------     
        private void showPanel_Paint(object sender, PaintEventArgs e)
        {
            if (currentPlayList != null)
            {
                drawInfo(e);
            }
        }
        private void drawInfo(PaintEventArgs e)
        {            
            Font font = new Font("TimeNewRoman", 14);
            SolidBrush timeBrush = new SolidBrush(Color.Azure);
            e.Graphics.DrawString(currentPlayList.getCurentSong().FileName, font, timeBrush, 30.0f, 90.0f);
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PlayerInterface_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                currentPlayList.getCurentSong().stop();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
