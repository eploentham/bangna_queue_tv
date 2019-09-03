namespace bangna_queue_tv.gui
{
    partial class FrmQueueAdd
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
            this.btnQueNext = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbQueCurr = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboStf = new System.Windows.Forms.ComboBox();
            this.lbQue = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnQueNext
            // 
            this.btnQueNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnQueNext.Location = new System.Drawing.Point(278, 291);
            this.btnQueNext.Name = "btnQueNext";
            this.btnQueNext.Size = new System.Drawing.Size(408, 175);
            this.btnQueNext.TabIndex = 0;
            this.btnQueNext.Text = "เรียก คิว";
            this.btnQueNext.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(219, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 73);
            this.label1.TabIndex = 2;
            this.label1.Text = "คิวปัจจุบัน :";
            // 
            // lbQueCurr
            // 
            this.lbQueCurr.AutoSize = true;
            this.lbQueCurr.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbQueCurr.Location = new System.Drawing.Point(535, 104);
            this.lbQueCurr.Name = "lbQueCurr";
            this.lbQueCurr.Size = new System.Drawing.Size(204, 73);
            this.lbQueCurr.TabIndex = 3;
            this.lbQueCurr.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(77, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 55);
            this.label3.TabIndex = 5;
            this.label3.Text = "ชื่อ คิว :";
            // 
            // cboStf
            // 
            this.cboStf.BackColor = System.Drawing.SystemColors.Window;
            this.cboStf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboStf.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboStf.FormattingEnabled = true;
            this.cboStf.Location = new System.Drawing.Point(335, 33);
            this.cboStf.Name = "cboStf";
            this.cboStf.Size = new System.Drawing.Size(556, 50);
            this.cboStf.TabIndex = 4;
            // 
            // lbQue
            // 
            this.lbQue.AutoSize = true;
            this.lbQue.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbQue.Location = new System.Drawing.Point(535, 193);
            this.lbQue.Name = "lbQue";
            this.lbQue.Size = new System.Drawing.Size(204, 73);
            this.lbQue.TabIndex = 7;
            this.lbQue.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(219, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(306, 73);
            this.label5.TabIndex = 6;
            this.label5.Text = "คิวต่อไป   :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnQueNext);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lbQue);
            this.panel1.Controls.Add(this.cboStf);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lbQueCurr);
            this.panel1.Location = new System.Drawing.Point(191, 130);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(928, 521);
            this.panel1.TabIndex = 8;
            // 
            // FrmQueueAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1407, 794);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmQueueAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmQueueAdd";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmQueueAdd_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnQueNext;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbQueCurr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboStf;
        private System.Windows.Forms.Label lbQue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
    }
}