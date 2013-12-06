using Microsoft.Win32;
using PocketMineRunner;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        List<string> m_ConsoleLines = new List<string>();
        bool m_UpdateConsoleLines = false;

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
                ServerPathTextBox.Text = Application.StartupPath;
            else
                ServerPathTextBox.Text = path;

            pictureBox1.Location = new Point(213, 33);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            button3_Click(null, EventArgs.Empty);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ServerPathTextBox.Text == string.Empty || Directory.Exists(ServerPathTextBox.Text) == false)
            {
                MessageBox.Show("Please browse to a valid PHP working directory.");
                return;
            }

            if (m_pocketMineProcess == null)
            {
                Cursor = Cursors.WaitCursor;
                m_pocketMineProcess = new Process();
                m_pocketMineProcess.StartInfo.CreateNoWindow = true;
                m_pocketMineProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                m_pocketMineProcess.StartInfo.WorkingDirectory = ServerPathTextBox.Text;
                m_pocketMineProcess.StartInfo.FileName = "cmd.exe";
                /////m_pocketMineProcess.StartInfo.FileName = "bin\\php\\php.exe";
                /////m_pocketMineProcess.StartInfo.Arguments = "PocketMine-MP.php --enable-ansi %*";
                //m_pocketMineProcess.StartInfo.Arguments = @"-o Columns=88 -o Rows=32 -o AllowBlinking=0 -o FontQuality=3 -o CursorType=0 -o CursorBlinks=1 -h error -t 'PocketMine-M' -i pocketmine.ico -w max php\php.exe -d enable_dl=On ..\PocketMine-MP.php --enable-ansi %*";
                m_pocketMineProcess.StartInfo.UseShellExecute = false;
                m_pocketMineProcess.StartInfo.RedirectStandardInput = true;
                m_pocketMineProcess.StartInfo.RedirectStandardOutput = true;

                m_pocketMineProcess.OutputDataReceived += m_pocketMineProcess_OutputDataReceived;

                //m_pocketMineProcess.StartInfo.EnvironmentVariables["PATH"] = m_pocketMineProcess.StartInfo.EnvironmentVariables["PATH"].ToString().Replace(@"\\", @"\");

                // Manipulate dictionary...

                try
                {
                    m_pocketMineProcess.Start();
                }
                catch(Exception err)
                {
                    MessageBox.Show("This is not a valid PockeMine directory.");
                    return;
                }

                m_pocketMineProcess.BeginOutputReadLine();

                //System.Threading.Thread.Sleep(10000);

                m_pocketMineProcess.StandardInput.WriteLine("bin\\php\\php.exe " + "PocketMine-MP.php --enable-ansi %*");

                System.Threading.Thread.Sleep(10000);

                button1.Enabled = false;
                button3.Enabled = true;
                button4.Enabled = true;
                UseWaitCursor = false;
                Cursor = Cursors.Arrow;
            }

        }

        void m_pocketMineProcess_OutputDataReceived(object sender, DataReceivedEventArgs outLine)
        {
            if (outLine.Data != null)
            {
                m_UpdateConsoleLines = true;
                m_ConsoleLines.Add(outLine.Data);
                Console.WriteLine(outLine.Data);
            }
        }

        private Process m_pocketMineProcess;


        [DllImport("User32.dll")]
        static extern int SetForegroundWindow(IntPtr point);
        
        private void button3_Click(object sender, EventArgs e)
        {
            if (m_pocketMineProcess != null)
            {
                m_pocketMineProcess.StandardInput.WriteLine("Stop");
                System.Threading.Thread.Sleep(2000);
                m_pocketMineProcess.StandardInput.WriteLine("Exit");
                m_pocketMineProcess.OutputDataReceived -= m_pocketMineProcess_OutputDataReceived;
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
                m_pocketMineProcess.StandardInput.WriteLine("Stop");
                System.Threading.Thread.Sleep(2000);
                m_pocketMineProcess.StandardInput.WriteLine("Exit");
                m_pocketMineProcess.OutputDataReceived -= m_pocketMineProcess_OutputDataReceived;
                m_pocketMineProcess = null;
                Cursor = Cursors.WaitCursor;
                m_pocketMineProcess = new Process();
                m_pocketMineProcess.StartInfo.CreateNoWindow = true;
                m_pocketMineProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                m_pocketMineProcess.StartInfo.WorkingDirectory = ServerPathTextBox.Text;
                m_pocketMineProcess.StartInfo.FileName = "cmd.exe";
                /////m_pocketMineProcess.StartInfo.FileName = "bin\\php\\php.exe";
                /////m_pocketMineProcess.StartInfo.Arguments = "PocketMine-MP.php --enable-ansi %*";
                //m_pocketMineProcess.StartInfo.Arguments = @"-o Columns=88 -o Rows=32 -o AllowBlinking=0 -o FontQuality=3 -o CursorType=0 -o CursorBlinks=1 -h error -t 'PocketMine-M' -i pocketmine.ico -w max php\php.exe -d enable_dl=On ..\PocketMine-MP.php --enable-ansi %*";
                m_pocketMineProcess.StartInfo.UseShellExecute = false;
                m_pocketMineProcess.StartInfo.RedirectStandardInput = true;
                m_pocketMineProcess.StartInfo.RedirectStandardOutput = true;

                m_pocketMineProcess.OutputDataReceived += m_pocketMineProcess_OutputDataReceived;

                //m_pocketMineProcess.StartInfo.EnvironmentVariables["PATH"] = m_pocketMineProcess.StartInfo.EnvironmentVariables["PATH"].ToString().Replace(@"\\", @"\");

                // Manipulate dictionary...

                try
                {
                    m_pocketMineProcess.Start();
                }
                catch (Exception err)
                {
                    MessageBox.Show("This is not a valid PockeMine directory.");
                    return;
                }

                m_pocketMineProcess.BeginOutputReadLine();

                //System.Threading.Thread.Sleep(10000);

                m_pocketMineProcess.StandardInput.WriteLine("bin\\php\\php.exe " + "PocketMine-MP.php --enable-ansi %*");

                System.Threading.Thread.Sleep(10000);
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
            dlg.SelectedPath = ServerPathTextBox.Text;
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ServerPathTextBox.Text = dlg.SelectedPath;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Lucas", true);
            if (key == null)
            {
                key = Registry.CurrentUser.CreateSubKey("Software\\Lucas", RegistryKeyPermissionCheck.ReadWriteSubTree);
            }

            key.SetValue("PocketMine Path", ServerPathTextBox.Text);
        }


        private void button9_Click(object sender, EventArgs e) //OPs
        {
            if (ServerPathTextBox.Text == string.Empty || Directory.Exists(ServerPathTextBox.Text) == false)
            {
                MessageBox.Show("Please browse to a valid PHP working directory.");
                return;
            }
            else
            {
                string text = System.IO.File.ReadAllText(ServerPathTextBox.Text + "\\ops.txt");
                if (text.Equals(""))
                {
                    MessageBox.Show("No OP users");
                }
                else
                {
                    MessageBox.Show(text);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) //Banned
        {
            if (ServerPathTextBox.Text == string.Empty || Directory.Exists(ServerPathTextBox.Text) == false)
            {
                MessageBox.Show("Please browse to a valid PHP working directory.");
                return;
            }
            else
            {
                string text = System.IO.File.ReadAllText(ServerPathTextBox.Text + "\\banned.txt");
                if (text.Equals(""))
                {
                    MessageBox.Show("No banned users");
                }
                else
                {
                    MessageBox.Show(text);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e) //Banned IPs
        {
            if (ServerPathTextBox.Text == string.Empty || Directory.Exists(ServerPathTextBox.Text) == false)
            {
                MessageBox.Show("Please browse to a valid PHP working directory.");
                return;
            }
            else
            {
                string text = System.IO.File.ReadAllText(ServerPathTextBox.Text + "\\banned-ips.txt");
                if (text.Equals(""))
                {
                    MessageBox.Show("No banned ips");
                }
                else
                {
                    MessageBox.Show(text);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e) //Whitelist
        {
            if (ServerPathTextBox.Text == string.Empty || Directory.Exists(ServerPathTextBox.Text) == false)
            {
                MessageBox.Show("Please browse to a valid PHP working directory.");
                return;
            }
            else
            {
                string text = System.IO.File.ReadAllText(ServerPathTextBox.Text + "\\white-list.txt");
                if (text.Equals(""))
                {
                    MessageBox.Show("No whitelisted users");
                }
                else
                {
                    MessageBox.Show(text);
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (ServerPathTextBox.Text == string.Empty || Directory.Exists(ServerPathTextBox.Text) == false)
            {
                MessageBox.Show("Please browse to a valid PHP working directory.");
                return;
            }
            else
            {
                string[] files = Directory.GetFiles(ServerPathTextBox.Text + "\\Plugins");
                string allFiles = string.Empty;
                foreach (string file in files)
                {
                    allFiles += Path.GetFileName(file).Substring(0, Path.GetFileName(file).Length - 4) + Environment.NewLine;
                }
                if (allFiles == string.Empty)
                {
                    allFiles = "No Plugins Found";
                }
                else
                {
                    MessageBox.Show(allFiles);
                }
            }
        }



        private void button6_Click(object sender, EventArgs e)
        {
            ServerProperties dlg = new ServerProperties(ServerPathTextBox.Text);
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //Save the new settings
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (m_UpdateConsoleLines)
            {
                ConsoleTextBox.Lines = m_ConsoleLines.ToArray();
                ConsoleTextBox.SelectionStart = ConsoleTextBox.Text.Length;
                ConsoleTextBox.ScrollToCaret();
                m_UpdateConsoleLines = false;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
                if (m_pocketMineProcess != null)
                {
                    if (CommandImputTextBox.Text == "stop" || CommandImputTextBox.Text == "Stop")
                    {
                        MessageBox.Show("Please use the Exit button");
                        CommandImputTextBox.Text = null;
                    }
                    else
                    {
                        m_pocketMineProcess.StandardInput.WriteLine(CommandImputTextBox.Text);
                        CommandImputTextBox.Text = null;
                    }
                }
                else
                {
                    CommandImputTextBox.Text = null;
                    MessageBox.Show("Server is not running");
                }
        }

        }

    
}
 