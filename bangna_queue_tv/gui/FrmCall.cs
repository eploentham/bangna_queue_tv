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
        ContextMenu menuGw;

        System.ComponentModel.IContainer components;
        ContextMenu contextMenu1;
        MenuItem menuShow;
        MenuItem menuExit;
        int colCalId = 1, colCalQue = 2, colCalQueName = 3;
        public FrmCall(BangnaQueueControl bqc)
        {
            this.bqc = bqc;
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

            setControl();

            initGrfQue();
            setGrfQueue();

            setTheme();
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Resize += FrmCall_Resize;

            pageLoad = false;
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
        private void setGrfQueue()
        {
            //grfQue.Clear();
            pageLoad = true;
            grf.DataSource = null;
            grf.Rows.Count = 1;
            //grfQue.Rows.Count = 200;
            grf.Cols.Count = 4;

            grf.Cols[colCalId].Width = 250;
            grf.Cols[colCalQue].Width = 250;
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
                grf[i, colCalQueName] = drow["queue_name"].ToString();
                i++;
            }
            //grfQue.Rows[0].Visible = false;
            grf.Cols[colCalId].Visible = false;
                        
            grf.Cols[colCalQue].AllowEditing = false;
            grf.Cols[colCalQueName].AllowEditing = false;

            //grfImg.AutoSizeCols();
            pageLoad = false;
            //theme1.SetTheme(grfQue, "Office2016Colorful");

        }
        private void setTheme()
        {

        }
    }
}
