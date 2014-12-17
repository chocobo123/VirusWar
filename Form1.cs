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
        Field field;
        Boolean control = true;
        int bigRound = 1;
        int i = 1;

        public Form1()
        {
            InitializeComponent();
            field = new Field(11);

            pictureBox1.Width = Field.ItemSize * 11 + 1;
            pictureBox1.Height = Field.ItemSize * 11 + 1;
            label3.Text = "Player 1's turn.";
            label4.Text = "You have 5 moves";
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            field.Paint(e.Graphics, control);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int xVal = e.X / Field.ItemSize;
            int yVal = e.Y / Field.ItemSize;
            Boolean gameOver = true;
            label1.Text = (xVal+1) + " x " + (yVal+1);         
            
            Field.Item Virus = control ? Field.Item.Virus1 : Field.Item.Virus2;
            Field.Item Zombie = control ? Field.Item.Zombie1 : Field.Item.Zombie2;

            if (bigRound < 3 && i == 1 && ((xVal == 0 && yVal == 0) || (xVal == (field.size - 1) && yVal == 0) || (xVal == 0 && yVal == (field.size - 1)) || (xVal == (field.size - 1) && yVal == (field.size - 1))) && field.isItemEmpty(xVal, yVal))
            {
                label2.Text = "";
                field.setItem(xVal, yVal, Virus);
                i++;
            }
            else if (field.searchForVirus(xVal, yVal, control))
            {
                label2.Text = "";
                if (field.isItemEmpty(xVal, yVal))
                    field.setItem(xVal, yVal, Virus);
                else if (field.isThereItem(xVal, yVal, control))
                    field.setItem(xVal, yVal, Zombie);
                i++;
            }
            else
                label2.Text = "You cannot place your virus there!";

            if (i == 6)
            {
                control = !control;
                bigRound++;
                i = 1;
            }

            if (control == true)
                label3.Text = "Player 1's turn.";
            else
                label3.Text = "Player 2's turn.";
            label4.Text = "You have " + (6 - i) + " moves";

            if (bigRound > 2)
            {
                for (int j = 0; j < field.size; j++)
                {
                    for (int k = 0; k < field.size; k++)
                    {
                        if (field.searchForVirus(j, k, !control) == true)
                        {
                            gameOver = false;
                        }
                    }
                }

                if (gameOver == true)
                {
                    if (control == true)
                        label5.Text = "Player 1 wins!";
                    else
                        label5.Text = "Player 2 wins!";
                }
            }

            pictureBox1.Refresh();
        }
    }
}
