using bangna_queue_tv.control;
using bangna_queue_tv.Properties;
using C1.Win.C1FlexGrid;
using C1.Win.C1Themes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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

        ContextMenuStrip contextMenuStrip1;
        ToolStripMenuItem menuShow;
        ToolStripMenuItem menuExit;
        public FrmCall(BangnaQueueControl bqc)
        {
            this.bqc = bqc;
            initConfig();
            setGrfQueue();
        }
        private void initConfig()
        {
            pageLoad = true;

            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));Office2016DarkGray
            this.ContextMenu = menuGw;
            pnQue = new Panel();
            pnQue.Dock = DockStyle.Fill;
            this.Controls.Add(pnQue);
            notifyIcon1 = new NotifyIcon();
            //MessageBox.Show("FrmLabLIS 111.1 ", "");
            notifyIcon1.Icon = Resources.backup_restore;
            //MessageBox.Show("FrmLabLIS 111.2 ", "");
            notifyIcon1.BalloonTipText = "";
            notifyIcon1.BalloonTipTitle = "LIS";
            notifyIcon1.Visible = true;
            notifyIcon1.MouseDoubleClick += NotifyIcon1_MouseDoubleClick;
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip();
            this.menuShow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuShow,
            this.menuExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(104, 48);
            this.menuShow.Name = "menuShow";
            this.menuShow.Size = new System.Drawing.Size(103, 22);
            this.menuShow.Text = "Show";
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(103, 22);
            this.menuExit.Text = "Exit";

            setTheme();
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Resize += FrmCall_Resize;
            pageLoad = false;
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
        private void setGrfQueue()
        {
            //grfQue.Clear();
            pageLoad = true;
            grf.DataSource = null;
            grf.Rows.Count = 1;
            //grfQue.Rows.Count = 200;
            grf.Cols.Count = 7;

            grf.Cols[colRowNo].Width = 250;
            grf.Cols[colQueName].Width = 250;
            grf.Cols[colQueNum].Width = 100;
            grf.Cols[colQueId].Width = 100;

            grf.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grf.Cols[colRowNo].Caption = " ";
            grf.Cols[colQueName].Caption = "queue name";
            grf.Cols[colQueNum].Caption = "queue";
            grf.Cols[colQueId].Caption = "id";
            grf.Cols[colQueCode].Caption = "ตัวย่อ";
            grf.Cols[colQuePrefix].Caption = "Prefix";

            DataTable dt = new DataTable();
            DateTime dtToday = new DateTime();
            DateTime.TryParse(txtDate.Text, out dtToday);
            String date = "";
            date = DateTime.Now.Year + DateTime.Now.ToString("-MM-dd");
            dt = bqc.bquDB.queDB.selectAllNotinToday(date);
            //dttoday = bqc.bquDB.queDateDB.selectBQueDate1(date);
            grf.Rows.Count = dt.Rows.Count + 1;
            if (dt.Rows.Count == 0)
                grf.Rows.Count++;
            int i = 1;
            foreach (DataRow drow in dt.Rows)
            {
                //Boolean chk = false;
                //foreach (DataRow drowtoday in dttoday.Rows)
                //{
                //    if (drowtoday["queue_id"].ToString().Equals(drow["queue_id"].ToString()))
                //    {
                //        chk = true;
                //        continue;
                //    }
                //}
                //if (chk) continue;
                grf.Rows[i][colRowNo] = i;
                grf[i, 0] = i;
                grf[i, colQueName] = drow["queue_name"].ToString();
                grf[i, colQueNum] = drow["queue_code"].ToString();
                grf[i, colQueId] = drow["queue_id"].ToString();
                grf[i, colQueCode] = drow["queue_code"].ToString();
                grf[i, colQuePrefix] = drow["queue_prefix"].ToString();
                i++;
            }
            //grfQue.Rows[0].Visible = false;
            grf.Cols[colQueId].Visible = false;
            grf.Cols[colRowNo].Visible = false;

            //grfImg.Cols[colPathPic].Visible = false;
            grf.Cols[colRowNo].AllowEditing = false;
            grf.Cols[colQueName].AllowEditing = false;
            grf.Cols[colQueNum].AllowEditing = false;
            grf.Cols[colQueId].AllowEditing = false;

            //grfImg.AutoSizeCols();
            grf.AutoSizeRows();
            pageLoad = false;
            //theme1.SetTheme(grfQue, "Office2016Colorful");

        }
        private void setTheme()
        {

        }
    }
}
