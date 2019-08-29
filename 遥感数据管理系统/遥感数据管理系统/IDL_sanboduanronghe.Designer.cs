namespace 遥感数据管理系统
{
    partial class IDL_sanboduanronghe
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
            this.btnxml = new System.Windows.Forms.Button();
            this.textidl = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnquit = new System.Windows.Forms.Button();
            this.btnok = new System.Windows.Forms.Button();
            this.addresult = new System.Windows.Forms.CheckBox();
            this.btnbaocun = new System.Windows.Forms.Button();
            this.txtbaocun = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnyingxiang = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnxml
            // 
            this.btnxml.Location = new System.Drawing.Point(525, 101);
            this.btnxml.Name = "btnxml";
            this.btnxml.Size = new System.Drawing.Size(75, 23);
            this.btnxml.TabIndex = 53;
            this.btnxml.Text = "...";
            this.btnxml.UseVisualStyleBackColor = true;
            this.btnxml.Click += new System.EventHandler(this.btnxml_Click);
            // 
            // textidl
            // 
            this.textidl.Location = new System.Drawing.Point(115, 98);
            this.textidl.Name = "textidl";
            this.textidl.Size = new System.Drawing.Size(385, 21);
            this.textidl.TabIndex = 52;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 51;
            this.label4.Text = "IDL程序：";
            // 
            // btnquit
            // 
            this.btnquit.Location = new System.Drawing.Point(515, 191);
            this.btnquit.Name = "btnquit";
            this.btnquit.Size = new System.Drawing.Size(75, 23);
            this.btnquit.TabIndex = 50;
            this.btnquit.Text = "取消";
            this.btnquit.UseVisualStyleBackColor = true;
            // 
            // btnok
            // 
            this.btnok.Location = new System.Drawing.Point(425, 191);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(75, 23);
            this.btnok.TabIndex = 49;
            this.btnok.Text = "确认";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // addresult
            // 
            this.addresult.AutoSize = true;
            this.addresult.Location = new System.Drawing.Point(16, 185);
            this.addresult.Name = "addresult";
            this.addresult.Size = new System.Drawing.Size(132, 16);
            this.addresult.TabIndex = 48;
            this.addresult.Text = "结果添加到工作空间";
            this.addresult.UseVisualStyleBackColor = true;
            // 
            // btnbaocun
            // 
            this.btnbaocun.Location = new System.Drawing.Point(525, 139);
            this.btnbaocun.Name = "btnbaocun";
            this.btnbaocun.Size = new System.Drawing.Size(75, 23);
            this.btnbaocun.TabIndex = 47;
            this.btnbaocun.Text = "...";
            this.btnbaocun.UseVisualStyleBackColor = true;
            this.btnbaocun.Click += new System.EventHandler(this.btnbaocun_Click);
            // 
            // txtbaocun
            // 
            this.txtbaocun.Location = new System.Drawing.Point(115, 141);
            this.txtbaocun.Name = "txtbaocun";
            this.txtbaocun.Size = new System.Drawing.Size(385, 21);
            this.txtbaocun.TabIndex = 46;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 45;
            this.label3.Text = "保存路径：";
            // 
            // btnyingxiang
            // 
            this.btnyingxiang.Location = new System.Drawing.Point(525, 31);
            this.btnyingxiang.Name = "btnyingxiang";
            this.btnyingxiang.Size = new System.Drawing.Size(75, 23);
            this.btnyingxiang.TabIndex = 44;
            this.btnyingxiang.Text = "...";
            this.btnyingxiang.UseVisualStyleBackColor = true;
            this.btnyingxiang.Click += new System.EventHandler(this.btnyingxiang_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 42;
            this.label1.Text = "待融合影像：";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(115, 17);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(385, 52);
            this.listBox1.TabIndex = 54;
            // 
            // IDL_sanboduanronghe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 226);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnxml);
            this.Controls.Add(this.textidl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnquit);
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.addresult);
            this.Controls.Add(this.btnbaocun);
            this.Controls.Add(this.txtbaocun);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnyingxiang);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "IDL_sanboduanronghe";
            this.Text = "三波段融合";
            this.Load += new System.EventHandler(this.IDL_sanboduanronghe_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnxml;
        private System.Windows.Forms.TextBox textidl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnquit;
        private System.Windows.Forms.Button btnok;
        private System.Windows.Forms.CheckBox addresult;
        private System.Windows.Forms.Button btnbaocun;
        private System.Windows.Forms.TextBox txtbaocun;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnyingxiang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
    }
}