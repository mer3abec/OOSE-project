using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VSAudioPlayer
{
    public class Browser
    {

        public static PlayList BuildPlayList(bool shufled)
        {
            PlayList list = null;
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string path = dialog.SelectedPath;
                DirectoryInfo dInfo = new DirectoryInfo(path);
                // File info docs
                FileInfo[] fInfor = dInfo.GetFiles("*.mp3");               
                list = new PlayList(fInfor);
                if (list.getPlayListSize() == 0) return null; 
                if (shufled) list.shufleQueue();
                
            }
            return list;
        }
        public static PlayList BuildPlayListFromFiles(bool shufled)
        {

            PlayList list = null;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "MP3 Files (.mp3)|*.mp3";
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {

                string[] path = dialog.FileNames;
                var fileInfos = path.Select(f => new FileInfo(f));
                FileInfo[] fInfos = fileInfos.ToArray();
                list = new PlayList(fInfos);
                if (list.getPlayListSize() == 0) return null; 
                if (shufled) list.shufleQueue();
            }
            
            return list;
        }


         


 
    }
}
