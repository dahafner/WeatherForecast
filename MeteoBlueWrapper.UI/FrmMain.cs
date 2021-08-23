using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace MeteoBlueWrapper.UI
{
    public partial class FrmMain : Form
    {
        private readonly List<Day> days = new();
        private readonly List<PictureBox> pictureBoxes = new();
        private int debugDays = 0;

        public FrmMain()
        {
            this.InitializeComponent();

            this.InitLists();
            this.GetImages();
        }        

        private void InitLists()
        {
            this.days.Add(new Day { Url = "https://www.meteoblue.com/de/wetter/14-tage/davos_schweiz_2661039", Date = new DateTime(2021, 9, 4) });
            this.days.Add(new Day { Url = "https://www.meteoblue.com/de/wetter/14-tage/sankt-moritz_schweiz_2658813", Date = new DateTime(2021, 9, 5) });
            this.days.Add(new Day { Url = "https://www.meteoblue.com/de/wetter/14-tage/tenero_schweiz_2658407", Date = new DateTime(2021, 9, 6) });
            this.days.Add(new Day { Url = "https://www.meteoblue.com/de/wetter/14-tage/tenero_schweiz_2658407", Date = new DateTime(2021, 9, 7) });
            this.days.Add(new Day { Url = "https://www.meteoblue.com/de/wetter/14-tage/brig_schweiz_2661394", Date = new DateTime(2021, 9, 8) });
            this.days.Add(new Day { Url = "https://www.meteoblue.com/de/wetter/14-tage/zermatt_schweiz_2657928", Date = new DateTime(2021, 9, 9) });
            this.days.Add(new Day { Url = "https://www.meteoblue.com/de/wetter/14-tage/morges_schweiz_2659587", Date = new DateTime(2021, 9, 10) });
            this.days.Add(new Day { Url = "https://www.meteoblue.com/de/wetter/14-tage/neuenburg_schweiz_2659496", Date = new DateTime(2021, 9, 11) });
            this.days.Add(new Day { Url = "https://www.meteoblue.com/de/wetter/14-tage/sugiez_schweiz_2658458", Date = new DateTime(2021, 9, 12) });
            this.days.Add(new Day { Url = "https://www.meteoblue.com/de/wetter/14-tage/sugiez_schweiz_2658458", Date = new DateTime(2021, 9, 13) });
            this.days.Add(new Day { Url = "https://www.meteoblue.com/de/wetter/14-tage/bern_schweiz_2661552", Date = new DateTime(2021, 9, 14) });
            this.days.Add(new Day { Url = "https://www.meteoblue.com/de/wetter/14-tage/luzern_schweiz_2659811", Date = new DateTime(2021, 9, 15) });
            this.days.Add(new Day { Url = "https://www.meteoblue.com/de/wetter/14-tage/arbon_schweiz_2661731", Date = new DateTime(2021, 9, 16) });
            this.days.Add(new Day { Url = "https://www.meteoblue.com/de/wetter/14-tage/arbon_schweiz_2661731", Date = new DateTime(2021, 9, 17) });

            this.pictureBoxes.Add(this.PbxDay1);
            this.pictureBoxes.Add(this.PbxDay2);
            this.pictureBoxes.Add(this.PbxDay3);
            this.pictureBoxes.Add(this.PbxDay4);
            this.pictureBoxes.Add(this.PbxDay5);
            this.pictureBoxes.Add(this.PbxDay6);
            this.pictureBoxes.Add(this.PbxDay7);
            this.pictureBoxes.Add(this.PbxDay8);
            this.pictureBoxes.Add(this.PbxDay9);
            this.pictureBoxes.Add(this.PbxDay10);
            this.pictureBoxes.Add(this.PbxDay11);
            this.pictureBoxes.Add(this.PbxDay12);
            this.pictureBoxes.Add(this.PbxDay13);
            this.pictureBoxes.Add(this.PbxDay14);
        }

        private async void GetImages()
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:91.0) Gecko/20100101 Firefox/91.0");

                for (var i = 0; i < this.days.Count; i++)
                {
                    var day = this.days[i];

                    // Calculate days until
                    var daysUntil = day.Date - DateTime.Now;
                    day.DaysUntil = (int)Math.Ceiling(daysUntil.TotalDays) - debugDays;

                    // Skip if not in range
                    if (day.DaysUntil > 13 || day.DaysUntil < 0)
                    {
                        continue;
                    }

                    // Scrape image url
                    var content = await client.DownloadStringTaskAsync(day.Url);
                    content = content.Replace("\n", "");
                    var split = content.Split(new string[] { "id=\"chart_download\" rel=\"nofollow\"", "target=\"_blank\"" }, StringSplitOptions.RemoveEmptyEntries);
                    var url = split[6].Trim();
                    url = url.Replace("&amp;", "&");
                    url = url.Substring(8, url.Length - 9);
                    day.ImageUrl = "https://" + url;

                    // Download image
                    var filename = $"image{i}.png";
                    await client.DownloadFileTaskAsync(new Uri(day.ImageUrl), filename);
                    day.Image = Image.FromFile(filename);

                    // Crop image
                    var widthPart = Convert.ToInt32((day.Image.Width - 25) / 14);
                    var left = 25 + (widthPart * day.DaysUntil);
                    var bmpImage = new Bitmap(day.Image);
                    day.CroppedImage = bmpImage.Clone(new Rectangle(left, 90, widthPart, day.Image.Height - 90), bmpImage.PixelFormat);

                    // Show image
                    this.pictureBoxes[i].Image = day.CroppedImage;
                }
            }
        }
    }
}
