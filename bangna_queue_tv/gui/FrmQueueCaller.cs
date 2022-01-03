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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bangna_queue_tv.gui
{
    public class FrmQueueCaller:Form
    {
        BangnaQueueControl bqc;
        Panel pn1;
        Font fEdit, fEditB, fEditPrintQue;
        C1FlexGrid grfQueCaller;
        C1SuperTooltip stt, sttHnOld;
        C1SuperErrorProvider sep;
        C1ThemeController theme1;
        C1StatusBar sB1;
        RibbonLabel lbStatus;
        RibbonButton btnStatus;

        int colId = 1, colName = 2, colSave=3;

        Boolean pageLoad = false;
        public FrmQueueCaller(BangnaQueueControl bqc)
        {
            this.bqc = bqc;
            initConfig();
        }
        private void initConfig()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(1224, 768);
            fEdit = new Font(bqc.iniC.grdViewFontName, bqc.grdViewFontSize, FontStyle.Regular);
            fEditPrintQue = new Font(bqc.iniC.printerQueueFontName, int.Parse(bqc.iniC.printerQueueFontSize), FontStyle.Regular);
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
            btnStatus.Text = "เพิ่มรายการ";
            btnStatus.SmallImage = Resources.setting1;
            btnStatus.Click += BtnStatus_Click;

            this.Controls.Add(sB1);

            initGrfQueCaller();
            setGrfQueCaller();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void BtnStatus_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            grfQueCaller.Rows.Add();
            grfQueCaller[grfQueCaller.Row, colId] = "";
            grfQueCaller[grfQueCaller.Row, colSave] = "";
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FrmQueueCaller
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "FrmQueueCaller";
            this.Load += new System.EventHandler(this.FrmQueueCaller_Load);
            this.ResumeLayout(false);

        }
        private void initGrfQueCaller()
        {
            grfQueCaller = new C1FlexGrid();
            grfQueCaller.Font = fEdit;
            grfQueCaller.Dock = System.Windows.Forms.DockStyle.Fill;
            grfQueCaller.Location = new System.Drawing.Point(0, 0);

            theme1.SetTheme(sB1, "Office2016DarkGray");
            grfQueCaller.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None;
            //FilterRow fr = new FilterRow(grfExpn);

            //grfVs.AfterRowColChange += GrfImg_AfterRowColChange;
            //grfVs.MouseDown += GrfImg_MouseDown;
            grfQueCaller.Click += GrfQueToday_Click;
            grfQueCaller.CellChanged += GrfQueCaller_CellChanged;
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Caller_Void));
            grfQueCaller.ContextMenu = menuGw;
            pn1.Controls.Add(grfQueCaller);
            grfQueCaller.AllowSorting = AllowSortingEnum.None;

            pn1.Controls.Add(sB1);

            theme1.SetTheme(grfQueCaller, "Office2007Blue");
        }
        private void ContextMenu_Caller_Void(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("ต้องการ ยกเลิก ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                String id = "";
                id = grfQueCaller[grfQueCaller.Row, colId] != null ? grfQueCaller[grfQueCaller.Row, colId].ToString() : "";
                String re = bqc.bquDB.quecDB.voiQueueCaller(id, "");
                int chk1 = 0;
                if (int.TryParse(re, out chk1))
                {
                    lbStatus.Text = "ยกเลิกเรียบร้อย";
                }
                else
                {
                    lbStatus.Text = re;
                }
            }
            setGrfQueCaller();
        }
        private void GrfQueCaller_CellChanged(object sender, RowColEventArgs e)
        {
            //throw new NotImplementedException();
            if (pageLoad) return;
            grfQueCaller[e.Row, colSave] = "SAVE";
            if (e.Row == (grfQueCaller.Rows.Count - 1))
            {
                grfQueCaller.Rows.Add();
                grfQueCaller[e.Row, colId] = "";
            }
            if(e.Col == colName)
            {
                if (grfQueCaller[e.Row, colName] == null) return;
                if (grfQueCaller.Row <= 0) return;
                if (grfQueCaller.Col <= 0) return;
                BQueueCaller quec = new BQueueCaller();
                quec = bqc.bquDB.quecDB.selectByName(grfQueCaller[e.Row, colName].ToString());
                if (quec.queue_call_id.Length > 0)
                {
                    MessageBox.Show("ชื่อ ซ้ำ", "");
                    grfQueCaller[e.Row, colName] = "";
                    lbStatus.Text = "ชื่อ ซ้ำ";
                }
            }
        }

        private void GrfQueToday_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfQueCaller.Row <= 0) return;
            if (grfQueCaller.Col <= 0) return;
            saveQueueCaller();
        }
        private Boolean saveQueueCaller()
        {
            Boolean chk = false;
            DataTable dt = new DataTable();
            String date = "";
            date = DateTime.Now.Year + DateTime.Now.ToString("-MM-dd");
            String id = "", name = "", num = "", todayid = "";
            id = grfQueCaller[grfQueCaller.Row, colId] != null ? grfQueCaller[grfQueCaller.Row, colId].ToString() : "";
            name = grfQueCaller[grfQueCaller.Row, colName] != null ? grfQueCaller[grfQueCaller.Row, colName].ToString() : "";
            BQueueCaller quec = new BQueueCaller();
            quec.queue_call_id = id;
            quec.queue_call_name = name.Trim();
            String re = bqc.bquDB.quecDB.insertQueueCaller(quec, "");
            int chk1 = 0;
            if (int.TryParse(re, out chk1))
            {
                chk = true;
                lbStatus.Text = "บันทึกเรียบร้อย";
            }
            else
            {
                lbStatus.Text = re;
            }
            return chk;
        }
        private void setGrfQueCaller()
        {
            pageLoad = true;
            
            grfQueCaller.DataSource = null;
            grfQueCaller.Rows.Count = 1;
            //grfQue.Rows.Count = 200;
            grfQueCaller.Cols.Count = 4;
            //Screen.PrimaryScreen.WorkingArea;

            grfQueCaller.Cols[colName].Width = 250;
            grfQueCaller.Cols[colSave].Width = 100;
            grfQueCaller.Cols[colId].Width = 100;

            grfQueCaller.ShowCursor = true;
            grfQueCaller.Cols[0].Visible = true;
            grfQueCaller.Rows[0].Visible = true;
            
            grfQueCaller.Cols[colName].Caption = "caller name";
            grfQueCaller.Cols[colSave].Caption = " ";
            grfQueCaller.Cols[colId].Caption = "id";

            DataTable dt = new DataTable();
            dt = bqc.bquDB.quecDB.selectAll();
            grfQueCaller.Rows.Count = dt.Rows.Count + 1;

            int i = 1;
            foreach (DataRow drow in dt.Rows)
            {
                grfQueCaller[i, 0] = i;
                grfQueCaller[i, colName] = drow["queue_call_name"].ToString();
                grfQueCaller[i, colSave] = "SAVE";
                grfQueCaller[i, colId] = drow["queue_call_id"].ToString();
                i++;
            }
            //grfQue.Rows[0].Visible = false;
            grfQueCaller.Cols[colId].Visible = false;
            pageLoad = false;
        }
        private void FrmQueueCaller_Load(object sender, EventArgs e)
        {

        }
    }
}
