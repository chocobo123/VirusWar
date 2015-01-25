using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VirusWar
{
    public partial class Form1 : Form
    {
        Field field = null;
        Boolean control = true;
        Boolean pcTurn = false;
        Boolean startGame = false;
        Int32 bigRound = 1;
        Int32 curSubMove = 1;
        Int32 maxSubMoves = 2;
        Int32 maxDepth = 4;
        Int32 fieldSize = 5;
        
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Visible = false;

            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            label6.Text = "";
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            field.Paint(e.Graphics, control);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int xVal = e.X / Field.ItemSize;
            int yVal = e.Y / Field.ItemSize;        
            
            Field.Item Virus = control ? Field.Item.Virus1 : Field.Item.Virus2;
            Field.Item Zombie = control ? Field.Item.Zombie1 : Field.Item.Zombie2;

            if (!startGame)
                return;

            //Player can not click
            if (singleplayerModeToolStripMenuItem.Checked && pcTurn)
                return;

            if (bigRound < 3 && curSubMove == 1 && ((xVal == 0 && yVal == 0) || (xVal == (field.size - 1) && yVal == 0) || (xVal == 0 && yVal == (field.size - 1)) || (xVal == (field.size - 1) && yVal == (field.size - 1))) && field.isItemEmpty(xVal, yVal))
            {
                // set first virus
                label2.Text = "";
                field.setItem(xVal, yVal, Virus);
                curSubMove++;
            }
            else if (field.searchForVirus(xVal, yVal, control))
            {   
                label2.Text = "";
                if (field.isItemEmpty(xVal, yVal))
                    //set virus
                    field.setItem(xVal, yVal, Virus);
                else if (field.isThereItem(xVal, yVal, control))
                    // set zombie
                    field.setItem(xVal, yVal, Zombie);
                curSubMove++;
            }
            else
                label2.Text = "You can not place your virus there!";

            //switch players turn
            if (curSubMove == maxSubMoves+1)
            {   
                if(twoplayerModeToolStripMenuItem.Checked)
                    control = !control;
                if(singleplayerModeToolStripMenuItem.Checked)
                    pcTurn = true;

                bigRound++;
                curSubMove = 1;
            }

            // check if player has wone
            if (bigRound > 2)
            {
                Boolean gameOver = true;
                for (int j = 0; j < field.size; j++)
                {
                    for (int k = 0; k < field.size; k++)
                    {
                        if (field.searchForVirus(j, k, control) == true)
                        {
                            gameOver = false;
                            break;
                        }
                    }
                }

                if (gameOver == true)
                {
                    if (control == true)
                        label6.Text = "Player 2 wins!";
                    else
                        label6.Text = "Player 1 wins!";

                    label2.Text = "";
                    label3.Text = "";
                    label4.Text = "";
                    startGame = false;

                    pictureBox1.Refresh();
                    return;
                }
            }

            if (control == true)
                label3.Text = "Player 1's turn.";
            else
                label3.Text = "Player 2's turn.";

            label4.Text = "You have " + (maxSubMoves + 1 - curSubMove) + " moves.";

            pictureBox1.Refresh();
            if (pcTurn == true && singleplayerModeToolStripMenuItem.Checked)
            {
                label3.Text = "";
                label4.Text = "";
                control = !control;
                pictureBox1_ComputerClick();
            }
        }
        
        private void pictureBox1_ComputerClick()
        {
            int xVal;
            int yVal;

            if (searchDepth1ToolStripMenuItem.Checked)
                maxDepth = 1;
            else if (searchDepth2ToolStripMenuItem.Checked)
                maxDepth = 2;
            else if (searchDepth3ToolStripMenuItem.Checked)
                maxDepth = 3;
            else if (searchDepth4ToolStripMenuItem.Checked)
                maxDepth = 4;
            else
                maxDepth = 5;

            #region "set first virus"
            if (curSubMove == 1 && bigRound < 3)
            {
                Random Rnd = new Random();
                int pseuNum = Rnd.Next(4);

                if (pseuNum == 1)
                {
                    xVal = 0;
                    yVal = 0;

                    if (!field.isItemEmpty(xVal, yVal))
                    {
                        xVal = field.size - 1; // opposite field
                        xVal = field.size - 1;
                    }
                }
                else if (pseuNum == 2)
                {
                    xVal = 0;
                    yVal = field.size - 1;

                    if (!field.isItemEmpty(xVal, yVal))
                    {
                        xVal = field.size - 1;  // opposite field
                        xVal = 0;
                    }
                }
                else if (pseuNum == 3)
                {
                    xVal = field.size - 1;
                    yVal = 0;

                    if (!field.isItemEmpty(xVal, yVal))
                    {
                        xVal = 0;   // opposite field
                        xVal = field.size - 1;
                    }
                }
                else
                {
                    xVal = field.size - 1;
                    yVal = field.size - 1;

                    if (!field.isItemEmpty(xVal, yVal))
                    {
                        xVal = 0;   // opposite field
                        xVal = 0;
                    }
                }

                field.setItem(xVal, yVal, Field.Item.Virus2);
                curSubMove++;

            }
            #endregion
            else
            {
                //create a tree
                TreeNode tree = new TreeNode(field, control);
                tree.Tree(1, maxDepth, curSubMove, maxSubMoves);
                if (tree.children.Count > 0)
                {
                    foreach (TreeNode n in tree.children)
                    {
                        if (n.rating == tree.rating)
                        {
                            if (field.isItemEmpty(n.pos.X, n.pos.Y))
                                field.setItem(n.pos.X, n.pos.Y, Field.Item.Virus2);
                            else
                                field.setItem(n.pos.X, n.pos.Y, Field.Item.Zombie2);
                            break;
                        }
                    }
                }
                else
                {
                    label6.Text = "Player 1 wins!";
                    label2.Text = "";
                    label3.Text = "";
                    label4.Text = "";
                    startGame = false;

                    pictureBox1.Refresh();
                    return; 
                }

                curSubMove++;
            }
            pictureBox1.Refresh(); 
            
            // check if pc has wone
            if (bigRound > 2)
            {
                Boolean gameOver = true;
                for (int j = 0; j < field.size; j++)
                {
                    for (int k = 0; k < field.size; k++)
                    {
                        if (field.searchForVirus(j, k, !control) == true)
                        {
                            gameOver = false;
                            break;
                        }
                    }
                }

                if (gameOver == true)
                {
                    label6.Text = "Player 2 wins!";
                    label2.Text = "";
                    label3.Text = "";
                    label4.Text = "";
                    startGame = false;

                    pictureBox1.Refresh();
                    return;
                }
            }
            //switch to player 1 turn
            if (curSubMove == maxSubMoves + 1)
            {
                bigRound++;
                pcTurn = false;
                control = true;
                curSubMove = 1;
                label3.Text = "Player 1's turn.";
                label4.Text = "You have " + (maxSubMoves + 1 - curSubMove) + " moves.";
                pictureBox1.Refresh();
            }
            else
            {
                if (singleplayerModeToolStripMenuItem.Checked)
                    pictureBox1_ComputerClick();
            }
        }

        #region "click in the menu"
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void singleplayerModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            singleplayerModeToolStripMenuItem.Checked = true;
            twoplayerModeToolStripMenuItem.Checked = false;
        }

        private void twoplayerModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            singleplayerModeToolStripMenuItem.Checked = false;
            twoplayerModeToolStripMenuItem.Checked = true;   
        }

        private void player1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            player1ToolStripMenuItem.Checked = true;
            player2ToolStripMenuItem.Checked = false;
            
        }

        private void player2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            player1ToolStripMenuItem.Checked = false;
            player2ToolStripMenuItem.Checked = true;
        }

        private void searchDepth1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            searchDepth1ToolStripMenuItem.Checked = true;
            searchDepth2ToolStripMenuItem.Checked = false;
            searchDepth3ToolStripMenuItem.Checked = false;
            searchDepth4ToolStripMenuItem.Checked = false;
            searchDepth5ToolStripMenuItem.Checked = false;

            maxDepth = 1;
        }

        private void searchDepth2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            searchDepth1ToolStripMenuItem.Checked = false;
            searchDepth2ToolStripMenuItem.Checked = true;
            searchDepth3ToolStripMenuItem.Checked = false;
            searchDepth4ToolStripMenuItem.Checked = false;
            searchDepth5ToolStripMenuItem.Checked = false;

            maxDepth = 2;
        }

        private void searchDepth3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            searchDepth1ToolStripMenuItem.Checked = false;
            searchDepth2ToolStripMenuItem.Checked = false;
            searchDepth3ToolStripMenuItem.Checked = true;
            searchDepth4ToolStripMenuItem.Checked = false;
            searchDepth5ToolStripMenuItem.Checked = false;

            maxDepth = 3;
        }

        private void searchDepth4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            searchDepth1ToolStripMenuItem.Checked = false;
            searchDepth2ToolStripMenuItem.Checked = false;
            searchDepth3ToolStripMenuItem.Checked = false;
            searchDepth4ToolStripMenuItem.Checked = true;
            searchDepth5ToolStripMenuItem.Checked = false;

            maxDepth = 4;
        }

        private void searchDepth5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            searchDepth1ToolStripMenuItem.Checked = false;
            searchDepth2ToolStripMenuItem.Checked = false;
            searchDepth3ToolStripMenuItem.Checked = false;
            searchDepth4ToolStripMenuItem.Checked = false;
            searchDepth5ToolStripMenuItem.Checked = true;

            maxDepth = 5;
        }

        private void instructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Virus War is a two-player-game and is played on a square board. Player 1 plays with" 
            + "the blue colored viruses and zombies and player 2, or rather the computer-player, plays with the "
            + "red colored viruses and zombies. Viruses have a smiled face and zombies are looking unhappy."
            + "\nBefore starting the game you can choose the player-mode, the " 
            + "number of moves, who starts the game and the depth of the searching algorithm for the computer-player. "
            + "The moves must executed in rotation.\nA player loses the game if he can not makes his moves.\nYou "
            + "can place a virus on an empty square of the board but this must be connected with a virus of the "
            + "same color. A zombie can be placed on a virus of an other player but it also must be connected with"
            + " a virus of the same color.\nThe first placed virus must be in a corner of the board. Around the" 
            +" viruses and zombies there are some circles which show you the possible moves. "
            + "\nStart the game with 'GAME – start'.", "VirusWar - Instructions", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void abotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This game was programmed by Monika Chromik, a student from the University of Technology Poznan.", "VirusWar - About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            control = true;
            pcTurn = false;
            bigRound = 1;
            curSubMove = 1;
            pictureBox1.Visible = false;
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            label6.Text = "";
            pictureBox1.Refresh();

            field = new Field(fieldSize);

            pictureBox1.Width = Field.ItemSize * fieldSize + 1;
            pictureBox1.Height = Field.ItemSize * fieldSize + 1;

            startGame = true;
            pictureBox1.Visible = true;

            if(singleplayerModeToolStripMenuItem.Checked && player2ToolStripMenuItem.Checked)
                pictureBox1_ComputerClick();
            if (twoplayerModeToolStripMenuItem.Checked && player2ToolStripMenuItem.Checked)
                control = !control;
            
            if (control == true)
                label3.Text = "Player 1's turn.";
            else
                label3.Text = "Player 2's turn.";
            label4.Text = "You have " + (maxSubMoves - curSubMove + 1) + " moves.";

            toolStripMenuItem1.Enabled = false;
        }

        // reset
        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startGame = false;
            toolStripMenuItem1.Enabled = true;
            control = true;
            pcTurn = false;
            bigRound = 1;
            curSubMove = 1;
            pictureBox1.Visible = false;
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            label6.Text = "";
            pictureBox1.Refresh();
        }

        // moves
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {   
            toolStripMenuItem4.Checked = true; // one move
            toolStripMenuItem5.Checked = false;
            toolStripMenuItem6.Checked = false;
            toolStripMenuItem7.Checked = false;
            toolStripMenuItem8.Checked = false;

            maxSubMoves = 1;
            fieldSize = 5;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = true; // two moves
            toolStripMenuItem6.Checked = false;
            toolStripMenuItem7.Checked = false;
            toolStripMenuItem8.Checked = false;

            maxSubMoves = 2;
            fieldSize = 5;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = false;
            toolStripMenuItem6.Checked = true; // three moves
            toolStripMenuItem7.Checked = false;
            toolStripMenuItem8.Checked = false;

            maxSubMoves = 3;
            fieldSize = 7;
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = false;
            toolStripMenuItem6.Checked = false;
            toolStripMenuItem7.Checked = true; // four moves
            toolStripMenuItem8.Checked = false;

            maxSubMoves = 4;
            fieldSize = 9;
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = false;
            toolStripMenuItem6.Checked = false;
            toolStripMenuItem7.Checked = false;
            toolStripMenuItem8.Checked = true; // five moves

            maxSubMoves = 5;
            fieldSize = 11;
        }

        #endregion
    }
}
