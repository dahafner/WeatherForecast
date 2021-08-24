using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Net.Cache;
using System.Windows.Forms;

namespace MeteoBlueWrapper.UI
{
    public partial class FrmMain : Form
    {
        private readonly List<Day> days = new();
        private readonly int debugDays = 0;

        public FrmMain()
        {
            this.InitializeComponent();

            this.InitLists();
            this.GetImages();
        }        

        private void InitLists()
        {
            this.days.Add(new Day { Url = "https://www.meteoblue.com/de/wetter/14-tage/davos_schweiz_2661039", Date = new DateTime(2021, 9, 4), City = "Davos", DateText = "Sa 04.09." });
            this.days.Add(new Day { Url = "https://www.meteoblue.com/de/wetter/14-tage/sankt-moritz_schweiz_2658813", Date = new DateTime(2021, 9, 5), City = "St. Moritz", DateText = "So 05.09." });
            this.days.Add(new Day { Url = "https://www.meteoblue.com/de/wetter/14-tage/tenero_schweiz_2658407", Date = new DateTime(2021, 9, 6), City = "Tenero", DateText = "Mo 06.09." });
            this.days.Add(new Day { Url = "https://www.meteoblue.com/de/wetter/14-tage/tenero_schweiz_2658407", Date = new DateTime(2021, 9, 7), City = "Tenero", DateText = "Di 07.09." });
            this.days.Add(new Day { Url = "https://www.meteoblue.com/de/wetter/14-tage/brig_schweiz_2661394", Date = new DateTime(2021, 9, 8), City = "Brig", DateText = "Mi 08.09." });
            this.days.Add(new Day { Url = "https://www.meteoblue.com/de/wetter/14-tage/zermatt_schweiz_2657928", Date = new DateTime(2021, 9, 9), City = "Zermatt", DateText = "Do 09.09." });
            this.days.Add(new Day { Url = "https://www.meteoblue.com/de/wetter/14-tage/morges_schweiz_2659587", Date = new DateTime(2021, 9, 10), City = "Morges", DateText = "Fr 10.09." });
            this.days.Add(new Day { Url = "https://www.meteoblue.com/de/wetter/14-tage/neuenburg_schweiz_2659496", Date = new DateTime(2021, 9, 11), City = "Neuchatel", DateText = "Sa 11.09." });
            this.days.Add(new Day { Url = "https://www.meteoblue.com/de/wetter/14-tage/sugiez_schweiz_2658458", Date = new DateTime(2021, 9, 12), City = "Sugiez", DateText = "So 12.09." });
            this.days.Add(new Day { Url = "https://www.meteoblue.com/de/wetter/14-tage/sugiez_schweiz_2658458", Date = new DateTime(2021, 9, 13), City = "Sugiez", DateText = "Mo 13.09." });
            this.days.Add(new Day { Url = "https://www.meteoblue.com/de/wetter/14-tage/bern_schweiz_2661552", Date = new DateTime(2021, 9, 14), City = "Bern", DateText = "Di 14.09." });
            this.days.Add(new Day { Url = "https://www.meteoblue.com/de/wetter/14-tage/luzern_schweiz_2659811", Date = new DateTime(2021, 9, 15), City = "Luzern", DateText = "Mi 15.09." });
            this.days.Add(new Day { Url = "https://www.meteoblue.com/de/wetter/14-tage/arbon_schweiz_2661731", Date = new DateTime(2021, 9, 16), City = "Arbon", DateText = "Do 16.09." });
            this.days.Add(new Day { Url = "https://www.meteoblue.com/de/wetter/14-tage/arbon_schweiz_2661731", Date = new DateTime(2021, 9, 17), City = "Arbon", DateText = "Fr 17.09." });
        }

        private async void GetImages()
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:91.0) Gecko/20100101 Firefox/91.0");
                client.Headers.Add("Cache-Control", "no-cache");
                client.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);

                for (var i = 0; i < this.days.Count; i++)
                {
                    var day = this.days[i];

                    // -- Show city and date --
                    var cityControl = this.tableLayoutPanel1.Controls.Find($"LblCity{i + 1}", false);
                    var lblCity = ((Label)cityControl[0]);
                    lblCity.Text = day.City;
                    lblCity.Tag = day.Url;
                    var date = this.tableLayoutPanel1.Controls.Find($"LblDate{i + 1}", false);
                    ((Label)date[0]).Text = day.DateText;

                    // -- Calculate days until --
                    // Add debug days to pretend we are in the future
                    var daysUntil = day.Date - DateTime.Now;
                    day.DaysUntil = (int)Math.Ceiling(daysUntil.TotalDays) - debugDays;

                    // -- Skip if not in range --
                    if (day.DaysUntil > 13 || day.DaysUntil < 0)
                    {
                        continue;
                    }

                    // -- Scrape image url --
                    // Work your way through to the url from the download button
                    var content = await client.DownloadStringTaskAsync(day.Url);
                    content = content.Replace("\n", "");
                    var split = content.Split(new string[] { "id=\"chart_download\" rel=\"nofollow\"", "target=\"_blank\"" }, StringSplitOptions.RemoveEmptyEntries);
                    var url = split[6].Trim();
                    url = url.Replace("&amp;", "&");
                    url = url.Substring(8, url.Length - 9);
                    day.ImageUrl = "https://" + url;

                    // -- Download image --
                    var filename = $"image{i}.png";
                    await client.DownloadFileTaskAsync(new Uri(day.ImageUrl), filename);
                    day.Image = Image.FromFile(filename);

                    // -- Crop image --
                    // For some reasons we don't need the first 25px from the left
                    // Cut the image in 14 columns and calculate the new left from DaysUntil
                    var widthPart = Convert.ToInt32((day.Image.Width - 25) / 14);
                    var left = 25 + (widthPart * day.DaysUntil);
                    var bmpImage = new Bitmap(day.Image);
                    day.CroppedImage = bmpImage.Clone(new Rectangle(left, 90, widthPart, day.Image.Height - 90), bmpImage.PixelFormat);

                    // -- Show image --
                    var pbx = this.tableLayoutPanel1.Controls.Find($"PbxDay{i + 1}", false);
                    ((PictureBox)pbx[0]).Image = day.CroppedImage;
                }
            }
        }

        private void LblCity_Click(object sender, EventArgs e)
        {
            var lblCity = (Label)sender;
            if (lblCity.Tag != null)
            {
                Process.Start("explorer.exe", lblCity.Tag.ToString());
            }
        }
    }
}