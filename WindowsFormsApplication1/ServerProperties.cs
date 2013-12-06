using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PocketMineRunner
{
    public partial class ServerProperties : Form
    {
        private string m_Path = string.Empty;
        private string[] m_arrLines;

        private string GetControlName(string key)
        {
            return key.Replace('.', '_').Replace('-', '_');
        }

        public ServerProperties(string basePath)
        {
            InitializeComponent();
            //test code
            string path = basePath + @"\server.properties";

            m_Path = path;
            m_arrLines = File.ReadAllLines(path);

            foreach (string line in m_arrLines)
            {
                int index = line.IndexOf('=');
                if (index > 0)
                {
                    string key = line.Substring(0, index);
                    string value = line.Substring(index + 1);
                    Control[] control = Controls.Find(GetControlName(key),true);
                    
                    if (control.GetLength(0) > 0)
                    {
                        CheckBox checkBox = control[0] as CheckBox;
                        if (checkBox != null)
                        {
                            if (value == "off")
                                checkBox.Checked = false;
                            else
                                checkBox.Checked = true;
                        }
                        else
                        {
                            control[0].Text = value;
                        }
                    }

                }
            }
        }

        private void Ok_Button_Click(object sender, EventArgs e)
        {
            string[] newValues = new string[m_arrLines.GetLength(0)];
            int lineIndex = 0;

            foreach(string line in m_arrLines)
            {
                int index = line.IndexOf('=');
                if (index > 0)
                {
                    string key = line.Substring(0, index);
                    string value = line.Substring(index + 1);
                    Control[] control = Controls.Find(GetControlName(key), true);

                    if (control.GetLength(0) > 0)
                    {
                        CheckBox checkBox = control[0] as CheckBox;
                        if (checkBox != null)
                        {
                            if (checkBox.Checked)
                                newValues[lineIndex] = key + "=" + "on";
                            else
                                newValues[lineIndex] = key + "=" + "off";
                        }
                        else
                        {
                            newValues[lineIndex] = key + "=" + control[0].Text;
                        }
                    }
                    else
                    {
                        newValues[lineIndex] = line;
                    }
                }
                else
                {
                    newValues[lineIndex] = line;
                }

                lineIndex++;
            }

            File.WriteAllLines(m_Path, newValues);
            this.Close();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
