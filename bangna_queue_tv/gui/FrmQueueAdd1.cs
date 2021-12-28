using bangna_queue_tv.control;
using bangna_queue_tv.object1;
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

        int colRowNo = 1, colQueName = 2, colQueNum = 3, colQueId = 4, colQueSave=5;
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
            sB1.LeftPaneItems.Add(lbStatus);
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
            }
        }
        private Boolean saveBQueue()
        {
            Boolean chk = false;
            BQueue que = new BQueue();
            String id = "", name = "", num = "";
            id = grfQue[grfQue.Row, colQueId] != null ? grfQue[grfQue.Row, colQueId].ToString():"";
            name = grfQue[grfQue.Row, colQueName] != null ? grfQue[grfQue.Row, colQueName].ToString() : "";
            num = grfQue[grfQue.Row, colQueNum] != null ? grfQue[grfQue.Row, colQueNum].ToString() : "";
            que.b_queue_id = id;
            que.queue_name = name;
            que.queue = num;
            String re = bqc.bquDB.queDB.insertQueue(que, "");
            int chk1 = 0;
            if(int.TryParse(re, out chk1))
            {
                chk = true;
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
            grfQue.Cols.Count = 6;

            grfQue.Cols[colRowNo].Width = 250;
            grfQue.Cols[colQueName].Width = 250;
            grfQue.Cols[colQueNum].Width = 100;
            grfQue.Cols[colQueId].Width = 100;
            grfQue.Cols[colQueSave].Width = 80;
            //CellStyle cs = grfQue.Styles.Add("btn");
            //cs.DataType = typeof(Button);
            //grfQue.Cols[colQueSave].Style = cs;
            //Column largeTextCol = grfQue.Cols[colQueSave];
            //largeTextCol.Style = cs;
            grfQue.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfQue.Cols[colRowNo].Caption = " ";
            grfQue.Cols[colQueName].Caption = "queue name";
            grfQue.Cols[colQueNum].Caption = "queue number";
            grfQue.Cols[colQueId].Caption = "id";
            grfQue.Cols[colQueSave].Caption = "save";

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
                grfQue[i, colQueNum] = drow["queue_code"].ToString();
                grfQue[i, colQueId] = drow["queue_id"].ToString();
                grfQue[i, colQueSave] = "";
                i++;
            }
            //grfQue.Rows[0].Visible = false;
            grfQue.Cols[colQueId].Visible = false;
            grfQue.Cols[colRowNo].Visible = false;

            //grfImg.Cols[colPathPic].Visible = false;
            grfQue.Cols[colRowNo].AllowEditing = true;
            grfQue.Cols[colQueName].AllowEditing = true;
            grfQue.Cols[colQueNum].AllowEditing = true;
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
