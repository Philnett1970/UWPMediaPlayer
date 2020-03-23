using FullMediaPlayer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace FullMediaPlayer
{
    
    public sealed partial class MainPage : Page
    {
       
        public MainPage()
        {
            this.InitializeComponent();
                        

            Player.AreTransportControlsEnabled = true;

            //Player.TransportControls.IsFastForwardButtonVisible = true;
            //Player.TransportControls.IsFastForwardEnabled = true;

            //Player.TransportControls.IsFastRewindButtonVisible = true;
            //Player.TransportControls.IsFastRewindEnabled = true;

            //Player.TransportControls.IsStopButtonVisible = true;
            //Player.TransportControls.IsStopEnabled = true;
            

            Player.TransportControls.IsSkipBackwardButtonVisible = true;
            Player.TransportControls.IsSkipBackwardEnabled = true;

            Player.TransportControls.IsCompactOverlayEnabled = true;
            Player.TransportControls.IsCompactOverlayButtonVisible = true;

            Player.TransportControls.IsSkipForwardButtonVisible = true;
            Player.TransportControls.IsSkipForwardEnabled = true;

    //        Player.TransportControls.IsPreviousTrackButtonVisible = true;
   //         Player.TransportControls.IsNextTrackButtonVisible = true;

            Player.TransportControls.IsRightTapEnabled = true;
        }

        private async void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.MusicLibrary;

            picker.FileTypeFilter.Add(".mp3");
            picker.FileTypeFilter.Add(".wav");
            picker.FileTypeFilter.Add(".avi");

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                this.NowPlaying.Text ="Now Playing..." + file.Name;

                Player.AutoPlay = true;
                Player.SetPlaybackSource(MediaSource.CreateFromStorageFile(file));

                Player.Play();

            }
            else
            {
                this.NowPlaying.Text = "Operation cancelled.";
            }
        }

        private void Player_MediaOpened(object sender, RoutedEventArgs e)
        {
            CMDBar.Visibility = Visibility.Collapsed;
        }

        private void Player_MediaEnded(object sender, RoutedEventArgs e)
        {
            CMDBar.Visibility = Visibility.Visible;

        }

        private void Player_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (CMDBar.Visibility == Visibility.Visible)
            {
                CMDBar.Visibility = Visibility.Collapsed;
            }
            else
            {
                CMDBar.Visibility = Visibility.Visible;
            }
        }

        private void FillWindow_Click(object sender, RoutedEventArgs e)
        {
            if (FillWindow.Label == "Fill Window")
            {
                ToggleZoom(Player);
                FillWindow.Label = "Normal Window";
                FillWindow.Icon = new SymbolIcon(Symbol.BackToWindow);
            }
            else if (FillWindow.Label == "Normal Window")
            {
                ToggleZoom(Player);
                FillWindow.Label = "Fill Window";
                FillWindow.Icon = new SymbolIcon(Symbol.FullScreen);
            }
        }

        private void ToggleZoom(MediaElement media)
        {
            if (media.Stretch != Stretch.UniformToFill)
            {
                // zoom
                media.Stretch = Stretch.UniformToFill;
            }
            else
            {
                // unzoom
                media.Stretch = Stretch.Uniform;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
