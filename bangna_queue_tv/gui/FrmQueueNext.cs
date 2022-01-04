using bangna_queue_tv.control;
using bangna_queue_tv.object1;
using C1.Win.C1FlexGrid;
using C1.Win.C1Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

            //bqc.bquDB.queDateDB.setCboQueDate(cboStf, bqc.iniC.queuefixid, System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd"));
            bqc.bquDB.queDateDB.setCboQueDate1(cboQueDate, bqc.iniC.queuefixid, System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd"));
            setControl();
            //cboStf.SelectedValueChanged += CboStf_SelectedValueChanged;
            cboQueDate.SelectedIndexChanged += CboQueDate_SelectedIndexChanged;
            btnQueNext.Click += BtnQueNext_Click;
            chkQueSend.Click += ChkQueSend_Click;
            btnQueSend.Click += BtnQueSend_Click;
            chkQueVoid.Click += ChkQueVoid_Click;
            btnQueVoid.Click += BtnQueVoid_Click;
            btnCaller.Click += BtnCaller_Click;

            setTheme();
            pageLoad = false;
        }

        private void CboQueDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            pageLoad = true;
            setControl();
            pageLoad = false;
        }

        private void setTheme()
        {
            //theme1.SetTheme(grf, "BeigeOne");
            theme1.SetTheme(btnQueNext, "BeigeOne");
            theme1.SetTheme(c1Button1, "BeigeOne");
            theme1.SetTheme(btnQueSend, "BeigeOne");
            theme1.SetTheme(c1StatusBar1, "BeigeOne");
            theme1.SetTheme(cboQueDate, "BeigeOne");
            theme1.SetTheme(c1CheckBox1, "BeigeOne");
            theme1.SetTheme(this, "BeigeOne");
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
                lbQueFinish.Text = "";
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
        private void BtnQueNext_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String stfid = "", queid = "", prefix = "", code = "";
            //stfid = bqc.getIdCombo(cboStf, cboStf.Text);

            if (queCaller.queue_call_id.Length<=0)
            {
                MessageBox.Show("ไม่พบ caller", "");
                return;
            }
            if (queCaller.queue_call_id == null)
            {
                MessageBox.Show("ไม่พบ caller", "");
                return;
            }
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
            tque = bqc.bquDB.tqueDB.LockQueue(stfid, tque.t_queue_id, queCaller.queue_call_id);
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

            lbQue.Text = code;
            lbQueFinish.Text = tque.queue_current;
            lbTQueId.Text = tque.t_queue_id;
            //lbStatus.Text = "";
            chkQueSend.Checked = false;
            chkQueVoid.Checked = false;
            cboQueSend.Text = "";
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

            String stfid = "";
            stfid = bqc.getIdCombo(cboQueDate, cboQueDate.Text);
            bqued = bqc.bquDB.queDateDB.selectByPk1(stfid);
            lbQue.Text = "";
            lbQueFinish.Text = "";
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
            rbCaller.Text = "";
            lbStatus.Text = "";
            rbQueueTotal.Text = "";
        }
    }
}
