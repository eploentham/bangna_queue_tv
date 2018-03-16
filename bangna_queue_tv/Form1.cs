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
        public Form1()
        {
            InitializeComponent();
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
            comboBox1.SelectedValue = 0;

            listBox1.Left = 0;
            listBox1.Top = 0;
            listBox1.Width = screenWidth;
            listBox1.Height = screenHeight - 40;

            setListBox1();

        }
        private void setListBox1()
        {
            for (int x = 1; x < int.Parse(comboBox1.Text); x++)
            {
                listBox1.Items.Add(x);
            }
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
