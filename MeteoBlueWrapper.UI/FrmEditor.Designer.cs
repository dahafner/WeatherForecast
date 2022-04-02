namespace MeteoBlueWrapper.UI
{
    partial class FrmEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditor));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LvwDays = new System.Windows.Forms.ListView();
            this.ChrDate = new System.Windows.Forms.ColumnHeader();
            this.ChrCity = new System.Windows.Forms.ColumnHeader();
            this.ChrDateText = new System.Windows.Forms.ColumnHeader();
            this.ChrUrl = new System.Windows.Forms.ColumnHeader();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnSaveList = new System.Windows.Forms.Button();
            this.BtnLoadList = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtUrl = new System.Windows.Forms.TextBox();
            this.TxtDateText = new System.Windows.Forms.TextBox();
            this.TxtCity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DtpDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.SfdSave = new System.Windows.Forms.SaveFileDialog();
            this.OfdOpen = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(915, 539);
            this.splitContainer1.SplitterDistance = 599;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LvwDays);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(599, 539);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tage";
            // 
            // LvwDays
            // 
            this.LvwDays.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ChrDate,
            this.ChrCity,
            this.ChrDateText,
            this.ChrUrl});
            this.LvwDays.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LvwDays.FullRowSelect = true;
            this.LvwDays.GridLines = true;
            this.LvwDays.HideSelection = false;
            this.LvwDays.Location = new System.Drawing.Point(3, 19);
            this.LvwDays.Name = "LvwDays";
            this.LvwDays.Size = new System.Drawing.Size(593, 517);
            this.LvwDays.TabIndex = 0;
            this.LvwDays.UseCompatibleStateImageBehavior = false;
            this.LvwDays.View = System.Windows.Forms.View.Details;
            this.LvwDays.SelectedIndexChanged += new System.EventHandler(this.LvwDays_SelectedIndexChanged);
            // 
            // ChrDate
            // 
            this.ChrDate.Text = "Datum";
            this.ChrDate.Width = 100;
            // 
            // ChrCity
            // 
            this.ChrCity.Text = "Ort";
            this.ChrCity.Width = 200;
            // 
            // ChrDateText
            // 
            this.ChrDateText.Text = "Tag";
            this.ChrDateText.Width = 100;
            // 
            // ChrUrl
            // 
            this.ChrUrl.Text = "Url";
            this.ChrUrl.Width = 100;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnDelete);
            this.groupBox2.Controls.Add(this.BtnSaveList);
            this.groupBox2.Controls.Add(this.BtnLoadList);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.BtnClose);
            this.groupBox2.Controls.Add(this.BtnSave);
            this.groupBox2.Controls.Add(this.BtnCancel);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.TxtUrl);
            this.groupBox2.Controls.Add(this.TxtDateText);
            this.groupBox2.Controls.Add(this.TxtCity);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.DtpDate);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(312, 539);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Eigenschaften";
            // 
            // BtnDelete
            // 
            this.BtnDelete.Enabled = false;
            this.BtnDelete.Location = new System.Drawing.Point(64, 297);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(64, 23);
            this.BtnDelete.TabIndex = 11;
            this.BtnDelete.Text = "Löschen";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnSaveList
            // 
            this.BtnSaveList.Location = new System.Drawing.Point(64, 481);
            this.BtnSaveList.Name = "BtnSaveList";
            this.BtnSaveList.Size = new System.Drawing.Size(110, 23);
            this.BtnSaveList.TabIndex = 10;
            this.BtnSaveList.Text = "Speichern...";
            this.BtnSaveList.UseVisualStyleBackColor = true;
            this.BtnSaveList.Click += new System.EventHandler(this.BtnSaveList_Click);
            // 
            // BtnLoadList
            // 
            this.BtnLoadList.Location = new System.Drawing.Point(180, 481);
            this.BtnLoadList.Name = "BtnLoadList";
            this.BtnLoadList.Size = new System.Drawing.Size(110, 23);
            this.BtnLoadList.TabIndex = 9;
            this.BtnLoadList.Text = "Öffnen...";
            this.BtnLoadList.UseVisualStyleBackColor = true;
            this.BtnLoadList.Click += new System.EventHandler(this.BtnLoadList_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 485);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Liste:";
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(6, 510);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(284, 23);
            this.BtnClose.TabIndex = 7;
            this.BtnClose.Text = "Schliessen";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Enabled = false;
            this.BtnSave.Location = new System.Drawing.Point(134, 297);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 6;
            this.BtnSave.Text = "Speichern";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Enabled = false;
            this.BtnCancel.Location = new System.Drawing.Point(215, 297);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 5;
            this.BtnCancel.Text = "Abbrechen";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Url:";
            // 
            // TxtUrl
            // 
            this.TxtUrl.Location = new System.Drawing.Point(90, 138);
            this.TxtUrl.Multiline = true;
            this.TxtUrl.Name = "TxtUrl";
            this.TxtUrl.Size = new System.Drawing.Size(200, 153);
            this.TxtUrl.TabIndex = 3;
            // 
            // TxtDateText
            // 
            this.TxtDateText.Location = new System.Drawing.Point(90, 103);
            this.TxtDateText.Name = "TxtDateText";
            this.TxtDateText.Size = new System.Drawing.Size(200, 23);
            this.TxtDateText.TabIndex = 3;
            // 
            // TxtCity
            // 
            this.TxtCity.Location = new System.Drawing.Point(90, 68);
            this.TxtCity.Name = "TxtCity";
            this.TxtCity.Size = new System.Drawing.Size(200, 23);
            this.TxtCity.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tag:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ort:";
            // 
            // DtpDate
            // 
            this.DtpDate.Location = new System.Drawing.Point(90, 33);
            this.DtpDate.Name = "DtpDate";
            this.DtpDate.Size = new System.Drawing.Size(200, 23);
            this.DtpDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Datum:";
            // 
            // SfdSave
            // 
            this.SfdSave.Filter = "*.json|Json Files";
            // 
            // OfdOpen
            // 
            this.OfdOpen.FileName = "*.json";
            this.OfdOpen.Filter = "*.json|Json Files";
            this.OfdOpen.RestoreDirectory = true;
            // 
            // FrmEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 539);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor";
            this.Load += new System.EventHandler(this.FrmEditor_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView LvwDays;
        private System.Windows.Forms.ColumnHeader ChrDate;
        private System.Windows.Forms.ColumnHeader ChrCity;
        private System.Windows.Forms.ColumnHeader ChrDateText;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ColumnHeader ChrUrl;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtUrl;
        private System.Windows.Forms.TextBox TxtDateText;
        private System.Windows.Forms.TextBox TxtCity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DtpDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button BtnSaveList;
        private System.Windows.Forms.Button BtnLoadList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.SaveFileDialog SfdSave;
        private System.Windows.Forms.OpenFileDialog OfdOpen;
        private System.Windows.Forms.Button BtnDelete;
    }
}