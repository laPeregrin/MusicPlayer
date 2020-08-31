using MusicPlayerInterface.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MusicPlayerInterface.ViewModels
{
    class MainViewModel : BindableBase
    {

        #region -Other class without initialization
        Music music;
        MusicPlayerInterface.Model.DataBase dataBase;
        #endregion
        #region PROPERTIES
        private bool _IsPlaying = false;
        public bool IsPlaying { get { return _IsPlaying; } private set { _IsPlaying = value; } }
        #endregion
        public ObservableCollection<MusicTrack> MusicTracks { get; set; }

        public MainViewModel()
        {
            MusicTracks = new ObservableCollection<MusicTrack>(DataBase.GetMusicTracks());
            music = new Music();
            dataBase = new DataBase();
        }
        #region -METHODS-
        public void PlayPause()
        {
           if(IsPlaying)
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
        #endregion
        #region -DelegateCommands-
        //public  DelegateCommand openFolder()
        //{
        //    return new DelegateCommand((obj) => { dataBase.; });
        //}
        #endregion
    }

}
