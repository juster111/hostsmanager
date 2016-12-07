namespace hostsmanager
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.호스트관리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.동작ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.적용ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.초기화ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.자동재시작초기화적용ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Btn_noProxy = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Btn_Proxy = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "호스트관리";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.호스트관리ToolStripMenuItem,
            this.동작ToolStripMenuItem,
            this.종료ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(139, 70);
            // 
            // 호스트관리ToolStripMenuItem
            // 
            this.호스트관리ToolStripMenuItem.Name = "호스트관리ToolStripMenuItem";
            this.호스트관리ToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.호스트관리ToolStripMenuItem.Text = "관리창 열기";
            this.호스트관리ToolStripMenuItem.Click += new System.EventHandler(this.호스트관리ToolStripMenuItem_Click);
            // 
            // 동작ToolStripMenuItem
            // 
            this.동작ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.적용ToolStripMenuItem1,
            this.초기화ToolStripMenuItem,
            this.자동재시작초기화적용ToolStripMenuItem});
            this.동작ToolStripMenuItem.Name = "동작ToolStripMenuItem";
            this.동작ToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.동작ToolStripMenuItem.Text = "동작";
            // 
            // 적용ToolStripMenuItem1
            // 
            this.적용ToolStripMenuItem1.Name = "적용ToolStripMenuItem1";
            this.적용ToolStripMenuItem1.Size = new System.Drawing.Size(214, 22);
            this.적용ToolStripMenuItem1.Text = "적용";
            this.적용ToolStripMenuItem1.Click += new System.EventHandler(this.적용ToolStripMenuItem1_Click);
            // 
            // 초기화ToolStripMenuItem
            // 
            this.초기화ToolStripMenuItem.Name = "초기화ToolStripMenuItem";
            this.초기화ToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.초기화ToolStripMenuItem.Text = "초기화";
            this.초기화ToolStripMenuItem.Click += new System.EventHandler(this.초기화ToolStripMenuItem_Click);
            // 
            // 자동재시작초기화적용ToolStripMenuItem
            // 
            this.자동재시작초기화적용ToolStripMenuItem.Name = "자동재시작초기화적용ToolStripMenuItem";
            this.자동재시작초기화적용ToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.자동재시작초기화적용ToolStripMenuItem.Text = "자동 재시작(초기화>적용)";
            this.자동재시작초기화적용ToolStripMenuItem.Click += new System.EventHandler(this.자동재시작초기화적용ToolStripMenuItem_Click);
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.종료ToolStripMenuItem.Text = "종료";
            this.종료ToolStripMenuItem.Click += new System.EventHandler(this.종료ToolStripMenuItem_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(929, 425);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(298, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "저장";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(116, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(176, 34);
            this.button2.TabIndex = 3;
            this.button2.Text = "윈도우 호스트 파일 불러오기";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnLoadHosts_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(98, 34);
            this.button4.TabIndex = 5;
            this.button4.Text = "txt 불러오기";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Btn_Proxy);
            this.panel1.Controls.Add(this.Btn_noProxy);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 425);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(929, 55);
            this.panel1.TabIndex = 6;
            // 
            // Btn_noProxy
            // 
            this.Btn_noProxy.Location = new System.Drawing.Point(765, 3);
            this.Btn_noProxy.Name = "Btn_noProxy";
            this.Btn_noProxy.Size = new System.Drawing.Size(101, 30);
            this.Btn_noProxy.TabIndex = 8;
            this.Btn_noProxy.Text = "프록시 사용안함";
            this.Btn_noProxy.UseVisualStyleBackColor = true;
            this.Btn_noProxy.Click += new System.EventHandler(this.Btn_noProxy_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(392, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "검색어";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(439, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(189, 21);
            this.textBox1.TabIndex = 6;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.richTextBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(929, 425);
            this.panel2.TabIndex = 7;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // Btn_Proxy
            // 
            this.Btn_Proxy.Location = new System.Drawing.Point(658, 3);
            this.Btn_Proxy.Name = "Btn_Proxy";
            this.Btn_Proxy.Size = new System.Drawing.Size(101, 30);
            this.Btn_Proxy.TabIndex = 9;
            this.Btn_Proxy.Text = "프록시 사용";
            this.Btn_Proxy.UseVisualStyleBackColor = true;
            this.Btn_Proxy.Click += new System.EventHandler(this.Btn_Proxy_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 480);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Hosts Remapper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 호스트관리ToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem 동작ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 적용ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 초기화ToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolStripMenuItem 자동재시작초기화적용ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.Button Btn_noProxy;
        private System.Windows.Forms.Button Btn_Proxy;
    }
}

