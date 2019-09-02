using bangna_queue_tv.control;
using bangna_queue_tv.gui;
using bangna_queue_tv.object1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace bangna_queue_tv.gui
{
    public partial class FrmQueueAdd : Form
    {
        BangnaQueueControl bqc;
        int cntclick = 0;
        String datestart = "", dateend = "";
        BQueue bque;

        public FrmQueueAdd(BangnaQueueControl bqc)
        {
            InitializeComponent();
            this.bqc = bqc;
            initConfig();
        }
        private void initConfig()
        {
            bqc.bquDB.stfDB.setCboStaff(cboStf, bqc.iniC.queuefixid);

            setControl();

            label1.Click += Label1_Click;
            btnQueNext.Click += BtnQueNext_Click;
            cboStf.SelectedValueChanged += CboStf_SelectedValueChanged;
        }
        private void setControl()
        {
            String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            bque = new BQueue();

            String stfid = "";
            stfid = bqc.getIdCombo(cboStf, cboStf.Text);
            bque = bqc.bquDB.bqueDB.selectByPk1(date, stfid);
            lbQueCurr.Text = bque.queue_current;
            lbQue.Text = bque.queue;
        }
        private void CboStf_SelectedValueChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setControl();
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //label1.ForeColor = Color.Red;
            cntclick++;
            if (datestart.Equals(""))
            {
                datestart = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            }
            if (cntclick == 3)
            {
                label1.ForeColor = Color.Red;
            }
            if (cntclick >= 5)
            {
                dateend = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                DateTime dtstart = new DateTime();
                DateTime dtend = new DateTime();
                DateTime dtcompare = new DateTime();
                if(DateTime.TryParse(datestart, out dtstart))
                {
                    if(DateTime.TryParse(dateend, out dtend))
                    {
                        int compare = DateTime.Compare(dtstart, dtend);
                        if (compare <= 5)
                        {
                            FrmQueueConfig frm = new FrmQueueConfig(bqc);
                            frm.ShowDialog(this);
                            cntclick = 0;
                        }
                    }
                }
                label1.ForeColor = Color.Black;

            }
        }

        private void BtnQueNext_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String stfid = "", bqueid="";
            stfid = bqc.getIdCombo(cboStf, cboStf.Text);
            if (stfid.Equals(""))
            {
                MessageBox.Show("", "");
                return;
            }
            String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            bqueid = bqc.bquDB.bqueDB.selectBQueIdByStfQueDate(stfid, date);
            Queue que = new Queue();
            que.queue_id = "";
            que.staff_id = stfid;
            que.queue_date = "";
            que.row_1 = "1";
            que.active = "";
            que.status_queue = "";
            que.staff_name = "";
            que.date_begin = "";
            que.date_finish = "";
            long chk = 0;
            String re = bqc.bquDB.queDB.insertQueue(que, "");
            if(long.TryParse(re, out chk))
            {
                int chk1 = 0;
                String re1 = "";
                re1 = bqc.bquDB.bqueDB.updateQueueMax(bqueid);
                if (int.TryParse(re1, out chk1))
                {
                    if (chk1 > 0)
                    {
                        printQueue();
                        lbQue.Text = chk1.ToString();
                    }
                }
            }
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
        private void printQueue()
        {
            PrintDocument document = new PrintDocument();
            //MessageBox.Show("ord1.printer_name "+ ord1.printer_name, "");
            document.PrinterSettings.PrinterName = bqc.iniC.printerQueue;
            document.PrintPage += new PrintPageEventHandler(printDocument1_PrintQueue);
            //This is where you set the printer in your case you could use "EPSON USB"
            //or whatever it is called on your machine, by Default it will choose the default printer
            //document.PrinterSettings.PrinterName = mposC.iniC.printerBill;
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
            //String RECEIPT = Environment.CurrentDirectory + "\\comprovante.txt";
            //if (File.Exists(RECEIPT))
            //{
            //    FileStream fs = new FileStream(RECEIPT, FileMode.Open);
            //    StreamReader sr = new StreamReader(fs);
            //    stringToPrint = sr.ReadToEnd();

            //    sr.Close();
            //    fs.Close();
            //}
            String date = "";
            date = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            
            //stringToPrint = mposC.mposDB.copDB.genQueue1Doc() + Environment.NewLine;
            stringToPrint += "เวลา " + date + Environment.NewLine;
            //stringToPrint += "" + textBox1.Text + Environment.NewLine;
            //stringToPrint += "" + txtTopUp1.Text + Environment.NewLine;
            //stringToPrint += "" + txtTopUp2.Text + Environment.NewLine;
            //stringToPrint += "" + txtTopUp3.Text + Environment.NewLine;
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

        }
        private void FrmQueueAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
