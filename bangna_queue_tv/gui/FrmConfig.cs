using bangna_queue_tv.control;
using bangna_queue_tv.object1;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace bangna_queue_tv.gui
{
    public partial class FrmConfig : Form
    {
        BangnaQueueControl bqc;
        Font fEdit, fEditB;
        SoundPlayer sound0, sound1, sound2, sound3, sound4, sound5, sound6, sound7, sound8, sound9;
        SoundPlayer soundA, soundB, soundC, soundD, soundE, soundF, soundG, soundH, soundI, soundJ;
        OpenFileDialog ofd = new OpenFileDialog();
        string CommandString;
        List<String> arrPlay = new List<string>();
        SoundPlayer soundInvite, soundKa, soundSlot;
        WaveOutEvent outputDevice;
        AudioFileReader audioFile;

        Timer time;
        int timecnt = 0;
        private static StringBuilder tmpBuffer = new StringBuilder("0", 256);
        [DllImport("winmm.dll")]
        private static extern int waveOutSetVolume(IntPtr uDeviceID, uint dwVolume);

        [DllImport("winmm.dll")]
        private static extern int waveOutGetVolume(IntPtr uDeviceID, out uint dwVolume);
        [DllImport("winmm.dll")]
        private static extern int mciSendString(string lpstrCommand, StringBuilder lpstrReturnString, int uReturnLength, int hwndCallback);
        public FrmConfig(BangnaQueueControl bqc)
        {
            InitializeComponent();
            this.bqc = bqc;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(bqc.iniC.grdViewFontName, bqc.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(bqc.iniC.grdViewFontName, bqc.grdViewFontSize, FontStyle.Bold);
            time = new Timer();
            time.Enabled = false;
            time.Interval = 500;
            time.Tick += Time_Tick;
            btnQueAdd.Click += BtnQueAdd_Click;
            btnQueToday.Click += BtnQueToday_Click;
            btnCaller.Click += BtnCaller_Click;
            chkPrintQue.Click += ChkPrintQue_Click;
            chkUnPrintQue.Click += ChkUnPrintQue_Click;
            c1Button5.Click += C1Button5_Click;

            String statusPrintQue = bqc.iniF.getIni("app", "statusPrintQue");
            if (statusPrintQue.Equals("0"))
            {
                chkUnPrintQue.Checked = true;
                chkPrintQue.Checked = false;
            }
            else if (statusPrintQue.Equals("1"))
            {
                chkUnPrintQue.Checked = false;
                chkPrintQue.Checked = true;
            }
            setControlSound();
        }

        private void Time_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (arrPlay.Count > 0 && timecnt < 20)
            {
                StringBuilder str = new StringBuilder(128);
                mciSendString("status MediaFile mode", str, 128, 0);
                c1Button5.Text = str.ToString();
                c1Button8.Text += "a";
                timecnt++;
            }
            else if (timecnt >= 20)
            {
                mciSendString("close media", null, 0, 0);
                c1Button8.Text = "";
            }
            else
            {
                time.Enabled = false;
            }
        }

        private void setControlSound()
        {
            String pathfile = "";
            pathfile = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            sound0 = new SoundPlayer(pathfile+"\\sound\\0.mp3");
            sound1 = new SoundPlayer(pathfile + "\\sound\\1.mp3");
            sound2 = new SoundPlayer(pathfile + "\\sound\\2.mp3");
            sound3 = new SoundPlayer(pathfile + "\\sound\\3.mp3");
            sound4 = new SoundPlayer(pathfile + "\\sound\\4.mp3");
            sound5 = new SoundPlayer(pathfile + "\\sound\\5.mp3");
            sound6 = new SoundPlayer(pathfile + "\\sound\\6.mp3");
            sound7 = new SoundPlayer(pathfile + "\\sound\\7.mp3");
            sound8 = new SoundPlayer(pathfile + "\\sound\\8.mp3");
            sound9 = new SoundPlayer(pathfile + "\\sound\\9.mp3");
            soundA = new SoundPlayer(pathfile + "\\sound\\A.mp3");
            soundB = new SoundPlayer(pathfile + "\\sound\\B.mp3");
            soundC = new SoundPlayer(pathfile + "\\sound\\C.mp3");
            soundD = new SoundPlayer(pathfile + "\\sound\\D.mp3");
            soundE = new SoundPlayer(pathfile + "\\sound\\E.mp3");
            soundF = new SoundPlayer(pathfile + "\\sound\\F.mp3");
            soundG = new SoundPlayer(pathfile + "\\sound\\G.mp3");
            soundH = new SoundPlayer(pathfile + "\\sound\\H.mp3");
            soundInvite = new SoundPlayer(pathfile + "\\sound\\invite_number.mp3");
            soundKa = new SoundPlayer(pathfile + "\\sound\\ka.mp3");
            soundSlot = new SoundPlayer(pathfile + "\\sound\\at_slot.mp3");

        }
        private void c1Button8_Click(object sender, EventArgs e)
        {
            //listBox1_SelectedIndexChanged(object sender, EventArgs e){
            //    mciSendString("close MediaFile"           , null IntPtr.Zero);
            //    mciSendString("open \"" + listBox1.Items[listBox1.SelectedIndex].ToString() + "\" type mpegvideo alias MediaFile", null, 0, IntPtr.Zero);
            //    mciSendString("play MediaFile" , null , 0, IntPtr.Zero);
            //    timer1.Enabled = true;

            //}
            String pathfile = "";
            pathfile = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            string tmpFilename = pathfile + "\\sound\\sample.mp3";
            arrPlay.Clear();
            tmpFilename = pathfile + "\\sound\\invite_number.mp3";
            arrPlay.Add(tmpFilename);
            tmpFilename = pathfile + "\\sound\\a.mp3";
            arrPlay.Add(tmpFilename);
            tmpFilename = pathfile + "\\sound\\0.mp3";
            arrPlay.Add(tmpFilename);
            tmpFilename = pathfile + "\\sound\\0.mp3";
            arrPlay.Add(tmpFilename);
            tmpFilename = pathfile + "\\sound\\0.mp3";
            arrPlay.Add(tmpFilename);
            tmpFilename = pathfile + "\\sound\\1.mp3";
            arrPlay.Add(tmpFilename);
            tmpFilename = pathfile + "\\sound\\at_slot.mp3";
            arrPlay.Add(tmpFilename);
            tmpFilename = pathfile + "\\sound\\4.mp3";
            arrPlay.Add(tmpFilename);
            tmpFilename = pathfile + "\\sound\\ka.mp3";
            arrPlay.Add(tmpFilename);
            bqc.CombineFile(arrPlay, pathfile+ "\\sound\\soundattend.mp3");

            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
                outputDevice.PlaybackStopped += OutputDevice_PlaybackStopped;
            }
            if (audioFile == null)
            {
                audioFile = new AudioFileReader(pathfile + "\\sound\\soundattend.mp3");
                outputDevice.Init(audioFile);
            }
            outputDevice.Play();
        }
        private void OutputDevice_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            //throw new NotImplementedException();
            outputDevice.Dispose();
            outputDevice = null;
            audioFile.Dispose();
            audioFile = null;
        }

        private void c1Button6_Click(object sender, EventArgs e)
        {
            if (ofd.FileName == "")
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    ofd.Filter = "MP3 Files|*.mp3";
                    CommandString = "open " + "\"" + ofd.FileName + "\"" + " type MPEGVideo alias Mp3File";
                    mciSendString(CommandString, null, 0, 0);
                    CommandString = "play Mp3File";
                    mciSendString(CommandString, null, 0, 0);
                    time.Enabled = true;
                    //timer1.Enabled = true;
                }
            }
            else
            {
                mciSendString("close media", null, 0, 0);
                CommandString = "play Mp3File";
                mciSendString(CommandString, null, 0, 0);

                //timer1.Enabled = true;
            }
        }
        private void c1Button7_Click(object sender, EventArgs e)
        {
            //mciSendString("Close MyMp3", tmpBuffer, 0, 0);
            String pathfile = "";
            pathfile = System.IO.Path.GetDirectoryName(Application.ExecutablePath);

            string tmpFilename = pathfile + "\\sound\\sample.mp3";

            tmpFilename = pathfile + "\\sound\\invite_number.wav";
            arrPlay.Add(tmpFilename);
            tmpFilename = pathfile + "\\sound\\a.wav";
            arrPlay.Add(tmpFilename);
            tmpFilename = pathfile + "\\sound\\0.wav";
            arrPlay.Add(tmpFilename);
            tmpFilename = pathfile + "\\sound\\0.wav";
            arrPlay.Add(tmpFilename);
            tmpFilename = pathfile + "\\sound\\0.wav";
            arrPlay.Add(tmpFilename);
            tmpFilename = pathfile + "\\sound\\1.wav";
            arrPlay.Add(tmpFilename);
            tmpFilename = pathfile + "\\sound\\at_slot.wav";
            arrPlay.Add(tmpFilename);
            tmpFilename = pathfile + "\\sound\\4.wav";
            arrPlay.Add(tmpFilename);
            tmpFilename = pathfile + "\\sound\\ka.wav";
            arrPlay.Add(tmpFilename);
            WaveIO wa = new WaveIO();
            wa.Merge(arrPlay, pathfile+"\\sound\\sound.wav");
            //MemoryStream sound  wa.MergetoStream(arrPlay);

            //MemoryStream stream = bqc.CombineFileStrean(arrPlay);
            //stream.Position = 0;
            //SoundPlayer sound = new SoundPlayer(stream);
            SoundPlayer sound1 = new SoundPlayer(pathfile + "\\sound\\sound.wav");
            sound1.Play();
            sound1.Dispose();
        }
        private void C1Button5_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();            
            //soundInvite.Play();
            //soundA.Play();
            //sound0.Play();
            //sound0.Play();
            //sound0.Play();
            //sound1.Play();
            //soundSlot.Play();
            //sound1.Play();
            //soundKa.Play();
            mciSendString("close media", null, 0, 0);
            String pathfile = "";
            pathfile = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            //string tmpFilename = pathfile+ "\\sound\\invite_number.mp3";
            string tmpFilename = pathfile + "\\sound\\sample.mp3";
            
            tmpFilename = pathfile + "\\sound\\invite_number.mp3";
            arrPlay.Add(tmpFilename);
            tmpFilename = pathfile + "\\sound\\a.mp3";
            arrPlay.Add(tmpFilename);
            tmpFilename = pathfile + "\\sound\\0.mp3";
            arrPlay.Add(tmpFilename);
            tmpFilename = pathfile + "\\sound\\0.mp3";
            arrPlay.Add(tmpFilename);
            tmpFilename = pathfile + "\\sound\\0.mp3";
            arrPlay.Add(tmpFilename);
            tmpFilename = pathfile + "\\sound\\1.mp3";
            arrPlay.Add(tmpFilename);
            tmpFilename = pathfile + "\\sound\\at_slot.mp3";
            arrPlay.Add(tmpFilename);
            tmpFilename = pathfile + "\\sound\\4.mp3";
            arrPlay.Add(tmpFilename);
            tmpFilename = pathfile + "\\sound\\ka.mp3";
            arrPlay.Add(tmpFilename);

            Combine(arrPlay, pathfile+"\\sound\\attend.mp3");

            string command = "open \"" + pathfile + "\\sound\\attend.mp3" + "\" type MPEGVideo alias MyMp3";
            //time.Start();
            mciSendString(command, null, 0, 0);
            command = "play  MyMp3";
            mciSendString(command, null, 0, 0);
            time.Enabled = true;
            //
            //mciSendString("Open " + tmpFilename + " Alias SND", tmpBuffer, 0, 0);
            //mciSendString("Play SND", tmpBuffer, 0, 0);
        }
        private void Combine(List<String> mp3Files, string mp3OuputFile)
        {
            if (File.Exists(mp3OuputFile))
            {
                File.Delete(mp3OuputFile);
            }
            using (var w = new BinaryWriter(File.Create(mp3OuputFile)))
            {
                new List<string>(mp3Files).ForEach(f => w.Write(File.ReadAllBytes(f)));
            }
        }
        private void ChkUnPrintQue_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setPrintQue();        }

        private void ChkPrintQue_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setPrintQue();
        }
        private void setPrintQue()
        {
            if (chkPrintQue.Checked)
            {
                bqc.iniF.setIni("app", "statusPrintQue","1");
            }
            else if(chkUnPrintQue.Checked)
            {
                bqc.iniF.setIni("app", "statusPrintQue", "0");
            }
        }
        private void BtnCaller_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmQueueCaller frm = new FrmQueueCaller(bqc);
            frm.ShowDialog(this);
        }

        private void BtnQueToday_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmQueueToday frm = new FrmQueueToday(bqc);
            frm.ShowDialog(this);
        }

        private void BtnQueAdd_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmQueueAdd1 frm = new FrmQueueAdd1(bqc);
            frm.ShowDialog(this);
        }

        private void FrmConfig_Load(object sender, EventArgs e)
        {

        }
    }
}
