using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bangna_queue_tv
{
    public partial class Form1 : Form
    {
        Timer timer1;
        ConnectDB conn;
        DataTable dt = new DataTable();
        public Form1()
        {
            InitializeComponent();
            conn = new ConnectDB();
            timer1 = new Timer();
            timer1.Tick += new EventHandler(OnTimedEvent);
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;

            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            label1.Top = screenHeight - 20;
            label1.Left = 10;
            label1.Text = "Resolution : " + screenWidth.ToString() + " X " + screenHeight.ToString();
            comboBox1.Top = screenHeight - 30;
            comboBox1.Left = label1.Left + label1.Width + 20;
            comboBox1 = getCboCnt(comboBox1);

            dgv1.Left = 0;
            dgv1.Top = 0;
            dgv1.Width = screenWidth;
            dgv1.Height = screenHeight - 40;
            dgv1.DefaultCellStyle.Font = new Font("Tahoma", 60);

            setGrd(screenWidth, screenHeight);
            setData();

        }
        private void setGrd(int screenWidth, int screenHeight)
        {
            int x = 0;
            int.TryParse(comboBox1.Text, out x);
            int col = screenWidth;
            int col2 = col / 3;
            int col1 = col2;
            col1 += col2;

            int row = screenHeight;
            int row1 = row / x;

            dgv1.ColumnHeadersVisible = false;

            dgv1.ColumnCount = 2;

            dgv1.RowCount = int.Parse(comboBox1.Text);
            dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv1.Columns[0].Width = col1-10;
            dgv1.Columns[1].Width = col2-35;

            //dGv.RowTemplate.Height = row1;
            foreach (DataGridViewRow rowH in dgv1.Rows)
            {
                rowH.Height = row1-15;
            }

        }
        public ComboBox getCboCnt(ComboBox c)
        {
            //ComboBox c = new ComboBox();
            ComboBoxItem item = new ComboBoxItem();
            c.Items.Clear();
            //c.Items.Add(id);

            //DataTable dt = selectByPk(id);
            for (int i = 1; i <= 4; i++)
            {
                item = new ComboBoxItem();
                item.Value = i.ToString();
                item.Text = i.ToString();
                //c.Items.Add(dt.Rows[i][dist.districtName].ToString() + "/" + dt.Rows[i][dist.amphurName].ToString() + "/" + dt.Rows[i][dist.provinceName].ToString());
                c.Items.Add(item);
            }
            c.SelectedItem = item;
            //c.DroppedDown = true;
            return c;
        }
        private void setData()
        {
            
            String sql = "", chk = "-";
            sql = "Select * " +
                    "From b_staff " +
                    "Where staff_active = '1' Order By sort1";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                int i = 0;
                foreach(DataRow row in dt.Rows)
                {
                    String que = "";
                    sql = "Select * From t_queue Where staff_id = '"+ row["staff_id"].ToString() + "' and status_queue = '1' Order By queue_id asc limit 1";
                    DataTable dt1 = conn.selectData(sql);
                    if (dt1.Rows.Count > 0)
                    {
                        que = dt1.Rows[0]["row_1"].ToString();
                    }
                    dgv1[0, i].Value = row["prefix"].ToString()+" "+ row["staff_fname_t"].ToString() + " " + row["staff_lname_t"].ToString();
                    dgv1[1, i].Value = que;
                    i++;
                }
            }
        }
        private void OnTimedEvent(object sender, EventArgs e)
        {
            setData();
            //Console.WriteLine("Hello World!");
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                if(MessageBox.Show("ต้องการออกจากโปรแกรม","ออกจากโปรแกรม", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    this.Close();
                    return true;
                }
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}
