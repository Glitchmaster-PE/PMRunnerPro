using Microsoft.Win32;
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

            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Lucas");
            if (key == null)
            {
                key = Registry.CurrentUser.CreateSubKey("Software\\Lucas");
            }

            string path = string.Empty;
            object objPath = key.GetValue("PocketMine Path");
            if (objPath != null)
                path = objPath.ToString();

            button3.Enabled = false;

            if (path == string.Empty)
                textBox1.Text = Application.StartupPath;
            else
                textBox1.Text = path;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty || Directory.Exists(textBox1.Text) == false)
            {
                MessageBox.Show("Please browse to a valid PHP working directory.");
                return;
            }

            if (m_pocketMineProcess == null)
            {
                Cursor = Cursors.WaitCursor;
                m_pocketMineProcess = new Process();
                m_pocketMineProcess.StartInfo.CreateNoWindow = true;
                m_pocketMineProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized;
                m_pocketMineProcess.StartInfo.WorkingDirectory = textBox1.Text;
                m_pocketMineProcess.StartInfo.FileName = "bin\\php\\php.exe";
                m_pocketMineProcess.StartInfo.Arguments = @"PocketMine-MP.php --enable-ansi %*";
                //m_pocketMineProcess.StartInfo.Arguments = @"-o Columns=88 -o Rows=32 -o AllowBlinking=0 -o FontQuality=3 -o CursorType=0 -o CursorBlinks=1 -h error -t 'PocketMine-M' -i pocketmine.ico -w max php\php.exe -d enable_dl=On ..\PocketMine-MP.php --enable-ansi %*";
                //m_pocketMineProcess.StartInfo.UseShellExecute = false;
                //m_pocketMineProcess.StartInfo.RedirectStandardInput = true;
                //m_pocketMineProcess.StartInfo.RedirectStandardOutput = true;

                try
                {
                    m_pocketMineProcess.Start();
                }
                catch(Exception)
                {
                    MessageBox.Show("This is not a valid PockeMine directory.");
                    return;
                }

                System.Threading.Thread.Sleep(10000);


                //Console.WriteLine(m_pocketMineProcess.StandardOutput.ReadToEnd());


                button1.Enabled = false;
                button3.Enabled = true;
                button4.Enabled = true;
                UseWaitCursor = false;
                Cursor = Cursors.Arrow;
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
                m_pocketMineProcess.StartInfo.WorkingDirectory = textBox1.Text; // @"C:\Users\Lucas\Documents\Visual Studio 2013\Projects\WindowsFormsApplication1\WindowsFormsApplication1\PocketMine-MP";
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
                button3.Enabled = true;
                button4.Enabled = true;
                UseWaitCursor = false;
                Cursor = Cursors.Arrow;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.Description = "Browse to PocketMine Path";
            dlg.SelectedPath = textBox1.Text;
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = dlg.SelectedPath;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Lucas", true);
            if (key == null)
            {
                key = Registry.CurrentUser.CreateSubKey("Software\\Lucas", RegistryKeyPermissionCheck.ReadWriteSubTree);
            }

            key.SetValue("PocketMine Path", textBox1.Text);
        }
        }

    
}
 