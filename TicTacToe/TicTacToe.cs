/**
 * 
 * Michael Lutch
 * CSCD 371, Fall 2013
 * Assignment 3: Drawing
 * 
 * Tic-Tac-Toe
 * 
**/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class TicTacToe : Form
    {
        #region Fields
        /**
         if grid[x,y] = 0 then open square
         if grid[x,y] = 1 then square contains X
         if grid[x,y] = 2 then square contains O
        **/
        private int[,] grid;
        private int player;
        private int players;
        private int[,] locations;
        private bool playing;
        private Random rnd;
        private int moves;
        #endregion
        #region Constructor
        public TicTacToe()
        {
            InitializeComponent();
            grid = new int[3,3];
            player = 0;
            players = 0;
            this.playing = false;
            this.moves = 9;
            locations = new int[,]
            {
                {0, 0},
                {100, 100},
                {250, 100},
                {400, 100},
                {100, 250},
                {250, 250},
                {400, 250},
                {100, 400},
                {250, 400},
                {400, 400}
            };
            rnd = new Random();
            quit_Button.Enabled = false;
            quitGameToolStripMenuItem.Enabled = false;
        }
        #endregion constructor
        #region Painting
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen black = new Pen(Color.Black, 5);
            g.DrawLine(black, 25, 25, 475, 25);     //(25,25) to (475,25)
            g.DrawLine(black, 25, 475, 475, 475);   //(25,475) to (475,475)
            g.DrawLine(black, 25, 25, 25, 475);     //(25,25) to (25,475)
            g.DrawLine(black, 475, 25, 475, 475);   //(475,25) to (475,475)

            g.DrawLine(black, 25, 175, 475, 175);   //(25,175) to (475,175)
            g.DrawLine(black, 25, 325, 475, 325);   //(25,352) to (475,325)
            g.DrawLine(black, 175, 25, 175, 475);   //(175,25) to (175,475)
            g.DrawLine(black, 325, 25, 325, 475);   //(325,25) to (325,475)
            base.OnPaint(e);
        }

        //Draw an O centered at (x,y)
        private void drawO(int x, int y)
        {
            Graphics g = this.CreateGraphics();
            Pen blue = new Pen(Color.Blue, 10);
            g.DrawEllipse(blue, x - 50, y - 50, 100, 100);
        }

        //Draw an O centered at (x,y)
        private void drawX(int x, int y)
        {
            Graphics g = this.CreateGraphics();
            Pen red = new Pen(Color.Red, 10);
            g.DrawLine(red, x, y, x + 50, y + 50);
            g.DrawLine(red, x, y, x + 50, y - 50);
            g.DrawLine(red, x, y, x - 50, y + 50);
            g.DrawLine(red, x, y, x - 50, y - 50);
        }

        //Draw a Line Through the Winning Line
        private void drawLine(int xStart, int yStart, int xEnd, int yEnd)
        {
            Graphics g = this.CreateGraphics();
            Pen black = new Pen(Color.Black, 25);
            g.DrawLine(black, xStart, yStart, xEnd, yEnd);
        }
        #endregion painting
        #region Mouse Click Handler
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (players == 1 && player == 2)
            {
                //ignore mouse event
            }
            else
            {
                Point p = this.PointToClient(Form.MousePosition);
                if (p.X > 25 && p.X < 175)//column  1
                {
                    if (p.Y > 0 && p.Y < 175)//Top Left
                    {
                        Controller(1);
                    }
                    else if (p.Y > 175 && p.Y < 325)// Middle Left
                    {
                        Controller(4);
                    }
                    else if (p.Y > 325 && p.Y < 475)//Lower Left
                    {
                        Controller(7);
                    }
                }
                else if (p.X > 175 && p.X < 325)//column  2
                {
                    if (p.Y > 0 && p.Y < 175)//Upper Middle
                    {
                        Controller(2);
                    }
                    else if (p.Y > 175 && p.Y < 325)//Middle
                    {
                        Controller(5);
                    }
                    else if (p.Y > 325 && p.Y < 475)//Lower Middle
                    {
                        Controller(8);
                    }
                }
                else if (p.X > 325 && p.X < 475)//column  3
                {
                    if (p.Y > 0 && p.Y < 175)//Top Right
                    {
                        Controller(3);
                    }
                    else if (p.Y > 175 && p.Y < 325)//Middle Right
                    {
                        Controller(6);
                    }
                    else if (p.Y > 325 && p.Y < 475)//Lower Right
                    {
                        Controller(9);
                    }
                }
            }
        }
        #endregion
        #region Grid Checking
        private bool valid(int selected)
        {
            bool valid = false;
            switch (selected)
            {
                case 1:
                    if(grid[0,0] == 0)
                        valid = true;
                    break;
                case 2:
                    if (grid[0,1] == 0)
                        valid = true;
                    break;
                case 3:
                    if (grid[0,2] == 0)
                        valid = true;
                    break;
                case 4:
                    if (grid[1,0] == 0)
                        valid = true;
                    break;
                case 5:
                    if (grid[1,1] == 0)
                        valid = true;
                    break;
                case 6:
                    if (grid[1,2] == 0)
                        valid = true;
                    break;
                case 7:
                    if (grid[2,0] == 0)
                        valid = true;
                    break;
                case 8:
                    if (grid[2,1] == 0)
                        valid = true;
                    break;
                case 9:
                    if (grid[2,2] == 0)
                        valid = true;
                    break;
            }
            return valid;
        }

        /**
            8 Possible Ways to win
                1: (1,2,3) row 1
                2: (4,5,6) row 2
                3: (7,8,9) row 3
                4: (1,4,7) column 1
                5: (2,5,8) column 2
                6: (3,6,9) column 3
                7: (1,5,9) diagonal 1-9
                8: (3,5,7) diagonal 3-7
        **/
        private bool CheckWinner()
        {
            bool winner = false;
            if(grid[0, 0] == grid[0, 1] && grid[0, 1] == grid[0, 2] && (grid[0, 0] !=0 || grid[0, 1] != 0 || grid[0, 2] != 0))//case 1
            {
                drawLine(locations[1, 0], locations[1, 1], locations[3, 0], locations[3, 1]);
                MessageBox.Show("Player: " + grid[0, 0] + " Won");
                if (grid[0, 0] == 1)
                {
                    int num;
                    if (int.TryParse(player_1_Score.Text, out num))
                    {
                        player_1_Score.Clear();
                        num += 1;
                        player_1_Score.AppendText(num.ToString());
                    }
                }
                else if (grid[0, 0] == 2)
                {
                    int num;
                    if (int.TryParse(player_2_Score.Text, out num))
                    {
                        player_2_Score.Clear();
                        num += 1;
                        player_2_Score.AppendText(num.ToString());
                    }
                }
                winner = true;
            }
            else if (grid[1, 0] == grid[1, 1] && grid[1, 1] == grid[1, 2] && (grid[1, 0] != 0 || grid[1, 1] != 0 || grid[1, 2] != 0))//case 2
            {
                drawLine(locations[4, 0], locations[4, 1], locations[6, 0], locations[6, 1]);
                MessageBox.Show("Player: " + grid[1, 0] + " Won");
                if (grid[1, 0] == 1)
                {
                    int num;
                    if (int.TryParse(player_1_Score.Text, out num))
                    {
                        player_1_Score.Clear();
                        num += 1;
                        player_1_Score.AppendText(num.ToString());
                    }
                }
                else if (grid[1, 0] == 2)
                {
                    int num;
                    if (int.TryParse(player_2_Score.Text, out num))
                    {
                        player_2_Score.Clear();
                        num += 1;
                        player_2_Score.AppendText(num.ToString());
                    }
                }
                winner = true;
            }
            else if (grid[2, 0] == grid[2, 1] && grid[2, 1] == grid[2, 2] && (grid[2, 0] != 0 || grid[2, 1] != 0 || grid[2, 2] != 0))//case 3
            {
                drawLine(locations[7, 0], locations[7, 1], locations[9, 0], locations[9, 1]);
                MessageBox.Show("Player: " + grid[2, 0] + " Won");
                if (grid[2, 0] == 1)
                {
                    int num;
                    if (int.TryParse(player_1_Score.Text, out num))
                    {
                        player_1_Score.Clear();
                        num += 1;
                        player_1_Score.AppendText(num.ToString());
                    }
                }
                else if (grid[2, 0] == 2)
                {
                    int num;
                    if (int.TryParse(player_2_Score.Text, out num))
                    {
                        player_2_Score.Clear();
                        num += 1;
                        player_2_Score.AppendText(num.ToString());
                    }
                }
                winner = true;
            }
            else if (grid[0, 0] == grid[1, 0] && grid[1, 0] == grid[2, 0] && (grid[0, 0] != 0 || grid[1, 0] != 0 || grid[2, 0] != 0))//case 4
            {
                drawLine(locations[1, 0], locations[1, 1], locations[7, 0], locations[7, 1]);
                MessageBox.Show("Player: " + grid[0, 0] + " Won");
                if (grid[0, 0] == 1)
                {
                    int num;
                    if (int.TryParse(player_1_Score.Text, out num))
                    {
                        player_1_Score.Clear();
                        num += 1;
                        player_1_Score.AppendText(num.ToString());
                    }
                }
                else if (grid[0, 0] == 2)
                {
                    int num;
                    if (int.TryParse(player_2_Score.Text, out num))
                    {
                        player_2_Score.Clear();
                        num += 1;
                        player_2_Score.AppendText(num.ToString());
                    }
                }
                winner = true;
            }
            else if (grid[0, 1] == grid[1, 1] && grid[1, 1] == grid[2, 1] && (grid[0, 1] != 0 || grid[1, 1] != 0 || grid[2, 1] != 0))//case 5
            {
                drawLine(locations[2, 0], locations[2, 1], locations[8, 0], locations[8, 1]);
                MessageBox.Show("Player: " + grid[0, 1] + " Won");
                if (grid[0, 1] == 1)
                {
                    int num;
                    if (int.TryParse(player_1_Score.Text, out num))
                    {
                        player_1_Score.Clear();
                        num += 1;
                        player_1_Score.AppendText(num.ToString());
                    }
                }
                else if (grid[0, 1] == 2)
                {
                    int num;
                    if (int.TryParse(player_2_Score.Text, out num))
                    {
                        player_2_Score.Clear();
                        num += 1;
                        player_2_Score.AppendText(num.ToString());
                    }
                }
                winner = true;
            }
            else if (grid[0, 2] == grid[1, 2] && grid[1, 2] == grid[2, 2] && (grid[0, 2] != 0 || grid[1, 2] != 0 || grid[2, 2] != 0))//case 6
            {
                drawLine(locations[3, 0], locations[3, 1], locations[9, 0], locations[9, 1]);
                MessageBox.Show("Player: " + grid[0, 2] + " Won");
                if (grid[0, 2] == 1)
                {
                    int num;
                    if (int.TryParse(player_1_Score.Text, out num))
                    {
                        player_1_Score.Clear();
                        num += 1;
                        player_1_Score.AppendText(num.ToString());
                    }
                }
                else if (grid[0, 2] == 2)
                {
                    int num;
                    if (int.TryParse(player_2_Score.Text, out num))
                    {
                        player_2_Score.Clear();
                        num += 1;
                        player_2_Score.AppendText(num.ToString());
                    }
                }
                winner = true;
            }
            else if (grid[0, 0] == grid[1, 1] && grid[1, 1] == grid[2, 2] && (grid[0, 0] != 0 || grid[1, 1] != 0 || grid[2, 2] != 0))//case 7
            {
                drawLine(locations[1, 0], locations[1, 1], locations[9, 0], locations[9, 1]);
                MessageBox.Show("Player: " + grid[0, 0] + " Won");
                if (grid[0, 0] == 1)
                {
                    int num;
                    if (int.TryParse(player_1_Score.Text, out num))
                    {
                        player_1_Score.Clear();
                        num += 1;
                        player_1_Score.AppendText(num.ToString());
                    }
                }
                else if (grid[0, 0] == 2)
                {
                    int num;
                    if (int.TryParse(player_2_Score.Text, out num))
                    {
                        player_2_Score.Clear();
                        num += 1;
                        player_2_Score.AppendText(num.ToString());
                    }
                }
                winner = true;
            }
            else if (grid[0, 2] == grid[1, 1] && grid[1, 1] == grid[2, 0] && (grid[0, 2] != 0 || grid[1, 1] != 0 || grid[2, 0] != 0))//case 8
            {
                drawLine(locations[3, 0], locations[3, 1], locations[7, 0], locations[7, 1]);
                MessageBox.Show("Player: " + grid[0, 2] + " Won");
                if (grid[0, 2] == 1)
                {
                    int num;
                    if (int.TryParse(player_1_Score.Text, out num))
                    {
                        player_1_Score.Clear();
                        num += 1;
                        player_1_Score.AppendText(num.ToString());
                    }
                }
                else if (grid[0, 2] == 2)
                {
                    int num;
                    if (int.TryParse(player_2_Score.Text, out num))
                    {
                        player_2_Score.Clear();
                        num += 1;
                        player_2_Score.AppendText(num.ToString());
                    }
                }
                winner = true;
            }
            return winner;
        }

        private bool HasNextMove()
        {
            bool hasNext = false;
            if (grid[0, 0] == 0)
                hasNext = true;
            else if (grid[0, 1] == 0)
                hasNext = true;
            else if (grid[0, 2] == 0)
                hasNext = true;
            else if (grid[1, 0] == 0)
                hasNext = true;
            else if (grid[1, 1] == 0)
                hasNext = true;
            else if (grid[1, 2] == 0)
                hasNext = true;
            else if (grid[2, 0] == 0)
                hasNext = true;
            else if (grid[2, 1] == 0)
                hasNext = true;
            else if (grid[2, 2] == 0)
                hasNext = true;
            return hasNext;
        }
        #endregion
        #region Game Controller
        private void Controller(int selected)
        {
            if (valid(selected))
            {
                switch (selected)
                {
                    case 1:
                        if (this.player == 1)
                        {
                            drawX(locations[1, 0], locations[1, 1]);
                            grid[0, 0] = 1;
                            this.player = 2;
                            turn_Display.Clear();
                            turn_Display.AppendText("Player 2's Turn");
                            moves = moves - 1;
                            if (CheckWinner())
                                Reset();
                            else if (players == 1)
                            {
                                AI(1);
                            }
                        }
                        else if (this.player == 2)
                        {
                            drawO(locations[1, 0], locations[1, 1]);
                            grid[0, 0] = 2;
                            this.player = 1;
                            turn_Display.Clear();
                            turn_Display.AppendText("Player 1's Turn");
                            moves = moves - 1;
                        }
                        break;
                    case 2:
                        if (this.player == 1)
                        {
                            drawX(locations[2, 0], locations[2, 1]);
                            grid[0, 1] = 1;
                            this.player = 2;
                            turn_Display.Clear();
                            turn_Display.AppendText("Player 2's Turn");
                            moves = moves - 1;
                            if (CheckWinner())
                                Reset();
                            else if (players == 1)
                            {
                                AI(2);
                            }
                        }
                        else if (this.player == 2)
                        {
                            drawO(locations[2, 0], locations[2, 1]);
                            grid[0, 1] = 2;
                            this.player = 1;
                            turn_Display.Clear();
                            turn_Display.AppendText("Player 1's Turn");
                            moves = moves - 1;
                        }
                        break;
                    case 3:
                        if (this.player == 1)
                        {
                            drawX(locations[3, 0], locations[3, 1]);
                            grid[0, 2] = 1;
                            this.player = 2;
                            turn_Display.Clear();
                            turn_Display.AppendText("Player 2's Turn");
                            moves = moves - 1;
                            if (CheckWinner())
                                Reset();
                            else if (players == 1)
                            {
                                AI(3);
                            }
                        }
                        else if (player == 2)
                        {
                            drawO(locations[3, 0], locations[3, 1]);
                            grid[0, 2] = 2;
                            this.player = 1;
                            turn_Display.Clear();
                            turn_Display.AppendText("Player 1's Turn");
                            moves = moves - 1;
                        }
                        break;
                    case 4:
                        if (this.player == 1)
                        {
                            drawX(locations[4, 0], locations[4, 1]);
                            grid[1, 0] = 1;
                            this.player = 2;
                            turn_Display.Clear();
                            turn_Display.AppendText("Player 2's Turn");
                            moves = moves - 1;
                            if (CheckWinner())
                                Reset();
                            else if (players == 1)
                            {
                                AI(4);
                            }
                        }
                        else if (player == 2)
                        {
                            drawO(locations[4, 0], locations[4, 1]);
                            grid[1, 0] = 2;
                            this.player = 1;
                            turn_Display.Clear();
                            turn_Display.AppendText("Player 1's Turn");
                            moves = moves - 1;
                        }
                        break;
                    case 5:
                        if (this.player == 1)
                        {
                            drawX(locations[5, 0], locations[5, 1]);
                            grid[1, 1] = 1;
                            this.player = 2;
                            turn_Display.Clear();
                            turn_Display.AppendText("Player 2's Turn");
                            moves = moves - 1;
                            if (CheckWinner())
                                Reset();
                            else if (players == 1)
                            {
                                AI(5);
                            }
                        }
                        else if (this.player == 2)
                        {
                            drawO(locations[5, 0], locations[5, 1]);
                            grid[1, 1] = 2;
                            this.player = 1;
                            turn_Display.Clear();
                            turn_Display.AppendText("Player 1's Turn");
                            moves = moves - 1;
                        }
                        break;
                    case 6:
                        if (this.player == 1)
                        {
                            drawX(locations[6, 0], locations[6, 1]);
                            grid[1, 2] = 1;
                            this.player = 2;
                            turn_Display.Clear();
                            turn_Display.AppendText("Player 2's Turn");
                            moves = moves - 1;
                            if (CheckWinner())
                                Reset();
                            else if (players == 1)
                            {
                                AI(6);
                            }
                        }
                        else if (this.player == 2)
                        {
                            drawO(locations[6, 0], locations[6, 1]);
                            grid[1, 2] = 2;
                            this.player = 1;
                            turn_Display.Clear();
                            turn_Display.AppendText("Player 1's Turn");
                            moves = moves - 1;
                        }
                        break;
                    case 7:
                        if (this.player == 1)
                        {
                            drawX(locations[7, 0], locations[7, 1]);
                            grid[2, 0] = 1;
                            this.player = 2;
                            turn_Display.Clear();
                            turn_Display.AppendText("Player 2's Turn");
                            moves = moves - 1;
                            if (CheckWinner())
                                Reset();
                            else if (players == 1)
                            {
                                AI(7);
                            }
                        }
                        else if (this.player == 2)
                        {
                            drawO(locations[7, 0], locations[7, 1]);
                            grid[2, 0] = 2;
                            this.player = 1;
                            turn_Display.Clear();
                            turn_Display.AppendText("Player 1's Turn");
                            moves = moves - 1;
                        }
                        break;
                    case 8:
                        if (this.player == 1)
                        {
                            drawX(locations[8, 0], locations[8, 1]);
                            grid[2, 1] = 1;
                            this.player = 2;
                            turn_Display.Clear();
                            turn_Display.AppendText("Player 2's Turn");
                            moves = moves - 1;
                            if (CheckWinner())
                                Reset();
                            else if (players == 1)
                            {
                                AI(8);
                            }
                        }
                        else if (this.player == 2)
                        {
                            drawO(locations[8, 0], locations[8, 1]);
                            grid[2, 1] = 2;
                            this.player = 1;
                            turn_Display.Clear();
                            turn_Display.AppendText("Player 1's Turn");
                            moves = moves - 1;
                        }
                        break;
                    case 9:
                        if (this.player == 1)
                        {
                            drawX(locations[9, 0], locations[9, 1]);
                            grid[2, 2] = 1;
                            this.player = 2;
                            turn_Display.Clear();
                            turn_Display.AppendText("Player 2's Turn");
                            moves = moves - 1;
                            if (CheckWinner())
                                Reset();
                            else if (players == 1)
                            {
                                AI(9);
                            }
                        }
                        else if (this.player == 2)
                        {
                            drawO(locations[9, 0], locations[9, 1]);
                            grid[2, 2] = 2;
                            this.player = 1;
                            turn_Display.Clear();
                            turn_Display.AppendText("Player 1's Turn");
                            moves = moves - 1;
                        }
                        break;
                }
            }
            if (CheckWinner())
                Reset();
            else if (HasNextMove() == false)
            {
                MessageBox.Show("Tie Game: No Winner!");
                Reset();
            }
        }

        private void Reset()
        {
            grid[0, 0] = 0;
            grid[0, 1] = 0;
            grid[0, 2] = 0;
            grid[1, 0] = 0;
            grid[1, 1] = 0;
            grid[1, 2] = 0;
            grid[2, 0] = 0;
            grid[2, 1] = 0;
            grid[2, 2] = 0;
            this.Refresh();
            moves = 9;
            if (players == 1)
            {
                if (player == 2)
                {
                    AI(0);
                }
            }    
        }
        #endregion
        #region AI
        private void AI(int lastMove)
        {
            int num, tmp;
            bool val = false;
            int blockMove, winningMove;
            bool madeMove = false;
            if (HasNextMove())
            {
                blockMove = CheckMove(1);
                winningMove = CheckMove(2);
                if (winningMove != 0 && !madeMove)
                {
                    Controller(winningMove);
                    madeMove = true;
                }
                else if (blockMove != 0 && !madeMove)
                {
                    Controller(blockMove);
                    madeMove = true;
                }
                else if(!madeMove)
                {
                    while (!val)
                    {
                        num = rnd.Next(52);
                        tmp = num % 9 + 1;
                        val = valid(tmp);
                        if (val)
                            Controller(tmp);
                    }
                }
            }
        }

        /**
         * 
         * Find A Winning Move By Passing in Current Player Number.
         * 
         * Or
         * 
         * Find a Blocking Move By Passing in Other Player's Number.
         * 
         * 
         * Returns Square Number(Blocking or Winning), Returns 0 when there is no winning or blocking move.
         * 
        **/
        private int CheckMove(int playerNum)
        {
            int move = 0;
            int tmp;
            //check row 1
            tmp = 0;
            if (grid[0, 0] == playerNum)
                tmp++;
            if (grid[0, 1] == playerNum)
                tmp++;
            if (grid[0, 2] == playerNum)
                tmp++;
            if (tmp == 2)//find move
            {
                if (grid[0, 0] == 0)
                    move = 1;
                else if (grid[0, 1] == 0)
                    move = 2;
                else if (grid[0, 2] == 0)
                    move = 3;
            }
            //check row 2
            tmp = 0;
            if (grid[1, 0] == playerNum)
                tmp++;
            if (grid[1, 1] == playerNum)
                tmp++;
            if (grid[1, 2] == playerNum)
                tmp++;
            if (tmp == 2)//find move
            {
                if (grid[1, 0] == 0)
                    move = 4;
                else if (grid[1, 1] == 0)
                    move = 5;
                else if (grid[1, 2] == 0)
                    move = 6;
            }
            //check row 3
            tmp = 0;
            if (grid[2, 0] == playerNum)
                tmp++;
            if (grid[2, 1] == playerNum)
                tmp++;
            if (grid[2, 2] == playerNum)
                tmp++;
            if (tmp == 2)//find move
            {
                if (grid[2, 0] == 0)
                    move = 7;
                else if (grid[2, 1] == 0)
                    move = 8;
                else if (grid[2, 2] == 0)
                    move = 9;
            }
            //check column 1
            tmp = 0;
            if (grid[0, 0] == playerNum)
                tmp++;
            if (grid[1, 0] == playerNum)
                tmp++;
            if (grid[2, 0] == playerNum)
                tmp++;
            if (tmp == 2)//find move
            {
                if (grid[0, 0] == 0)
                    move = 1;
                else if (grid[1, 0] == 0)
                    move = 4;
                else if (grid[2, 0] == 0)
                    move = 7;
            }
            //check column 2
            tmp = 0;
            if (grid[0, 1] == playerNum)
                tmp++;
            if (grid[1, 1] == playerNum)
                tmp++;
            if (grid[2, 1] == playerNum)
                tmp++;
            if (tmp == 2)//find move
            {
                if (grid[0, 1] == 0)
                    move = 2;
                else if (grid[1, 1] == 0)
                    move = 5;
                else if (grid[2, 1] == 0)
                    move = 8;
            }
            //check column 3
            tmp = 0;
            if (grid[0, 2] == playerNum)
                tmp++;
            if (grid[1, 2] == playerNum)
                tmp++;
            if (grid[2, 2] == playerNum)
                tmp++;
            if (tmp == 2)//find move
            {
                if (grid[0, 2] == 0)
                    move = 3;
                else if (grid[1, 2] == 0)
                    move = 6;
                else if (grid[2, 2] == 0)
                    move = 9;
            }
            //check diagonal 1
            tmp = 0;
            if (grid[0, 0] == playerNum)
                tmp++;
            if (grid[1, 1] == playerNum)
                tmp++;
            if (grid[2, 2] == playerNum)
                tmp++;
            if (tmp == 2)//find move
            {
                if (grid[0, 0] == 0)
                    move = 1;
                else if (grid[1, 1] == 0)
                    move = 5;
                else if (grid[2, 2] == 0)
                    move = 9;
            }
            //check diagonal 2
            tmp = 0;
            if (grid[0, 2] == playerNum)
                tmp++;
            if (grid[1, 1] == playerNum)
                tmp++;
            if (grid[2, 0] == playerNum)
                tmp++;
            if (tmp == 2)//find move
            {
                if (grid[0, 2] == 0)
                    move = 3;
                else if (grid[1, 1] == 0)
                    move = 5;
                else if (grid[2, 0] == 0)
                    move = 7;
            }
            return move;
        }
        #endregion
        #region Form Controls
        private void onePlayerButton_CheckedChanged(object sender, EventArgs e)
        {
            this.Text = "Tic-Tac-Toe     1-Player VS AI";
            this.players = 1;
            this.player = 0;
            turn_Display.Clear();
            Reset();
        }

        private void twoPlayerButton_CheckedChanged(object sender, EventArgs e)
        {
            this.Text = "Tic-Tac-Toe     2-Player";
            this.players = 2;
            this.player = 0;
            turn_Display.Clear();
            Reset();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void roll_Button_Click(object sender, EventArgs e)
        {
            int num = rnd.Next(52);
            int tmp = num % 2 + 1;
            onePlayerButton.Enabled = false;
            twoPlayerButton.Enabled = false;
            onePlayerToolStripMenuItem.Enabled = false;
            twoPlayerToolStripMenuItem.Enabled = false;
            newGameToolStripMenuItem.Enabled = false;
            quit_Button.Enabled = true;
            quitGameToolStripMenuItem.Enabled = true;
            roll_Button.Enabled = false;
            if (!playing)
            {
                Reset();
                this.player = 2;
                turn_Display.Clear();
                turn_Display.AppendText("Player 2's Turn");
                playing = true;
                if (tmp == 1)
                {
                    this.player = 1;
                    turn_Display.Clear();
                    turn_Display.AppendText("Player 1's Turn");
                    playing = true;
                }
                else if (tmp == 2)
                {
                    this.player = 2;
                    turn_Display.Clear();
                    turn_Display.AppendText("Player 2's Turn");
                    playing = true;
                    if (players == 1)
                    {
                        AI(0);
                    }
                }
            }
        }

        private void quit_Button_Click(object sender, EventArgs e)
        {
            this.player = 0;
            playing = false;
            turn_Display.Clear();
            player_1_Score.Clear();
            player_1_Score.AppendText("0");
            player_2_Score.Clear();
            player_2_Score.AppendText("0");
            onePlayerButton.Enabled = true;
            twoPlayerButton.Enabled = true;
            onePlayerToolStripMenuItem.Enabled = true;
            twoPlayerToolStripMenuItem.Enabled = true;
            newGameToolStripMenuItem.Enabled = true;
            quit_Button.Enabled = false;
            quitGameToolStripMenuItem.Enabled = false;
            roll_Button.Enabled = true;
            this.Refresh();
            Reset();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
        #region Menu Strip Handlers
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int num = rnd.Next(52);
            int tmp = num % 2 + 1;
            onePlayerButton.Enabled = false;
            twoPlayerButton.Enabled = false;
            onePlayerToolStripMenuItem.Enabled = false;
            twoPlayerToolStripMenuItem.Enabled = false;
            newGameToolStripMenuItem.Enabled = false;
            quit_Button.Enabled = true;
            quitGameToolStripMenuItem.Enabled = true;
            roll_Button.Enabled = false;
            if (!playing)
            {
                if (tmp == 1)
                {
                    this.player = 1;
                    turn_Display.Clear();
                    turn_Display.AppendText("Player 1's Turn");
                    playing = true;
                }
                else if (tmp == 2)
                {
                    this.player = 2;
                    turn_Display.Clear();
                    turn_Display.AppendText("Player 2's Turn");
                    playing = true;
                    if (players == 1)
                    {
                        AI(0);
                    }
                }
            }
        }

        private void quitGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.player = 0;
            playing = false;
            turn_Display.Clear();
            player_1_Score.Clear();
            player_1_Score.AppendText("0");
            player_2_Score.Clear();
            player_2_Score.AppendText("0");
            onePlayerButton.Enabled = true;
            twoPlayerButton.Enabled = true;
            onePlayerToolStripMenuItem.Enabled = true;
            twoPlayerToolStripMenuItem.Enabled = true;
            newGameToolStripMenuItem.Enabled = true;
            quit_Button.Enabled = false;
            quitGameToolStripMenuItem.Enabled = false;
            roll_Button.Enabled = true;
            this.Refresh();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Michael Lutch\nCSCD 371 Fall 2013\nAssignment 3 Drawing: Tic-Tac-Toe\nExtra Credit: 'Smart' AI Completed");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void onePlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Tic-Tac-Toe     1-Player VS AI";
            this.players = 1;
            this.player = 0;
            turn_Display.Clear();
            onePlayerButton.Select();
            Reset();
        }

        private void twoPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Tic-Tac-Toe     2-Player";
            this.players = 2;
            this.player = 0;
            twoPlayerButton.Select();
            turn_Display.Clear();
            Reset();
        }
        #endregion
    }
}