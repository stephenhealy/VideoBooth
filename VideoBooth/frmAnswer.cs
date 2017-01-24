using Core;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.Expression.Encoder;
using Microsoft.Expression.Encoder.Devices;
using Microsoft.Expression.Encoder.Live;
using Microsoft.Expression.Encoder.Profiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoBooth.Properties;

namespace VideoBooth
{
    public partial class frmAnswer : CustomForm
    {
        private System.Windows.Forms.Timer Timer;
        private LiveJob _job { get; set; }
        private LiveDeviceSource _deviceSource { get; set; }
        private frmQuestion Question;
        public int EventID { get; set; }
        public int QuestionID { get; set; }
        private Thread workerThread = null;
        private bool turnOn { get; set; }
        // Declare a delegate used to communicate with the UI thread
        private delegate void UpdateWebcamLoaded();
        private UpdateWebcamLoaded updateWebcamLoaded = null;

        public frmAnswer(frmQuestion form)
        {
            InitializeComponent();
            Question = form;
            ScreenName = form.ScreenName;
            Maximized = form.Maximized;
        }

        private void frmAnswer_Load(object sender, EventArgs e)
        {
            picArrow.Image = Resources.arrow;
            turnOn = true;
            SetScreen();
            lblTimer.Visible = ShowTimers;

            // Initialise the delegate
            this.updateWebcamLoaded = new UpdateWebcamLoaded(this.WebcamLoaded);
        }

        public void LoadHelp()
        {
            StartCountdown();
        }

        public void StartCountdown()
        {
            // Initialise and start worker thread
            this.workerThread = new Thread(new ThreadStart(this.LoadWebcam));
            this.workerThread.Start();
        }

