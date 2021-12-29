namespace bangna_queue_tv.gui
{
    partial class FrmQueueNext
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
            this.button2 = new System.Windows.Forms.Button();
            this.btnQueNext = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cboStf = new System.Windows.Forms.ComboBox();
            this.lbQueCurr = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbQueFinish = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbTQueId = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button2.Location = new System.Drawing.Point(627, 333);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(188, 125);
            this.button2.TabIndex = 5;
            this.button2.Text = "เรียก คิว ซ้ำ";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnQueNext
            // 
            this.btnQueNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnQueNext.Location = new System.Drawing.Point(127, 333);
            this.btnQueNext.Name = "btnQueNext";
            this.btnQueNext.Size = new System.Drawing.Size(188, 125);
            this.btnQueNext.TabIndex = 4;
            this.btnQueNext.Text = "เรียก คิว";
            this.btnQueNext.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(19, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 55);
            this.label3.TabIndex = 9;
            this.label3.Text = "ชื่อ คิว :";
            // 
            // cboStf
            // 
            this.cboStf.BackColor = System.Drawing.SystemColors.Window;
            this.cboStf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboStf.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboStf.FormattingEnabled = true;
            this.cboStf.Location = new System.Drawing.Point(277, 22);
            this.cboStf.Name = "cboStf";
            this.cboStf.Size = new System.Drawing.Size(556, 50);
            this.cboStf.TabIndex = 8;
            // 
            // lbQueCurr
            // 
            this.lbQueCurr.AutoSize = true;
            this.lbQueCurr.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbQueCurr.Location = new System.Drawing.Point(329, 112);
            this.lbQueCurr.Name = "lbQueCurr";
            this.lbQueCurr.Size = new System.Drawing.Size(204, 73);
            this.lbQueCurr.TabIndex = 11;
            this.lbQueCurr.Text = "label2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(13, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(310, 73);
            this.label4.TabIndex = 10;
            this.label4.Text = "คิวปัจจุบัน :";
            // 
            // lbQueFinish
            // 
            this.lbQueFinish.AutoSize = true;
            this.lbQueFinish.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbQueFinish.Location = new System.Drawing.Point(329, 216);
            this.lbQueFinish.Name = "lbQueFinish";
            this.lbQueFinish.Size = new System.Drawing.Size(204, 73);
            this.lbQueFinish.TabIndex = 13;
            this.lbQueFinish.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(13, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(334, 73);
            this.label5.TabIndex = 12;
            this.label5.Text = "คิวสุดท้าย   :";
            // 
            // lbTQueId
            // 
            this.lbTQueId.AutoSize = true;
            this.lbTQueId.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbTQueId.Location = new System.Drawing.Point(16, 521);
            this.lbTQueId.Name = "lbTQueId";
            this.lbTQueId.Size = new System.Drawing.Size(204, 73);
            this.lbTQueId.TabIndex = 14;
            this.lbTQueId.Text = "label4";
            // 
            // FrmQueueNext
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 603);
            this.Controls.Add(this.lbTQueId);
            this.Controls.Add(this.lbQueFinish);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbQueCurr);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboStf);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnQueNext);
            this.Name = "FrmQueueNext";
            this.Text = "FrmQueueNext";
            this.Load += new System.EventHandler(this.FrmQueueNext_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnQueNext;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboStf;
        private System.Windows.Forms.Label lbQueCurr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbQueFinish;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbTQueId;
    }
}