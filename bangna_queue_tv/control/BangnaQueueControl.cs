﻿using bangna_queue_tv.obgdb;
using bangna_queue_tv.object1;
using C1.Win.C1Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace bangna_queue_tv.control
{
    public class BangnaQueueControl
    {
        public InitConfig iniC;
        public IniFile iniF;
        public ConnectDB conn;

        public Company cop;
        public Staff user;

        public String StartupPath = "";
        public LogWriter logw;

        public int grdViewFontSize = 0, grdQueFontSize = 0, grdQueTodayFontSize = 0, timerImgScanNew=0, printerQueueFontSize=0;
        public Decimal CreditCharge = 0;
        public Boolean ftpUsePassive = false, chkAppExit=false;

        public BangnaQueueDB bquDB;
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        public BangnaQueueControl()
        {
            initConfig();
            
        }
        private void initConfig()
        {
            try
            {
                //new LogWriter("d", "BangnaQueueControl initConfig ");
                String appName = "";
                appName = System.AppDomain.CurrentDomain.FriendlyName;
                appName = appName.ToLower().Replace(".exe", "");
                if (System.IO.File.Exists(Environment.CurrentDirectory + "\\" + appName + ".ini"))
                {
                    appName = Environment.CurrentDirectory + "\\" + appName + ".ini";
                }
                else
                {
                    appName = Environment.CurrentDirectory + "\\" + Application.ProductName + ".ini";
                }
                StartupPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                iniF = new IniFile(appName);
                iniC = new InitConfig();
                user = new Staff();

                cop = new Company();
                logw = new LogWriter();
                GetConfig();
                conn = new ConnectDB(iniC);
                bquDB = new BangnaQueueDB(conn);
            }
            catch(Exception ex)
            {
                new LogWriter("e", "BangnaQueueControl initConfig "+ ex.Message);
            }
        }
        public void GetConfig()
        {
            iniC.hostDB = iniF.getIni("connection", "hostDB");
            iniC.nameDB = iniF.getIni("connection", "nameDB");
            iniC.userDB = iniF.getIni("connection", "userDB");
            iniC.passDB = iniF.getIni("connection", "passDB");
            iniC.portDB = iniF.getIni("connection", "portDB");

            iniC.hostDBEx = iniF.getIni("connection", "hostDBEx");
            iniC.nameDBEx = iniF.getIni("connection", "nameDBEx");
            iniC.userDBEx = iniF.getIni("connection", "userDBEx");
            iniC.passDBEx = iniF.getIni("connection", "passDBEx");
            iniC.portDBEx = iniF.getIni("connection", "portDBEx");

            iniC.hostFTP = iniF.getIni("ftp", "hostFTP");
            iniC.userFTP = iniF.getIni("ftp", "userFTP");
            iniC.passFTP = iniF.getIni("ftp", "passFTP");
            iniC.portFTP = iniF.getIni("ftp", "portFTP");
            iniC.folderFTP = iniF.getIni("ftp", "folderFTP");
            iniC.usePassiveFTP = iniF.getIni("ftp", "usePassiveFTP");

            iniC.grdViewFontSize = iniF.getIni("app", "grdViewFontSize");
            iniC.grdViewFontName = iniF.getIni("app", "grdViewFontName");

            iniC.grdQueFontSize = iniF.getIni("app", "grdQueFontSize");
            iniC.grdQueFontName = iniF.getIni("app", "grdQueFontName");

            iniC.grdQueTodayFontSize = iniF.getIni("app", "grdQueTodayFontSize");
            iniC.grdQueTodayFontName = iniF.getIni("app", "grdQueTodayFontName");

            iniC.txtFocus = iniF.getIni("app", "txtFocus");
            iniC.grfRowColor = iniF.getIni("app", "grfRowColor");
            iniC.statusAppDonor = iniF.getIni("app", "statusAppDonor");
            iniC.themeApplication = iniF.getIni("app", "themeApplication");
            iniC.themeDonor = iniF.getIni("app", "themeDonor");
            iniC.themeDonor1 = iniF.getIni("app", "themeDonor1");
            iniC.printerSticker = iniF.getIni("app", "printerSticker");
            iniC.timerlabreqaccept = iniF.getIni("app", "timerlabreqaccept");
            iniC.printerQueue = iniF.getIni("app", "printerQueue");
            iniC.queuefixid = iniF.getIni("app", "queuefixid");
            iniC.FrmQueueShow = iniF.getIni("app", "FrmQueueShow");
            iniC.printerQueueFontSize = iniF.getIni("app", "printerQueueFontSize");
            iniC.printerQueueFontName = iniF.getIni("app", "printerQueueFontName");

            iniC.sticker_donor_width = iniF.getIni("sticker_donor", "width");
            iniC.sticker_donor_height = iniF.getIni("sticker_donor", "height");
            iniC.sticker_donor_start_y = iniF.getIni("sticker_donor", "start_y");
            iniC.sticker_donor_barcode_height = iniF.getIni("sticker_donor", "barcode_height");
            iniC.sticker_donor_barcode_gap_x = iniF.getIni("sticker_donor", "barcode_gap_x");
            iniC.sticker_donor_barcode_gap_y = iniF.getIni("sticker_donor", "barcode_gap_y");
            iniC.sticker_donor_gap = iniF.getIni("sticker_donor", "gap");
            iniC.sticker_donor_start_x = iniF.getIni("sticker_donor", "start_x");
            iniC.status_show_border = iniF.getIni("sticker_donor", "status_show_border");
            iniC.barcode_width_minus = iniF.getIni("sticker_donor", "barcode_width_minus");
            iniC.printStickerLeft = iniF.getIni("sticker_donor", "printStickerLeft");
            iniC.printStickerRight = iniF.getIni("sticker_donor", "printStickerRight");
            iniC.printStickerTop = iniF.getIni("sticker_donor", "printStickerTop");

            iniC.grfRowRed = iniF.getIni("app", "grfRowRed");
            iniC.grfRowGreen = iniF.getIni("app", "grfRowGreen");
            iniC.grfRowYellow = iniF.getIni("app", "grfRowYellow");
            iniC.timerImgScanNew = iniF.getIni("app", "timerImgScanNew");
            iniC.pathImageScan = iniF.getIni("app", "pathImageScan");
            iniC.patientaddpanel1weight = iniF.getIni("app", "patientaddpanel1weight");
            iniC.creditCharge = iniF.getIni("app", "creditCharge");
            iniC.service_point_id = iniF.getIni("app", "service_point_id");
            iniC.statusCheckDonor = iniF.getIni("app", "statusCheckDonor");
            iniC.printerBill = iniF.getIni("app", "printerBill");
            iniC.printerAppointment = iniF.getIni("app", "printerAppointment");
            iniC.pathSaveExcelAppointment = iniF.getIni("app", "pathSaveExcelAppointment");
            iniC.printerA4 = iniF.getIni("app", "printerA4");
            iniC.hostname = iniF.getIni("app", "hostname");
            iniC.hostnamee = iniF.getIni("app", "hostnamee");

            iniC.email_form = iniF.getIni("email", "email_form");
            iniC.email_auth_user = iniF.getIni("email", "email_auth_user");
            iniC.email_auth_pass = iniF.getIni("email", "email_auth_pass");
            iniC.email_port = iniF.getIni("email", "email_port");
            iniC.email_ssl = iniF.getIni("email", "email_ssl");
            iniC.email_to_sperm_freezing = iniF.getIni("email", "email_to_sperm_freezing");

            iniC.grdViewFontName = iniC.grdViewFontName.Equals("") ? "Microsoft Sans Serif" : iniC.grdViewFontName;
            iniC.grdQueFontName = iniC.grdQueFontName.Equals("") ? "Microsoft Sans Serif" : iniC.grdQueFontName;
            iniC.grdQueTodayFontName = iniC.grdQueTodayFontName.Equals("") ? "Microsoft Sans Serif" : iniC.grdQueTodayFontName;

            iniC.statusPrintQue = iniF.getIni("app", "statusPrintQue");
            iniC.statusQueueNameHide = iniF.getIni("app", "statusQueueNameHide");
            iniC.printQueueCount = iniF.getIni("app", "printQueueCount");

            iniC.sticker_donor_width = iniC.sticker_donor_width.Equals("") ? "120" : iniC.sticker_donor_width;
            iniC.sticker_donor_height = iniC.sticker_donor_height.Equals("") ? "90" : iniC.sticker_donor_height;
            iniC.sticker_donor_start_y = iniC.sticker_donor_start_y.Equals("") ? "60" : iniC.sticker_donor_start_y;
            iniC.sticker_donor_barcode_height = iniC.sticker_donor_barcode_height.Equals("") ? "40" : iniC.sticker_donor_barcode_height;
            iniC.sticker_donor_barcode_gap_x = iniC.sticker_donor_barcode_gap_x.Equals("") ? "5" : iniC.sticker_donor_barcode_gap_x;
            iniC.sticker_donor_barcode_gap_y = iniC.sticker_donor_barcode_gap_y.Equals("") ? "30" : iniC.sticker_donor_barcode_gap_y;
            iniC.sticker_donor_gap = iniC.sticker_donor_gap.Equals("") ? "20" : iniC.sticker_donor_gap;
            iniC.sticker_donor_start_x = iniC.sticker_donor_start_x.Equals("") ? "52" : iniC.sticker_donor_start_x;
            iniC.patientaddpanel1weight = iniC.patientaddpanel1weight == null ? "320" : iniC.patientaddpanel1weight.Equals("") ? "300" : iniC.patientaddpanel1weight;
            iniC.printerSticker = iniC.printerSticker.Equals("") ? "default" : iniC.printerSticker;
            iniC.status_show_border = iniC.status_show_border.Equals("") ? "0" : iniC.status_show_border;
            iniC.barcode_width_minus = iniC.barcode_width_minus.Equals("") ? "0" : iniC.barcode_width_minus;
            iniC.timerlabreqaccept = iniC.timerlabreqaccept.Equals("") ? "120" : iniC.timerlabreqaccept;

            iniC.statusPrintQue = iniC.statusPrintQue.Equals("") ? "0" : iniC.statusPrintQue;
            iniC.statusQueueNameHide = iniC.statusQueueNameHide.Equals("") ? "1" : iniC.statusQueueNameHide;
            iniC.hostname = iniC.hostname.Equals("") ? "" : iniC.hostname;
            iniC.hostnamee = iniC.hostnamee.Equals("") ? "" : iniC.hostnamee;

            iniC.hostFTP = iniC.hostFTP == null ? "" : iniC.hostFTP;
            iniC.userFTP = iniC.userFTP == null ? "" : iniC.userFTP;
            iniC.passFTP = iniC.passFTP == null ? "" : iniC.passFTP;
            iniC.portFTP = iniC.portFTP == null ? "" : iniC.portFTP;

            iniC.themeApplication = iniC.themeApplication == null ? "Office2007Blue" : iniC.themeApplication.Equals("") ? "Office2007Blue" : iniC.themeApplication;
            iniC.themeDonor = iniC.themeDonor == null ? "Office2007Blue" : iniC.themeDonor.Equals("") ? "Office2007Blue" : iniC.themeDonor;
            iniC.themeDonor1 = iniC.themeDonor1 == null ? "MacBlue" : iniC.themeDonor1.Equals("") ? "MacBlue" : iniC.themeDonor1;
            iniC.grfRowRed = iniC.grfRowRed == null ? "#FF0266" : iniC.grfRowRed.Equals("") ? "#FF0266" : iniC.grfRowRed;
            iniC.grfRowGreen = iniC.grfRowGreen == null ? "#7CB342" : iniC.grfRowGreen.Equals("") ? "#7CB342" : iniC.grfRowGreen;
            iniC.grfRowYellow = iniC.grfRowYellow == null ? "#FFDE03" : iniC.grfRowYellow.Equals("") ? "#FFDE03" : iniC.grfRowYellow;

            iniC.statusAppDonor = iniC.statusAppDonor == null ? "1" : iniC.statusAppDonor.Equals("") ? "1" : iniC.statusAppDonor;
            iniC.timerImgScanNew = iniC.timerImgScanNew == null ? "2" : iniC.timerImgScanNew.Equals("") ? "0" : iniC.timerImgScanNew;
            iniC.pathImageScan = iniC.pathImageScan == null ? "d:\\images" : iniC.pathImageScan.Equals("") ? "d:\\images" : iniC.pathImageScan;
            iniC.folderFTP = iniC.folderFTP == null ? "images_medical_record" : iniC.folderFTP.Equals("") ? "images_medical_record" : iniC.folderFTP;
            iniC.creditCharge = iniC.creditCharge == null ? "3" : iniC.creditCharge.Equals("") ? "3" : iniC.creditCharge;
            iniC.usePassiveFTP = iniC.usePassiveFTP == null ? "false" : iniC.usePassiveFTP.Equals("") ? "false" : iniC.usePassiveFTP;
            iniC.service_point_id = iniC.service_point_id == null ? "2120000002" : iniC.service_point_id.Equals("") ? "2120000002" : iniC.service_point_id;
            iniC.statusCheckDonor = iniC.statusCheckDonor == null ? "0" : iniC.statusCheckDonor.Equals("") ? "0" : iniC.statusCheckDonor;
            iniC.printQueueCount = iniC.printQueueCount == null ? "1" : iniC.printQueueCount.Equals("") ? "1" : iniC.printQueueCount;

            int.TryParse(iniC.grdViewFontSize, out grdViewFontSize);
            int.TryParse(iniC.grdQueFontSize, out grdQueFontSize);
            int.TryParse(iniC.grdQueTodayFontSize, out grdQueTodayFontSize);
            int.TryParse(iniC.timerImgScanNew, out timerImgScanNew);
            int.TryParse(iniC.printerQueueFontSize, out printerQueueFontSize);
            Decimal.TryParse(iniC.creditCharge, out CreditCharge);
            Boolean.TryParse(iniC.usePassiveFTP, out ftpUsePassive);
        }
        public String getIdCombo(C1ComboBox c, String data)
        {
            String re = "";
            if (c.Items.Count == 0) return "";
            c.SelectedIndex = c.SelectedItem == null ? 0 : c.SelectedIndex;
            foreach (ComboBoxItem item in c.Items)
            {
                if (item.Text.Equals(data))
                {
                    //c.SelectedItem = item;
                    re = item.Value;
                    break;
                }
            }
            return re;
        }
        public String getIdCombo(ComboBox c, String data)
        {
            String re = "";
            if (c.Items.Count == 0) return "";
            c.SelectedIndex = c.SelectedItem == null ? 0 : c.SelectedIndex;
            foreach (ComboBoxItem item in c.Items)
            {
                if (item.Text.Equals(data))
                {
                    //c.SelectedItem = item;
                    re = item.Value;
                    break;
                }
            }
            return re;
        }
        public BQueue selectBQueueByPk(String tqueid)
        {
            TQueue stf1 = new TQueue();
            BQueue que = new BQueue();
            stf1 = bquDB.tqueDB.selectByPk(tqueid);
            que = bquDB.queDB.selectByPk(stf1.queue_id);
            return que;
        }
        public String prefixQue(TQueue tque)
        {
            String code = "", prefix = "";
            BQueue que = new BQueue();
            que = bquDB.queDB.selectByTQueId(tque.t_queue_id);
            prefix = que.queue_prefix.Length > 0 ? que.queue_prefix : "";
            if (que.queue_code.Length > 0)
            {
                for (int i = 0; i < que.queue_code.Length; i++)
                {
                    code += "0";
                }
                code = code + tque.queue;
                code = code.Substring(tque.queue.Length);
            }
            return prefix+code;
        }
        public String prefixQue1(String quecode, String prefix, String queue)
        {
            String code = "";
            //prefix = que.queue_prefix.Length > 0 ? que.queue_prefix : "";
            if (quecode.Length > 0)
            {
                for (int i = 0; i < quecode.Length; i++)
                {
                    code += "0";
                }
                code = code + queue;
                code = code.Substring(queue.Length);
            }
            return prefix+code;
        }
        public void CombineFile(List<String> mp3Files, string mp3OuputFile)
        {
            try
            {
                if (File.Exists(mp3OuputFile))
                {
                    File.Delete(mp3OuputFile);
                }
                using (var w = new BinaryWriter(File.Create(mp3OuputFile)))
                {
                    new List<string>(mp3Files).ForEach(f => w.Write(File.ReadAllBytes(f)));
                    //foreach(String file in mp3Files)
                    //{
                    //    w.Write(File.ReadAllBytes(file));
                    //}
                }
            }
            catch(Exception ex)
            {

            }
            
        }
        public MemoryStream CombineFileStrean(List<String> mp3Files)
        {
            MemoryStream steram=new MemoryStream();
            using (var w = new BinaryWriter(steram))
            {
                new List<string>(mp3Files).ForEach(f => w.Write(File.ReadAllBytes(f)));
            }
            return steram;
        }
        public Size MeasureString(Control c)
        {
            return TextRenderer.MeasureText(c.Text, c.Font, new Size(int.MaxValue, int.MaxValue), TextFormatFlags.SingleLine | TextFormatFlags.NoClipping | TextFormatFlags.PreserveGraphicsClipping);
        }
        public void setControlC1Button(ref C1Button btn, Font fEdit, String text, String name, int x, int y)
        {
            btn = new C1Button();
            btn.Name = name;
            btn.Text = text;
            btn.Font = fEdit;
            btn.Location = new System.Drawing.Point(x, y);
            btn.Size = new Size(MeasureString(btn).Width + 50, fEdit.Height+5);
            btn.ImageAlign = ContentAlignment.MiddleLeft;
            btn.TextAlign = ContentAlignment.MiddleRight;
            btn.Font = fEdit;
        }
        private bool ProgramIsRunning(string FullPath)
        {
            string FilePath = Path.GetDirectoryName(FullPath);
            string FileName = Path.GetFileNameWithoutExtension(FullPath).ToLower();
            bool isRunning = false;

            Process[] pList = Process.GetProcessesByName(FileName);

            foreach (Process p in pList)
            {
                if (p.MainModule.FileName.StartsWith(FilePath, StringComparison.InvariantCultureIgnoreCase))
                {
                    isRunning = true;
                    break;
                }
            }
            return isRunning;
        }
        public int getProcessId()
        {
            int proc = 0;
            Process[] processes = Process.GetProcessesByName(System.AppDomain.CurrentDomain.FriendlyName);
            if (processes.Length == 0)
            {
                MessageBox.Show("111", "");
                Console.WriteLine("Not running");
            }
            else
            {
                MessageBox.Show("222", "");
                Console.WriteLine("Running");
                BringWindowToFront();
            }
            return proc;
        }
        public Boolean BringWindowToFront()
        {
            Boolean chk = false;
            var currentProcess = Process.GetCurrentProcess();
            var processes = Process.GetProcessesByName(currentProcess.ProcessName);
            var process = processes.FirstOrDefault(p => p.Id != currentProcess.Id);
            if (process == null) chk=true;
            var exists = System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Count() > 1;
            if (exists)
            {
                chk = true;
                chkAppExit = true;
                //MessageBox.Show("222", "");
                SetForegroundWindow(process.MainWindowHandle);
                Application.Exit();
            }
            return chk;
        }
    }
}
