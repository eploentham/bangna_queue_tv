using bangna_queue_tv.control;
using bangna_queue_tv.Properties;
using C1.Win.C1FlexGrid;
using C1.Win.C1Themes;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bangna_queue_tv.gui
{
    public class FrmCall:Form
    {
        BangnaQueueControl bqc;
        C1FlexGrid grf;
        Font fEdit, fEditB, fEditPrintQue;

        C1ThemeController theme1;
        Boolean pageLoad = false;
        Panel pnQue;
        NotifyIcon notifyIcon1;
        ContextMenu menuGw;

        System.ComponentModel.IContainer components;
        ContextMenu contextMenu1;
        MenuItem menuShow;
        MenuItem menuExit;
        int colCalId = 1, colCalQueName = 2, colCalQue = 3, colSoundImg=4, colQueId=5, colTQueId=6, colPrefix=7, colCode=8, colCaller=9, colCallerId=10;
        Timer timer;
        WaveOutEvent outputDevice;
        AudioFileReader audioFile;
        List<String> arrPlay = new List<string>();
        String callerid = "";
        public FrmCall(BangnaQueueControl bqc)
        {
            this.bqc = bqc;
            if (bqc.chkAppExit)
            {
                Close();
            }
            initConfig();
        }
        private void initConfig()
        {
            pageLoad = true;
            theme1 = new C1ThemeController();
            menuGw = new ContextMenu();
            notifyIcon1 = new NotifyIcon();
            this.components = new System.ComponentModel.Container();
            contextMenu1 = new System.Windows.Forms.ContextMenu();

            timer = new Timer();
            timer.Interval = 2000;
            timer.Enabled = false;
            timer.Tick += Timer_Tick;

            setControl();

            initGrfQue();
            setGrfQueue();

            setTheme();
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Resize += FrmCall_Resize;
            this.Load += FrmCall_Load;

            pageLoad = false;
        }

        private void FrmCall_Load(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            timer.Enabled = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            playSound();
        }
        private void playSound()
        {
            timer.Enabled = false;
            grf[1, colSoundImg] = Resources.start24;
            String queid = grf[1, colQueId] != null ? grf[1, colQueId].ToString():"";
            String tqueid = grf[1, colTQueId] != null ? grf[1, colTQueId].ToString() : "";
            String queue = grf[1, colCalQue] != null ? grf[1, colCalQue].ToString() : "";
            String code = grf[1, colCode] != null ? grf[1, colCode].ToString() : "";
            String caller = grf[1, colCaller] != null ? grf[1, colCaller].ToString() : "";
            callerid = grf[1, colCallerId] != null ? grf[1, colCallerId].ToString() : "";
            String prefix = bqc.bquDB.queDB.getQuePrefixById(queid);
            String pathfile = "";
            pathfile = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            string tmpFilename = pathfile + "\\sound\\sample.mp3";
            arrPlay.Clear();
            tmpFilename = pathfile + "\\sound\\invite_number.mp3";
            arrPlay.Add(tmpFilename);
            if (prefix.Length > 0)
            {
                tmpFilename = pathfile + "\\sound\\" + prefix.ToLower() + ".mp3";
                arrPlay.Add(tmpFilename);
            }
            if (queue.Length > 0)
            {
                tmpFilename = pathfile + "\\sound\\0.mp3";
                String code1 = "";
                int chk = 0;
                //code = bqc.bquDB.queDB.getQueCodeById(bqued.queue_id);
                for (int i = 0; i < (code.Length - queue.Length); i++)
                {
                    //code += "0";
                    arrPlay.Add(tmpFilename);
                }
                //code1 = code + tque.queue;
                if (int.TryParse(queue, out chk))
                {
                    for(int j = 0; j < queue.Length; j++)
                    {
                        code1 = queue.Substring(j, 1);
                        tmpFilename = pathfile + "\\sound\\" + code1 + ".mp3";
                        arrPlay.Add(tmpFilename);
                    }
                }
            }
            //arrPlay.Add(tmpFilename);
            tmpFilename = pathfile + "\\sound\\at_slot.mp3";
            arrPlay.Add(tmpFilename);
            // caller ไม่ต้องทำ เพราะ ฟังเสียง แล้ว 14 เป็น 1    4   ไม่ใช่ 14
            //if (caller.Length > 0)
            //{
            //    String caller1 = "";
            //    for (int j = 0; j < caller.Length; j++)
            //    {
            //        caller1 = caller.Substring(j, 1);
            //        tmpFilename = pathfile + "\\sound\\" + caller1 + ".mp3";
            //        arrPlay.Add(tmpFilename);
            //    }
            //}
            tmpFilename = pathfile + "\\sound\\" + caller + ".mp3";
            arrPlay.Add(tmpFilename);
            tmpFilename = pathfile + "\\sound\\ka.mp3";
            arrPlay.Add(tmpFilename);
            if (!Directory.Exists(pathfile + "\\temp"))
            {
                Directory.CreateDirectory(pathfile + "\\temp");
            }
            bqc.CombineFile(arrPlay, pathfile + "\\temp\\soundattend" + tqueid + ".mp3");

            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
                outputDevice.PlaybackStopped += OutputDevice_PlaybackStopped;
            }
            
            audioFile = new AudioFileReader(pathfile + "\\temp\\soundattend" + tqueid + ".mp3");
            outputDevice.Init(audioFile);
            
            outputDevice.Play();
        }

        private void OutputDevice_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            //throw new NotImplementedException();
            bqc.bquDB.tcallDB.deleteCallById(callerid, "");
            setGrfQueue1();
            timer.Enabled = true;
        }

        private void setControl()
        {
            menuShow = new MenuItem();
            menuExit = new MenuItem();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));Office2016DarkGray
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.menuShow });
            this.ContextMenu = menuGw;
            pnQue = new Panel();
            pnQue.Dock = DockStyle.Fill;
            this.Controls.Add(pnQue);
            
            //MessageBox.Show("FrmLabLIS 111.1 ", "");
            notifyIcon1.Icon = Resources.backup_restore;
            //MessageBox.Show("FrmLabLIS 111.2 ", "");
            notifyIcon1.BalloonTipText = "";
            notifyIcon1.BalloonTipTitle = "LIS";
            notifyIcon1.Visible = true;
            notifyIcon1.MouseDoubleClick += NotifyIcon1_MouseDoubleClick;

            this.menuShow.Name = "menuShow";
            this.menuShow.Text = "Show";
            menuShow.Click += MenuShow_Click;
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Text = "Exit";
            menuExit.Click += MenuExit_Click;

        }

        private void MenuExit_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.Close();
        }
        protected override void Dispose(bool disposing)
        {
            // Clean up any components being used.
            if (disposing)
                if (components != null)
                    components.Dispose();

            base.Dispose(disposing);
        }
        private void MenuShow_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
            try
            {
                //MessageBox.Show("1111", "");
                this.Show();
                //MessageBox.Show("2222", "");
                this.WindowState = FormWindowState.Normal;
                //MessageBox.Show("3333", "");
                this.StartPosition = FormStartPosition.CenterScreen;
                //MessageBox.Show("4444", "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message, "");
            }
        }

        private void FrmCall_Resize(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(2000, "system hide", "11", ToolTipIcon.Info);
                this.ShowInTaskbar = true;
            }
        }

        private void initGrfQue()
        {
            grf = new C1FlexGrid();
            grf.Font = fEdit;
            grf.Dock = System.Windows.Forms.DockStyle.Fill;
            grf.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);                     
            pnQue.Controls.Add(grf);

            theme1.SetTheme(grf, "Office2016DarkGray");
        }
        private void setGrfQueue1()
        {
            DataTable dt = new DataTable();

            dt = bqc.bquDB.tcallDB.selectAll();
            //dttoday = bqc.bquDB.queDateDB.selectBQueDate1(date);
            grf.Rows.Count = dt.Rows.Count + 1;
            if (dt.Rows.Count == 0)
                grf.Rows.Count++;
            int i = 1;
            foreach (DataRow drow in dt.Rows)
            {
                grf.Rows[i][0] = i;
                grf[i, 0] = i;
                grf[i, colCalId] = drow["call_id"].ToString();
                grf[i, colCalQue] = drow["queue"].ToString();
                grf[i, colQueId] = drow["queue_id"].ToString();
                grf[i, colTQueId] = drow["t_queue_id"].ToString();
                grf[i, colPrefix] = drow["prefix"].ToString();
                grf[i, colCode] = drow["code"].ToString();
                grf[i, colCaller] = drow["caller"].ToString();
                grf[i, colCallerId] = drow["call_id"].ToString();
                grf[i, colCalQueName] = bqc.prefixQue1(drow["code"].ToString(), drow["prefix"].ToString(), drow["queue"].ToString());
                grf[i, colSoundImg] = Resources.stop24; ;
                i++;
            }
        }
        private void setGrfQueue()
        {
            //grfQue.Clear();
            timer.Enabled = false;
            pageLoad = true;
            grf.DataSource = null;
            grf.Rows.Count = 1;
            //grfQue.Rows.Count = 200;
            grf.Cols.Count = 11;
            Column imageCol = grf.Cols[colSoundImg];
            imageCol.Caption = "Images";
            imageCol.DataType = typeof(Image);
            imageCol.ImageAlign = ImageAlignEnum.CenterCenter;
            //imageCol.Editor = new ImagePicker();
            imageCol.Width = 75;

            grf.Cols[colCalId].Width = 250;
            grf.Cols[colCalQue].Width = 100;
            grf.Cols[colCalQueName].Width = 100;
            //grf.Cols[colQueId].Width = 100;

            grf.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grf.Cols[colCalId].Caption = " ";
            grf.Cols[colCalQue].Caption = "queue ";
            grf.Cols[colCalQueName].Caption = "queue name";            

            DataTable dt = new DataTable();
            
            dt = bqc.bquDB.tcallDB.selectAll();
            //dttoday = bqc.bquDB.queDateDB.selectBQueDate1(date);
            grf.Rows.Count = dt.Rows.Count + 1;
            if (dt.Rows.Count == 0)
                grf.Rows.Count++;
            int i = 1;
            foreach (DataRow drow in dt.Rows)
            {
                grf.Rows[i][0] = i;
                grf[i, 0] = i;
                grf[i, colCalId] = drow["call_id"].ToString();
                grf[i, colCalQue] = drow["queue"].ToString();
                grf[i, colQueId] = drow["queue_id"].ToString();
                grf[i, colTQueId] = drow["t_queue_id"].ToString();
                grf[i, colPrefix] = drow["prefix"].ToString();
                grf[i, colCode] = drow["code"].ToString();
                grf[i, colCaller] = drow["caller"].ToString();
                grf[i, colCallerId] = drow["call_id"].ToString();
                grf[i, colCalQueName] = bqc.prefixQue1(drow["code"].ToString(), drow["prefix"].ToString(), drow["queue"].ToString());
                grf[i, colSoundImg] = Resources.stop24; ;
                i++;
            }
            grf.Rows[colCallerId].Visible = false;
            grf.Cols[colCalId].Visible = false;
            grf.Cols[colQueId].Visible = false;
            grf.Cols[colTQueId].Visible = false;
            grf.Cols[colPrefix].Visible = false;
            grf.Cols[colCode].Visible = false;

            grf.Cols[colCalQue].AllowEditing = false;
            grf.Cols[colCalQueName].AllowEditing = false;

            grf.AutoSizeRows();
            pageLoad = true;
            //theme1.SetTheme(grfQue, "Office2016Colorful");

        }
        private void setTheme()
        {

        }
    }
}
