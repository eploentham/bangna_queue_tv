using bangna_queue_tv.control;
using bangna_queue_tv.object1;
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
        String datestart = "", dateend = "";
        BQueueDate bqued;
        TQueue tque;
        public FrmQueueNext(BangnaQueueControl bqc)
        {
            InitializeComponent();
            this.bqc = bqc;
            initConfig();
        }
        private void initConfig()
        {
            tque = new TQueue();
            bqc.bquDB.queDateDB.setCboQueDate(cboStf, bqc.iniC.queuefixid, System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd"));
            setControl();
            cboStf.SelectedValueChanged += CboStf_SelectedValueChanged;
            btnQueNext.Click += BtnQueNext_Click;
            chkQueSend.Click += ChkQueSend_Click;
            btnQueSend.Click += BtnQueSend_Click;
            chkQueVoid.Click += ChkQueVoid_Click;
            btnQueVoid.Click += BtnQueVoid_Click;
        }

        private void BtnQueVoid_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String re = bqc.bquDB.tqueDB.voidQueue(tque.t_queue_id, "");
            int chk = 0;
            if (int.TryParse(re, out chk))
            {
                lbQueSend.Text = "ยกเลิกคิวเรียบร้อย";
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
            stfid = bqc.getIdCombo(cboQueSend, cboQueSend.Text);
            if (stfid.Equals(""))
            {
                MessageBox.Show("ไม่พบเลขที่คิว", "");
                return;
            }
            tque.t_queue_id = tque.t_queue_id == null ? "" : tque.t_queue_id;
            String re = bqc.bquDB.tqueDB.FinishAndNewQueue(tque.t_queue_id, stfid, "");
            int chk = 0;
            if(int.TryParse(re, out chk))
            {
                lbQueSend.Text = "ส่งคิวเรียบร้อย";
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
            stfid = bqc.getIdCombo(cboStf, cboStf.Text);
            if (stfid.Equals(""))
            {
                MessageBox.Show("ไม่พบเลขที่คิว", "");
                return;
            }
            String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            //que = bqc.bquDB.queDB.selectQueByStfQueDate(stfid, date);

            //เรียกคิว
            tque.t_queue_id = tque.t_queue_id == null ? "" : tque.t_queue_id;
            tque = bqc.bquDB.tqueDB.LockQueue(stfid, tque.t_queue_id);
            //tque = new TQueue();
            code = bqc.prefixQue(tque);

            lbQue.Text = code;
            lbQueFinish.Text = tque.queue_current;
            lbTQueId.Text = tque.t_queue_id;
            lbQueSend.Text = "";
            chkQueSend.Checked = false;
            chkQueVoid.Checked = false;
            cboQueSend.Text = "";
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
            stfid = bqc.getIdCombo(cboStf, cboStf.Text);
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
            lbQueSend.Visible = flag;
            if (flag)
            {
                bqc.bquDB.queDateDB.setCboQueDate(cboQueSend, bqc.iniC.queuefixid, System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd"));
            }
        }
        private void FrmQueueNext_Load(object sender, EventArgs e)
        {

        }
    }
}
