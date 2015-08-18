namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Start = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.Restart = new System.Windows.Forms.Button();
            this.ServerPathTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.browse = new System.Windows.Forms.Button();
            this.banned = new System.Windows.Forms.Button();
            this.whitelist = new System.Windows.Forms.Button();
            this.bannedips = new System.Windows.Forms.Button();
            this.ops = new System.Windows.Forms.Button();
            this.plugins = new System.Windows.Forms.Button();
            this.properties = new System.Windows.Forms.Button();
            this.ConsoleTextBox = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.CommandImputTextBox = new System.Windows.Forms.TextBox();
            this.CMDInputTextBox = new System.Windows.Forms.Label();
            this.EnterButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Start
            // 
            resources.ApplyResources(this.Start, "Start");
            this.Start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Start.Name = "Start";
            this.Start.UseVisualStyleBackColor = false;
            this.Start.Click += new System.EventHandler(this.button1_Click);
            // 
            // Exit
            // 
            resources.ApplyResources(this.Exit, "Exit");
            this.Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Exit.Name = "Exit";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.button3_Click);
            // 
            // Restart
            // 
            resources.ApplyResources(this.Restart, "Restart");
            this.Restart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Restart.Name = "Restart";
            this.Restart.UseVisualStyleBackColor = false;
            this.Restart.Click += new System.EventHandler(this.button4_Click);
            // 
            // ServerPathTextBox
            // 
            resources.ApplyResources(this.ServerPathTextBox, "ServerPathTextBox");
            this.ServerPathTextBox.Name = "ServerPathTextBox";
            this.ServerPathTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            // 
            // browse
            // 
            resources.ApplyResources(this.browse, "browse");
            this.browse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.browse.Name = "browse";
            this.browse.UseVisualStyleBackColor = false;
            this.browse.Click += new System.EventHandler(this.button5_Click);
            // 
            // banned
            // 
            resources.ApplyResources(this.banned, "banned");
            this.banned.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.banned.Name = "banned";
            this.banned.UseVisualStyleBackColor = false;
            this.banned.Click += new System.EventHandler(this.button2_Click);
            // 
            // whitelist
            // 
            resources.ApplyResources(this.whitelist, "whitelist");
            this.whitelist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.whitelist.Name = "whitelist";
            this.whitelist.UseVisualStyleBackColor = false;
            this.whitelist.Click += new System.EventHandler(this.button7_Click);
            // 
            // bannedips
            // 
            resources.ApplyResources(this.bannedips, "bannedips");
            this.bannedips.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bannedips.Name = "bannedips";
            this.bannedips.UseVisualStyleBackColor = false;
            this.bannedips.Click += new System.EventHandler(this.button8_Click);
            // 
            // ops
            // 
            resources.ApplyResources(this.ops, "ops");
            this.ops.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ops.Name = "ops";
            this.ops.UseVisualStyleBackColor = false;
            this.ops.Click += new System.EventHandler(this.button9_Click);
            // 
            // plugins
            // 
            resources.ApplyResources(this.plugins, "plugins");
            this.plugins.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.plugins.Name = "plugins";
            this.plugins.UseVisualStyleBackColor = false;
            this.plugins.Click += new System.EventHandler(this.button10_Click);
            // 
            // properties
            // 
            resources.ApplyResources(this.properties, "properties");
            this.properties.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.properties.Name = "properties";
            this.properties.UseVisualStyleBackColor = false;
            this.properties.Click += new System.EventHandler(this.button6_Click);
            // 
            // ConsoleTextBox
            // 
            resources.ApplyResources(this.ConsoleTextBox, "ConsoleTextBox");
            this.ConsoleTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ConsoleTextBox.Name = "ConsoleTextBox";
            this.ConsoleTextBox.ReadOnly = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // CommandImputTextBox
            // 
            resources.ApplyResources(this.CommandImputTextBox, "CommandImputTextBox");
            this.CommandImputTextBox.Name = "CommandImputTextBox";
            // 
            // CMDInputTextBox
            // 
            resources.ApplyResources(this.CMDInputTextBox, "CMDInputTextBox");
            this.CMDInputTextBox.BackColor = System.Drawing.Color.Transparent;
            this.CMDInputTextBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CMDInputTextBox.Name = "CMDInputTextBox";
            // 
            // EnterButton
            // 
            resources.ApplyResources(this.EnterButton, "EnterButton");
            this.EnterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.EnterButton.Name = "EnterButton";
            this.EnterButton.UseVisualStyleBackColor = false;
            this.EnterButton.Click += new System.EventHandler(this.button11_Click);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::PMRunnerPro.Properties.Resources.PocketMine_h;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AcceptButton = this.EnterButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.EnterButton);
            this.Controls.Add(this.CMDInputTextBox);
            this.Controls.Add(this.CommandImputTextBox);
            this.Controls.Add(this.ConsoleTextBox);
            this.Controls.Add(this.properties);
            this.Controls.Add(this.plugins);
            this.Controls.Add(this.ops);
            this.Controls.Add(this.bannedips);
            this.Controls.Add(this.whitelist);
            this.Controls.Add(this.banned);
            this.Controls.Add(this.browse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ServerPathTextBox);
            this.Controls.Add(this.Restart);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Start);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button Restart;
        private System.Windows.Forms.TextBox ServerPathTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.Button banned;
        private System.Windows.Forms.Button whitelist;
        private System.Windows.Forms.Button bannedips;
        private System.Windows.Forms.Button ops;
        private System.Windows.Forms.Button plugins;
        private System.Windows.Forms.Button properties;
        private System.Windows.Forms.TextBox ConsoleTextBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox CommandImputTextBox;
        private System.Windows.Forms.Label CMDInputTextBox;
        private System.Windows.Forms.Button EnterButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

