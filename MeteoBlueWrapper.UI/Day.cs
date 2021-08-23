using System;
using System.Drawing;

namespace MeteoBlueWrapper.UI
{
    public class Day
    {
        public string Url { get; set; }

        public string ImageUrl { get; set; }

        public Image Image { get; set; }

        public Image CroppedImage { get; set; }

        public DateTime Date { get; set; }

        public int DaysUntil { get; set; }
        
        public string City { get; set; }

        public string DateText { get; set; }
        
    }
}
