using bangna_queue_tv.control;
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
    public partial class FrmConfig : Form
    {
        BangnaQueueControl bqc;
        Font fEdit, fEditB;
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

            btnQueAdd.Click += BtnQueAdd_Click;
            btnQueToday.Click += BtnQueToday_Click;
            btnCaller.Click += BtnCaller_Click;
            chkPrintQue.Click += ChkPrintQue_Click;
            chkUnPrintQue.Click += ChkUnPrintQue_Click;
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
