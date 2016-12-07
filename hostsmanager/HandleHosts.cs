using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hostsmanager
{
    public class HandleHosts
    {
        public HandleHosts()
        {
        }
        private List<string> originHosts = new List<string>();
        private List<string> newHosts = new List<string>();
        

        private static string systemPath = Environment.GetFolderPath(Environment.SpecialFolder.System);
        private static string path = System.IO.Path.Combine(systemPath, @"drivers\etc\hosts");


        public void ReadHosttoVariable()
        {
            string line;
            System.IO.StreamReader hostFile = new System.IO.StreamReader(path);
            originHosts.RemoveRange(0, originHosts.Count);
            while ((line = hostFile.ReadLine()) != null)
            {
                originHosts.Add(line);
            }
            hostFile.Dispose();
            hostFile.Close();
        }

        public void applyHosts()
        {
            try
            {
                ReadHosttoVariable();
                newHosts.RemoveRange(0, newHosts.Count);
                newHosts.Add("#############hosts remapper start#############");
                foreach (var item in Form1._Form1.getTextboxLines())
                {
                    newHosts.Add(item);
                }
                newHosts.Add("#############hosts remapper end#############");

                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (var item in newHosts)
                    {
                        sw.WriteLine(item);
                    }
                    foreach (var item in originHosts)
                    {
                        sw.WriteLine(item);
                    }
                    dispose(fs, sw);
                }
                ballonTip("host가 등록된 ip-dns로 override 되었습니다. ");

            }
            catch
            {
                ballonTip("applyHosts - 오류 발생");
            }
        }
        public void resetHost()
        {
            System.IO.StreamReader hostFile = new System.IO.StreamReader(path);
            string line;
            List<string> hostsList = new List<string>();
            while ((line = hostFile.ReadLine()) != null)
            {
                hostsList.Add(line);
            } 
            bool isOverride = true;
            try
            {
                while (isOverride)
                {
                    int startAt = 0; int endAt = 0; int index = 0;
                    isOverride = false;
                    foreach (var item in hostsList)
                    {
                        if (item.Equals("#############hosts remapper start#############"))
                        {
                            isOverride = true;
                            startAt = index;
                        }
                        if (item.Equals("#############hosts remapper end#############"))
                        {
                            isOverride = true;
                            endAt = index;
                        }
                        index += 1;
                    }
                    if (isOverride)
                    {
                        hostsList.RemoveRange(startAt, endAt + 1 - startAt);
                    }
                }
                hostFile.Dispose();
                hostFile.Close();

                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    fs.SetLength(0);
                    foreach (var item in hostsList)
                    {
                        sw.WriteLine(item);
                    }
                    dispose(fs, sw);
                }
                ballonTip("override된 내용을 모두 초기화 하였습니다. 필요시 동작-실행을 선택하세요.");

            }
            catch
            {
                ballonTip("resetHost - 오류 발생");
            }
        }

        public void loadHostsfile()
        {
            ReadHosttoVariable();
            Form1._Form1.setTextboxLines(originHosts);
        }

        public void defaultLoadFile()
        {
            try
            {
                string line;
                string file = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), @"hostmanager.txt");

                System.IO.StreamReader hostFile = new System.IO.StreamReader(file);  
                List<string> list = new List<string>();

                while ((line = hostFile.ReadLine()) != null)
                {
                    list.Add(line);
                }
                hostFile.Dispose();
                hostFile.Close();
                Form1._Form1.setTextboxLines(list);
            }
            catch(Exception ex) { } 
        }
        public void defaultSaveFile()
        {
            try
            { 
                string file = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), @"hostmanager.txt");    
                using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    fs.SetLength(0);
                    foreach (var item in Form1._Form1.getTextboxLines())
                    {
                        sw.WriteLine(item);
                    } 
                    dispose(fs, sw);
                } 
            }
            catch (Exception ex) { }
        }

        public void ballonTip(string msg)
        {
            var notification = new System.Windows.Forms.NotifyIcon()
            {
                Visible = true,
                Icon = System.Drawing.SystemIcons.Information,
                BalloonTipText = msg,
            };
            notification.ShowBalloonTip(2);
            Thread.Sleep(1000);
            notification.Dispose();
        }
        private void dispose(FileStream fs, StreamWriter sw)
        {
            sw.Close();
            sw.Dispose();
            fs.Dispose();
            fs.Close();
        }
    }
}
