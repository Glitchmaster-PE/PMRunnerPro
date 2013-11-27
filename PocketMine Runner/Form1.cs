using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button3.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (m_pocketMineProcess == null)
            {
                Cursor = Cursors.WaitCursor;
                m_pocketMineProcess = new Process();
                m_pocketMineProcess.StartInfo.CreateNoWindow = true;
                m_pocketMineProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized;
                m_pocketMineProcess.StartInfo.WorkingDirectory = @"C:\Users\Lucas\Documents\Visual Studio 2013\Projects\WindowsFormsApplication1\WindowsFormsApplication1\PocketMine-MP";
                m_pocketMineProcess.StartInfo.FileName = "bin\\php\\php.exe";
                m_pocketMineProcess.StartInfo.Arguments = @"PocketMine-MP.php --enable-ansi %*";
                //m_pocketMineProcess.StartInfo.Arguments = @"-o Columns=88 -o Rows=32 -o AllowBlinking=0 -o FontQuality=3 -o CursorType=0 -o CursorBlinks=1 -h error -t 'PocketMine-M' -i pocketmine.ico -w max php\php.exe -d enable_dl=On ..\PocketMine-MP.php --enable-ansi %*";
                //m_pocketMineProcess.StartInfo.UseShellExecute = false;
                //m_pocketMineProcess.StartInfo.RedirectStandardInput = true;
                //m_pocketMineProcess.StartInfo.RedirectStandardOutput = true;

                m_pocketMineProcess.Start();

                System.Threading.Thread.Sleep(10000);


                //Console.WriteLine(m_pocketMineProcess.StandardOutput.ReadToEnd());


                button1.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                UseWaitCursor = false;
                Cursor = Cursors.Arrow;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (m_pocketMineProcess != null)
            {
                m_pocketMineProcess.Kill();
                m_pocketMineProcess = null;
                button1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = false;
            }
        }

        private Process m_pocketMineProcess;


        [DllImport("User32.dll")]
        static extern int SetForegroundWindow(IntPtr point);
        
        private void button3_Click(object sender, EventArgs e)
        {
            if (m_pocketMineProcess != null)
            {
                IntPtr pointer = m_pocketMineProcess.MainWindowHandle;
                int status = SetForegroundWindow(pointer);
                SendKeys.Send("Stop" + Environment.NewLine);
                m_pocketMineProcess = null;
            }
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (m_pocketMineProcess != null)
            {
                IntPtr pointer = m_pocketMineProcess.MainWindowHandle;
                int status = SetForegroundWindow(pointer);
                SendKeys.Send("Stop" + Environment.NewLine);
                m_pocketMineProcess = null;
                System.Threading.Thread.Sleep(1);
                Cursor = Cursors.WaitCursor;
                m_pocketMineProcess = new Process();
                m_pocketMineProcess.StartInfo.CreateNoWindow = true;
                m_pocketMineProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized;
                m_pocketMineProcess.StartInfo.WorkingDirectory = @"C:\Users\Lucas\Documents\Visual Studio 2013\Projects\WindowsFormsApplication1\WindowsFormsApplication1\PocketMine-MP";
                m_pocketMineProcess.StartInfo.FileName = "bin\\php\\php.exe";
                m_pocketMineProcess.StartInfo.Arguments = @"PocketMine-MP.php --enable-ansi %*";
                //m_pocketMineProcess.StartInfo.Arguments = @"-o Columns=88 -o Rows=32 -o AllowBlinking=0 -o FontQuality=3 -o CursorType=0 -o CursorBlinks=1 -h error -t 'PocketMine-M' -i pocketmine.ico -w max php\php.exe -d enable_dl=On ..\PocketMine-MP.php --enable-ansi %*";
                //m_pocketMineProcess.StartInfo.UseShellExecute = false;
                //m_pocketMineProcess.StartInfo.RedirectStandardInput = true;
                //m_pocketMineProcess.StartInfo.RedirectStandardOutput = true;

                m_pocketMineProcess.Start();

                System.Threading.Thread.Sleep(10000);


                //Console.WriteLine(m_pocketMineProcess.StandardOutput.ReadToEnd());


                button1.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                UseWaitCursor = false;
                Cursor = Cursors.Arrow;
            }

        }
        }

    
}
 