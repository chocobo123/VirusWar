namespace VirusWar
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.singleplayerModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twoplayerModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.player1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.player2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchDepthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchDepth1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchDepth2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchDepth3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchDepth4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchDepth5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameInstructionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instructionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(144, 66);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(321, 321);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 374);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 262);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "label5";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.toolStripMenuItem1,
            this.gameInstructionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(559, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.cancelToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.gameToolStripMenuItem.Text = "GAME";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.startToolStripMenuItem.Text = "start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.cancelToolStripMenuItem.Text = "cancel";
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(105, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.startGameToolStripMenuItem,
            this.searchDepthToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(71, 20);
            this.toolStripMenuItem1.Text = "SETTINGS";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.singleplayerModeToolStripMenuItem,
            this.twoplayerModeToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(154, 22);
            this.toolStripMenuItem2.Text = "player mode";
            // 
            // singleplayerModeToolStripMenuItem
            // 
            this.singleplayerModeToolStripMenuItem.Checked = true;
            this.singleplayerModeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.singleplayerModeToolStripMenuItem.Name = "singleplayerModeToolStripMenuItem";
            this.singleplayerModeToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.singleplayerModeToolStripMenuItem.Text = "singleplayer mode";
            this.singleplayerModeToolStripMenuItem.Click += new System.EventHandler(this.singleplayerModeToolStripMenuItem_Click);
            // 
            // twoplayerModeToolStripMenuItem
            // 
            this.twoplayerModeToolStripMenuItem.Name = "twoplayerModeToolStripMenuItem";
            this.twoplayerModeToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.twoplayerModeToolStripMenuItem.Text = "twoplayer mode";
            this.twoplayerModeToolStripMenuItem.Click += new System.EventHandler(this.twoplayerModeToolStripMenuItem_Click);
            // 
            // startGameToolStripMenuItem
            // 
            this.startGameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.player1ToolStripMenuItem,
            this.player2ToolStripMenuItem});
            this.startGameToolStripMenuItem.Name = "startGameToolStripMenuItem";
            this.startGameToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.startGameToolStripMenuItem.Text = "open the game";
            // 
            // player1ToolStripMenuItem
            // 
            this.player1ToolStripMenuItem.Checked = true;
            this.player1ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.player1ToolStripMenuItem.Name = "player1ToolStripMenuItem";
            this.player1ToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.player1ToolStripMenuItem.Text = "player 1";
            this.player1ToolStripMenuItem.Click += new System.EventHandler(this.player1ToolStripMenuItem_Click);
            // 
            // player2ToolStripMenuItem
            // 
            this.player2ToolStripMenuItem.Name = "player2ToolStripMenuItem";
            this.player2ToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.player2ToolStripMenuItem.Text = "player 2/ computer";
            this.player2ToolStripMenuItem.Click += new System.EventHandler(this.player2ToolStripMenuItem_Click);
            // 
            // searchDepthToolStripMenuItem
            // 
            this.searchDepthToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchDepth1ToolStripMenuItem,
            this.searchDepth2ToolStripMenuItem,
            this.searchDepth3ToolStripMenuItem,
            this.searchDepth4ToolStripMenuItem,
            this.searchDepth5ToolStripMenuItem});
            this.searchDepthToolStripMenuItem.Name = "searchDepthToolStripMenuItem";
            this.searchDepthToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.searchDepthToolStripMenuItem.Text = "search depth";
            // 
            // searchDepth1ToolStripMenuItem
            // 
            this.searchDepth1ToolStripMenuItem.Name = "searchDepth1ToolStripMenuItem";
            this.searchDepth1ToolStripMenuItem.Size = new System.Drawing.Size(80, 22);
            this.searchDepth1ToolStripMenuItem.Text = "1";
            this.searchDepth1ToolStripMenuItem.Click += new System.EventHandler(this.searchDepth1ToolStripMenuItem_Click);
            // 
            // searchDepth2ToolStripMenuItem
            // 
            this.searchDepth2ToolStripMenuItem.Checked = true;
            this.searchDepth2ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.searchDepth2ToolStripMenuItem.Name = "searchDepth2ToolStripMenuItem";
            this.searchDepth2ToolStripMenuItem.Size = new System.Drawing.Size(80, 22);
            this.searchDepth2ToolStripMenuItem.Text = "2";
            this.searchDepth2ToolStripMenuItem.Click += new System.EventHandler(this.searchDepth2ToolStripMenuItem_Click);
            // 
            // searchDepth3ToolStripMenuItem
            // 
            this.searchDepth3ToolStripMenuItem.Name = "searchDepth3ToolStripMenuItem";
            this.searchDepth3ToolStripMenuItem.Size = new System.Drawing.Size(80, 22);
            this.searchDepth3ToolStripMenuItem.Text = "3";
            this.searchDepth3ToolStripMenuItem.Click += new System.EventHandler(this.searchDepth3ToolStripMenuItem_Click);
            // 
            // searchDepth4ToolStripMenuItem
            // 
            this.searchDepth4ToolStripMenuItem.Name = "searchDepth4ToolStripMenuItem";
            this.searchDepth4ToolStripMenuItem.Size = new System.Drawing.Size(80, 22);
            this.searchDepth4ToolStripMenuItem.Text = "4";
            this.searchDepth4ToolStripMenuItem.Click += new System.EventHandler(this.searchDepth4ToolStripMenuItem_Click);
            // 
            // searchDepth5ToolStripMenuItem
            // 
            this.searchDepth5ToolStripMenuItem.Name = "searchDepth5ToolStripMenuItem";
            this.searchDepth5ToolStripMenuItem.Size = new System.Drawing.Size(80, 22);
            this.searchDepth5ToolStripMenuItem.Text = "5";
            this.searchDepth5ToolStripMenuItem.Click += new System.EventHandler(this.searchDepth5ToolStripMenuItem_Click);
            // 
            // gameInstructionsToolStripMenuItem
            // 
            this.gameInstructionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.instructionsToolStripMenuItem,
            this.abotToolStripMenuItem});
            this.gameInstructionsToolStripMenuItem.Name = "gameInstructionsToolStripMenuItem";
            this.gameInstructionsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.gameInstructionsToolStripMenuItem.Text = "HELP";
            // 
            // instructionsToolStripMenuItem
            // 
            this.instructionsToolStripMenuItem.Name = "instructionsToolStripMenuItem";
            this.instructionsToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.instructionsToolStripMenuItem.Text = "Instructions";
            this.instructionsToolStripMenuItem.Click += new System.EventHandler(this.instructionsToolStripMenuItem_Click);
            // 
            // abotToolStripMenuItem
            // 
            this.abotToolStripMenuItem.Name = "abotToolStripMenuItem";
            this.abotToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.abotToolStripMenuItem.Text = "About";
            this.abotToolStripMenuItem.Click += new System.EventHandler(this.abotToolStripMenuItem_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(200, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 42);
            this.label6.TabIndex = 13;
            this.label6.Text = "label6";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 443);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "VirusWar";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem gameInstructionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem singleplayerModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem twoplayerModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem player1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem player2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchDepthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchDepth1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchDepth2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchDepth3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchDepth4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchDepth5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem instructionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label6;

    }
}

