using SliderUproszczony.Class;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SliderUproszczony
{
    public partial class MainPage : TabbedPage
    {
        List<Images> _images;
        private bool _isAutoSliding = true;
        private bool _timerRunning = false;

        public MainPage()
        {
            InitializeComponent();
            _images = new List<Images>();

            var img = new Images()
            {
                ImageName = "Kyoto",
                ImageSource = "Kyoto.jpg"
            };

            _images.Add(img);

            ChangeImages();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadImages();
        }

        private void LoadImages()
        {
            imageCarousel.ItemsSource = null;
            imageCarousel.ItemsSource = _images;
        }

        private void AddImage(object sender, EventArgs e)
        {
            string imageName = ImageNameEntry.Text;
            string imageSource = ImageSourceEntry.Text;

            if (String.IsNullOrEmpty(imageName) || String.IsNullOrEmpty(imageSource))
            {
                DisplayAlert("Info", "Proszę wprowadzić dane", "OK");
            }
            else
            {
                var img = new Images()
                {
                    ImageName = imageName,
                    ImageSource = imageSource
                };

                _images.Add(img);
                LoadImages();

                ImageNameEntry.Text = string.Empty;
                ImageSourceEntry.Text = string.Empty;
            }
        }

        private void RemoveImage(object sender, EventArgs e)
        {
            var button = sender as Button;
            var image = (Images)button.BindingContext;

            if (image != null)
            {
                _images.Remove(image);
                LoadImages();
            }
        }

        private void OnToggleButtonClicked(object sender, EventArgs e)
        {
            _isAutoSliding = !_isAutoSliding;

            if (_isAutoSliding)
            {
                toggleButton.Text = "Stop Auto Slide";
                ChangeImages();
            }
            else
            {
                toggleButton.Text = "Start Auto Slide";
                _timerRunning = false;
            }
        }

        private void ChangeImages()
        {
            if (!_timerRunning)
            {
                Device.StartTimer(TimeSpan.FromSeconds(3), () =>
                {
                    if (!_isAutoSliding)
                    {
                        _timerRunning = false;
                        return false;
                    }

                    imageCarousel.Position = (imageCarousel.Position + 1) % _images.Count;
                    _timerRunning = true;
                    return true;
                });
            }
        }
    }
}
