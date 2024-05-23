using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Windows.Forms;

namespace MeteoBlueWrapper.UI
{
    public partial class FrmMain : Form
    {
        private readonly List<Day> days = new();
        private DateTime today = DateTime.Now;
        private int debugDays = 0;

        public FrmMain()
        {
            this.InitializeComponent();

            this.InitLists();
            this.GetImages();
        }        

        private void InitLists()
        {
            if (File.Exists("tours\\deutschland.json"))
            {
                this.days.Clear();
                var json = File.ReadAllText("tours\\deutschland.json");
                this.days.AddRange(JsonConvert.DeserializeObject<List<Day>>(json));
            }            
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
                    var lblCity = (Label)cityControl[0];
                    lblCity.Text = day.City;
                    lblCity.Tag = day.Url;
                    var date = this.tableLayoutPanel1.Controls.Find($"LblDate{i + 1}", false);
                    var lblDate = (Label)date[0];
                    lblDate.Text = day.DateText;
                    lblDate.Tag = day.Date;

                    // -- Mark today's date with some color --
                    lblCity.BackColor = day.Date == this.today.Date ? Color.LightGreen : SystemColors.Control;
                    lblDate.BackColor = day.Date == this.today.Date ? Color.LightGreen : SystemColors.Control;

                    // -- Calculate days until --
                    // Add debug days to pretend we are in the future
                    var daysUntil = day.Date - DateTime.Now;
                    day.DaysUntil = (int)Math.Ceiling(daysUntil.TotalDays) - debugDays;

                    // -- Release image if present --
                    var pbxControl = this.tableLayoutPanel1.Controls.Find($"PbxDay{i + 1}", false);
                    var pbx = (PictureBox)pbxControl[0];
                    if (pbx.Image != null)
                    {
                        pbx.Image = null;
                        day.Image = null;
                        day.CroppedImage = null;
                    }

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
                    pbx.Tag = day.ImageUrl;

                    // -- Download image --
                    // Loading the image from disk with the using statement prevents any file lock
                    var filename = $"image{i}.png";
                    await client.DownloadFileTaskAsync(new Uri(day.ImageUrl), filename);
                    using (var bmpTemp = new Bitmap(filename))
                    {
                        day.Image = new Bitmap(bmpTemp);
                    }

                    // -- Crop image --
                    // For some reasons we don't need the first 25px from the left
                    // Cut the image in 14 columns and calculate the new left from DaysUntil
                    var widthPart = Convert.ToInt32((day.Image.Width - 25) / 14);
                    var left = 25 + (widthPart * day.DaysUntil);
                    var bmpImage = new Bitmap(day.Image);
                    day.CroppedImage = bmpImage.Clone(new Rectangle(left, 90, widthPart, day.Image.Height - 90), bmpImage.PixelFormat);

                    // -- Show image --                    
                    pbx.Image = day.CroppedImage;                    
                }
            }
        }
                
        private void LblCity_Click(object sender, EventArgs e)
        {
            var lblCity = (Label)sender;
            if (lblCity.Tag != null)
            {
                var webview = new FrmWeb(lblCity.Tag.ToString());
                webview.ShowDialog();
            }
        }

        private void BtnApplyDebugDays_Click(object sender, EventArgs e)
        {
            this.debugDays = (int)this.NudDebugDays.Value;
            this.today = DateTime.Now.AddDays(this.debugDays);
            this.GetImages();
        }

        private void PbxDay_Click(object sender, EventArgs e)
        {
            var pbxImage = (PictureBox)sender;
            if (pbxImage.Tag != null)
            {
                var webview = new FrmWeb(pbxImage.Tag.ToString());
                webview.ShowDialog();
            }
        }

        private void BtnEditor_Click(object sender, EventArgs e)
        {
            var frmEditor = new FrmEditor { Days = this.days };
            frmEditor.ShowDialog();
            this.GetImages();
        }
    }
}