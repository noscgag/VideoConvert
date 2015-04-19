namespace VideoConvert
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonFaster = new System.Windows.Forms.RadioButton();
            this.radioButtonSlower = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1_ContainerType = new System.Windows.Forms.ComboBox();
            this.comboBox2_VideoFormat = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.QualityLabel = new System.Windows.Forms.Label();
            this.trackBar1_Quality = new System.Windows.Forms.TrackBar();
            this.QualityValue = new System.Windows.Forms.Label();
            this.PreserveSize = new System.Windows.Forms.CheckBox();
            this.cbMute = new System.Windows.Forms.CheckBox();
            this.cbStabilize = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1_Quality)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.AllowDrop = true;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(26, 51);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(260, 186);
            this.listBox1.TabIndex = 0;
            this.listBox1.DataSourceChanged += new System.EventHandler(this.onDataSourceChanged);
            this.listBox1.DragOver += new System.Windows.Forms.DragEventHandler(this.listBox1_onDragOver);
            this.listBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox1_DragDrop);
            this.listBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox1_onDragEnter);
            this.listBox1.DragLeave += new System.EventHandler(this.listBox1_onDragLeave);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 244);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Convert";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(211, 244);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Drag and drop files to be converted into the box below";
            // 
            // radioButtonFaster
            // 
            this.radioButtonFaster.AutoSize = true;
            this.radioButtonFaster.Location = new System.Drawing.Point(26, 274);
            this.radioButtonFaster.Name = "radioButtonFaster";
            this.radioButtonFaster.Size = new System.Drawing.Size(101, 17);
            this.radioButtonFaster.TabIndex = 4;
            this.radioButtonFaster.TabStop = true;
            this.radioButtonFaster.Text = "Fast, bigger files";
            this.radioButtonFaster.UseVisualStyleBackColor = true;
            this.radioButtonFaster.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButtonSlower
            // 
            this.radioButtonSlower.AutoSize = true;
            this.radioButtonSlower.Location = new System.Drawing.Point(178, 274);
            this.radioButtonSlower.Name = "radioButtonSlower";
            this.radioButtonSlower.Size = new System.Drawing.Size(107, 17);
            this.radioButtonSlower.TabIndex = 5;
            this.radioButtonSlower.TabStop = true;
            this.radioButtonSlower.Text = "Slow, smaller files";
            this.radioButtonSlower.UseVisualStyleBackColor = true;
            this.radioButtonSlower.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 304);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Output Type:";
            // 
            // comboBox1_ContainerType
            // 
            this.comboBox1_ContainerType.FormattingEnabled = true;
            this.comboBox1_ContainerType.Items.AddRange(new object[] {
            "avi",
            "mpg",
            "mp4",
            "wmv"});
            this.comboBox1_ContainerType.Location = new System.Drawing.Point(26, 323);
            this.comboBox1_ContainerType.Name = "comboBox1_ContainerType";
            this.comboBox1_ContainerType.Size = new System.Drawing.Size(121, 21);
            this.comboBox1_ContainerType.TabIndex = 8;
            this.comboBox1_ContainerType.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2_VideoFormat
            // 
            this.comboBox2_VideoFormat.FormattingEnabled = true;
            this.comboBox2_VideoFormat.Items.AddRange(new object[] {
            "h264",
            "mpeg4",
            "wmv",
            "mpeg1video",
            "mpeg2video",
            "theora",
            "webm"});
            this.comboBox2_VideoFormat.Location = new System.Drawing.Point(178, 323);
            this.comboBox2_VideoFormat.Name = "comboBox2_VideoFormat";
            this.comboBox2_VideoFormat.Size = new System.Drawing.Size(121, 21);
            this.comboBox2_VideoFormat.TabIndex = 9;
            this.comboBox2_VideoFormat.SelectedIndexChanged += new System.EventHandler(this.comboBox2_VideoFormat_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(175, 304);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Video Format:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(26, 350);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(75, 17);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "Advanced";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // QualityLabel
            // 
            this.QualityLabel.AutoSize = true;
            this.QualityLabel.Location = new System.Drawing.Point(23, 376);
            this.QualityLabel.Name = "QualityLabel";
            this.QualityLabel.Size = new System.Drawing.Size(42, 13);
            this.QualityLabel.TabIndex = 13;
            this.QualityLabel.Text = "Quality:";
            // 
            // trackBar1_Quality
            // 
            this.trackBar1_Quality.Location = new System.Drawing.Point(98, 373);
            this.trackBar1_Quality.Minimum = 1;
            this.trackBar1_Quality.Name = "trackBar1_Quality";
            this.trackBar1_Quality.Size = new System.Drawing.Size(104, 45);
            this.trackBar1_Quality.TabIndex = 14;
            this.trackBar1_Quality.Value = 1;
            this.trackBar1_Quality.Scroll += new System.EventHandler(this.trackBar1_Quality_Scroll);
            // 
            // QualityValue
            // 
            this.QualityValue.AutoSize = true;
            this.QualityValue.Location = new System.Drawing.Point(79, 376);
            this.QualityValue.Name = "QualityValue";
            this.QualityValue.Size = new System.Drawing.Size(19, 13);
            this.QualityValue.TabIndex = 15;
            this.QualityValue.Text = "10";
            // 
            // PreserveSize
            // 
            this.PreserveSize.AutoSize = true;
            this.PreserveSize.Location = new System.Drawing.Point(178, 351);
            this.PreserveSize.Name = "PreserveSize";
            this.PreserveSize.Size = new System.Drawing.Size(91, 17);
            this.PreserveSize.TabIndex = 16;
            this.PreserveSize.Text = "Preserve Size";
            this.PreserveSize.UseVisualStyleBackColor = true;
            this.PreserveSize.CheckedChanged += new System.EventHandler(this.PreserveSize_CheckedChanged);
            // 
            // cbMute
            // 
            this.cbMute.AutoSize = true;
            this.cbMute.Location = new System.Drawing.Point(26, 401);
            this.cbMute.Name = "cbMute";
            this.cbMute.Size = new System.Drawing.Size(80, 17);
            this.cbMute.TabIndex = 17;
            this.cbMute.Text = "Mute Audio";
            this.cbMute.UseVisualStyleBackColor = true;
            this.cbMute.CheckedChanged += new System.EventHandler(this.cbMute_CheckedChanged);
            // 
            // cbStabilize
            // 
            this.cbStabilize.AutoSize = true;
            this.cbStabilize.Location = new System.Drawing.Point(26, 425);
            this.cbStabilize.Name = "cbStabilize";
            this.cbStabilize.Size = new System.Drawing.Size(130, 17);
            this.cbStabilize.TabIndex = 18;
            this.cbStabilize.Text = "Stabilize (VERY slow!)";
            this.cbStabilize.UseVisualStyleBackColor = true;
            this.cbStabilize.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 448);
            this.Controls.Add(this.cbStabilize);
            this.Controls.Add(this.cbMute);
            this.Controls.Add(this.PreserveSize);
            this.Controls.Add(this.QualityValue);
            this.Controls.Add(this.trackBar1_Quality);
            this.Controls.Add(this.QualityLabel);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox2_VideoFormat);
            this.Controls.Add(this.comboBox1_ContainerType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radioButtonSlower);
            this.Controls.Add(this.radioButtonFaster);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Video Converter";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1_Quality)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButtonFaster;
        private System.Windows.Forms.RadioButton radioButtonSlower;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1_ContainerType;
        private System.Windows.Forms.ComboBox comboBox2_VideoFormat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label QualityLabel;
        private System.Windows.Forms.TrackBar trackBar1_Quality;
        private System.Windows.Forms.Label QualityValue;
        private System.Windows.Forms.CheckBox PreserveSize;
        private System.Windows.Forms.CheckBox cbMute;
        private System.Windows.Forms.CheckBox cbStabilize;
    }
}

