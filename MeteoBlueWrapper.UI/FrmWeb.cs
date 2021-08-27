using System;
using System.Windows.Forms;

namespace MeteoBlueWrapper.UI
{
    public partial class FrmWeb : Form
    {
        public FrmWeb()
        {
            this.InitializeComponent();
        }

        public FrmWeb(string url) : this()
        {
            this.WebView.Source = new Uri(url);
        }
    }
}