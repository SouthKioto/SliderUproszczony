using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace SliderUproszczony.Class
{
    public class Images
    {
        public ImageSource ImageSource { get; set; }
        public string ImageName { get; set; }

        public Images(string imageName, string imageSource)
        {
            ImageSource = imageSource;
            ImageName = imageName;
        }

        public Images()
        {
            
        }
    }
}
