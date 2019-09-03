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
    public partial class FrmQueueConfig : Form
    {
        BangnaQueueControl bqc;
        Font fEdit, fEditB;
        public FrmQueueConfig(BangnaQueueControl bqc)
        {
            InitializeComponent();
            this.bqc = bqc;
            initConfig();
        }
        private void initConfig()
        {
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            fEdit = new Font(bqc.iniC.grdViewFontName, bqc.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(bqc.iniC.grdViewFontName, bqc.grdViewFontSize, FontStyle.Bold);
            bqc.bquDB.stfDB.setCboStaff(cboStf, "");

            initGrd(screenWidth, screenHeight);
            

            btnQuePlus.Click += BtnQuePlus_Click;
        }

        private void BtnQuePlus_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            int que = 0, chk=0;
            String stfid = "";
            DateTime dt = new DateTime();
            if(!int.TryParse(txtQue.Text, out que))
            {
                MessageBox.Show("", "");
                return;
            }
            stfid = bqc.getIdCombo(cboStf,cboStf.Text);
            if (stfid.Equals(""))
            {
                MessageBox.Show("", "");
                return;
            }
            if(!DateTime.TryParse(txtQueDate.Text, out dt))
            {
                MessageBox.Show("", "");
                return;
            }
            BQueue bque = new BQueue();
            bque.queue_id = "";
            bque.staff_id = stfid;
            bque.queue_date = dt.Year+"-"+dt.ToString("MM-dd");
            bque.queue_current = "0";
            bque.queue = que.ToString();
            String bquid = "";
            bquid = bqc.bquDB.bqueDB.selectBQueIdByStfQueDate(stfid, bque.queue_date);
            bque.queue_id = bquid;
            String re = bqc.bquDB.bqueDB.insertBQueue(bque, "");
            if(int.TryParse(re, out chk))
            {
                initGrd(screenWidth, screenHeight);
                setGrd();
            }
        }
        private void setGrd()
        {
            String date = "";
            DateTime dt = new DateTime();
            if (!DateTime.TryParse(txtQueDate.Text, out dt))
            {
                MessageBox.Show("", "");
                return;
            }
            DataTable dt1 = new DataTable();
            date = dt.Year + "-" + dt.ToString("MM-dd");
            dt1 = bqc.bquDB.bqueDB.selectBQueDate(date);
            int i = 0;
            if (dt1.Rows.Count >= 1)
            {
                dgv1.RowCount = dt1.Rows.Count;
            }
            else
            {
                dgv1.RowCount = 1;
            }
            foreach (DataRow row in dt1.Rows)
            {
                
                dgv1[1, i].Value = row["name"].ToString();
                dgv1[2, i].Value = row["queue"].ToString();
                dgv1[3, i].Value = row["b_queue_id"].ToString();
                i++;
                //dgv1[0, i].Value = i;
            }
            
        }
        private void initGrd(int screenWidth, int screenHeight)
        {
            int x = 0;
            //int.TryParse(comboBox1.Text, out x);
            //int col = screenWidth;
            //int col2 = col / 3;
            //int col1 = col2;
            //col1 += col2;

            int row = screenHeight;
            //int row1 = row / x;

            dgv1.Font = fEditB;
            //dgv1.ColumnHeadersVisible = false;

            dgv1.ColumnCount = 4;

            dgv1.RowCount = 1;
            dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv1.Columns[0].Width = 40;
            dgv1.Columns[1].Width = 220;
            dgv1.Columns[1].HeaderText = "Name";
            dgv1.Columns[2].HeaderText = "Queue";
            dgv1.Columns[3].HeaderText = "ID";

            //dGv.RowTemplate.Height = row1;
            foreach (DataGridViewRow rowH in dgv1.Rows)
            {
                //rowH.Height = row1 - 15;
            }

        }
        private void FrmQueueConfig_Load(object sender, EventArgs e)
        {
            setGrd();
        }
    }
}
