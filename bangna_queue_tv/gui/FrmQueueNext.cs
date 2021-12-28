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
        BQueueDate bque;
        public FrmQueueNext(BangnaQueueControl bqc)
        {
            InitializeComponent();
            this.bqc = bqc;
            initConfig();
        }
        private void initConfig()
        {
            
            bqc.bquDB.stfDB.setCboStaff(cboStf, bqc.iniC.queuefixid);

            setControl();

            cboStf.SelectedValueChanged += CboStf_SelectedValueChanged;
            btnQueNext.Click += BtnQueNext_Click;
        }

        private void BtnQueNext_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            BQueue que = new BQueue();
            BQueueDate bque1 = new BQueueDate();
            String stfid = "", queid = "";
            stfid = bqc.getIdCombo(cboStf, cboStf.Text);
            if (stfid.Equals(""))
            {
                MessageBox.Show("", "");
                return;
            }
            String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            //que = bqc.bquDB.queDB.selectQueByStfQueDate(stfid, date);
            
            long chk = 0;
            que = bqc.bquDB.queDB.updateStatusQue(stfid, date);
            String quecurr = bqc.bquDB.queDateDB.updateQueueCurrent(stfid, date, que.queue);
            bque1 = bqc.bquDB.queDateDB.selectByPk1(date, stfid);
            lbQueCurr.Text = que.queue;
            //lbQueFinish.Text = bque1.queue;
        }

        private void CboStf_SelectedValueChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setControl();
        }

        private void setControl()
        {
            String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            bque = new BQueueDate();

            String stfid = "";
            stfid = bqc.getIdCombo(cboStf, cboStf.Text);
            bque = bqc.bquDB.queDateDB.selectByPk1(date, stfid);
            lbQueCurr.Text = bque.queue_current;
            //lbQueFinish.Text = bque.queue;
        }
        private void FrmQueueNext_Load(object sender, EventArgs e)
        {

        }
    }
}
