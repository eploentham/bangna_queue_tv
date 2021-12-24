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
    public class FrmQueueAdd1:Form
    {
        BangnaQueueControl bqc;
        Panel pn1;
        Font fEdit, fEditB;
        C1FlexGrid grfQue;
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
        public FrmQueueAdd1(BangnaQueueControl bqc)
        {
            this.bqc = bqc;
            initConfig();
        }
        private void initConfig()
        {
            this.Size = new System.Drawing.Size(1224, 768);
            fEdit = new Font(bqc.iniC.grdViewFontName, bqc.grdViewFontSize, FontStyle.Regular);
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


            initGrfQue();
            setGrfImg();

            this.StartPosition = FormStartPosition.CenterScreen;
            btnStatus.Click += BtnStatus_Click;
            this.Load += FrmQueueAdd1_Load;
        }

        private void BtnStatus_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //MessageBox.Show("aaaaa", "");
            FrmQueueConfig frm = new FrmQueueConfig(bqc);
            frm.ShowDialog(this);
        }

        private void initGrfQue()
        {
            grfQue = new C1FlexGrid();
            grfQue.Font = fEdit;
            grfQue.Dock = System.Windows.Forms.DockStyle.Fill;
            grfQue.Location = new System.Drawing.Point(0, 0);

            theme1.SetTheme(sB1, "Office2016DarkGray");
            
            //FilterRow fr = new FilterRow(grfExpn);

            //grfVs.AfterRowColChange += GrfImg_AfterRowColChange;
            //grfVs.MouseDown += GrfImg_MouseDown;
            grfQue.Click += GrfQue_Click;
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfQue.ContextMenu = menuGw;
            pn1.Controls.Add(grfQue);
            this.Controls.Add(sB1);

            theme1.SetTheme(grfQue, "Office2016DarkGray");

        }
        private void setGrfImg()
        {
            //grfQue.Clear();
            grfQue.DataSource = null;
            grfQue.Rows.Count = 1;
            //grfQue.Rows.Count = 200;
            grfQue.Cols.Count = 5;
            
            grfQue.Cols[colRowNo].Width = 250;
            grfQue.Cols[colQueName].Width = 100;
            grfQue.Cols[colQueNum].Width = 100;
            grfQue.Cols[colQueId].Width = 100;

            grfQue.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfQue.Cols[colRowNo].Caption = " ";
            grfQue.Cols[colQueName].Caption = "Desc1";
            grfQue.Cols[colQueNum].Caption = "Desc2";
            grfQue.Cols[colQueId].Caption = "Desc3";
            grfQue.Rows[0].Visible = false;
            grfQue.Cols[0].Visible = false;

            
            //grfImg.Cols[colPathPic].Visible = false;
            grfQue.Cols[colRowNo].AllowEditing = false;
            grfQue.Cols[colQueName].AllowEditing = false;
            grfQue.Cols[colQueNum].AllowEditing = false;
            grfQue.Cols[colQueId].AllowEditing = false;
            grfQue.Cols[colQueId].Visible = false;
            //grfImg.AutoSizeCols();
            grfQue.AutoSizeRows();
            //theme1.SetTheme(grfQue, "Office2016Colorful");

        }
        private void GrfQue_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

        }
        private void FrmQueueAdd1_Load(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
