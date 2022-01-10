using bangna_queue_tv.control;
using bangna_queue_tv.object1;
using bangna_queue_tv.Properties;
using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1Ribbon;
using C1.Win.C1SuperTooltip;
using C1.Win.C1Themes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace bangna_queue_tv.gui
{
    public class FrmQueueDate:Form
    {
        BangnaQueueControl bqc;
        Panel pn1, pnQuenewTop, pnQueNewBotton;
        Font fEdit, fEditB, fEditPrintQue;
        C1FlexGrid grfQueToday, grfQueNew;
        C1SuperTooltip stt, sttHnOld;
        C1SuperErrorProvider sep;
        C1ThemeController theme1;
        C1StatusBar sB1;
        RibbonLabel lbStatus;
        RibbonButton btnStatus;
        C1Button btnQueNewOK;

        Bitmap img;
        Image image1;
        Color color;
        int colRowNo = 1, colQueName = 2, colQueNum = 3, colQueId=4;
        int colTodayrowno = 1, colTodayQueName = 2, colTodayqueid = 3,colTodayQue=4, colTodayQuCurr = 5, colTodayId = 6, colTodayQueCode=7, colTodayPrefix=8;
        Boolean pageLoad = false, statusNewDay = false;
        Timer timer;
        Form frmQueNew;
        public FrmQueueDate(BangnaQueueControl bqc)
        {
            this.bqc = bqc;
            initConfig();
        }
        private void initConfig()
        {
            try
            {
                InitializeComponent();
                this.Size = new System.Drawing.Size(1224, 768);
                fEdit = new Font(bqc.iniC.grdQueTodayFontName, bqc.grdQueTodayFontSize, FontStyle.Regular);
                fEditPrintQue = new Font(bqc.iniC.printerQueueFontName, int.Parse(bqc.iniC.printerQueueFontSize), FontStyle.Regular);
                theme1 = new C1ThemeController();

                this.Text = "Run-time Controls";
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.StartPosition = FormStartPosition.CenterParent;
                //this.StartPosition = FormStartPosition.CenterParent;

                timer = new Timer();
                timer.Interval = bqc.timerImgScanNew;
                timer.Enabled = false;
                timer.Tick += Timer_Tick;

                initGrfQueToday();
                setGrfQueToday();
                theme1.SetTheme(pn1, bqc.iniC.themeApplication);
                theme1.SetTheme(sB1, bqc.iniC.themeApplication);
                //this.ResumeLayout(false);
                //this.PerformLayout();

                this.StartPosition = FormStartPosition.CenterScreen;
                btnStatus.Click += BtnStatus_Click;
            }
            catch(Exception ex)
            {
                new LogWriter("e", "FrmQueueDate initConfig err " + ex.Message);
            }
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FrmQueueDate
            // 
            //this.ClientSize = new System.Drawing.Size(284, 261);
            sB1 = new C1StatusBar();
            sB1.AutoSizeElement = C1.Framework.AutoSizeElement.Width;
            sB1.Location = new System.Drawing.Point(0, 428);
            sB1.Name = "c1StatusBar1";
            sB1.Size = new System.Drawing.Size(800, 22);
            lbStatus = new RibbonLabel();
            btnStatus = new RibbonButton();
            sB1.Dock = DockStyle.Bottom;
            sB1.LeftPaneItems.Add(lbStatus);
            sB1.RightPaneItems.Add(btnStatus);
            lbStatus.Text = "";
            btnStatus.Text = "config";
            btnStatus.SmallImage = Resources.setting1;

            pn1 = new Panel();
            pn1.Dock = DockStyle.Fill;
            //pn1.Height = this.Height - sB1.Height - 25;
            
            this.Controls.Add(pn1);
            this.Controls.Add(sB1);

            this.Name = "FrmQueueDate";
            this.Load += new System.EventHandler(this.FrmQueueDate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setGrfQueToday1();
        }
        private void BtnStatus_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //MessageBox.Show("aaaaa", "");
            FrmConfig frm = new FrmConfig(bqc);
            frm.ShowDialog(this);
            setGrfQueToday1();
        }
        private void printQueue()
        {
            PrintDocument document = new PrintDocument();
            //MessageBox.Show("ord1.printer_name "+ ord1.printer_name, "");
            try
            {
                document.PrinterSettings.PrinterName = bqc.iniC.printerQueue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message, "");
            }
            document.PrintPage += new PrintPageEventHandler(printDocument1_PrintQueue);
            //This is where you set the printer in your case you could use "EPSON USB"
            //or whatever it is called on your machine, by Default it will choose the default printer
            //document.PrinterSettings.PrinterName = mposC.iniC.printerBill;
            int copy = 0;
            if(int.TryParse(bqc.iniC.printQueueCount, out copy))
            {
                document.PrinterSettings.Copies = (short)copy;
            }
            document.Print();
            Application.DoEvents();
        }
        private void printDocument1_PrintQueue(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //This part sets up the data to be printed
            Graphics g = e.Graphics;
            SolidBrush Brush = new SolidBrush(Color.Black);
            //gets the text from the textbox
            String stringToPrint = "";
            string printText = "";
            float yPos = 0, gap = 6;
            //String RECEIPT = Environment.CurrentDirectory + "\\comprovante.txt";
            //if (File.Exists(RECEIPT))
            //{
            //    FileStream fs = new FileStream(RECEIPT, FileMode.Open);
            //    StreamReader sr = new StreamReader(fs);
            //    stringToPrint = sr.ReadToEnd();

            //    sr.Close();
            //    fs.Close();
            //}
            String date = "", year = "", hhmmss = "", quename="", qurcurr="", que="", que1="", prefix="", todayque="";
            year = (DateTime.Now.Year + 543).ToString();
            hhmmss = DateTime.Now.ToString("hh:mm:ss");
            date = DateTime.Now.ToString("dd/MM/") + year + " " + hhmmss;
            que1 = grfQueToday[grfQueToday.Row, colTodayQueCode] != null ? grfQueToday[grfQueToday.Row, colTodayQueCode].ToString() : "";
            prefix = grfQueToday[grfQueToday.Row, colTodayPrefix] != null ? grfQueToday[grfQueToday.Row, colTodayPrefix].ToString() : "";
            todayque = grfQueToday[grfQueToday.Row, colTodayQue] != null ? grfQueToday[grfQueToday.Row, colTodayQue].ToString() : "";
            qurcurr = grfQueToday[grfQueToday.Row, colTodayQuCurr] != null ? grfQueToday[grfQueToday.Row, colTodayQuCurr].ToString() : "";
            quename = grfQueToday[grfQueToday.Row, colTodayQueName] != null ? grfQueToday[grfQueToday.Row, colTodayQueName].ToString() : "";
            que = grfQueToday[grfQueToday.Row, colTodayQue] != null ? bqc.prefixQue1(que1, prefix, todayque) : "";
            //stringToPrint = mposC.mposDB.copDB.genQueue1Doc() + Environment.NewLine;
            stringToPrint += "เวลา " + date + Environment.NewLine;
            stringToPrint += Environment.NewLine;
            //stringToPrint += "คิว " + quename + Environment.NewLine;
            //stringToPrint += Environment.NewLine;
            //stringToPrint += "คิวปัจจุบัน " + qurcurr + Environment.NewLine;
            stringToPrint += Environment.NewLine;
            stringToPrint += "คิวที่ " + que + Environment.NewLine;
            stringToPrint += Environment.NewLine;
            //stringToPrint += "โต๊ะ   " + txtDesk.Text + Environment.NewLine;
            //Makes the file to print and sets the look of it
            //int i = 1;
            //foreach (Order1 ord in lOrd)
            //{
            //    printText += i.ToString() + "  " + ord.foods_name + "  " + ord.qty + "  " + ord.price + Environment.NewLine;
            //    printText += "          " + ord.remark + Environment.NewLine;
            //    i++;
            //}
            String name = "";
            //name = ord1.foods_name;
            //ord1.special = ord1.special == null ? "" : ord1.special;
            //ord1.topping = ord1.topping == null ? "" : ord1.topping;

            //printText += iprn.ToString() + "  " + ord1.foods_name + "  " + ord1.qty + Environment.NewLine;

            //String[] txt = ord1.special.Split('+');
            //if (txt.Length > 1)
            //{
            //    String name1 = "";
            //    foreach (String txt1 in txt)
            //    {
            //        name1 += txt1.Trim() + Environment.NewLine;
            //    }
            //    name1 = name1.Trim();
            //    if (name1.IndexOf("+") == 0)
            //    {
            //        name1 = name1.Substring(1, name1.Length - 1);
            //    }
            //    //printText += iprn.ToString() + "  " + ord1.foods_name + "  " + ord1.qty + Environment.NewLine;
            //    //printText += "         " + ord1.qty + "  " + ord1.price + Environment.NewLine;
            //    printText += name1 + Environment.NewLine;

            //}
            //String[] txtT = ord1.topping.Split('+');
            //if (txtT.Length > 1)
            //{
            //    String name1 = "";
            //    foreach (String txt1 in txtT)
            //    {
            //        name1 += txt1.Trim() + Environment.NewLine;
            //    }
            //    name1 = name1.Trim();
            //    if (name1.IndexOf("+") == 0)
            //    {
            //        name1 = name1.Substring(1, name1.Length - 1);
            //    }
            //    //printText += iprn.ToString() + "  " + ord1.foods_name + "  " + ord1.qty + Environment.NewLine;
            //    //printText += "         " + ord1.qty + "  " + ord1.price + Environment.NewLine;
            //    printText += name1 + Environment.NewLine;

            //}
            //else
            //{
            //    //printText += iprn.ToString() + "  " + ord1.foods_name + "  " + ord1.qty + "  " + ord1.price + Environment.NewLine;
            //    printText += iprn.ToString() + "  " + ord1.foods_name + "  " + ord1.qty + Environment.NewLine;
            //}
            //printText += "          " + ord1.remark + Environment.NewLine;

            //stringToPrint += printText;
            //stringToPrint += Environment.NewLine;
            //stringToPrint += "         จำนวนเงิน " + amt1.ToString("0.00") + Environment.NewLine;
            g.DrawString(stringToPrint, new Font("arial", 16), Brush, 10, 10);
            StringFormat flags = new StringFormat(StringFormatFlags.LineLimit);  //wraps
            float marginR = e.MarginBounds.Right;
            float avg = marginR / 2;
            Size proposedSize = new Size(100, 100);
            Size textSize = TextRenderer.MeasureText(quename, fEditPrintQue, proposedSize, TextFormatFlags.RightToLeft);
            //textSize = TextRenderer.MeasureText(lbQue.Text, fEditPrintQue, proposedSize, TextFormatFlags.RightToLeft);
            //yPos = topMargin + (count * fEdit.GetHeight(e.Graphics) + gap);
            yPos = 200;
            e.Graphics.DrawString(quename, fEditPrintQue, Brushes.Black, avg - (textSize.Width / 2) + 50, yPos, flags);

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // ...
            if (keyData == (Keys.Escape))
            {
                //appExit();
                if (MessageBox.Show("ต้องการออกจากโปรแกรม1", "ออกจากโปรแกรม", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    //frmmain.Show();
                    Close();
                    return true;
                }
            }
            else
            {

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void initGrfQueToday()
        {
            grfQueToday = new C1FlexGrid();
            grfQueToday.Font = fEdit;
            grfQueToday.Dock = System.Windows.Forms.DockStyle.Fill;
            grfQueToday.Location = new System.Drawing.Point(0, 0);
                        
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

            theme1.SetTheme(grfQueToday, bqc.iniC.themeApplication);
        }

        private void GrfQueToday_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfQueToday.Row <= 0) return;
            if (grfQueToday.Col <= 0) return;
            try
            {
                bool chk = false;
                if(bqc.iniC.statusQueueNameHide.Equals("0") && (grfQueToday.Col == colQueName))
                {
                    chk = true;
                }
                else if (bqc.iniC.statusQueueNameHide.Equals("1") && (grfQueToday.Col == colTodayQue))
                {
                    chk = true;
                }
                else
                {
                    chk = false;
                }
                if (chk)
                {
                    DataTable dt = new DataTable();
                    String date = "";
                    date = DateTime.Now.Year + DateTime.Now.ToString("-MM-dd");
                    lbStatus.Text = grfQueToday.Col.ToString();
                    String id = "", name = "", num = "", todayid = "";
                    todayid = grfQueToday[grfQueToday.Row, colTodayId] != null ? grfQueToday[grfQueToday.Row, colTodayId].ToString() : "";
                    id = grfQueToday[grfQueToday.Row, colTodayqueid] != null ? grfQueToday[grfQueToday.Row, colTodayqueid].ToString() : "";
                    name = grfQueToday[grfQueToday.Row, colTodayQueName] != null ? grfQueToday[grfQueToday.Row, colTodayQueName].ToString() : "";
                    num = grfQueToday[grfQueToday.Row, colTodayQuCurr] != null ? grfQueToday[grfQueToday.Row, colTodayQuCurr].ToString() : "";
                    String re = bqc.bquDB.queDateDB.QueuetNext(id, date, todayid);
                    setGrfQueToday1();
                    if (bqc.iniC.statusPrintQue.Equals("1"))
                    {
                        printQueue();
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }
        private void setGrfQueToday1()
        {
            try
            {
                timer.Enabled = false;
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
                    grfQueToday[i, colTodayQue] = bqc.prefixQue1(drow["queue_code"].ToString(), drow["queue_prefix"].ToString(), drow["queue"].ToString());
                    grfQueToday.Rows[i].Height = 120;
                    //grfQueToday.Rows[i].HeightDisplay = 1500;
                    i++;
                }
            }
            catch(Exception ex)
            {
                new LogWriter("e", "FrmQueueDate setGrfQueToday1 ");
            }
            finally
            {
                timer.Enabled = true;
            }
        }
        private void setGrfQueToday()
        {
            int collect = 450;
            pageLoad = true;
            timer.Enabled = false;
            grfQueToday.DataSource = null;
            grfQueToday.Rows.Count = 1;
            //grfQue.Rows.Count = 200;
            grfQueToday.Cols.Count = 9;
            //Screen.PrimaryScreen.WorkingArea;
            collect = bqc.iniC.statusQueueNameHide.Equals("0") ? 450 : 700;
            grfQueToday.Cols[colTodayrowno].Width = 250;
            grfQueToday.Cols[colTodayQueName].Width = this.Width - collect;
            grfQueToday.Cols[colTodayQuCurr].Width = 200;//ตอนนี้ ถึงคิว ที่เท่าไร จะได้รู้ว่าต้องรอ อีกกี่คิว
            grfQueToday.Cols[colTodayQue].Width = 200;//คิวที่กดได้ เลขที่คิว
            grfQueToday.Cols[colTodayId].Width = 100;

            grfQueToday.ShowCursor = true;
            grfQueToday.Cols[0].Visible = false;
            grfQueToday.Rows[0].Visible = true;

            grfQueToday.Cols[colTodayrowno].Caption = " ";
            grfQueToday.Cols[colTodayQueName].Caption = "queue name";
            grfQueToday.Cols[colTodayQuCurr].Caption = "จำนวนคิว";
            grfQueToday.Cols[colTodayQue].Caption = "queue";
            grfQueToday.Cols[colTodayId].Caption = "id";

            DataTable dt = new DataTable();
            String date = "";
            date = DateTime.Now.Year + DateTime.Now.ToString("-MM-dd");
            dt = bqc.bquDB.queDateDB.selectBQueDate1(date);
            grfQueToday.Rows.Count = dt.Rows.Count + 1;
            // check ว่าเป็นวันใหม่หรือเปล่า
            statusNewDay = dt.Rows.Count == 0 ? true : false;
            int i = 1;
            foreach (DataRow drow in dt.Rows)
            {
                grfQueToday.Rows[i][colTodayrowno] = i;
                grfQueToday[i, 0] = i;
                grfQueToday[i, colTodayQueName] = drow["queue_name"].ToString();
                grfQueToday[i, colTodayQuCurr] = drow["queue_current"].ToString();
                grfQueToday[i, colTodayId] = drow["b_queue_date_id"].ToString();
                grfQueToday[i, colTodayqueid] = drow["queue_id"].ToString();
                grfQueToday[i, colTodayQueCode] = drow["queue_code"].ToString();
                grfQueToday[i, colTodayPrefix] = drow["queue_prefix"].ToString();
                grfQueToday[i, colTodayQue] = bqc.prefixQue1(drow["queue_code"].ToString(), drow["queue_prefix"].ToString(), drow["queue"].ToString());
                grfQueToday.Rows[i].Height = 120;
                //grfQueToday.Rows[i].HeightDisplay = 1500;
                i++;
            }
            //grfQue.Rows[0].Visible = false;
            grfQueToday.Cols[colTodayId].Visible = false;
            grfQueToday.Cols[colTodayrowno].Visible = false;
            grfQueToday.Cols[colTodayqueid].Visible = false;
            grfQueToday.Cols[colTodayQueCode].Visible = false;
            grfQueToday.Cols[colTodayPrefix].Visible = false;
            if (bqc.iniC.statusQueueNameHide.Equals("1"))
            {
                grfQueToday.Cols[colTodayQueName].Visible = false;
            }

            grfQueToday.Cols[colTodayQue].AllowEditing = false;
            grfQueToday.Cols[colTodayrowno].AllowEditing = false;
            grfQueToday.Cols[colTodayQueName].AllowEditing = false;
            grfQueToday.Cols[colTodayQuCurr].AllowEditing = false;
            grfQueToday.Cols[colTodayqueid].AllowEditing = false;
            grfQueToday.Cols[colTodayId].AllowEditing = false;
            grfQueToday.SelectionMode = SelectionModeEnum.Default;

            //grfImg.AutoSizeCols();
            //grfQueToday.AutoSizeRows();
            pageLoad = false;
            timer.Enabled = true;
        }
        private void initGrfQueNew()
        {
            grfQueNew = new C1FlexGrid();
            grfQueNew.Font = fEdit;
            grfQueNew.Dock = System.Windows.Forms.DockStyle.Fill;
            grfQueNew.Location = new System.Drawing.Point(0, 0);

            grfQueToday.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None;
            //FilterRow fr = new FilterRow(grfExpn);

            //grfVs.AfterRowColChange += GrfImg_AfterRowColChange;
            //grfVs.MouseDown += GrfImg_MouseDown;
            //grfQueToday.Click += GrfQueToday_Click;
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            //ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));Office2016DarkGray
            //grfQueToday.ContextMenu = menuGw;
            pnQuenewTop.Controls.Add(grfQueNew);
            grfQueNew.AllowSorting = AllowSortingEnum.None;

            theme1.SetTheme(grfQueNew, bqc.iniC.themeApplication);
        }
        private void showFrmNewDay()
        {
            frmQueNew = new Form();
            frmQueNew.Size = new System.Drawing.Size(800, 600);
            frmQueNew.WindowState = FormWindowState.Normal;
            frmQueNew.FormBorderStyle = FormBorderStyle.FixedDialog;
            frmQueNew.StartPosition = FormStartPosition.CenterScreen;
            pnQueNewBotton = new Panel();
            pnQuenewTop = new Panel();
            pnQueNewBotton.Dock = DockStyle.Bottom;
            pnQuenewTop.Dock = DockStyle.Fill;
            
            btnQueNewOK = new C1Button();
            bqc.setControlC1Button(ref btnQueNewOK, fEdit, "SAVE", "btnQueNewOK", pnQueNewBotton.Width - btnQueNewOK.Width - 20,20);
            //btnQueNewOK.Width = 
            btnQueNewOK.Click += BtnQueNewOK_Click;
            initGrfQueNew();
            frmQueNew.Controls.Add(pnQuenewTop);
            frmQueNew.Controls.Add(pnQueNewBotton);
            pnQueNewBotton.Controls.Add(btnQueNewOK);

            String date = "";
            date = DateTime.Now.Year + DateTime.Now.ToString("-MM-dd");
            DataTable dt = new DataTable();
            dt = bqc.bquDB.queDB.selectAllStatusEveryDay();
            foreach (DataRow drow in dt.Rows)
            {
                BQueueDate quetoday = new BQueueDate();
                quetoday.b_queue_date_id = "";
                quetoday.queue_id = drow["queue_id"].ToString();
                quetoday.queue_current = "0";
                quetoday.queue_date = date;
                quetoday.queue = "0";
                String re = bqc.bquDB.queDateDB.insertBQueue(quetoday, "");
                int chk = 0;
                if (int.TryParse(re, out chk))
                {
                    
                    //setGrfQueue();
                    lbStatus.Text = "Save success ";
                }
            }
            setGrfQueueToday();
            frmQueNew.ShowDialog(this);
        }
        private void setGrfQueueToday()
        {
            //grfQue.Clear();
            pageLoad = true;
            grfQueNew.DataSource = null;
            grfQueNew.Rows.Count = 1;
            //grfQue.Rows.Count = 200;
            grfQueNew.Cols.Count = 7;

            grfQueNew.Cols[colTodayrowno].Width = 250;
            grfQueNew.Cols[colTodayQueName].Width = 250;
            grfQueNew.Cols[colTodayQuCurr].Width = 100;
            grfQueNew.Cols[colTodayId].Width = 100;

            grfQueNew.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfQueNew.Cols[colTodayrowno].Caption = " ";
            grfQueNew.Cols[colTodayQueName].Caption = "queue name";
            grfQueNew.Cols[colTodayQuCurr].Caption = "queue number";
            grfQueNew.Cols[colTodayId].Caption = "id";

            DataTable dt = new DataTable();
            //DateTime dtToday = new DateTime();
            //DateTime.TryParse(txtDate.Text, out dtToday);
            String date = "";
            date = DateTime.Now.Year + DateTime.Now.ToString("-MM-dd");
            dt = bqc.bquDB.queDateDB.selectBQueDate1(date);
            grfQueNew.Rows.Count = dt.Rows.Count + 1;
            //if (dt.Rows.Count == 0)
            //    grfQueToday.Rows.Count++;
            int i = 1;
            foreach (DataRow drow in dt.Rows)
            {
                grfQueNew.Rows[i][colTodayrowno] = i;
                grfQueNew[i, 0] = i;
                grfQueNew[i, colTodayQueName] = drow["queue_name"].ToString();
                grfQueNew[i, colTodayQuCurr] = drow["queue_current"].ToString();
                grfQueNew[i, colTodayId] = drow["b_queue_date_id"].ToString();
                grfQueNew[i, colTodayqueid] = drow["queue_id"].ToString();

                i++;
            }
            //grfQue.Rows[0].Visible = false;
            grfQueNew.Cols[colTodayId].Visible = false;
            grfQueNew.Cols[colTodayrowno].Visible = false;

            //grfImg.Cols[colPathPic].Visible = false;
            grfQueNew.Cols[colTodayrowno].AllowEditing = false;
            grfQueNew.Cols[colTodayQueName].AllowEditing = false;
            grfQueNew.Cols[colTodayQuCurr].AllowEditing = false;
            grfQueNew.Cols[colTodayqueid].AllowEditing = false;
            grfQueNew.Cols[colTodayId].AllowEditing = false;

            //grfImg.AutoSizeCols();
            grfQueNew.AutoSizeRows();
            pageLoad = false;
            //theme1.SetTheme(grfQue, "Office2016Colorful");

        }
        private void BtnQueNewOK_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            frmQueNew.Dispose();
        }

        private void FrmQueueDate_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            timer.Enabled = true;
            if (statusNewDay)
            {
                showFrmNewDay();
            }
        }
    }
}