        public void LoadWebcam()
        {
            if (turnOn)
            {
                turnOn = false;
                EncoderDevice video = null;
                var videoDevices = EncoderDevices.FindDevices(EncoderDeviceType.Video);
                foreach (var videoDevice in videoDevices)
                {
                    if (videoDevice.Name == "HD Pro Webcam C920")
                    {
                        video = videoDevice;
                        break;
                    }
                }
                EncoderDevice audio = null;
                var audioDevices = EncoderDevices.FindDevices(EncoderDeviceType.Audio);
                foreach (var audioDevice in audioDevices)
                {
                    if (audioDevice.Name == "Microphone (HD Pro Webcam C920)")
                    {
                        audio = audioDevice;
                        break;
                    }
                }
                //EncoderDevice audio = audioDevices[1];

                if (video != null && audio != null)
                {
                    try
                    {
                        // Starts new job for preview window
                        _job = new LiveJob();
                        // Create a new device source. We use the first audio and video devices on the system
                        _deviceSource = _job.AddDeviceSource(video, audio);
                        // Set video format options
                        //Size framesize = new Size(640, 480);
                        Size framesize = new Size(1280, 720);
                        _deviceSource.PickBestVideoFormat(framesize, 60);
                        //_job.ApplyPreset(LivePresets.H264IISSmoothStreaming720pWidescreen);
                        _job.OutputFormat.VideoProfile.Size = framesize;
                        _job.OutputFormat.VideoProfile.FrameRate = 60;
                        _job.OutputFormat.VideoProfile.Bitrate = new ConstantBitrate(15000);

                        // Sets preview window to winform panel hosted by xaml window
                        //_deviceSource.PreviewWindow = new PreviewWindow(new HandleRef(panPreview, panPreview.Handle));
                        // Make this source the active one
                        _job.ActivateSource(_deviceSource);
                    }
                    catch (Exception ex)
                    {

                    }
                }
                else
                    MessageBox.Show("Could not find a video or audio device.", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Show progress
            this.Invoke(this.updateWebcamLoaded);
            this.workerThread.Abort();
        }

        private void WebcamLoaded()
        {
            // Once webcam is loaded.
            this.lblNow.Text = "Respond Now!";

            ShowHide(false);
            lblCounter.Text = "5";
            Timer = new System.Windows.Forms.Timer();
            Timer.Tick += new EventHandler(timer_Tick);
            Timer.Interval = 1000; // 1 second
            Timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            int counter = Int32.Parse(lblCounter.Text);
            counter--;
            if (counter == 0)
            {
                Timer.Stop();
                ShowHide(true);
                lblCounter.Text = "RESPOND NOW!!";

                StartRecording();
            }
            else
                lblCounter.Text = counter.ToString();
        }

        private void StartRecording()
        {
            if (Demo == false)
            {
                // Sets up publishing format for file archival type
                FileArchivePublishFormat fileOut = new FileArchivePublishFormat();
                fileOut.OutputFileName = String.Format("C:\\Users\\Steve\\Videos\\WebCam{0:yyyyMMdd_hhmmss}.wmv", DateTime.Now);
                // Adds the format to the job. You can add additional formats
                // as well such as Publishing streams or broadcasting from a port
                _job.PublishFormats.Add(fileOut);
                // Start encoding
                _job.StartEncoding();
            }
        }

        private void StopRecording()
        {
            if (Demo == false)
            {
                _job.StopEncoding();
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            StopRecording();

            // Remove the Device Source and destroy the job
            _job.RemoveDeviceSource(_deviceSource);
            // Destroy the device source
            _deviceSource.PreviewWindow = null;
            _deviceSource = null;

            // Send back to question
            Question.Back();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            StopRecording();
            StartCountdown();
        }
        private void ShowHide(bool loading)
        {
            lblCounter.Visible = lblCountdown.Visible = !loading;
            lblNow.Visible = btnDone.Visible = btnRestart.Visible = panPreview.Visible = loading;
            panPreview.Visible = false;
        }

        public void SetTimer(int timer)
        {
            lblTimer.Text = "Timer = " + timer.ToString();
        }









        private string ConvertByteDataToFile(string targetFileName, byte[] value)
        {
            // ReSharper disable EmptyGeneralCatchClause
            var str = string.Empty;
            try
            {
                try
                {
                    var path = Path.GetTempPath();
                    str = path + "\\" + targetFileName;
                    if (File.Exists(str))
                        File.Delete(str);
                }
                catch (Exception) { }

                var file = (new BinaryWriter(new FileStream(str, FileMode.OpenOrCreate, FileAccess.Write)));
                file.Write(value);
                file.Close();
                return str;
            }
            catch (Exception) { }
            // ReSharper restore EmptyGeneralCatchClause
            return string.Empty;
        }

        private static byte[] ConvertFileToByteData(string sourceFileName)
        {
            BinaryReader binaryReader = null;
            if (!File.Exists(sourceFileName))
                return null;

            try
            {
                binaryReader = new BinaryReader(new FileStream(sourceFileName, FileMode.Open, FileAccess.Read));
                return binaryReader.ReadBytes(ConvertToInt32(binaryReader.BaseStream.Length));
            }
            finally
            {
                if (null != binaryReader) binaryReader.Close();
            }
        }

        public static int ConvertToInt32(object parameter)
        {
            var returnvalue = Int32.MinValue;

            // If exception (Input string was not in a correct format) 
            // is raised then default return value is returned.
            try
            {
                if (null != parameter)
                    returnvalue = Convert.ToInt32(parameter, CultureInfo.InvariantCulture);
            }
            catch
            {
                return returnvalue;
            }

            return returnvalue;
        }

        public static byte[] GetCompressedData(string fileName, byte[] value)
        {
            try
            {
                // Code for zip file.
                if (value != null && !string.IsNullOrEmpty(fileName))
                    using (var zippedMemoryStream = new MemoryStream())
                    {
                        // A ZIP stream
                        using (var zipOutputStream = new ZipOutputStream(zippedMemoryStream))
                        {
                            // Highest compression rating 0 - 9.
                            zipOutputStream.SetLevel(9);

                            var entry = new ZipEntry(fileName) { DateTime = DateTime.Now };
                            zipOutputStream.PutNextEntry(entry);

                            zipOutputStream.Write(value, 0, ConvertToInt32(value.Length));

                            zipOutputStream.Finish();
                            zipOutputStream.Close();

                            return zippedMemoryStream.ToArray();
                        }
                    }
            }
            catch (Exception)
            {
                return value;
            }

            return null;
        }

        public static byte[] GetUnCompressedData(byte[] value)
        {
            try
            {
                if (value != null)
                    using (var zipInputStream = new ZipInputStream(new MemoryStream(value)))
                    {
                        while ((zipInputStream.GetNextEntry()) != null)
                        {
                            using (var zippedInMemoryStream = new MemoryStream())
                            {
                                var data = new byte[2048];
                                while (true)
                                {
                                    var size = zipInputStream.Read(data, 0, data.Length);
                                    if (size <= 0)
                                        break;

                                    zippedInMemoryStream.Write(data, 0, size);
                                }
                                zippedInMemoryStream.Close();

                                return zippedInMemoryStream.ToArray();
                            }
                        }
                    }
                return null;
            }
            catch (Exception)
            {
                return value;
            }
        }

    }
}
