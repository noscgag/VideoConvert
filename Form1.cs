using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Diagnostics;

namespace VideoConvert
{
    public partial class Form1 : Form
    {
        protected bool validData;
        protected string lastFilename = String.Empty;
        protected string [] filenameArray;
        protected bool Advanced = false;
        private static int numOutputLines = 0;
        private static StringBuilder ffOutput = null;

        public Form1()
        {
            InitializeComponent();
            radioButtonFaster.Checked = true;
            radioButtonSlower.Checked = false;
            comboBox1_ContainerType.SelectedIndex = 0;
            comboBox2_VideoFormat.SelectedIndex = 0;
            trackBar1_Quality.Value = 9;
            trackBar1_Quality.Enabled = false;
            QualityValue.Text = trackBar1_Quality.Value.ToString();
            trackBar1_Quality.Enabled = false;
            QualityValue.Enabled = false;
            QualityLabel.Enabled = false;
            cbMute.Checked = false;
            cbStabilize.Checked = false;
       }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            Debug.Print("DragDrop!");
            for (int i = 0; i < filenameArray.Length; i++)
                listBox1.Items.Add(filenameArray[i]);
            validData = false;
        }

        private void listBox1_onDragEnter(object sender, DragEventArgs e)
        {
            System.Diagnostics.Debug.Print("onDragEnter!");
            string filename;
            validData = GetFilename(out filename, e);
            if (validData)
            {
                lastFilename = filename;
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void listBox1_onDragLeave(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.Print("onDragLeave!");
        }

        private void listBox1_onDragOver(object sender, DragEventArgs e)
        {
            //System.Diagnostics.Debug.Print("onDragOver!");
        }

        protected bool GetFilename(out string filename, DragEventArgs e)
        {
            bool ret = false;
            filename = String.Empty;

            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                Array data = ((IDataObject)e.Data).GetData("FileDrop") as Array;
                if (data != null)
                {
                    filenameArray = new string[data.Length];
                    for (int i = 0; i < data.Length; i++) {
                        if (data.GetValue(i) is String) {
                            filename = ((string[])data)[i];
                            string ext = System.IO.Path.GetExtension(filename).ToLower();
                            //if ((ext == ".txt") || (ext == ".mpg") || (ext == ".mov"))
                            //{
                            //    ret = true;
                            //}
                            filenameArray[i] = filename;
                        }
                    }
                    return true;
                }
            }
            return ret;
        }

        private void onDataSourceChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("DataSource Changed!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Use ProcessStartInfo class
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = "ffmpeg.exe";
            //startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            System.Collections.IEnumerator ie = listBox1.Items.GetEnumerator();
            string ext = comboBox1_ContainerType.Text;
            int curitem = 0;
            // Make a copy of the listbox string so when we iterate through
            // the file list we can highlight the current item in the listbox.
            List<String> files = new List<String>();
            foreach (string s in listBox1.Items)
            {
                files.Add(s);
            }
            foreach (string s in files)
            {
                listBox1.SetSelected(curitem, true);
                Debug.WriteLine(s);
                string path = System.IO.Path.GetDirectoryName(s);
                string filename = System.IO.Path.GetFileNameWithoutExtension(s);
                startInfo.Arguments = "-i ";
                startInfo.Arguments += '"' + s + '"' + " ";

                // If stabilization is requested run ffmpeg to generate the
                // stabilization transform file stabtrans.trf. This will later
                // be used during the final pass to stabilize the output file.
                if (cbStabilize.Checked)
                {
                    ProcessStartInfo stabInfo = new ProcessStartInfo();
                    stabInfo.CreateNoWindow = false;
                    stabInfo.UseShellExecute = false;
                    stabInfo.FileName = "ffmpeg.exe";
                    stabInfo.Arguments = "-i ";
                    stabInfo.Arguments += '"' + s + '"' + " ";

                    //stabInfo.Arguments += "-vf vidstabdetect=shakiness=10:accuracy=15:result=stabtrans.trf:show=1 staboutput.mp4";
                    stabInfo.Arguments += "-vf vidstabdetect=shakiness=10:accuracy=15:result=stabtrans.trf:show=0 -f null -";
                    Debug.Write("ffmpeg ");
                    Debug.WriteLine(stabInfo.Arguments);
                    try
                    {
                        // Start the process with the info we specified.
                        // Call WaitForExit and then the using statement will close.
                        //stabInfo.RedirectStandardError = true;
                        //stabInfo.RedirectStandardOutput = true;
                        //stabInfo.UseShellExecute = false;
                        //using (Process exeProcess = new Process())
                        //{
                            Process exeProcess = new Process();
                            exeProcess.StartInfo = stabInfo;
                            //exeProcess.StartInfo.UseShellExecute = false;
                            //exeProcess.StartInfo.FileName = "ffmpeg.exe";
                            //exeProcess.StartInfo.Arguments = "-i ";
                            //exeProcess.StartInfo.Arguments += '"' + s + '"' + " ";
                            //exeProcess.StartInfo.Arguments += "-vf vidstabdetect=shakiness=10:accuracy=15:result=stabtrans.trf:show=0 -f null -";
                            //exeProcess.StartInfo.RedirectStandardError = true;
                            //exeProcess.StartInfo.RedirectStandardOutput = true;
                            //exeProcess.OutputDataReceived += new DataReceivedEventHandler(ffOutputHandler);
                            //exeProcess.BeginErrorReadLine();
                            //exeProcess.BeginOutputReadLine();
                            exeProcess.Start();
                            while (!exeProcess.WaitForExit(100))
                            {
                                //Debug.Write(".");
                                //Debug.WriteLine(exeProcess.StandardError.ReadToEnd());
                            }
                            //Debug.Write("stdout = ");
                            //Debug.WriteLine(exeProcess.StandardOutput.ReadToEnd());
                            //Debug.WriteLine(exeProcess.StandardError.ReadToEnd());
                            if (exeProcess.ExitCode != 0)
                            {
                                string msg = "ffmpeg exited with error code " + exeProcess.ExitCode;
                                MessageBox.Show(msg);
                            }
                        //}
                    }
                    catch
                    {
                        // Log error.
                    }
                }
                
                if (cbMute.Checked)
                    startInfo.Arguments += "-an ";
                string fmt = comboBox2_VideoFormat.Text;
                int quality = trackBar1_Quality.Value;
                if (fmt == "wmv")
                {
                    quality = 11 - quality;
                    startInfo.Arguments += "-q:a " + quality + " -q:v " + quality + " ";
                    startInfo.Arguments += "-acodec wmav2 -vcodec msmpeg4 ";
                    ext = "wmv";
                }
                // NOTE: theora has different quality factors than everything
                // else, seems to be the opposite. Normally quality increases as
                // the "q" decreases toward 1, whereas theora tend to get worse
                // when the "q" decreases.
                else if (fmt == "theora")
                {
                    startInfo.Arguments += "-q:a " + quality + " -q:v " + quality + " ";
                    startInfo.Arguments += "-acodec libvorbis -vcodec libtheora ";
                    ext = "mkv";
                }
                else if (fmt == "webm")
                {
                    // The quality for webm is really determined by the two
                    // parameters:
                    //  -b:v        bitrate, roughly 1M to 10M
                    //  -crf        constant quality mode, 4 - 63, 4 being best
                    // The <quality> value ranges from 1 - 10 (range of 9), where 1 is bad and 10 is best.
                    // Multiply the input quality (-1) by the crf range (63-4), then divide by
                    // the input quality range (10 - 1 = 9) to get the crf in the range 0 - 59
                    // This is inverted (0 is bad, 59 is good), so we subtract it
                    // from our crf range to make 0 good and 59 bad, then add 4 to
                    // get it into the 4 - 63 range.
                    int bitrate = quality;  // Will just tack on 'M' to make it megabits/sec
                    int aquality = quality;    // Audio quality
                    int crf = (quality-1) * (63 - 4) / 9;
                    crf = (63 - 4) - crf + 4;
                    startInfo.Arguments += "-q:a " + aquality + " -b:v " + bitrate + "M " + "-crf " + crf + " ";
                    startInfo.Arguments += "-acodec libvorbis -vcodec libvpx ";
                    ext = "webm";
                }
                else
                {
                    if (radioButtonFaster.Checked)
                        startInfo.Arguments += "-target ntsc-dvd ";
                    else
                    {
                        int crf = (quality - 1) * (51 - 18) / 9;
                        crf = (51 - 18) - crf + 18;
                        startInfo.Arguments += "-c:v libx264 -crf " + crf + " -preset slow ";
                        if (!PreserveSize.Checked)
                            startInfo.Arguments += "-s hd480 ";
                    }
                }
                // The following commented-out because it doesn't work with the latest version of ffmpeg
                //if (ext == "avi") {
                //    startInfo.Arguments += "-acodec mp2 ";
                //}
                // Add stabilization arguments if needed
                if (cbStabilize.Checked)
                {
                    //startInfo.Arguments += "-vf vidstabtransform=crop=black:input=stabtrans.trf,unsharp=5:5:0.8:3:3:0.4 -c:v libx264 -level 41 -pix_fmt yuv420p -g 24 -crf 19 -c:a aac -strict experimental -ar 48000 -ab 256k ";
                    startInfo.Arguments += "-vf vidstabtransform=crop=black:input=stabtrans.trf,unsharp=5:5:0.8:3:3:0.4 ";
                }

                string fullname = GetUniqueFilename(path, filename, ext);
                startInfo.Arguments += fullname;
                //startInfo.RedirectStandardError = true;
                //startInfo.RedirectStandardOutput = true;
                //startInfo.UseShellExecute = false;
                Debug.WriteLine(startInfo.Arguments);
                try
                {
                    // Start the process with the info we specified.
                    // Call WaitForExit and then the using statement will close.
                    using (Process exeProcess = Process.Start(startInfo))
                    {
                        while (!exeProcess.WaitForExit(100))
                        {
                            // twiddle our thumbs
                        }
                        if (exeProcess.ExitCode != 0)
                        {
                            Debug.WriteLine("stderr:");
                            Debug.WriteLine(exeProcess.StandardError.ReadToEnd());
                            Debug.WriteLine("stdout:");
                            Debug.WriteLine(exeProcess.StandardOutput.ReadToEnd());
                            string msg = "ffmpeg exited with error code " + exeProcess.ExitCode;
                            MessageBox.Show(msg);
                        }
                    }
                }
                catch
                {
                    // Log error.
                }
                listBox1.SetSelected(curitem, false);
                curitem++;
            }

        }
        private static void ffOutputHandler(object sendingProcess,
            DataReceivedEventArgs outLine)
        {
            // Collect the sort command output. 
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                numOutputLines++;
                Debug.WriteLine(outLine.Data);

                // Add the text to the collected output.
                ffOutput.Append(Environment.NewLine +
                    "[" + numOutputLines.ToString() + "] - " + outLine.Data);
            }
        }

        private string GetUniqueFilename(string path, string filename, string ext)
        {
            string fullname = path + "\\" + filename + "." + ext;
            for (int i = 0; i < 100; i++)
            {
                if (File.Exists(fullname))
                {
                    fullname = path + "\\" + filename + i + "." + ext;
                }
                else
                    break;
            }
            return '"' + fullname + '"';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //radioButtonFaster.Checked = true;
            //radioButtonSlower.Checked = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //radioButtonFaster.Checked = false;
            //radioButtonSlower.Checked = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_VideoFormat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Advanced = checkBox1.Checked;
            if (Advanced)
            {
                trackBar1_Quality.Enabled = true;
                QualityValue.Enabled = true;
                QualityLabel.Enabled = true;
            }
            else
            {
                trackBar1_Quality.Enabled = false;
                QualityValue.Enabled = false;
                QualityLabel.Enabled = false;
           }
        }

        private void trackBar1_Quality_Scroll(object sender, EventArgs e)
        {
            QualityValue.Text = trackBar1_Quality.Value.ToString();
        }

        private void PreserveSize_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (cbStabilize.Checked)
                radioButtonSlower.Checked = true;
        }

        private void cbMute_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
