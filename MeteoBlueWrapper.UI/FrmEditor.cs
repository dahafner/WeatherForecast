using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

        private void FrmEditor_Load(object sender, EventArgs e)
        {
            this.ShowDays();
        }

        private void LvwDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.LvwDays.SelectedItems.Count > 0)
            {
                this.selectedDay = (Day)this.LvwDays.SelectedItems[0].Tag;
                this.DtpDate.Value = this.selectedDay.Date;
                this.TxtCity.Text = this.selectedDay.City;
                this.TxtDateText.Text = this.selectedDay.DateText;
                this.TxtUrl.Text = this.selectedDay.Url;
                this.EnableDisable(true);
            }
            else
            {
                this.selectedDay = null;
                this.EnableDisable(false);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            this.LvwDays.Items.Remove(this.LvwDays.SelectedItems[0]);
            this.ClearInputs();
            this.EnableDisable(false);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            this.selectedDay.Date = this.DtpDate.Value;
            this.selectedDay.City = this.TxtCity.Text;
            this.selectedDay.DateText = this.TxtDateText.Text;
            this.selectedDay.Url = this.TxtUrl.Text;

            this.ClearInputs();
            this.EnableDisable(false);
            this.ShowDays();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.ClearInputs();
            this.EnableDisable(false);
            this.LvwDays.SelectedItems.Clear();
            this.selectedDay = null;
        }

        private void ShowDays()
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

        private void ClearInputs()
        {
            this.DtpDate.Value = DateTime.Now;
            this.TxtCity.Text = null;
            this.TxtDateText.Text = null;
            this.TxtUrl.Text = null;
        }

        private void EnableDisable(bool enable)
        {
            this.BtnSave.Enabled = enable;
            this.BtnDelete.Enabled = enable;
            this.BtnCancel.Enabled = enable;
        }

        private void BtnSaveList_Click(object sender, EventArgs e)
        {
            if (this.SfdSave.ShowDialog() == DialogResult.OK)
            {
                var json = JsonConvert.SerializeObject(this.Days);
                File.WriteAllText(this.SfdSave.FileName, json);
            }
        }

        private void BtnLoadList_Click(object sender, EventArgs e)
        {
            if (this.OfdOpen.ShowDialog() == DialogResult.OK)
            {
                this.Days.Clear();
                var json = File.ReadAllText(this.OfdOpen.FileName);
                this.Days.AddRange(JsonConvert.DeserializeObject<List<Day>>(json));
                this.ShowDays();
                this.ClearInputs();
                this.EnableDisable(false);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
