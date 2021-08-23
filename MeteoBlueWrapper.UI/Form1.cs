using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeteoBlueWrapper.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var url1 = "https://my.meteoblue.com/visimage/meteogram_14day_hd?look=KILOMETER_PER_HOUR%2CCELSIUS%2CMILLIMETER&apikey=5838a18e295d&temperature=C&windspeed=kmh&precipitationamount=mm&winddirection=3char&city=Davos&iso2=ch&lat=46.8043&lon=9.83723&asl=1560&tz=Europe%2FZurich&lang=de&ts=1629716542&sig=206ee7f73aa88a52d6cc8b5263150afb";

            using (var client = new WebClient())
            {
                client.DownloadFile(new Uri(url1), "url1.png");
                var img1 = Image.FromFile("url1.png");

                var widthPart = Convert.ToInt32(img1.Width / 14);
                var left = widthPart * 12;
                var img1Cropped = cropImage(img1, new Rectangle(left, 90, widthPart, img1.Height - 90));
                this.pictureBox1.Image = img1Cropped;
            }
        }

        private static Image cropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            return bmpImage.Clone(cropArea, bmpImage.PixelFormat);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }
    }
}
