namespace ChatApp
{
    partial class MainForm
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
            this.textLog = new System.Windows.Forms.RichTextBox();
            this.groupMyClient = new System.Windows.Forms.GroupBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.textHost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textMessage = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.labelConnection = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelRemaining = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.groupMyClient.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // textLog
            // 
            this.textLog.Location = new System.Drawing.Point(1, 87);
            this.textLog.Name = "textLog";
            this.textLog.ReadOnly = true;
            this.textLog.Size = new System.Drawing.Size(420, 96);
            this.textLog.TabIndex = 0;
            this.textLog.Text = "";
            // 
            // groupMyClient
            // 
            this.groupMyClient.Controls.Add(this.buttonConnect);
            this.groupMyClient.Controls.Add(this.textHost);
            this.groupMyClient.Controls.Add(this.label1);
            this.groupMyClient.Location = new System.Drawing.Point(4, 5);
            this.groupMyClient.Name = "groupMyClient";
            this.groupMyClient.Size = new System.Drawing.Size(417, 51);
            this.groupMyClient.TabIndex = 1;
            this.groupMyClient.TabStop = false;
            this.groupMyClient.Text = "Kamarád";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(243, 15);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(61, 23);
            this.buttonConnect.TabIndex = 4;
            this.buttonConnect.Text = "Připojit";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // textHost
            // 
            this.textHost.Location = new System.Drawing.Point(130, 17);
            this.textHost.Name = "textHost";
            this.textHost.Size = new System.Drawing.Size(107, 20);
            this.textHost.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP adresa/DNS jméno:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Zpráva:";
            // 
            // textMessage
            // 
            this.textMessage.Location = new System.Drawing.Point(59, 191);
            this.textMessage.MaxLength = 500;
            this.textMessage.Name = "textMessage";
            this.textMessage.Size = new System.Drawing.Size(294, 20);
            this.textMessage.TabIndex = 3;
            this.textMessage.TextChanged += new System.EventHandler(this.textMessage_TextChanged);
            this.textMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textMessage_KeyDown);
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(360, 189);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(61, 23);
            this.buttonSend.TabIndex = 4;
            this.buttonSend.Text = "Poslat";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Záznam";
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelConnection,
            this.labelRemaining});
            this.statusBar.Location = new System.Drawing.Point(0, 216);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(426, 22);
            this.statusBar.TabIndex = 6;
            this.statusBar.Text = "statusStrip1";
            // 
            // labelConnection
            // 
            this.labelConnection.Name = "labelConnection";
            this.labelConnection.Size = new System.Drawing.Size(59, 17);
            this.labelConnection.Text = "Nepřipojen";
            // 
            // labelRemaining
            // 
            this.labelRemaining.Name = "labelRemaining";
            this.labelRemaining.Size = new System.Drawing.Size(89, 17);
            this.labelRemaining.Text = "Zbývá 500 znaků";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 238);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.textMessage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupMyClient);
            this.Controls.Add(this.textLog);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "LAN Chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupMyClient.ResumeLayout(false);
            this.groupMyClient.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox textLog;
        private System.Windows.Forms.GroupBox groupMyClient;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.TextBox textHost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textMessage;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel labelConnection;
        private System.Windows.Forms.ToolStripStatusLabel labelRemaining;
        private System.Windows.Forms.Timer timer;
    }
}

