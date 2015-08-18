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
using System.Text.RegularExpressions;
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

            Exit.Enabled = false;

            if (path == string.Empty)
                ServerPathTextBox.Text = "";
            else
                ServerPathTextBox.Text = path;

            pictureBox1.Location = new Point(95, 91);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            button3_Click(null, EventArgs.Empty);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ServerPathTextBox.Text == string.Empty || Directory.Exists(ServerPathTextBox.Text) == false || !File.Exists(ServerPathTextBox.Text + "\\PocketMine-MP.phar"))
            {
                MessageBox.Show("Please browse to a valid PocketMine-MP directory.");
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

                m_pocketMineProcess.StandardInput.WriteLine("bin\\php\\php.exe " + "PocketMine-MP.phar --disable-ansi %*");

                //System.Threading.Thread.Sleep(10000);

                Start.Enabled = false;
                Exit.Enabled = true;
                Restart.Enabled = true;
                properties.Enabled = false;
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

                //Regex reg = new Regex("\\u.*3[0..9]");

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
            Start.Enabled = true;
            Exit.Enabled = false;
            Restart.Enabled = false;
            properties.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ServerPathTextBox.Text = PMRunnerPro.Properties.Settings.Default.PocketMinePath;
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

                m_pocketMineProcess.StandardInput.WriteLine("bin\\php\\php.exe " + "PocketMine-MP.phar --disable-ansi %*");

                System.Threading.Thread.Sleep(10000);
                Start.Enabled = false;
                Exit.Enabled = true;
                Restart.Enabled = true;
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
                PMRunnerPro.Properties.Settings.Default.PocketMinePath = ServerPathTextBox.Text;
                PMRunnerPro.Properties.Settings.Default.Save();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }


        private void button9_Click(object sender, EventArgs e) //OPs
        {


            if (ServerPathTextBox.Text == string.Empty || Directory.Exists(ServerPathTextBox.Text) == false || !File.Exists(ServerPathTextBox.Text + "\\PocketMine-MP.phar"))
            {
                MessageBox.Show("Please browse to a valid PocketMine-MP directory.");
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
            if (ServerPathTextBox.Text == string.Empty || Directory.Exists(ServerPathTextBox.Text) == false || !File.Exists(ServerPathTextBox.Text + "\\PocketMine-MP.phar"))
            {
                MessageBox.Show("Please browse to a valid PocketMine-MP directory.");
                return;
            }
            else
            {
                string text = System.IO.File.ReadAllText(ServerPathTextBox.Text + "\\banned-players.txt");
                if (text.Equals(""))
                {
                    MessageBox.Show("No banned users");
                }
                else
                {
                    MessageBox.Show(text.Replace("# ","").Replace("|"," | "));
                }
            }
        }

        private void button8_Click(object sender, EventArgs e) //Banned IPs
        {
            if (ServerPathTextBox.Text == string.Empty || Directory.Exists(ServerPathTextBox.Text) == false || !File.Exists(ServerPathTextBox.Text + "\\PocketMine-MP.phar"))
            {
                MessageBox.Show("Please browse to a valid PocketMine-MP directory.");
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
                    MessageBox.Show(text.Replace("# ", "").Replace("|", " | "));
                }
            }
        }

        private void button7_Click(object sender, EventArgs e) //Whitelist
        {
            if (ServerPathTextBox.Text == string.Empty || Directory.Exists(ServerPathTextBox.Text) == false || !File.Exists(ServerPathTextBox.Text + "\\PocketMine-MP.phar"))
            {
                MessageBox.Show("Please browse to a valid PocketMine-MP directory.");
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
            if (ServerPathTextBox.Text == string.Empty || Directory.Exists(ServerPathTextBox.Text) == false || !File.Exists(ServerPathTextBox.Text + "\\PocketMine-MP.phar"))
            {
                MessageBox.Show("Please browse to a valid PocketMine-MP directory.");
                return;
            }
            else
            {
                string[] files = Directory.GetFiles(ServerPathTextBox.Text + "\\Plugins");
                string allFiles = string.Empty;
                foreach (string file in files)
                {
                    allFiles += Path.GetFileName(file).Substring(0, Path.GetFileName(file).Length - 5).Replace('_',' ') + Environment.NewLine;
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
            if (ServerPathTextBox.Text == string.Empty || Directory.Exists(ServerPathTextBox.Text) == false || !File.Exists(ServerPathTextBox.Text + "\\PocketMine-MP.phar"))
            {
                MessageBox.Show("Please browse to a valid PocketMine-MP directory.");
                return;
            }
            else
            {
                ServerProperties dlg = new ServerProperties(ServerPathTextBox.Text);
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //Save the new settings
                }
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
                        if (checkBox1.Checked == true)
                        {
                            if (CommandImputTextBox.Text.StartsWith("/"))
                            {
                                m_pocketMineProcess.StandardInput.WriteLine(CommandImputTextBox.Text.Remove(0, 1));
                                CommandImputTextBox.Text = null;
                            }
                            else
                            { 
                                m_pocketMineProcess.StandardInput.WriteLine("say " + CommandImputTextBox.Text);
                                CommandImputTextBox.Text = null;
                            }
                    }
                        else
                        {
                            m_pocketMineProcess.StandardInput.WriteLine(CommandImputTextBox.Text);
                            CommandImputTextBox.Text = null;
                        }
                    }
                }
                else
                {
                    CommandImputTextBox.Text = null;
                    MessageBox.Show("Server is not running");
                }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                Start.BackColor = Color.FromArgb(255, 192, 192);
                Exit.BackColor = Color.FromArgb(255, 192, 192);
                Restart.BackColor = Color.FromArgb(255, 192, 192);
                banned.BackColor = Color.FromArgb(255, 192, 192);
                bannedips.BackColor = Color.FromArgb(255, 192, 192);
                ops.BackColor = Color.FromArgb(255, 192, 192);
                whitelist.BackColor = Color.FromArgb(255, 192, 192);
                plugins.BackColor = Color.FromArgb(255, 192, 192);
                properties.BackColor = Color.FromArgb(255, 192, 192);
                browse.BackColor = Color.FromArgb(255, 192, 192);
                ConsoleTextBox.BackColor = Color.FromArgb(255, 192, 192);
                EnterButton.BackColor = Color.FromArgb(255, 192, 192);
            }
            else
            {
                Start.BackColor = Color.FromArgb(192, 192, 255);
                Exit.BackColor = Color.FromArgb(192, 192, 255);
                Restart.BackColor = Color.FromArgb(192, 192, 255);
                banned.BackColor = Color.FromArgb(192, 192, 255);
                bannedips.BackColor = Color.FromArgb(192, 192, 255);
                ops.BackColor = Color.FromArgb(192, 192, 255);
                whitelist.BackColor = Color.FromArgb(192, 192, 255);
                plugins.BackColor = Color.FromArgb(192, 192, 255);
                properties.BackColor = Color.FromArgb(192, 192, 255);
                browse.BackColor = Color.FromArgb(192, 192, 255);
                ConsoleTextBox.BackColor = Color.FromArgb(192, 192, 255);
                EnterButton.BackColor = Color.FromArgb(192, 192, 255);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            PMRunnerPro.Properties.Settings.Default.PocketMinePath = ServerPathTextBox.Text;
            PMRunnerPro.Properties.Settings.Default.Save();
        }
    }

    
}
 