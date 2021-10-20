using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MeteoBlueWrapper.UI
{
    public partial class FrmEditor : Form
    {
        private Day selectedDay;

        public FrmEditor()
        {
            this.InitializeComponent();
        }

        public List<Day> Days { get; set; }

        private void LvwDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.LvwDays.SelectedItems.Count > 0)
            {
                this.selectedDay = (Day)this.LvwDays.SelectedItems[0].Tag;
                this.DtpDate.Value = this.selectedDay.Date;
                this.TxtCity.Text = this.selectedDay.City;
                this.TxtDateText.Text = this.selectedDay.DateText;
                this.TxtUrl.Text = this.selectedDay.Url;
            }
            else
            {
                this.selectedDay = null;
            }
        }

        private void LoadDays()
        {
            this.LvwDays.Items.Clear();
            foreach (var day in this.Days)
            {
                var item = new ListViewItem(day.Date.ToShortDateString());
                item.Tag = day;
                item.SubItems.Add(day.City);
                item.SubItems.Add(day.DateText);
                item.SubItems.Add(day.Url);
                this.LvwDays.Items.Add(item);
            }
        }

        private void FrmEditor_Load(object sender, EventArgs e)
        {
            this.LoadDays();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            this.selectedDay.Date = this.DtpDate.Value;
            this.selectedDay.City = this.TxtCity.Text;
            this.selectedDay.DateText = this.TxtDateText.Text;
            this.selectedDay.Url = this.TxtUrl.Text;

            this.ClearInputs();
            this.LoadDays();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.ClearInputs();
            this.LvwDays.SelectedItems.Clear();
            this.selectedDay = null;
        }

        private void ClearInputs()
        {
            this.DtpDate.Value = DateTime.Now;
            this.TxtCity.Text = null;
            this.TxtDateText.Text = null;
            this.TxtUrl.Text = null;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
