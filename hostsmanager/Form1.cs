using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;


namespace hostsmanager
{
    public partial class Form1 : Form
    {
        private const int CP_NOCLOSE_BUTTON = 0x200;
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MINIMIZE = 0xF020;

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_SYSCOMMAND:
                    int command = m.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MINIMIZE)
                    {
                        Console.WriteLine("AAAAAAAAAA");
                    }
                    break;
            }
            base.WndProc(ref m);
        }


        public static Form1 _Form1;
        protected HandleHosts host = new HandleHosts(); 
        protected Proxy Cproxy = new Proxy();

       
        public Form1()
        {
            _Form1 = this;
            InitializeComponent(); 
            this.WindowState = FormWindowState.Maximized;
            //this.ShowInTaskbar = false;
            this.Visible = true;
            this.notifyIcon1.Visible = true;

            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            host.resetHost();
            host.defaultLoadFile();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HandleHosts host = new HandleHosts();
            host.ReadHosttoVariable();
            //Cproxy.setProxy("127.0.0.1:8881", true);

            //Thread t = new Thread(new ThreadStart(Cproxy.AcceptSockets));
            //t.Start();


            //Console.WriteLine("소켓 끝"); 
           
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            //if (this.ShowInTaskbar)
            //    this.ShowInTaskbar = false;
            if (this.WindowState != FormWindowState.Minimized)
                this.WindowState = FormWindowState.Minimized;

            host.defaultSaveFile();
            host.ballonTip("저장되었습니다. 동작-적용을 실행해 주세요.");
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLoadHosts_Click(object sender, EventArgs e)
        {
            host.loadHostsfile();
        }
         
        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
            mi.Invoke(notifyIcon1, null);
        }

        private void 호스트관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (!this.ShowInTaskbar)
            //    this.ShowInTaskbar = true;
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;
        }

        private void 적용ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            적용ToolStripMenuItem1.Enabled = false;
            초기화ToolStripMenuItem.Enabled = true;
            host.applyHosts();
        }

        private void 초기화ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            초기화ToolStripMenuItem.Enabled = false;
            적용ToolStripMenuItem1.Enabled = true;
            host.resetHost();
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.

            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                try
                {
                    string[] text = File.ReadAllLines(file);
                    foreach (var item in text)
                    {
                        richTextBox1.AppendText(item + Environment.NewLine);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }

        }

        private void 자동재시작초기화적용ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            host.resetHost();
            적용ToolStripMenuItem1.Enabled = false;
            초기화ToolStripMenuItem.Enabled = true;
            host.applyHosts();
            Flush.FlushMyCache();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i <= richTextBox1.Lines.Count(); i++)
            { 
                if (richTextBox1.Lines[i].IndexOf(textBox1.Text) > -1 && textBox1.Text.Trim().Length > 0)
                { 
                    Console.WriteLine("start index={0}, end index={1}", richTextBox1.Lines[i].IndexOf(textBox1.Text), textBox1.Text.Length);

                    string[] lines = richTextBox1.Lines; 
                    richTextBox1.Select(richTextBox1.GetFirstCharIndexFromLine(i), richTextBox1.Lines[i].Length); 
                    richTextBox1.SelectionBackColor = System.Drawing.Color.Yellow;
                     
                }
                else
                {
                    richTextBox1.Select(richTextBox1.GetFirstCharIndexFromLine(i), richTextBox1.Lines[i].ToString().Length);
                    richTextBox1.SelectionBackColor = System.Drawing.Color.White; 
                }
            }
            textBox1.Focus();

        }
        public string[] getTextboxLines()
        {
            return richTextBox1.Lines;
        }

        public void setTextboxLines(List<string> collection)
        {
            foreach (var item in collection)
            {
                richTextBox1.AppendText(item + Environment.NewLine);
            }
        } 

        private void Btn_noProxy_Click(object sender, EventArgs e)
        {  

            Cproxy.setProxy("", false);
             
        }

        private void Btn_Proxy_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(Cproxy.AcceptSockets));
            t.Start();


        } 
    }
}
