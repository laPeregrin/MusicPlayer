using Microsoft.Win32;
using MusicPlayerInterface.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicPlayerInterface.Model
{
    class DataBase : BindableBase
    {
        string[] fileNames;
        public static IEnumerable<MusicTrack> GetMusicTracks()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            var res = ofd?.SafeFileName;
            yield return new MusicTrack { FileName = res };
        }
    }
}
