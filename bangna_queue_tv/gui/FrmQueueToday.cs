using bangna_queue_tv.control;
using bangna_queue_tv.object1;
using C1.Win.C1FlexGrid;
using C1.Win.C1SuperTooltip;
using C1.Win.C1Themes;
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
    public partial class FrmQueueToday : Form
    {
        BangnaQueueControl bqc;
        Font fEdit, fEditB;

        C1FlexGrid grfQue, grfQueToday;
        C1SuperTooltip stt, sttHnOld;
        C1SuperErrorProvider sep;
        C1ThemeController theme1;
        BQueue que;

        int colRowNo = 1, colQueName = 2, colQueNum = 3, colQueCode=4, colQuePrefix=5, colQueId = 6;
        int colTodayrowno = 1, colTodayQueName = 2, colTodayqueid = 3, colTodayQuCurr = 4, colTodayId = 5;

        Boolean pageLoad = false;
        public FrmQueueToday(BangnaQueueControl bqc)
        {
            InitializeComponent();
            this.bqc = bqc;
            initConfig();
        }
        private void initConfig()
        {
            pageLoad = true;
            fEdit = new Font(bqc.iniC.grdQueFontName, bqc.grdQueFontSize, FontStyle.Regular);
            fEditB = new Font(bqc.iniC.grdQueFontName, bqc.grdQueFontSize, FontStyle.Bold);
            theme1 = new C1ThemeController();

            que = new BQueue();
            btnQueAdd.Click += BtnQueAdd_Click;
            btnQueDel.Click += BtnQueDel_Click;
            btnQueUpdate.Click += BtnQueUpdate_Click;

            initGrfQue();
            setGrfQueue();

            initGrfQueToday();
            setGrfQueueToday();
            String date = "";
            date = DateTime.Now.Year + DateTime.Now.ToString("-MM-dd");
            txtDate.Value = date;
            this.ClientSize = new Size(1200, 600);
            txtQueNum.Value = "0";
            pnQueAdd.SizeRatio = 40;
            pnQueToday.SizeRatio = 30;
            pnQue.SizeRatio = 30;
            rbStatus.Text = "";
            lbStatus.Text = "";
            pageLoad = false;
        }

        private void BtnQueUpdate_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String re = bqc.bquDB.queDateDB.VoidClearQue(txtQueTodayId.Text.Trim(), txtQueNum.Text.Trim(), "");
            int chk = 0;
            if(int.TryParse(re, out chk))
            {
                lbStatus.Text = "clear que และupdate เลขque ใหม่ เรียบร้อย";
            }
            else
            {
                lbStatus.Text = re;
            }
        }

        private void BtnQueDel_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            bqc.bquDB.queDateDB.deleteQueToday(txtQueTodayId.Text.Trim());
            bqc.bquDB.tqueDB.voidQueueByQueDate(txtQueTodayId.Text.Trim(),"");
            clearControl();
            setGrfQueueToday();
            setGrfQueue();
            lbStatus.Text = "Delete success ";
        }
        private void clearControl()
        {
            txtQueId.Value = "";
            txtQueTodayId.Value = "";
            txtQueName.Value = "";
            txtQueNum.Value = "0";
            
        }
        private void BtnQueAdd_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String date = "";
            date = DateTime.Now.Year + DateTime.Now.ToString("-MM-dd");

            que.b_queue_id = txtQueId.Text;
            que.queue_name = txtQueName.Text;
            que.queue = txtQueNum.Text;
            BQueueDate quetoday = new BQueueDate();
            quetoday.b_queue_date_id = "";
            quetoday.queue_id = que.b_queue_id;
            quetoday.queue_current = txtQueNum.Text.Trim();
            quetoday.queue_date = date;
            quetoday.queue = txtQueNum.Text.Trim();
            String re = bqc.bquDB.queDateDB.insertBQueue(quetoday, "");
            int chk = 0;
            if(int.TryParse(re, out chk))
            {
                setGrfQueueToday();
                setGrfQueue();
                lbStatus.Text = "Save success ";
            }
        }

        private void initGrfQue()
        {
            grfQue = new C1FlexGrid();
            grfQue.Font = fEdit;
            grfQue.Dock = System.Windows.Forms.DockStyle.Fill;
            grfQue.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfQue.Click += GrfQue_Click;
            //grfVs.MouseDown += GrfImg_MouseDown;

            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);            
            pnQue.Controls.Add(grfQue);

            theme1.SetTheme(grfQue, "Office2016DarkGray");
        }

        private void GrfQue_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfQue.Row <= 0) return;
            String id = "", name = "", num = "", code="", prefix="";
            id = grfQue[grfQue.Row, colQueId] != null ? grfQue[grfQue.Row, colQueId].ToString() : "";
            name = grfQue[grfQue.Row, colQueName] != null ? grfQue[grfQue.Row, colQueName].ToString() : "";
            num = grfQue[grfQue.Row, colQueNum] != null ? grfQue[grfQue.Row, colQueNum].ToString() : "";
            code = grfQue[grfQue.Row, colQueCode] != null ? grfQue[grfQue.Row, colQueCode].ToString() : "";
            prefix = grfQue[grfQue.Row, colQuePrefix] != null ? grfQue[grfQue.Row, colQuePrefix].ToString() : "";
            if (id.Length <= 0)
            {
                btnQueAdd.Enabled = false;
            }
            else
            {
                btnQueAdd.Enabled = true;
            }
            que.b_queue_id = id;
            que.queue_name = name;
            que.queue = num;
            que.queue_prefix = prefix;
            que.queue_code = code;
            int chk = 0;
            int.TryParse(que.queue, out chk);
            if (chk <= 0)
            {
                que.queue = "0";
            }
            txtQueId.Value = que.b_queue_id;
            txtQueName.Value = que.queue_name;
            txtQueNum.Value = que.queue;
            txtQueCode.Value = que.queue_code;
            txtQuePrefix.Value = que.queue_prefix;
        }

        private void setGrfQueue()
        {
            //grfQue.Clear();
            pageLoad = true;
            grfQue.DataSource = null;
            grfQue.Rows.Count = 1;
            //grfQue.Rows.Count = 200;
            grfQue.Cols.Count = 7;

            grfQue.Cols[colRowNo].Width = 250;
            grfQue.Cols[colQueName].Width = 250;
            grfQue.Cols[colQueNum].Width = 100;
            grfQue.Cols[colQueId].Width = 100;
            
            grfQue.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfQue.Cols[colRowNo].Caption = " ";
            grfQue.Cols[colQueName].Caption = "queue name";
            grfQue.Cols[colQueNum].Caption = "queue";
            grfQue.Cols[colQueId].Caption = "id";
            grfQue.Cols[colQueCode].Caption = "ตัวย่อ";
            grfQue.Cols[colQuePrefix].Caption = "Prefix";

            DataTable dt = new DataTable();
            DateTime dtToday = new DateTime();
            DateTime.TryParse(txtDate.Text, out dtToday);
            String date = "";
            date = DateTime.Now.Year + DateTime.Now.ToString("-MM-dd");
            dt = bqc.bquDB.queDB.selectAllNotinToday(date);
            //dttoday = bqc.bquDB.queDateDB.selectBQueDate1(date);
            grfQue.Rows.Count = dt.Rows.Count + 1;
            if (dt.Rows.Count == 0)
                grfQue.Rows.Count++;
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
                grfQue.Rows[i][colRowNo] = i;
                grfQue[i, 0] = i;
                grfQue[i, colQueName] = drow["queue_name"].ToString();
                grfQue[i, colQueNum] = drow["queue_code"].ToString();
                grfQue[i, colQueId] = drow["queue_id"].ToString();
                grfQue[i, colQueCode] = drow["queue_code"].ToString();
                grfQue[i, colQuePrefix] = drow["queue_prefix"].ToString();
                i++;
            }
            //grfQue.Rows[0].Visible = false;
            grfQue.Cols[colQueId].Visible = false;
            grfQue.Cols[colRowNo].Visible = false;

            //grfImg.Cols[colPathPic].Visible = false;
            grfQue.Cols[colRowNo].AllowEditing = false;
            grfQue.Cols[colQueName].AllowEditing = false;
            grfQue.Cols[colQueNum].AllowEditing = false;
            grfQue.Cols[colQueId].AllowEditing = false;
            
            //grfImg.AutoSizeCols();
            grfQue.AutoSizeRows();
            pageLoad = false;
            //theme1.SetTheme(grfQue, "Office2016Colorful");

        }
        private void initGrfQueToday()
        {
            grfQueToday = new C1FlexGrid();
            grfQueToday.Font = fEdit;
            grfQueToday.Dock = System.Windows.Forms.DockStyle.Fill;
            grfQueToday.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfQueToday.Click += GrfQueToday_Click;
            //grfVs.MouseDown += GrfImg_MouseDown;

            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);            
            pnQueToday.Controls.Add(grfQueToday);
            grfQueToday.Rows.Count = 1;
            grfQueToday.Cols.Count = 5;

            theme1.SetTheme(grfQueToday, "Office2007Blue");
        }

        private void GrfQueToday_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfQueToday.Row <= 0) return;
            String id = "", name = "", num = "", todayid="";
            todayid = grfQueToday[grfQueToday.Row, colTodayId] != null ? grfQueToday[grfQueToday.Row, colTodayId].ToString() : "";
            id = grfQueToday[grfQueToday.Row, colTodayqueid] != null ? grfQueToday[grfQueToday.Row, colTodayqueid].ToString() : "";
            name = grfQueToday[grfQueToday.Row, colTodayQueName] != null ? grfQueToday[grfQueToday.Row, colTodayQueName].ToString() : "";
            num = grfQueToday[grfQueToday.Row, colTodayQuCurr] != null ? grfQueToday[grfQueToday.Row, colTodayQuCurr].ToString() : "";
            que.b_queue_id = id;
            que.queue_name = name;
            que.queue = num;

            txtQueId.Value = que.b_queue_id;
            txtQueName.Value = que.queue_name;
            txtQueNum.Value = que.queue;
            txtQueTodayId.Value = todayid;
            txtQueCode.Value = "";
            txtQuePrefix.Value = "";
            //setGrfQueueToday();
        }
        private void setGrfQueueToday()
        {
            //grfQue.Clear();
            pageLoad = true;
            grfQueToday.DataSource = null;
            grfQueToday.Rows.Count = 1;
            //grfQue.Rows.Count = 200;
            grfQueToday.Cols.Count = 6;

            grfQueToday.Cols[colTodayrowno].Width = 250;
            grfQueToday.Cols[colTodayQueName].Width = 250;
            grfQueToday.Cols[colTodayQuCurr].Width = 100;
            grfQueToday.Cols[colTodayId].Width = 100;

            grfQueToday.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfQueToday.Cols[colTodayrowno].Caption = " ";
            grfQueToday.Cols[colTodayQueName].Caption = "queue name";
            grfQueToday.Cols[colTodayQuCurr].Caption = "queue number";
            grfQueToday.Cols[colTodayId].Caption = "id";

            DataTable dt = new DataTable();
            //DateTime dtToday = new DateTime();
            //DateTime.TryParse(txtDate.Text, out dtToday);
            String date = "";
            date = DateTime.Now.Year + DateTime.Now.ToString("-MM-dd");
            dt = bqc.bquDB.queDateDB.selectBQueDate1(date);
            grfQueToday.Rows.Count = dt.Rows.Count + 1;
            //if (dt.Rows.Count == 0)
            //    grfQueToday.Rows.Count++;
            int i = 1;
            foreach (DataRow drow in dt.Rows)
            {
                grfQueToday.Rows[i][colTodayrowno] = i;
                grfQueToday[i, 0] = i;
                grfQueToday[i, colTodayQueName] = drow["queue_name"].ToString();
                grfQueToday[i, colTodayQuCurr] = drow["queue_current"].ToString();
                grfQueToday[i, colTodayId] = drow["b_queue_date_id"].ToString();
                grfQueToday[i, colTodayqueid] = drow["queue_id"].ToString();

                i++;
            }
            //grfQue.Rows[0].Visible = false;
            grfQueToday.Cols[colTodayId].Visible = false;
            grfQueToday.Cols[colTodayrowno].Visible = false;

            //grfImg.Cols[colPathPic].Visible = false;
            grfQueToday.Cols[colTodayrowno].AllowEditing = false;
            grfQueToday.Cols[colTodayQueName].AllowEditing = false;
            grfQueToday.Cols[colTodayQuCurr].AllowEditing = false;
            grfQueToday.Cols[colTodayqueid].AllowEditing = false;
            grfQueToday.Cols[colTodayId].AllowEditing = false;

            //grfImg.AutoSizeCols();
            grfQueToday.AutoSizeRows();
            pageLoad = false;
            //theme1.SetTheme(grfQue, "Office2016Colorful");

        }
        private void FrmQueueToday_Load(object sender, EventArgs e)
        {
            String date = "";
            date = DateTime.Now.ToString("dd-MM-") + DateTime.Now.Year;
        }
    }
}
