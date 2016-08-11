/**
 * 
 * Michael Lutch
 * CSCD 371, Fall 2013
 * Assignment 3: Drawing
 * 
 * Tic-Tac-Toe
 * 
**/

namespace TicTacToe
{
    partial class TicTacToe
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onePlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twoPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onePlayerButton = new System.Windows.Forms.RadioButton();
            this.twoPlayerButton = new System.Windows.Forms.RadioButton();
            this.player_1 = new System.Windows.Forms.Label();
            this.player_2 = new System.Windows.Forms.Label();
            this.player_1_Score = new System.Windows.Forms.RichTextBox();
            this.player_2_Score = new System.Windows.Forms.RichTextBox();
            this.turn_Display = new System.Windows.Forms.RichTextBox();
            this.roll_Button = new System.Windows.Forms.Button();
            this.quit_Button = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(780, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.quitGameToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // quitGameToolStripMenuItem
            // 
            this.quitGameToolStripMenuItem.Name = "quitGameToolStripMenuItem";
            this.quitGameToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.quitGameToolStripMenuItem.Text = "Quit Game";
            this.quitGameToolStripMenuItem.Click += new System.EventHandler(this.quitGameToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.onePlayerToolStripMenuItem,
            this.twoPlayerToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // onePlayerToolStripMenuItem
            // 
            this.onePlayerToolStripMenuItem.Name = "onePlayerToolStripMenuItem";
            this.onePlayerToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.onePlayerToolStripMenuItem.Text = "1-Player";
            this.onePlayerToolStripMenuItem.Click += new System.EventHandler(this.onePlayerToolStripMenuItem_Click);
            // 
            // twoPlayerToolStripMenuItem
            // 
            this.twoPlayerToolStripMenuItem.Name = "twoPlayerToolStripMenuItem";
            this.twoPlayerToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.twoPlayerToolStripMenuItem.Text = "2-Player";
            this.twoPlayerToolStripMenuItem.Click += new System.EventHandler(this.twoPlayerToolStripMenuItem_Click);
            // 
            // onePlayerButton
            // 
            this.onePlayerButton.AutoSize = true;
            this.onePlayerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onePlayerButton.Location = new System.Drawing.Point(586, 145);
            this.onePlayerButton.Name = "onePlayerButton";
            this.onePlayerButton.Size = new System.Drawing.Size(92, 24);
            this.onePlayerButton.TabIndex = 2;
            this.onePlayerButton.TabStop = true;
            this.onePlayerButton.Text = "1-Player";
            this.onePlayerButton.UseVisualStyleBackColor = true;
            this.onePlayerButton.CheckedChanged += new System.EventHandler(this.onePlayerButton_CheckedChanged);
            // 
            // twoPlayerButton
            // 
            this.twoPlayerButton.AutoSize = true;
            this.twoPlayerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.twoPlayerButton.Location = new System.Drawing.Point(586, 175);
            this.twoPlayerButton.Name = "twoPlayerButton";
            this.twoPlayerButton.Size = new System.Drawing.Size(92, 24);
            this.twoPlayerButton.TabIndex = 3;
            this.twoPlayerButton.TabStop = true;
            this.twoPlayerButton.Text = "2-Player";
            this.twoPlayerButton.UseVisualStyleBackColor = true;
            this.twoPlayerButton.CheckedChanged += new System.EventHandler(this.twoPlayerButton_CheckedChanged);
            // 
            // player_1
            // 
            this.player_1.AutoSize = true;
            this.player_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player_1.Location = new System.Drawing.Point(486, 37);
            this.player_1.Name = "player_1";
            this.player_1.Size = new System.Drawing.Size(110, 20);
            this.player_1.TabIndex = 4;
            this.player_1.Text = "Player: 1 = X";
            // 
            // player_2
            // 
            this.player_2.AutoSize = true;
            this.player_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player_2.Location = new System.Drawing.Point(662, 37);
            this.player_2.Name = "player_2";
            this.player_2.Size = new System.Drawing.Size(111, 20);
            this.player_2.TabIndex = 5;
            this.player_2.Text = "Player: 2 = O";
            // 
            // player_1_Score
            // 
            this.player_1_Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player_1_Score.Location = new System.Drawing.Point(490, 60);
            this.player_1_Score.Name = "player_1_Score";
            this.player_1_Score.ReadOnly = true;
            this.player_1_Score.Size = new System.Drawing.Size(106, 79);
            this.player_1_Score.TabIndex = 6;
            this.player_1_Score.Text = "0";
            // 
            // player_2_Score
            // 
            this.player_2_Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player_2_Score.Location = new System.Drawing.Point(662, 60);
            this.player_2_Score.Name = "player_2_Score";
            this.player_2_Score.ReadOnly = true;
            this.player_2_Score.Size = new System.Drawing.Size(106, 79);
            this.player_2_Score.TabIndex = 7;
            this.player_2_Score.Text = "0";
            // 
            // turn_Display
            // 
            this.turn_Display.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turn_Display.Location = new System.Drawing.Point(499, 244);
            this.turn_Display.Name = "turn_Display";
            this.turn_Display.ReadOnly = true;
            this.turn_Display.Size = new System.Drawing.Size(250, 54);
            this.turn_Display.TabIndex = 8;
            this.turn_Display.Text = "";
            // 
            // roll_Button
            // 
            this.roll_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roll_Button.Location = new System.Drawing.Point(540, 205);
            this.roll_Button.Name = "roll_Button";
            this.roll_Button.Size = new System.Drawing.Size(176, 33);
            this.roll_Button.TabIndex = 9;
            this.roll_Button.Text = "Coin Toss";
            this.roll_Button.UseVisualStyleBackColor = true;
            this.roll_Button.Click += new System.EventHandler(this.roll_Button_Click);
            // 
            // quit_Button
            // 
            this.quit_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quit_Button.Location = new System.Drawing.Point(540, 365);
            this.quit_Button.Name = "quit_Button";
            this.quit_Button.Size = new System.Drawing.Size(176, 33);
            this.quit_Button.TabIndex = 10;
            this.quit_Button.Text = "Quit Current Game";
            this.quit_Button.UseVisualStyleBackColor = true;
            this.quit_Button.Click += new System.EventHandler(this.quit_Button_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetButton.Location = new System.Drawing.Point(586, 326);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(92, 33);
            this.ResetButton.TabIndex = 11;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(540, 453);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(176, 33);
            this.exitButton.TabIndex = 12;
            this.exitButton.Text = "Exit Game";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // TicTacToe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gold;
            this.ClientSize = new System.Drawing.Size(780, 498);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.quit_Button);
            this.Controls.Add(this.roll_Button);
            this.Controls.Add(this.turn_Display);
            this.Controls.Add(this.player_2_Score);
            this.Controls.Add(this.player_1_Score);
            this.Controls.Add(this.player_2);
            this.Controls.Add(this.player_1);
            this.Controls.Add(this.twoPlayerButton);
            this.Controls.Add(this.onePlayerButton);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "TicTacToe";
            this.Text = "Tic-Tac-Toe";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.RadioButton onePlayerButton;
        private System.Windows.Forms.RadioButton twoPlayerButton;
        private System.Windows.Forms.Label player_1;
        private System.Windows.Forms.Label player_2;
        private System.Windows.Forms.RichTextBox player_1_Score;
        private System.Windows.Forms.RichTextBox player_2_Score;
        private System.Windows.Forms.RichTextBox turn_Display;
        private System.Windows.Forms.Button roll_Button;
        private System.Windows.Forms.Button quit_Button;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onePlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem twoPlayerToolStripMenuItem;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

