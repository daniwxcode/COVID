using MediaManager;
using MediaManager.Video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using Xamarin.Forms.Xaml;

namespace COVID
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviesPage : ContentPage
    {
        /// <summary>
        /// Variables contenanant le lien de chaque videos de sensibilisations ainsi que les index
        /// </summary>
        string[] myvideos = new string[] { "https://www.youtube.com/embed/HitHuhclWtg?feature=oembed&start&end&wmode=opaque&loop=0&controls=1&mute=0&rel=0&modestbranding=0", "https://www.youtube.com/embed/xBfw8KjDzd8?feature=oembed&start&end&wmode=opaque&loop=0&controls=1&mute=0&rel=0&modestbranding=0", "https://www.youtube.com/embed/tU-O6HebH00?feature=oembed&start&end&wmode=opaque&loop=0&controls=1&mute=0&rel=0&modestbranding=0", "https://www.youtube.com/embed/H1dA2xfj__0?feature=oembed&start&end&wmode=opaque&loop=0&controls=1&mute=0&rel=0&modestbranding=0", "https://www.youtube.com/embed/2x6-shgJgUI?feature=oembed&start&end&wmode=opaque&loop=0&controls=1&mute=0&rel=0&modestbranding=0", "https://www.youtube.com/embed/dCj2gby0BWM?feature=oembed&start&end&wmode=opaque&loop=0&controls=1&mute=0&rel=0&modestbranding=0" };
        int index = 0;
        public MoviesPage()
        {
            InitializeComponent();

            FillInformation();
        }

        // Evenement play
        private void ButtonPlay_Clicked(object sender, EventArgs e)
        {
            PlayVideo(index);

        }
        // Evenement pause
        private async void ButtonPause_Clicked(object sender, EventArgs e)
        {
            await CrossMediaManager.Current.Pause();
            btnpause.IsVisible = false;
            btnplay.IsVisible = true;
        }

        private void ButtonPlayBack_Clicked(object sender, EventArgs e)
        {

        }


        private async void PlayVideo(int index)
        {
            await CrossMediaManager.Current.Play(myvideos[index]);
            btnplay.IsVisible = false;
            btnpause.IsVisible = true;
        }


        private void ButtonPlayNext_Clicked(object sender, EventArgs e)
        {

            index++;
            if (index > 5)
            {
                index = 0;
            }
            PlayVideo(index);
        }


        private void FillInformation()
        {
            List<VideoModel> videoModels = new List<VideoModel>
            {
                new VideoModel
                {
                    VideoImage="ImageVideo.jpg",
                    VideoTitle="Mesures de prévention du Coronavirus (en kabyè)",
                    VideoIndex=0
                },
                new VideoModel
                {
                    VideoImage="ImageVideo.jpg",
                    VideoTitle="Mesures de prévention du Coronavirus (en moba)",
                    VideoIndex=1
                },
                new VideoModel
                {
                    VideoImage="ImageVideo.jpg",
                    VideoTitle="Mesures de prévention du Coronavirus (en kotokoli)",
                    VideoIndex=2
                },
                new VideoModel
                {
                    VideoImage="ImageVideo.jpg",
                    VideoTitle="Mesures de prévention du Coronavirus (en français)",
                    VideoIndex=3
                },
                new VideoModel
                {
                    VideoIndex=4,
                    VideoImage="ImageVideo.jpg",
                    VideoTitle="Mesures de prévention du Coronavirus (en éwé)"
                },
                new VideoModel
                {
                    VideoIndex=5,
                    VideoImage="sddefault.jpg",
                    VideoTitle="Mesures prises par le gouvernement – Conseil des ministres extraordinaire (16 mars 2020)"
                }
            };
            lstvideos.BindingContext = videoModels;
            lstvideos.HeightRequest = videoModels.Count * 45;
        }

        class VideoModel
        {
            public string VideoImage { get; set; }
            public string VideoTitle { get; set; }
            public int VideoIndex { get; set; }
        }

        private void Lstvideos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            ListView lv = sender as ListView;
            lv.SelectedItem = null;

            var item = e.SelectedItem as VideoModel;
            index = item.VideoIndex;
            PlayVideo(item.VideoIndex);
        }


        private void ButtonFullScreen_Clicked(object sender, EventArgs e)
        {
            MyVideoView.VideoAspect = VideoAspectMode.AspectFill;
        }
    }
}