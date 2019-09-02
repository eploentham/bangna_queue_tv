namespace bangna_queue_tv.gui
{
    partial class FrmQueueConfig
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtQueDate = new System.Windows.Forms.DateTimePicker();
            this.cboStf = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.btnQuePlus = new System.Windows.Forms.Button();
            this.btnQueMinus = new System.Windows.Forms.Button();
            this.txtQue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(16, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "วันที่";
            // 
            // txtQueDate
            // 
            this.txtQueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtQueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtQueDate.Location = new System.Drawing.Point(161, 41);
            this.txtQueDate.Name = "txtQueDate";
            this.txtQueDate.Size = new System.Drawing.Size(200, 31);
            this.txtQueDate.TabIndex = 1;
            // 
            // cboStf
            // 
            this.cboStf.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboStf.FormattingEnabled = true;
            this.cboStf.Location = new System.Drawing.Point(161, 93);
            this.cboStf.Name = "cboStf";
            this.cboStf.Size = new System.Drawing.Size(416, 33);
            this.cboStf.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(17, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Queue Name";
            // 
            // dgv1
            // 
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(26, 260);
            this.dgv1.Name = "dgv1";
            this.dgv1.Size = new System.Drawing.Size(716, 255);
            this.dgv1.TabIndex = 4;
            // 
            // btnQuePlus
            // 
            this.btnQuePlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnQuePlus.Location = new System.Drawing.Point(666, 85);
            this.btnQuePlus.Name = "btnQuePlus";
            this.btnQuePlus.Size = new System.Drawing.Size(106, 46);
            this.btnQuePlus.TabIndex = 5;
            this.btnQuePlus.Text = "เพิ่ม que";
            this.btnQuePlus.UseVisualStyleBackColor = true;
            // 
            // btnQueMinus
            // 
            this.btnQueMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnQueMinus.Location = new System.Drawing.Point(666, 137);
            this.btnQueMinus.Name = "btnQueMinus";
            this.btnQueMinus.Size = new System.Drawing.Size(106, 46);
            this.btnQueMinus.TabIndex = 6;
            this.btnQueMinus.Text = "ลบ que";
            this.btnQueMinus.UseVisualStyleBackColor = true;
            // 
            // txtQue
            // 
            this.txtQue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtQue.Location = new System.Drawing.Point(583, 93);
            this.txtQue.Name = "txtQue";
            this.txtQue.Size = new System.Drawing.Size(77, 31);
            this.txtQue.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(568, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Que เริ่มต้น";
            // 
            // FrmQueueConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 527);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtQue);
            this.Controls.Add(this.btnQueMinus);
            this.Controls.Add(this.btnQuePlus);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboStf);
            this.Controls.Add(this.txtQueDate);
            this.Controls.Add(this.label1);
            this.Name = "FrmQueueConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmQueueConfig";
            this.Load += new System.EventHandler(this.FrmQueueConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtQueDate;
        private System.Windows.Forms.ComboBox cboStf;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Button btnQuePlus;
        private System.Windows.Forms.Button btnQueMinus;
        private System.Windows.Forms.TextBox txtQue;
        private System.Windows.Forms.Label label3;
    }
}