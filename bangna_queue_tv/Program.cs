﻿using bangna_queue_tv.control;
using bangna_queue_tv.gui;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bangna_queue_tv
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                 
                if (File.Exists("log.txt"))
                {
                    long length = new System.IO.FileInfo("log.txt").Length;
                    if (length >= 1024) length = length / 1024;     // kb
                    if (length >= 1024) length = length / 1024;     // mb
                    if (length >= 2) File.Delete("log.txt");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error delete log.txt", "");
            }
            //MessageBox.Show("00000", "");
            BangnaQueueControl bqc = new BangnaQueueControl();
            Boolean chk = bqc.BringWindowToFront();
            
            
            //Application.Run(new Form1());
            if (bqc.iniC.FrmQueueShow.Equals("1"))
            {
                //MessageBox.Show("11111", "");
                Application.Run(new FrmQueueNext(bqc));                
            }
            else if (bqc.iniC.FrmQueueShow.Equals("2"))
            {
                //MessageBox.Show("11111", "");
                //new LogWriter("d", "Main bqc.iniC.FrmQueueShow 2 ");
                Application.Run(new FrmCall(bqc));
            }
            else
            {
                //MessageBox.Show("222222", "");
                //new LogWriter("d", "Main bqc.iniC.FrmQueueShow 0 ");
                Application.Run(new FrmQueueDate(bqc));
            }
        }
    }
}
