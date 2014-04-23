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
            PlayList newPlayList = null;
            if (currentPlayList != null && currentPlayList.getCurentSong().playbackState() == "Playing")
            {
                newPlayList = Browser.BuildPlayList(random.Checked);
                if (newPlayList != null)
                {
                    currentPlayList.getCurentSong().stop();
                    currentPlayList = newPlayList;
                }
            }
            else
            {
                
                newPlayList = Browser.BuildPlayList(random.Checked);              
            }           
            if (newPlayList != null )
            {
                //Adding to each song a Player event hendler which will listen for end file event to turn next file on play
                currentPlayList = newPlayList;
                for (int i = 0; i < currentPlayList.getPlayListSize(); i++)
                {
                    currentPlayList.getElementAt(i).songFinished += PlayerInterface_songFinished;
                    currentPlayList.getElementAt(i).firePlayBackChanged += PlayerInterface_firePlayBackChanged;
                }
                currentPlayList.getCurentSong().play();// start play
                play.Image = VSAudioPlayer.Properties.Resources.pause_icon;//change icon 
                initCombobox(); // Initialise combobox with playlist data.
            }
        }
        // Event hendler, ocured when play back data is changed, every 100ms state checked in Mp3 class.
        void PlayerInterface_firePlayBackChanged()
        {
            this.Invoke((MethodInvoker)delegate
            {
                //trackBar1.Value = (int)(trackBar1.Maximum * currentPlayList.getCurentSong().Position / currentPlayList.getCurentSong().TotalLenght);// runs on UI thread
                trackBar1.Value = (int)(trackBar1.Maximum * currentPlayList.getElementAt(currentPlayList.Index).Position / currentPlayList.getElementAt(currentPlayList.Index).TotalLenght);
                
            });
            this.showPanel.Invalidate();

        }
        //Executes when songFinished event occured
        void PlayerInterface_songFinished()
        {//if repeat is checked, then next song replayed, else start next in the queue
            if (repeat.Checked)
            {
                currentPlayList.getCurentSong().play();
                currentPlayList.getCurentSong().Vol = trackBar2.Value * 0.01f;//setting up vol
                comboBox1.SelectedIndex = currentPlayList.Index;
            }
            else
            {
                currentPlayList.getNextSong().play();
                currentPlayList.getCurentSong().Vol = trackBar2.Value * 0.01f;//setting up vol
                comboBox1.SelectedIndex = currentPlayList.Index;
            }
        }
        // exit menu
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void openFileToPlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Checking if there is playing a song from previous playlist
            PlayList newPlayList = null;
            if (currentPlayList != null && currentPlayList.getCurentSong().playbackState() == "Playing")
            {
                newPlayList = Browser.BuildPlayListFromFiles(random.Checked);
                if (newPlayList != null)
                {
                    currentPlayList.getCurentSong().stop();
                    currentPlayList = newPlayList;
                }
            }
            else
            {

                newPlayList = Browser.BuildPlayListFromFiles(random.Checked);
            }
            if (newPlayList != null)
            {
                //Adding to each song a Player event hendler which will listen for end file event to turn next file on play
                currentPlayList = newPlayList;
                for (int i = 0; i < currentPlayList.getPlayListSize(); i++)
                {
                    currentPlayList.getElementAt(i).songFinished += PlayerInterface_songFinished;
                    currentPlayList.getElementAt(i).firePlayBackChanged += PlayerInterface_firePlayBackChanged;
                }
                currentPlayList.getCurentSong().play();// start play
                play.Image = VSAudioPlayer.Properties.Resources.pause_icon;//change icon 
                initCombobox(); // Initialise combobox with playlist data.
            }
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
        // Repeat check box 
        private void repeat_CheckedChanged(object sender, EventArgs e)
        {

        }
        //--------------------------control buttons event handlers---------------------------------
        private void previous_Click(object sender, EventArgs e)
        {
            if (currentPlayList != null)
            {   // After shufle was trigered, songs queue has been changed. Need to remember last song played and stop it before next
                // ...taken from new queue will paly.         
                currentPlayList.getElementAt(currentPlayList.Index).stop();
                currentPlayList.getPrevSong().play();
                currentPlayList.getCurentSong().Vol = trackBar2.Value * 0.01f;//setting up vol
                comboBox1.SelectedIndex = currentPlayList.Index;
            }
        }

        private void stop_Click(object sender, EventArgs e)
        {
            if (currentPlayList != null)
            {
                currentPlayList.getCurentSong().stop();
                play.Image = VSAudioPlayer.Properties.Resources.play;
                trackBar1.Value = 1;
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
        // next button
        private void next_Click(object sender, EventArgs e)
        {
            if (currentPlayList != null)
            {   //Stops curent song at Index, starts next song, sets vol,         
                currentPlayList.getElementAt(currentPlayList.Index).stop();
                currentPlayList.getNextSong().play();               
                currentPlayList.getCurentSong().Vol = trackBar2.Value * 0.01f;//setting up vol
                comboBox1.SelectedIndex = currentPlayList.Index; // updates combobox selected index state
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

            if (currentPlayList != null)
            {
                currentPlayList.getElementAt(currentPlayList.Index).Position = (int)(trackBar1.Value * currentPlayList.getElementAt(currentPlayList.Index).TotalLenght / trackBar1.Maximum);
            }
        }

        //-----------------show panel update method------------------------------     
        private void showPanel_Paint(object sender, PaintEventArgs e)
        {
            
            SolidBrush timeBrush = new SolidBrush(Color.DarkSalmon);
            Pen pen = new Pen(timeBrush);
            int width = showPanel.Width; int height = showPanel.Height;
            e.Graphics.DrawRectangle(pen, 0, 0, width - 2, height - 2);
            
            if (currentPlayList != null)
            {
                drawInfo(e);
            }
        }
        // Draw song info on the show panel
        private void drawInfo(PaintEventArgs e)
        {            
            Font font = new Font("TimeNewRoman", 9);
            SolidBrush timeBrush = new SolidBrush(Color.DarkOrchid);
            TimeSpan span = currentPlayList.getCurentSong().Time;
            int min = span.Minutes; int sec = span.Seconds;
            int next = currentPlayList.getNextIndexInQuaue();
            e.Graphics.DrawString(currentPlayList.getCurentSong().SongName + " " + min + ":" + sec + " >> " + currentPlayList.getElementAt(next).SongName + " " + currentPlayList.getElementAt(next).FileName, font, timeBrush, 5.0f, 5.0f);
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
        //Called when Combobox item selected
         private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
             
            int index = comboBox1.SelectedIndex;
            currentPlayList.getElementAt(currentPlayList.Index).stop(); //get current song playing and stop it
            currentPlayList.Index = index;
            currentPlayList.getCurentSong().play();// Starts selected
            currentPlayList.getCurentSong().Vol = trackBar2.Value * 0.01f;//setting up vol
            
        }
         
        // Loads playlist into combobox element
        private void initCombobox()
        {
            comboBox1.DataSource = currentPlayList.Playlist;
            comboBox1.DisplayMember = "fileName";
           
            
        }

     
    }
}
