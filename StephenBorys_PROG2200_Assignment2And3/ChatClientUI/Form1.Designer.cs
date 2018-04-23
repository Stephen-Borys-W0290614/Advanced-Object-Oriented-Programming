namespace ChatClientUI
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.connectMenuBarItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectMenuBarItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chatBoxArea = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.inputTextGroupBox = new System.Windows.Forms.GroupBox();
            this.convoGroupBox = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.inputTextGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.gameToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(2, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(542, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectMenuBarItem,
            this.disconnectMenuBarItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(64, 22);
            this.toolStripMenuItem1.Text = "Network";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // connectMenuBarItem
            // 
            this.connectMenuBarItem.Name = "connectMenuBarItem";
            this.connectMenuBarItem.Size = new System.Drawing.Size(133, 22);
            this.connectMenuBarItem.Text = "Connect";
            this.connectMenuBarItem.Click += new System.EventHandler(this.connectMenuBarItem_Click);
            // 
            // disconnectMenuBarItem
            // 
            this.disconnectMenuBarItem.Enabled = false;
            this.disconnectMenuBarItem.Name = "disconnectMenuBarItem";
            this.disconnectMenuBarItem.Size = new System.Drawing.Size(133, 22);
            this.disconnectMenuBarItem.Text = "Disconnect";
            this.disconnectMenuBarItem.Click += new System.EventHandler(this.disconnectMenuBarItem_Click);
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 22);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // chatBoxArea
            // 
            this.chatBoxArea.Enabled = false;
            this.chatBoxArea.Location = new System.Drawing.Point(4, 159);
            this.chatBoxArea.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.chatBoxArea.Multiline = true;
            this.chatBoxArea.Name = "chatBoxArea";
            this.chatBoxArea.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.chatBoxArea.Size = new System.Drawing.Size(486, 154);
            this.chatBoxArea.TabIndex = 3;
            this.chatBoxArea.TextChanged += new System.EventHandler(this.chatBoxArea_TextChanged);
            // 
            // sendButton
            // 
            this.sendButton.Enabled = false;
            this.sendButton.Location = new System.Drawing.Point(396, 13);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(87, 23);
            this.sendButton.TabIndex = 4;
            this.sendButton.Text = "Send Message";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // messageTextBox
            // 
            this.messageTextBox.Enabled = false;
            this.messageTextBox.Location = new System.Drawing.Point(4, 118);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(380, 20);
            this.messageTextBox.TabIndex = 5;
            // 
            // inputTextGroupBox
            // 
            this.inputTextGroupBox.Controls.Add(this.sendButton);
            this.inputTextGroupBox.Location = new System.Drawing.Point(4, 98);
            this.inputTextGroupBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.inputTextGroupBox.Name = "inputTextGroupBox";
            this.inputTextGroupBox.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.inputTextGroupBox.Size = new System.Drawing.Size(483, 42);
            this.inputTextGroupBox.TabIndex = 6;
            this.inputTextGroupBox.TabStop = false;
            this.inputTextGroupBox.Text = "Type Your Message Here.";
            // 
            // convoGroupBox
            // 
            this.convoGroupBox.Location = new System.Drawing.Point(0, 143);
            this.convoGroupBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.convoGroupBox.Name = "convoGroupBox";
            this.convoGroupBox.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.convoGroupBox.Size = new System.Drawing.Size(495, 172);
            this.convoGroupBox.TabIndex = 7;
            this.convoGroupBox.TabStop = false;
            this.convoGroupBox.Text = "Conversation";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 316);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.inputTextGroupBox);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.chatBoxArea);
            this.Controls.Add(this.convoGroupBox);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "Form1";
            this.Text = "Chat Applicaton";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing_1);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.inputTextGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem connectMenuBarItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectMenuBarItem;
        private System.Windows.Forms.TextBox chatBoxArea;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox inputTextGroupBox;
        private System.Windows.Forms.GroupBox convoGroupBox;
    }
}

