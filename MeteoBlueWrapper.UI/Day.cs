using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        
    }
}
