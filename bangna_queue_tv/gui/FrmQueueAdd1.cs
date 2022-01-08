using bangna_queue_tv.control;
using bangna_queue_tv.object1;
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
    public class FrmQueueAdd1:Form
    {
        BangnaQueueControl bqc;
        Font fEdit, fEditB;

        Panel pn1;
        C1FlexGrid grfQue;
        C1SuperTooltip stt, sttHnOld;
        C1SuperErrorProvider sep;
        C1ThemeController theme1;
        C1StatusBar sB1;
        RibbonLabel lbStatus;
        RibbonButton btnStatus;

        int colRowNo = 1, colQueName = 2, colQuePrefix = 3, colQueCode=4, colQueStart=5, colQueId = 6, colEveryDay = 7, colEveryDayImage=8, colQueSave=9;
        Boolean pageLoad = false;
        public FrmQueueAdd1(BangnaQueueControl bqc)
        {
            this.bqc = bqc;
            initConfig();
        }
        private void initConfig()
        {
            pageLoad = true;
            fEdit = new Font(bqc.iniC.grdQueFontName, bqc.grdQueFontSize, FontStyle.Regular);
            fEditB = new Font(bqc.iniC.grdQueFontName, bqc.grdQueFontSize, FontStyle.Bold);
            theme1 = new C1ThemeController();
            InitializeComponent();

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
            btnStatus.Click += BtnStatus_Click;
            this.Controls.Add(sB1);
            lbStatus.Text = "";
            theme1.SetTheme(sB1, "Office2016DarkGray");

            initGrfQue();
            setGrfQueue();
            this.WindowState = FormWindowState.Normal;
            //this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            pageLoad = false;
        }

        private void BtnStatus_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            grfQue.Rows.Add();
            grfQue[grfQue.Row, colQueId] = "";
            grfQue[grfQue.Row, colQueSave] = "";
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FrmQueueAdd1
            // 
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Name = "FrmQueueAdd1";
            this.Load += new System.EventHandler(this.FrmQueueAdd1_Load);
            this.ResumeLayout(false);

        }
        private void initGrfQue()
        {
            grfQue = new C1FlexGrid();
            grfQue.Font = fEdit;
            grfQue.Dock = System.Windows.Forms.DockStyle.Fill;
            grfQue.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            //grfVs.AfterRowColChange += GrfImg_AfterRowColChange;
            //grfVs.MouseDown += GrfImg_MouseDown;
            grfQue.Click += GrfQue_Click;
            grfQue.CellChanged += GrfQue_CellChanged;
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfQue.ContextMenu = menuGw;
            pn1.Controls.Add(grfQue);

            theme1.SetTheme(grfQue, "Office2016DarkGray");

        }

        private void GrfQue_CellChanged(object sender, RowColEventArgs e)
        {
            //throw new NotImplementedException();
            if (pageLoad) return;
            grfQue[e.Row, colQueSave] = "SAVE";
            if (e.Row == (grfQue.Rows.Count-1))
            {
                grfQue.Rows.Add();
                grfQue[e.Row, colQueId] = "";
            }
            //grfQue[e.Row, 3] = grfQue[e.Row, e.Col];
        }

        private void GrfQue_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfQue.Row <= 0) return;
            if (grfQue.Col <= 0) return;
            if (grfQue.Col == colQueSave)
            {
                try
                {
                    String chk = grfQue[grfQue.Row, colQueSave] != null ? grfQue[grfQue.Row, colQueSave].ToString() : "";
                    if (!chk.Equals("SAVE")) return;
                    lbStatus.Text = "Save ...";
                    pageLoad = true;
                    if (saveBQueue())
                    {
                        grfQue[grfQue.Row, colQueSave] = "";
                    }
                }
                catch(Exception ex)
                {

                }
                pageLoad = false;
            }else if (grfQue.Col == colEveryDayImage)
            {
                try
                {
                    if(grfQue[grfQue.Row, colEveryDay] != null)
                    {
                        if (grfQue[grfQue.Row, colEveryDay].ToString().Equals("1"))
                        {
                            grfQue[grfQue.Row, colEveryDayImage] = Resources.trafficlight_red16;
                            grfQue[grfQue.Row, colEveryDay] = "0";
                        }
                        else
                        {
                            grfQue[grfQue.Row, colEveryDayImage] = Resources.trafficlight_green16;
                            grfQue[grfQue.Row, colEveryDay] = "1";
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
        private Boolean saveBQueue()
        {
            Boolean chk = false;
            BQueue que = new BQueue();
            String id = "", name = "", num = "", code="", prefix="", start="", everyday="";
            id = grfQue[grfQue.Row, colQueId] != null ? grfQue[grfQue.Row, colQueId].ToString():"";
            name = grfQue[grfQue.Row, colQueName] != null ? grfQue[grfQue.Row, colQueName].ToString() : "";
            prefix = grfQue[grfQue.Row, colQuePrefix] != null ? grfQue[grfQue.Row, colQuePrefix].ToString() : "";
            code = grfQue[grfQue.Row, colQueCode] != null ? grfQue[grfQue.Row, colQueCode].ToString() : "";
            start = grfQue[grfQue.Row, colQueStart] != null ? grfQue[grfQue.Row, colQueStart].ToString() : "";
            everyday = grfQue[grfQue.Row, colEveryDay] != null ? grfQue[grfQue.Row, colEveryDay].ToString() : "";
            que.b_queue_id = id;
            que.queue_name = name.Trim();
            que.queue = num;
            que.queue_code = code.Trim();
            que.queue_prefix = prefix.Trim();
            que.queue_start = start;
            que.status_everyday = everyday;
            String re = bqc.bquDB.queDB.insertQueue(que, "");
            int chk1 = 0;
            if(int.TryParse(re, out chk1))
            {
                chk = true;
            }
            else
            {
                lbStatus.Text = re;
            }
            return chk;
        }
        private void setGrfQueue()
        {
            //grfQue.Clear();
            pageLoad = true;
            grfQue.DataSource = null;
            grfQue.Rows.Count = 1;
            //grfQue.Rows.Count = 200;
            grfQue.Cols.Count = 10;

            grfQue.Cols[colRowNo].Width = 250;
            grfQue.Cols[colQueName].Width = 250;
            grfQue.Cols[colQuePrefix].Width = 100;
            grfQue.Cols[colQueId].Width = 100;
            grfQue.Cols[colQueSave].Width = 80;
            grfQue.Cols[colQueCode].Width = 100;
            grfQue.Cols[colEveryDay].Width = 100;

            Column imageCol = grfQue.Cols[colEveryDayImage];
            imageCol.Caption = "Images";
            imageCol.DataType = typeof(Image);
            imageCol.ImageAlign = ImageAlignEnum.CenterCenter;
            //imageCol.Editor = new ImagePicker();
            imageCol.Width = 75;

            grfQue.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfQue.Cols[colRowNo].Caption = " ";
            grfQue.Cols[colQueName].Caption = "queue name";
            grfQue.Cols[colQuePrefix].Caption = "prefix";  //ตัวย่อ ชื่อย่อ
            grfQue.Cols[colQueId].Caption = "id";
            grfQue.Cols[colQueSave].Caption = "save";
            grfQue.Cols[colQueCode].Caption = "XXXX";   //XXXX
            grfQue.Cols[colQueStart].Caption = "คิวเริ่มต้น";   //XXXX
            grfQue.Cols[colEveryDayImage].Caption = "status";   //XXXX
            DataTable dt = new DataTable();

            dt = bqc.bquDB.queDB.selectAll();
            grfQue.Rows.Count = dt.Rows.Count + 1;
            if (dt.Rows.Count == 0)
                grfQue.Rows.Count++;
            int i = 1;
            foreach (DataRow drow in dt.Rows)
            {
                grfQue.Rows[i][colRowNo] = i;
                grfQue[i, 0] = i;
                grfQue[i, colQueName] = drow["queue_name"].ToString();
                grfQue[i, colQuePrefix] = drow["queue_prefix"].ToString();
                grfQue[i, colQueId] = drow["queue_id"].ToString();
                grfQue[i, colQueCode] = drow["queue_code"].ToString();
                grfQue[i, colQueStart] = drow["queue_start"].ToString();
                grfQue[i, colEveryDay] = drow["status_everyday"] != null ? drow["status_everyday"].ToString().Equals("") ? "0": drow["status_everyday"].ToString():"0";
                grfQue[i, colEveryDayImage] = drow["status_everyday"].ToString().Equals("1") ? Resources.trafficlight_green16 : Resources.trafficlight_red16;
                grfQue[i, colQueSave] = "";
                i++;
            }
            //grfQue.Rows[0].Visible = false;
            grfQue.Cols[colQueId].Visible = false;
            grfQue.Cols[colRowNo].Visible = false;
            grfQue.Cols[colEveryDay].Visible = false;

            //grfQue.Cols[colEveryDay].Visible = false;
            grfQue.Cols[colEveryDayImage].AllowEditing = false;
            grfQue.Cols[colRowNo].AllowEditing = true;
            grfQue.Cols[colQueName].AllowEditing = true;
            grfQue.Cols[colQuePrefix].AllowEditing = true;
            grfQue.Cols[colQueCode].AllowEditing = true;
            grfQue.Cols[colQueId].AllowEditing = false;
            grfQue.Cols[colQueSave].AllowEditing = false;
            //grfImg.AutoSizeCols();
            grfQue.AutoSizeRows();
            pageLoad = false;
            //theme1.SetTheme(grfQue, "Office2016Colorful");

        }
        private void FrmQueueAdd1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            //this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
