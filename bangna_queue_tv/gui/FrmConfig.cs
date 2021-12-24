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
        }

        private void BtnQueAdd_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void FrmConfig_Load(object sender, EventArgs e)
        {

        }
    }
}
