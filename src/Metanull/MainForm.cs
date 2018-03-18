using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;
using System.IO;
using System.Drawing;

namespace Metanull
{
    public partial class MainForm : Form
    {
        private const int exifOrientationID = 0x112; //274

        string log = string.Empty;
        bool isRun = false;
        List<string> images = new List<string>();

        public MainForm()
        {
            InitializeComponent();
            //recreate the folder tree
        }

        private static RotateFlipType ExifRotate(Image img)
        {
            try
            {
                var prop = img.GetPropertyItem(exifOrientationID);
                int val = BitConverter.ToUInt16(prop.Value, 0);
                var rot = RotateFlipType.RotateNoneFlipNone;

                if (val == 3 || val == 4)
                    rot = RotateFlipType.Rotate180FlipNone;
                else if (val == 5 || val == 6)
                    rot = RotateFlipType.Rotate90FlipNone;
                else if (val == 7 || val == 8)
                    rot = RotateFlipType.Rotate270FlipNone;

                if (val == 2 || val == 4 || val == 5 || val == 7)
                    rot |= RotateFlipType.RotateNoneFlipX;

                return rot;
            }
            catch (Exception)
            {
                return RotateFlipType.RotateNoneFlipNone;
            }
        }

        private static void FlipImage(string input, string output)
        {
            using (Image sourceImg = Image.FromFile(input))
            {
                var rot = ExifRotate(sourceImg);

                using (Image destImg = Image.FromFile(output))
                {
                    if (rot != RotateFlipType.RotateNoneFlipNone)
                    {
                        destImg.RotateFlip(rot);
                        destImg.Save(output, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }
            }
        }

        private void batchFolderBrowseButton_Click(object sender, EventArgs e)
        {
            if (sourceFolderDialog.ShowDialog() == DialogResult.OK)
            {
                batchFolderTextBox.Text = sourceFolderDialog.SelectedPath;
            }
        }

        private void destFolderButton_Click(object sender, EventArgs e)
        {
            if (destFolderDialog.ShowDialog() == DialogResult.OK)
            {
                destFolderTextBox.Text = destFolderDialog.SelectedPath;
            }
        }

        private void LogLn(string text)
        {
            Log(text + Environment.NewLine);
        }

        private void Log(string text)
        {
            log += text;
            try
            {
                if (logTextBox == null) return;
                logTextBox.BeginInvoke(
                    new MethodInvoker(
                        delegate {
                            logTextBox.Text = log;
                            logTextBox.SelectionStart = logTextBox.Text.Length;
                            logTextBox.ScrollToCaret();
                        }));
            }
            catch { }
        }

        private void UpdateProgress(int progress)
        {
            try
            {
                if (progressBar == null) return;
                progressBar.BeginInvoke(
                    new MethodInvoker(
                        delegate
                        {
                            progressBar.Value = progress;
                        }));
            }
            catch { }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = "Metanull 1.1";
            LogLn("Metanull version " + Assembly.GetExecutingAssembly().GetName().Version.ToString());
            Log(@"Copyright © 2012-2013 Nikolai Voronin

https://github.com/nikvoronin/Metanull

");
        }

        private void nullItButton_Click(object sender, EventArgs e)
        {
            images.Clear();
            SearchOption opts = SearchOption.AllDirectories;
            string[] files = Directory.GetFiles(batchFolderTextBox.Text, "*.jp*g", opts);
            images.AddRange(files);

            nullItButton.Enabled = false;
            batchFolderBrowseButton.Enabled = false;
            batchFolderTextBox.Enabled = false;
            destFolderTextBox.Enabled = false;
            destFolderButton.Enabled = false;

            progressBar.Value = 0;
            isRun = true;
            waitTimer.Enabled = true;

            Thread thread = new Thread(
                    (ThreadStart)delegate
                    {
                        NullIt(batchFolderTextBox.Text);
                    });
            thread.Priority = ThreadPriority.BelowNormal;
            thread.Start();
        }

        private void NullIt(string srcFolder)
        {
            LogLn("----------------");
            LogLn("");
            DateTime startTime = DateTime.Now;
            int alreadyDo = 0;
            long totalLenRemoved = 0;
            int doFiles = 0;
            foreach (string filename in images)
            {
                BinaryReader reader =
                    new BinaryReader(
                        File.Open(filename, FileMode.Open));
                LogLn(filename);

                FileInfo srcFileInfo = new FileInfo(filename);
                string comma = filename.Contains("/") ? "/" : "\\";
                string destFolder = destFolderDialog.SelectedPath;

                // Scan source folder tree
                if (srcFolder != srcFileInfo.DirectoryName)
                {
                    string newSubFolder =
                        srcFileInfo.DirectoryName.Substring(
                            srcFolder.Length,
                            srcFileInfo.DirectoryName.Length - srcFolder.Length);
                    destFolder += newSubFolder;
                    Directory.CreateDirectory(destFolder);
                }

                BinaryWriter writer =
                    new BinaryWriter(
                        File.Open(destFolder + comma + srcFileInfo.Name, FileMode.Create));

                int removedSects = TruncateAll(reader, writer);
                LogLn(
                    "Done: " +
                    reader.BaseStream.Length + " bytes --> " +
                    writer.BaseStream.Length + " bytes. " + Environment.NewLine +
                    "Removed " + formatBytes(reader.BaseStream.Length - writer.BaseStream.Length) + " in " +
                    removedSects + " sections" +
                    Environment.NewLine);

                if (removedSects > 0)
                {
                    doFiles++;
                    totalLenRemoved += reader.BaseStream.Length - writer.BaseStream.Length;
                }

                reader.Close();
                writer.Flush();
                writer.Close();

                FlipImage(filename, destFolder + comma + srcFileInfo.Name);

                alreadyDo++;
                UpdateProgress(alreadyDo * 100 / images.Count);
                if (!isRun) break;
            }
            isRun = false;

            DateTime endTime = DateTime.Now;
            LogLn(
                "Completed (" +
                TimeSpan.FromTicks(endTime.Ticks - startTime.Ticks).ToString() + "): removed " +
                formatBytes(totalLenRemoved) + " in " +
                doFiles + " images." + Environment.NewLine
                );
        }

        private string formatBytes(float bytes)
        {
            string[] Suffix = { "bytes", "KB", "MB", "GB", "TB" };
            int i = 0;
            double dblSByte = 0;
            if ((int)(bytes / 1024) == 0)
            {
                return string.Format("{0} bytes", bytes);
            }
            else
            {
                for (i = 0; (int)(bytes / 1024) > 0; i++, bytes /= 1024)
                {
                    dblSByte = bytes / 1024.0;
                }
                return string.Format("{0:0.00} {1}", dblSByte, Suffix[i]);
            }
        }

        private int TruncateAll(BinaryReader reader, BinaryWriter writer)
        {
            int sectsRemoved = 0;
            long rLen = reader.BaseStream.Length;
            long wPos = 2;
            byte b1 = reader.ReadByte();
            byte b2 = reader.ReadByte();
            if (b1 != 0xff || b2 != 0xd8)
            {
                return 0;
            }
            else
            {
                writer.Write(b1);
                writer.Write(b2);
            }

            byte[] buffer;
            while (wPos < rLen)
            {
                // read section marker
                buffer = reader.ReadBytes(2);
                wPos += 2;
                // check end of image marker
                if (buffer[0] == 0xff && buffer[1] == 0xd9)
                {
                    writer.Write(buffer);
                    break;
                }

                if (buffer[0] == 0xff && buffer[1] == 0xda)
                {
                    // write section marker
                    writer.Write(buffer);
                    byte[] buf = new byte[4096];
                    while (wPos < rLen)
                    {
                        int readedBytes = reader.Read(buf, 0, buf.Length);
                        wPos += readedBytes;
                        writer.Write(buf, 0, readedBytes);
                    }
                }
                else
                {
                    if (buffer[0] == 0xff && (buffer[1] < 0xe0 || buffer[1] > 0xee))
                    {
                        // write section marker
                        writer.Write(buffer);
                        // read section length
                        buffer = reader.ReadBytes(2);
                        wPos += 2;
                        // write section length
                        writer.Write(buffer);
                        int sectionLen = buffer[0] * 256 + buffer[1];
                        // read section data
                        byte[] sectionBuffer = reader.ReadBytes(sectionLen - 2);
                        wPos += sectionLen - 2;
                        // write secion buffer
                        writer.Write(sectionBuffer);
                    }
                    else
                    {
                        // read section length
                        buffer = reader.ReadBytes(2);
                        wPos += 2;
                        int sectionLen = buffer[0] * 256 + buffer[1];
                        // read section data
                        byte[] sectionBuffer = reader.ReadBytes(sectionLen - 2);
                        wPos += sectionLen - 2;
                        sectsRemoved++;
                    }
                }
            }

            return sectsRemoved;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            waitTimer.Enabled = false;
            isRun = false;

            nullItButton.Enabled = true;
            batchFolderBrowseButton.Enabled = true;
            batchFolderTextBox.Enabled = true;
            destFolderTextBox.Enabled = true;
            destFolderButton.Enabled = true;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            isRun = false;
        }

        private void waitTimer_Tick(object sender, EventArgs e)
        {
            if (!isRun)
                stopButton_Click(this, e);
        }
    }
}
