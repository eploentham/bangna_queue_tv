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

            //long chk = 0;
            //String re = bqc.bquDB.queDateDB.updateQueueCurrent(stfid, date,"");
            //String quecurr = bqc.bquDB.queDateDB.updateQueueCurrent(stfid, date, que.queue);
            //bque1 = bqc.bquDB.queDateDB.selectByPk1(date, stfid);
            //lbQueCurr.Text = que.queue;
            //lbQueFinish.Text = bque1.queue;
            //เรียกคิว
            tque.t_queue_id = tque.t_queue_id == null ? "" : tque.t_queue_id;
            tque = bqc.bquDB.tqueDB.LockQueue(stfid, tque.t_queue_id);
            //tque = new TQueue();            
            lbQueCurr.Text = tque.queue_current;
            lbTQueId.Text = tque.t_queue_id;
            
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
            bque = bqc.bquDB.queDateDB.selectByPk1(stfid);
            lbQueCurr.Text = "";
            lbQueFinish.Text = "";
        }
        private void FrmQueueNext_Load(object sender, EventArgs e)
        {

        }
    }
}
