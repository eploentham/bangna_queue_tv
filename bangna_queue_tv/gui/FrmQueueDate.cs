using bangna_queue_tv.control;
using bangna_queue_tv.Properties;
using C1.Win.C1FlexGrid;
using C1.Win.C1Ribbon;
using C1.Win.C1SuperTooltip;
using C1.Win.C1Themes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace bangna_queue_tv.gui
{
    public class FrmQueueDate:Form
    {
        BangnaQueueControl bqc;
        Panel pn1;
        Font fEdit, fEditB;
        C1FlexGrid grfQueToday;
        C1SuperTooltip stt, sttHnOld;
        C1SuperErrorProvider sep;
        C1ThemeController theme1;
        C1StatusBar sB1;
        RibbonLabel lbStatus;
        RibbonButton btnStatus;

        Bitmap img;
        Image image1;
        Color color;
        int colRowNo = 1, colQueName = 2, colQueNum = 3, colQueId=4;
        int colTodayrowno = 1, colTodayQueName = 2, colTodayqueid = 3, colTodayQuCurr = 4, colTodayId = 5;
        Boolean pageLoad = false;
        public FrmQueueDate(BangnaQueueControl bqc)
        {
            this.bqc = bqc;
            initConfig();
        }
        private void initConfig()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(1224, 768);
            fEdit = new Font(bqc.iniC.grdQueTodayFontName, bqc.grdQueTodayFontSize, FontStyle.Regular);
            theme1 = new C1ThemeController();

            this.Text = "Run-time Controls";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            //this.StartPosition = FormStartPosition.CenterParent;
            pn1 = new Panel();
            pn1.Dock = DockStyle.Fill;
            this.Controls.Add(pn1);
            
            sB1 = new C1StatusBar();
            sB1.AutoSizeElement = C1.Framework.AutoSizeElement.Width;
            sB1.Location = new System.Drawing.Point(0, 428);
            sB1.Name = "c1StatusBar1";
            sB1.Size = new System.Drawing.Size(800, 22);
            lbStatus = new RibbonLabel();
            btnStatus = new RibbonButton();
            sB1.LeftPaneItems.Add(lbStatus);
            sB1.RightPaneItems.Add(btnStatus);
            lbStatus.Text = "";
            btnStatus.Text = "config";
            btnStatus.SmallImage = Resources.setting1;

            initGrfQueToday();
            setGrfQueToday();

            this.StartPosition = FormStartPosition.CenterScreen;
            btnStatus.Click += BtnStatus_Click;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FrmQueueDate
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "FrmQueueDate";
            this.Load += new System.EventHandler(this.FrmQueueDate_Load);
            this.ResumeLayout(false);

        }
        private void BtnStatus_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //MessageBox.Show("aaaaa", "");
            FrmConfig frm = new FrmConfig(bqc);
            frm.ShowDialog(this);
        }

        private void initGrfQueToday()
        {
            grfQueToday = new C1FlexGrid();
            grfQueToday.Font = fEdit;
            grfQueToday.Dock = System.Windows.Forms.DockStyle.Fill;
            grfQueToday.Location = new System.Drawing.Point(0, 0);

            theme1.SetTheme(sB1, "Office2016DarkGray");
            grfQueToday.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None;
            //FilterRow fr = new FilterRow(grfExpn);

            //grfVs.AfterRowColChange += GrfImg_AfterRowColChange;
            //grfVs.MouseDown += GrfImg_MouseDown;
            grfQueToday.Click += GrfQueToday_Click;
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));Office2016DarkGray
            grfQueToday.ContextMenu = menuGw;
            pn1.Controls.Add(grfQueToday);
            grfQueToday.AllowSorting = AllowSortingEnum.None;


            this.Controls.Add(sB1);

            theme1.SetTheme(grfQueToday, "Office2007Blue"); 

        }

        private void GrfQueToday_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfQueToday.Row <= 0) return;
            DataTable dt = new DataTable();
            String date = "";
            date = DateTime.Now.Year + DateTime.Now.ToString("-MM-dd");

            String id = "", name = "", num = "", todayid = "";
            todayid = grfQueToday[grfQueToday.Row, colTodayId] != null ? grfQueToday[grfQueToday.Row, colTodayId].ToString() : "";
            id = grfQueToday[grfQueToday.Row, colTodayqueid] != null ? grfQueToday[grfQueToday.Row, colTodayqueid].ToString() : "";
            name = grfQueToday[grfQueToday.Row, colTodayQueName] != null ? grfQueToday[grfQueToday.Row, colTodayQueName].ToString() : "";
            num = grfQueToday[grfQueToday.Row, colTodayQuCurr] != null ? grfQueToday[grfQueToday.Row, colTodayQuCurr].ToString() : "";
            bqc.bquDB.queDateDB.updateQueueCurrentNext(todayid,date);
            setGrfQueToday1();
        }
        private void setGrfQueToday1()
        {
            DataTable dt = new DataTable();
            String date = "";
            date = DateTime.Now.Year + DateTime.Now.ToString("-MM-dd");
            dt = bqc.bquDB.queDateDB.selectBQueDate1(date);
            grfQueToday.Rows.Count = dt.Rows.Count + 1;
            int i = 1;
            foreach (DataRow drow in dt.Rows)
            {
                grfQueToday.Rows[i][colTodayrowno] = i;
                grfQueToday[i, 0] = i;
                grfQueToday[i, colTodayQueName] = drow["queue_name"].ToString();
                grfQueToday[i, colTodayQuCurr] = drow["queue_current"].ToString();
                grfQueToday[i, colTodayId] = drow["b_queue_date_id"].ToString();
                grfQueToday[i, colTodayqueid] = drow["queue_id"].ToString();
                grfQueToday.Rows[i].Height = 120;
                //grfQueToday.Rows[i].HeightDisplay = 1500;
                i++;
            }
        }
        private void setGrfQueToday()
        {
            pageLoad = true;
            grfQueToday.DataSource = null;
            grfQueToday.Rows.Count = 1;
            //grfQue.Rows.Count = 200;
            grfQueToday.Cols.Count = 6;
            //Screen.PrimaryScreen.WorkingArea;
            
            grfQueToday.Cols[colTodayrowno].Width = 250;
            grfQueToday.Cols[colTodayQueName].Width = this.Width -220;
            grfQueToday.Cols[colTodayQuCurr].Width = 200;
            //grfQueToday.Cols[colTodayQuCurr].Width = 400;
            grfQueToday.Cols[colTodayId].Width = 100;

            grfQueToday.ShowCursor = true;
            grfQueToday.Cols[0].Visible = false;
            grfQueToday.Rows[0].Visible = true;
            

            grfQueToday.Cols[colTodayrowno].Caption = " ";
            grfQueToday.Cols[colTodayQueName].Caption = "queue name";
            grfQueToday.Cols[colTodayQuCurr].Caption = "queue number";
            grfQueToday.Cols[colTodayId].Caption = "id";

            DataTable dt = new DataTable();
            String date = "";
            date = DateTime.Now.Year + DateTime.Now.ToString("-MM-dd");
            dt = bqc.bquDB.queDateDB.selectBQueDate1(date);
            grfQueToday.Rows.Count = dt.Rows.Count + 1;
            
            int i = 1;
            foreach (DataRow drow in dt.Rows)
            {
                grfQueToday.Rows[i][colTodayrowno] = i;
                grfQueToday[i, 0] = i;
                grfQueToday[i, colTodayQueName] = drow["queue_name"].ToString();
                grfQueToday[i, colTodayQuCurr] = drow["queue_current"].ToString();
                grfQueToday[i, colTodayId] = drow["b_queue_date_id"].ToString();
                grfQueToday[i, colTodayqueid] = drow["queue_id"].ToString();
                grfQueToday.Rows[i].Height = 120;
                //grfQueToday.Rows[i].HeightDisplay = 1500;
                i++;
            }
            //grfQue.Rows[0].Visible = false;
            grfQueToday.Cols[colTodayId].Visible = false;
            grfQueToday.Cols[colTodayrowno].Visible = false;
            grfQueToday.Cols[colTodayqueid].Visible = false;

            //grfImg.Cols[colPathPic].Visible = false;
            grfQueToday.Cols[colTodayrowno].AllowEditing = false;
            grfQueToday.Cols[colTodayQueName].AllowEditing = false;
            grfQueToday.Cols[colTodayQuCurr].AllowEditing = false;
            grfQueToday.Cols[colTodayqueid].AllowEditing = false;
            grfQueToday.Cols[colTodayId].AllowEditing = false;
            grfQueToday.SelectionMode = SelectionModeEnum.Default;

            //grfImg.AutoSizeCols();
            //grfQueToday.AutoSizeRows();
            pageLoad = false;
        }
        private void FrmQueueDate_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
