
namespace bangna_queue_tv.gui
{
    partial class FrmQueueToday
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.c1StatusBar1 = new C1.Win.C1Ribbon.C1StatusBar();
            this.lbStatus = new C1.Win.C1Ribbon.RibbonLabel();
            this.rbStatus = new C1.Win.C1Ribbon.RibbonLabel();
            this.c1SplitContainer1 = new C1.Win.C1SplitContainer.C1SplitContainer();
            this.pnQue = new C1.Win.C1SplitContainer.C1SplitterPanel();
            this.pnQueAdd = new C1.Win.C1SplitContainer.C1SplitterPanel();
            this.txtQuePrefix = new C1.Win.C1Input.C1TextBox();
            this.txtQueCode = new C1.Win.C1Input.C1TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQueTodayId = new C1.Win.C1Input.C1TextBox();
            this.txtQueId = new C1.Win.C1Input.C1TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQueNum = new C1.Win.C1Input.C1NumericEdit();
            this.btnQueDel = new C1.Win.C1Input.C1Button();
            this.btnQueAdd = new C1.Win.C1Input.C1Button();
            this.txtQueName = new C1.Win.C1Input.C1TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDate = new C1.Win.C1Input.C1DateEdit();
            this.pnQueToday = new C1.Win.C1SplitContainer.C1SplitterPanel();
            ((System.ComponentModel.ISupportInitialize)(this.c1StatusBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1SplitContainer1)).BeginInit();
            this.c1SplitContainer1.SuspendLayout();
            this.pnQueAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuePrefix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQueCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQueTodayId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQueId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQueNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnQueDel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnQueAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQueName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate)).BeginInit();
            this.SuspendLayout();
            // 
            // c1StatusBar1
            // 
            this.c1StatusBar1.AutoSizeElement = C1.Framework.AutoSizeElement.Width;
            this.c1StatusBar1.LeftPaneItems.Add(this.lbStatus);
            this.c1StatusBar1.Location = new System.Drawing.Point(0, 581);
            this.c1StatusBar1.Name = "c1StatusBar1";
            this.c1StatusBar1.RightPaneItems.Add(this.rbStatus);
            this.c1StatusBar1.Size = new System.Drawing.Size(1099, 22);
            // 
            // lbStatus
            // 
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Text = "Label";
            // 
            // rbStatus
            // 
            this.rbStatus.Name = "rbStatus";
            this.rbStatus.Text = "Label";
            // 
            // c1SplitContainer1
            // 
            this.c1SplitContainer1.AutoSizeElement = C1.Framework.AutoSizeElement.Both;
            this.c1SplitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.c1SplitContainer1.CollapsingCueColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(133)))), ((int)(((byte)(150)))));
            this.c1SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1SplitContainer1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.c1SplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.c1SplitContainer1.Name = "c1SplitContainer1";
            this.c1SplitContainer1.Panels.Add(this.pnQue);
            this.c1SplitContainer1.Panels.Add(this.pnQueAdd);
            this.c1SplitContainer1.Panels.Add(this.pnQueToday);
            this.c1SplitContainer1.Size = new System.Drawing.Size(1099, 581);
            this.c1SplitContainer1.TabIndex = 1;
            // 
            // pnQue
            // 
            this.pnQue.Collapsible = true;
            this.pnQue.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Left;
            this.pnQue.Location = new System.Drawing.Point(0, 21);
            this.pnQue.Name = "pnQue";
            this.pnQue.Size = new System.Drawing.Size(431, 560);
            this.pnQue.SizeRatio = 40D;
            this.pnQue.TabIndex = 0;
            this.pnQue.Text = "Master";
            this.pnQue.Width = 438;
            // 
            // pnQueAdd
            // 
            this.pnQueAdd.Collapsible = true;
            this.pnQueAdd.Controls.Add(this.txtQuePrefix);
            this.pnQueAdd.Controls.Add(this.txtQueCode);
            this.pnQueAdd.Controls.Add(this.label5);
            this.pnQueAdd.Controls.Add(this.label4);
            this.pnQueAdd.Controls.Add(this.txtQueTodayId);
            this.pnQueAdd.Controls.Add(this.txtQueId);
            this.pnQueAdd.Controls.Add(this.label3);
            this.pnQueAdd.Controls.Add(this.txtQueNum);
            this.pnQueAdd.Controls.Add(this.btnQueDel);
            this.pnQueAdd.Controls.Add(this.btnQueAdd);
            this.pnQueAdd.Controls.Add(this.txtQueName);
            this.pnQueAdd.Controls.Add(this.label2);
            this.pnQueAdd.Controls.Add(this.label1);
            this.pnQueAdd.Controls.Add(this.txtDate);
            this.pnQueAdd.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Left;
            this.pnQueAdd.Location = new System.Drawing.Point(442, 0);
            this.pnQueAdd.Name = "pnQueAdd";
            this.pnQueAdd.Size = new System.Drawing.Size(350, 581);
            this.pnQueAdd.SizeRatio = 54.671D;
            this.pnQueAdd.TabIndex = 1;
            this.pnQueAdd.Width = 357;
            // 
            // txtQuePrefix
            // 
            this.txtQuePrefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtQuePrefix.Location = new System.Drawing.Point(97, 186);
            this.txtQuePrefix.Name = "txtQuePrefix";
            this.txtQuePrefix.Size = new System.Drawing.Size(100, 29);
            this.txtQuePrefix.TabIndex = 15;
            this.txtQuePrefix.Tag = null;
            // 
            // txtQueCode
            // 
            this.txtQueCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtQueCode.Location = new System.Drawing.Point(97, 138);
            this.txtQueCode.Name = "txtQueCode";
            this.txtQueCode.Size = new System.Drawing.Size(100, 29);
            this.txtQueCode.TabIndex = 14;
            this.txtQueCode.Tag = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(8, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 25);
            this.label5.TabIndex = 13;
            this.label5.Text = "prefix :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(6, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "ตัวย่อ :";
            // 
            // txtQueTodayId
            // 
            this.txtQueTodayId.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtQueTodayId.Location = new System.Drawing.Point(254, 50);
            this.txtQueTodayId.Name = "txtQueTodayId";
            this.txtQueTodayId.Size = new System.Drawing.Size(42, 29);
            this.txtQueTodayId.TabIndex = 9;
            this.txtQueTodayId.Tag = null;
            this.txtQueTodayId.Visible = false;
            // 
            // txtQueId
            // 
            this.txtQueId.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtQueId.Location = new System.Drawing.Point(254, 21);
            this.txtQueId.Name = "txtQueId";
            this.txtQueId.Size = new System.Drawing.Size(42, 29);
            this.txtQueId.TabIndex = 8;
            this.txtQueId.Tag = null;
            this.txtQueId.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(6, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "ลำดับ :";
            // 
            // txtQueNum
            // 
            this.txtQueNum.DataType = typeof(short);
            this.txtQueNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtQueNum.ImagePadding = new System.Windows.Forms.Padding(0);
            this.txtQueNum.Location = new System.Drawing.Point(97, 225);
            this.txtQueNum.Name = "txtQueNum";
            this.txtQueNum.Size = new System.Drawing.Size(121, 33);
            this.txtQueNum.TabIndex = 6;
            this.txtQueNum.Tag = null;
            // 
            // btnQueDel
            // 
            this.btnQueDel.Image = global::bangna_queue_tv.Properties.Resources.DeleteRows_small;
            this.btnQueDel.Location = new System.Drawing.Point(122, 430);
            this.btnQueDel.Name = "btnQueDel";
            this.btnQueDel.Size = new System.Drawing.Size(61, 51);
            this.btnQueDel.TabIndex = 5;
            this.btnQueDel.UseVisualStyleBackColor = true;
            // 
            // btnQueAdd
            // 
            this.btnQueAdd.Image = global::bangna_queue_tv.Properties.Resources.IncreaseIndent_small;
            this.btnQueAdd.Location = new System.Drawing.Point(122, 320);
            this.btnQueAdd.Name = "btnQueAdd";
            this.btnQueAdd.Size = new System.Drawing.Size(61, 51);
            this.btnQueAdd.TabIndex = 4;
            this.btnQueAdd.UseVisualStyleBackColor = true;
            // 
            // txtQueName
            // 
            this.txtQueName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtQueName.Location = new System.Drawing.Point(68, 85);
            this.txtQueName.Name = "txtQueName";
            this.txtQueName.Size = new System.Drawing.Size(248, 29);
            this.txtQueName.TabIndex = 3;
            this.txtQueName.Tag = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(6, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "คิว :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "วันที่ :";
            // 
            // txtDate
            // 
            this.txtDate.AllowSpinLoop = false;
            // 
            // 
            // 
            this.txtDate.Calendar.DayNameLength = 1;
            this.txtDate.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.System;
            this.txtDate.CurrentTimeZone = false;
            this.txtDate.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            this.txtDate.DisplayFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText) 
            | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) 
            | C1.Win.C1Input.FormatInfoInheritFlags.CalendarType)));
            this.txtDate.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            this.txtDate.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText) 
            | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) 
            | C1.Win.C1Input.FormatInfoInheritFlags.CalendarType)));
            this.txtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtDate.GMTOffset = System.TimeSpan.Parse("00:00:00");
            this.txtDate.ImagePadding = new System.Windows.Forms.Padding(0);
            this.txtDate.Location = new System.Drawing.Point(68, 24);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(171, 29);
            this.txtDate.TabIndex = 0;
            this.txtDate.Tag = null;
            // 
            // pnQueToday
            // 
            this.pnQueToday.Collapsible = true;
            this.pnQueToday.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Left;
            this.pnQueToday.Location = new System.Drawing.Point(803, 21);
            this.pnQueToday.Name = "pnQueToday";
            this.pnQueToday.Size = new System.Drawing.Size(296, 560);
            this.pnQueToday.SizeRatio = 40D;
            this.pnQueToday.TabIndex = 2;
            this.pnQueToday.Text = "Queue Today";
            this.pnQueToday.Width = 296;
            // 
            // FrmQueueToday
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 603);
            this.Controls.Add(this.c1SplitContainer1);
            this.Controls.Add(this.c1StatusBar1);
            this.Name = "FrmQueueToday";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmQueueToday";
            this.Load += new System.EventHandler(this.FrmQueueToday_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c1StatusBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1SplitContainer1)).EndInit();
            this.c1SplitContainer1.ResumeLayout(false);
            this.pnQueAdd.ResumeLayout(false);
            this.pnQueAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuePrefix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQueCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQueTodayId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQueId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQueNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnQueDel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnQueAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQueName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Ribbon.C1StatusBar c1StatusBar1;
        private C1.Win.C1Ribbon.RibbonLabel lbStatus;
        private C1.Win.C1SplitContainer.C1SplitContainer c1SplitContainer1;
        private C1.Win.C1SplitContainer.C1SplitterPanel pnQue;
        private C1.Win.C1SplitContainer.C1SplitterPanel pnQueAdd;
        private C1.Win.C1Input.C1DateEdit txtDate;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1TextBox txtQueName;
        private System.Windows.Forms.Label label2;
        private C1.Win.C1Input.C1Button btnQueAdd;
        private C1.Win.C1Input.C1Button btnQueDel;
        private System.Windows.Forms.Label label3;
        private C1.Win.C1Input.C1NumericEdit txtQueNum;
        private C1.Win.C1SplitContainer.C1SplitterPanel pnQueToday;
        private C1.Win.C1Input.C1TextBox txtQueId;
        private C1.Win.C1Ribbon.RibbonLabel rbStatus;
        private C1.Win.C1Input.C1TextBox txtQueTodayId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private C1.Win.C1Input.C1TextBox txtQuePrefix;
        private C1.Win.C1Input.C1TextBox txtQueCode;
    }
}