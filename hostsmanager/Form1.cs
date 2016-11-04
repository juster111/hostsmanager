using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hostsmanager
{
    public partial class Form1 : Form
    {
        private const int CP_NOCLOSE_BUTTON = 0x200;
        public static Form1 _Form1;
        protected HandleHosts host = new HandleHosts();
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

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                //myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
        public Form1()
        {
            _Form1 = this;
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            this.Visible = false;
            this.notifyIcon1.Visible = true;
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            host.resetHost();
            host.defaultLoadFile(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HandleHosts host = new HandleHosts();
            host.ReadHosttoVariable();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            if (this.ShowInTaskbar)
                this.ShowInTaskbar = false;
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

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
            mi.Invoke(notifyIcon1, null);
        }

        private void 호스트관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.ShowInTaskbar)
                this.ShowInTaskbar = true;
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
    }
}
