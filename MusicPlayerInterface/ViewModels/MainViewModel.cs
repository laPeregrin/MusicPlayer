using MusicPlayerInterface.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace MusicPlayerInterface.ViewModels
{
    public class MainViewModel : BindableBase
    {

        #region -Other class without initialization
        Music music;
        #endregion
        #region PROPERTIES
        private ObservableCollection<string> _MusicList;
        private string _SelectedTrack = String.Empty;
        private string HistoryTrack = "default";

        public string SelectedTrack { get { return _SelectedTrack; } set { _SelectedTrack = value; OnPropertyChanged(); } }
        public ObservableCollection<string> MusicList { get { return _MusicList; } private set { _MusicList = value; OnPropertyChanged(); } }

        private bool _IsPlaying = false;
        public bool IsPlaying { get { return _IsPlaying; } private set { _IsPlaying = value; } }
        #endregion

        public MainViewModel()
        {
            music = new Music();
        }
        #region -METHODS-

        public string getNameMetaData(string fileName)
        {
            using (BinaryReader stream = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                var stringContent = stream.ReadString();
                return stringContent;
            }
        }

        public void PlayPause()
        {
            if (SelectedTrack != String.Empty)
            {
                if (SelectedTrack != HistoryTrack)
                {
                    HistoryTrack = SelectedTrack;
                    music.stop();
                    music.open(HistoryTrack);
                    music.play();

                }
                else
                {
                    if (IsPlaying)
                    {
                        music.pause();
                        IsPlaying = false;
                    }
                    else
                    {
                        music.play();
                        IsPlaying = true;
                    }
                }

            }

        }
        #endregion
        #region -DelegateCommands-

        public DelegateCommand ImportMusic
        {
            get { return new DelegateCommand((obj) => { MusicList = music.getMusAlbum(); }); }
        }
        public DelegateCommand PlayOrPause
        {
            get { return new DelegateCommand((obj) => { PlayPause(); }); }
        }
        #endregion
    }

}
