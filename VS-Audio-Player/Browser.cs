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
                if (shufled) list.shufleQueue();
                
            }
            return list;
        }


         


 
    }
}
