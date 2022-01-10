using bangna_queue_tv.control;
using bangna_queue_tv.object1;
using C1.Win.C1FlexGrid;
using C1.Win.C1Ribbon;
using C1.Win.C1Themes;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace bangna_queue_tv.gui
{
    public partial class FrmQueueNext : Form
    {
        BangnaQueueControl bqc;

        C1FlexGrid grf;
        Font fEdit, fEditB, fEditPrintQue;

        String datestart = "", dateend = "";
        BQueueDate bqued;
        BQueueCaller queCaller;
        TQueue tque;
        Boolean pageLoad = false;
        Form frmCaller;

        C1ThemeController theme1;
        WaveOutEvent outputDevice;
        AudioFileReader audioFile;
        List<String> arrPlay = new List<string>();
        public FrmQueueNext(BangnaQueueControl bqc)
        {
            InitializeComponent();
            this.bqc = bqc;
            initConfig();
        }
        private void initConfig()
        {
            pageLoad = true;
            tque = new TQueue();
            queCaller = new BQueueCaller();
            theme1 = new C1ThemeController();
            fEdit = new Font(bqc.iniC.grdViewFontName, bqc.grdViewFontSize, FontStyle.Regular);

            foreach(String aaa in C1ThemeController.GetThemes())
            {
                rbTheme.Items.Add(aaa);
            }
            //rbTheme.SelectedItem.Description = "Office2016Colorful";

            //bqc.bquDB.queDateDB.setCboQueDate(cboStf, bqc.iniC.queuefixid, System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd"));
            bqc.bquDB.queDateDB.setCboQueDate1(cboQueDate, bqc.iniC.queuefixid, System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd"));
            //new LogWriter("d", "FrmQueueNext initConfig ");
            setControl();
            //cboStf.SelectedValueChanged += CboStf_SelectedValueChanged;
            cboQueDate.SelectedIndexChanged += CboQueDate_SelectedIndexChanged;
            btnQueNext.Click += BtnQueNext_Click;
            chkQueSend.Click += ChkQueSend_Click;
            btnQueSend.Click += BtnQueSend_Click;
            chkQueVoid.Click += ChkQueVoid_Click;
            btnQueVoid.Click += BtnQueVoid_Click;
            btnCaller.Click += BtnCaller_Click;
            rbTheme.Text = "VS2013Red";
            rbTheme.SelectedIndexChanged += RbTheme_SelectedIndexChanged;

            setTheme1(rbTheme.Text);
            pageLoad = false;
        }

        private void RbTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            //throw new NotImpl   ementedException();
            if (pageLoad) return;
            setTheme1(rbTheme.Text);
        }

        private void CboQueDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            pageLoad = true;
            setControl();
            pageLoad = false;
        }
        private void setTheme1(String theme)
        {
            //theme1.SetTheme(grf, "BeigeOne");
            theme1.SetTheme(btnQueNext, theme);
            theme1.SetTheme(c1Button1, theme);
            theme1.SetTheme(btnQueSend, theme);
            theme1.SetTheme(c1StatusBar1, theme);
            theme1.SetTheme(cboQueDate, theme);
            theme1.SetTheme(chkQueVoid, theme);
            theme1.SetTheme(btnQueVoid, theme);
            theme1.SetTheme(chkQueSend, theme);
            theme1.SetTheme(this, theme);
        }
        private void setTheme()
        {
            //theme1.SetTheme(grf, "BeigeOne");
            theme1.SetTheme(btnQueNext, bqc.iniC.themeDonor);
            theme1.SetTheme(c1Button1, bqc.iniC.themeDonor);
            theme1.SetTheme(btnQueSend, bqc.iniC.themeDonor);
            theme1.SetTheme(c1StatusBar1, bqc.iniC.themeDonor);
            theme1.SetTheme(cboQueDate, bqc.iniC.themeDonor);
            theme1.SetTheme(chkQueVoid, bqc.iniC.themeDonor);
            theme1.SetTheme(btnQueVoid, bqc.iniC.themeDonor);
            theme1.SetTheme(chkQueSend, bqc.iniC.themeDonor);
            theme1.SetTheme(this, bqc.iniC.themeDonor);
        }
        private void BtnQueVoid_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String re = bqc.bquDB.tqueDB.voidQueue(tque.t_queue_id, "");
            int chk = 0;
            if (int.TryParse(re, out chk))
            {
                lbStatus.Text = "ยกเลิกคิวเรียบร้อย";
                tque = new TQueue();
                lbTQueId.Text = "";
                lbQue.Text = "";
                lbQueCur.Text = "";
            }
        }

        private void ChkQueVoid_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            btnQueVoid.Visible = chkQueVoid.Checked;
        }

        private void BtnQueSend_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String stfid = "", queid = "";
            //stfid = bqc.getIdCombo(cboQueSend, cboQueSend.Text);
            if (queCaller.queue_call_id.Length <= 0)
            {
                MessageBox.Show("ไม่พบ caller", "");
                return;
            }
            if (tque.t_queue_id.Length <= 0)
            {
                MessageBox.Show("ไม่พบเลขที่คิว", "");
                return;
            }
            tque.t_queue_id = tque.t_queue_id == null ? "" : tque.t_queue_id;
            String re = bqc.bquDB.tqueDB.FinishAndNewQueue(tque.t_queue_id, stfid, "", queCaller.queue_call_id);
            int chk = 0;
            if (int.TryParse(re, out chk))
            {
                lbStatus.Text = "ส่งคิวเรียบร้อย";
            }
        }
        private void ChkQueSend_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setControlQueSend(chkQueSend.Checked);
        }
        private void playSound()
        {
            lbStatus.Text = "play sound";
            String prefix = bqc.bquDB.queDB.getQuePrefixById(bqued.queue_id);
            String pathfile = "";
            pathfile = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            string tmpFilename = pathfile + "\\sound\\sample.mp3";
            arrPlay.Clear();
            tmpFilename = pathfile + "\\sound\\invite_number.mp3";
            arrPlay.Add(tmpFilename);
            if (prefix.Length > 0)
            {
                tmpFilename = pathfile + "\\sound\\"+prefix.ToLower()+".mp3";
                arrPlay.Add(tmpFilename);
            }
            if (tque.queue.Length > 0)
            {
                tmpFilename = pathfile + "\\sound\\0.mp3";
                String code = "", code1="";
                int chk = 0;
                code = bqc.bquDB.queDB.getQueCodeById(bqued.queue_id);
                for(int i = 0; i < (code.Length - tque.queue.Length); i++)
                {
                    //code += "0";
                    arrPlay.Add(tmpFilename);
                }
                //code1 = code + tque.queue;
                if (int.TryParse(tque.queue,out chk))
                {
                    tmpFilename = pathfile + "\\sound\\"+ tque.queue + ".mp3";
                    arrPlay.Add(tmpFilename);
                }
            }
            //arrPlay.Add(tmpFilename);
            tmpFilename = pathfile + "\\sound\\at_slot.mp3";
            arrPlay.Add(tmpFilename);

            tmpFilename = pathfile + "\\sound\\"+ queCaller .queue_call_name+ ".mp3";
            arrPlay.Add(tmpFilename);
            tmpFilename = pathfile + "\\sound\\ka.mp3";
            arrPlay.Add(tmpFilename);
            if (!Directory.Exists(pathfile+"\\temp"))
            {
                Directory.CreateDirectory(pathfile + "\\temp");
            }
            bqc.CombineFile(arrPlay, pathfile + "\\temp\\soundattend"+tque.t_queue_id+".mp3");

            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
                outputDevice.PlaybackStopped += OutputDevice_PlaybackStopped;
            }
            if (audioFile == null)
            {
                audioFile = new AudioFileReader(pathfile + "\\temp\\soundattend" + tque.t_queue_id + ".mp3");
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
            lbStatus.Text = "";
            btnQueNext.Enabled = true;
        }

        private void BtnQueNext_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String stfid = "", queid = "", prefix = "", code = "";
            //stfid = bqc.getIdCombo(cboStf, cboStf.Text);
            if (queCaller == null)
            {
                MessageBox.Show("ไม่พบ caller", "");
                return;
            }
            if (queCaller.queue_call_id == null)
            {
                MessageBox.Show("ไม่พบ caller", "");
                return;
            }
            if (queCaller.queue_call_id.Length<=0)
            {
                MessageBox.Show("ไม่พบ caller", "");
                return;
            }
            
            btnQueNext.Enabled = false;
            //if (tque.t_queue_id == null)
            //{
            //    MessageBox.Show("ไม่พบเลขที่คิว", "");
            //    return;
            //}
            //if (tque.t_queue_id.Length <= 0)
            //{
            //    MessageBox.Show("ไม่พบเลขที่คิว", "");
            //    return;
            //}
            String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            //que = bqc.bquDB.queDB.selectQueByStfQueDate(stfid, date);

            //เรียกคิว
            tque.t_queue_id = tque.t_queue_id == null ? "" : tque.t_queue_id;
            tque = bqc.bquDB.tqueDB.LockQueue(bqued.b_queue_date_id, tque.t_queue_id, queCaller.queue_call_id);
            //tque = new TQueue();
            if (tque.t_queue_id.Equals("-1"))
            {
                lbStatus.Text = tque.queue_name;
            }
            else if (tque.t_queue_id.Length>3)
            {
                lbStatus.Text = "OK";
            }
            code = bqc.prefixQue(tque);
            bqued = bqc.bquDB.queDateDB.selectByPk1(bqued.b_queue_date_id);
            lbQue.Text = bqc.prefixQue1(bqued.queuecode, bqued.queueprefix, bqued.queue);
            lbQueCur.Text = tque.queue_current;
            lbTQueId.Text = tque.t_queue_id;
            //lbStatus.Text = "";
            chkQueSend.Checked = false;
            chkQueVoid.Checked = false;
            cboQueSend.Text = "";
            playSound();
        }
        private void CboCaller_SelectedIndexChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            pageLoad = true;

            pageLoad = false;
        }
        private void BtnCaller_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            DataTable dt = new DataTable();
            frmCaller = new Form();
            grf = new C1FlexGrid();
            grf.Dock = DockStyle.Fill;
            grf.Font = fEdit;
            grf.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None;
            grf.SelectionMode = SelectionModeEnum.Row;
            grf.Rows[0].Visible = false;
            grf.Cols[0].Visible = false;
            grf.Cols.Count = 4;
            grf.Click += Grf_Click;
            grf.DoubleClick += Grf_DoubleClick;
            theme1.SetTheme(grf, "Office2007Blue");
            int i = 1;
            dt = bqc.bquDB.quecDB.selectAll();
            grf.Rows.Count = dt.Rows.Count + 1;
            foreach (DataRow drow in dt.Rows)
            {
                grf[i, 0] = i;
                grf[i, 1] = drow["queue_call_id"].ToString();
                grf[i, 2] = drow["queue_call_name"].ToString();
                grf[i, 3] = drow["status_lock"].ToString();
                i++;
            }
            grf.Cols[1].Visible = false;
            grf.Cols[3].Visible = false;
            grf.Cols[2].AllowEditing = false;
            frmCaller.Controls.Add(grf);
            frmCaller.StartPosition = FormStartPosition.CenterScreen;
            frmCaller.Size = new Size(300, 200);
            frmCaller.ShowDialog(this);
        }

        private void Grf_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String aaa = "";
            queCaller.queue_call_id = grf[grf.Row, 1] != null ? grf[grf.Row, 1].ToString():"";
            queCaller.queue_call_name = grf[grf.Row, 2] != null ? grf[grf.Row, 2].ToString() : "";
            String re = bqc.bquDB.quecDB.updateStatusLock(queCaller.queue_call_id, "");
            int chk = 0;
            if(int.TryParse(re, out chk))
            {
                rbCaller.Text = "caller ["+queCaller.queue_call_name+"]";
                bqc.iniF.setIni("app", "QueueCaller", queCaller.queue_call_name);
                grf.Dispose();
                frmCaller.Dispose();
            }
        }

        private void Grf_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String aaa = "";
        }
        private void CboStf_SelectedValueChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setControl();
        }
        private void setControl()
        {
            String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            bqued = new BQueueDate();

            String stfid = "", caller="", call="";
            stfid = bqc.getIdCombo(cboQueDate, cboQueDate.Text);
            bqued = bqc.bquDB.queDateDB.selectByPk1(stfid);
            call = bqc.iniF.getIni("app", "QueueCaller");
            //new LogWriter("d", "FrmQueueNext call " + call);
            queCaller = bqc.bquDB.quecDB.selectByName(bqc.iniF.getIni("app", "QueueCaller"));
            //new LogWriter("d", "FrmQueueNext queCaller " + queCaller.queue_call_id+" "+ queCaller.queue_call_name);
            //queCaller.queue_call_id = grf[grf.Row, 1] != null ? grf[grf.Row, 1].ToString() : "";
            //queCaller.queue_call_name = grf[grf.Row, 2] != null ? grf[grf.Row, 2].ToString() : "";
            rbCaller.Text = "caller [" + queCaller.queue_call_name + "]";

            lbQue.Text = "";
            lbQueCur.Text = "";
            btnQueVoid.Visible = false;
            setControlQueSend(false);
            chkQueSend.Checked = false;
            chkQueVoid.Checked = false;
        }
        private void setControlQueSend(Boolean flag)
        {
            cboQueSend.Visible = flag;
            btnQueSend.Visible = flag;
            //lbQueSend.Visible = flag;
            if (flag)
            {
                bqc.bquDB.queDateDB.setCboQueDate(cboQueSend, bqc.iniC.queuefixid, System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd"));
            }
        }
        private void FrmQueueNext_Load(object sender, EventArgs e)
        {
           // rbCaller.Text = "";
            lbStatus.Text = "";
            rbQueueTotal.Text = "";
            String pathfile = "";
            pathfile = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            if (!Directory.Exists(pathfile + "\\temp"))
            {
                Directory.CreateDirectory(pathfile + "\\temp");
            }
            else
            {
                System.IO.DirectoryInfo di = new DirectoryInfo(pathfile + "\\temp");

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
            }
        }
    }
}
