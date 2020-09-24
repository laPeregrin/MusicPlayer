using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Text;



namespace MusicPlayerInterface.Model
{
    public class Music
    {
        //Collection using in 46 line
        private ObservableCollection<string> musicCollection = new ObservableCollection<string>();
        //To import the dll winmn.dll which allows to play mp3 files
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string lpstrCommand, StringBuilder lpstrReturnString,
            int uReturnLength, int hwndCallback);
        //To open a file to our application
        public void open(string file)
        {
            string command = "open \"" + file + "\" type MPEGVideo alias MyMusic";
            mciSendString(command, null, 0, 0);
        }
        //To play the file
        public void play()
        {
            string command = "play MyMusic";
            mciSendString(command, null, 0, 0);
        }
        //To pause the file
        public void pause()
        {
            string command = "stop MyMusic";
            mciSendString(command, null, 0, 0);

        }
        //To stop the file
        public void stop()
        {
            string command = "close MyMusic";
            mciSendString(command, null, 0, 0);
        }

        public ObservableCollection<string> getMusAlbum()
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Title = "Choose music";
            if (openFileDialog.ShowDialog().HasValue == true)
            {
                if (openFileDialog.FileNames != null)
                {
                    foreach (var item in openFileDialog.FileNames)
                    {
                        musicCollection.Add(item);
                    }

                }

            }
            return musicCollection;
        }
    }
}
