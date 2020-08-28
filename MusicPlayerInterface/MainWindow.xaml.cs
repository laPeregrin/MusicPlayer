using System.Windows;
using System.Windows.Controls;

namespace MusicPlayerInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MediaElement myMediaElement = new MediaElement();
        public MainWindow()
        {
           
            InitializeComponent();
        }
        // Change the volume of the media.
        public void ChangeMediaVolume(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            myMediaElement.Volume = (double)SliderVolume.Value;
        }
    }
}
