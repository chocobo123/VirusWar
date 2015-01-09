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
        public Boolean pcTurn = false;

        public Form1()
        {
            InitializeComponent();
            field = new Field(11);

            pictureBox1.Width = Field.ItemSize * 11 + 1;
            pictureBox1.Height = Field.ItemSize * 11 + 1;
            label2.Text = "";
            label3.Text = "Player 1's turn.";
            label4.Text = "You have 5 moves";
            label5.Text = "";
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

            //Player can not click
            if (pcTurn)
                return;

            if (control == false && bigRound > 2)
            {
                field.searchForVirus(xVal, yVal, control);
            }

            if (bigRound < 3 && i == 1 && ((xVal == 0 && yVal == 0) || (xVal == (field.size - 1) && yVal == 0) || (xVal == 0 && yVal == (field.size - 1)) || (xVal == (field.size - 1) && yVal == (field.size - 1))) && field.isItemEmpty(xVal, yVal))
            {
                // set first virus
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
            
            label6.Text = "Fitness Spieler: " + field.fitnessfunction(true);

            if (i == 6)
            {
                //control = !control;
                bigRound++;
                pcTurn = true;
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
 
                    pictureBox1.Refresh();
                    return;
                }

            }

            pictureBox1.Refresh();
            if (pcTurn == true)
            {
                pictureBox1_ComputerClick();
            }

        }


        private void pictureBox1_ComputerClick()
        {
            int xVal;
            int yVal;
            List<Field> possibleMoves = new List<Field>();
            

            #region "set first virus"
            if (i==1 && bigRound < 3)
            {
                Random Rnd = new Random();
                int pseuNum = Rnd.Next(4);

                
                
                if (pseuNum == 1)
                {
                    xVal = 0;
                    yVal = 0;

                    if (field.isItemEmpty(xVal, yVal))
                    {
                        field.setItem(xVal, yVal, Field.Item.Virus2);
                        i++;
                    }
                    else
                    {
                        xVal = field.size - 1; // opposite field
                        xVal = field.size - 1;
                        field.setItem(xVal, yVal, Field.Item.Virus2);
                        i++;
                    }

                }
                else if (pseuNum == 2)
                {
                    xVal = 0;
                    yVal = field.size - 1;

                    if (field.isItemEmpty(xVal, yVal))
                    {
                        field.setItem(xVal, yVal, Field.Item.Virus2);
                        i++;
                    }
                    else
                    {
                        xVal = field.size - 1;  // opposite field
                        xVal = 0;
                        field.setItem(xVal, yVal, Field.Item.Virus2);
                        i++;
                    }
                }
                else if (pseuNum == 3)
                {
                    xVal = field.size - 1;
                    yVal = 0;

                    if (field.isItemEmpty(xVal, yVal))
                    {
                        field.setItem(xVal, yVal, Field.Item.Virus2);
                        i++;
                    }
                    else
                    {
                        xVal = 0;   // opposite field
                        xVal = field.size - 1;
                        field.setItem(xVal, yVal, Field.Item.Virus2);
                        i++;
                    }
                }
                else
                {
                    xVal = field.size - 1;
                    yVal = field.size - 1;

                    if (field.isItemEmpty(xVal, yVal))
                    {
                        field.setItem(xVal, yVal, Field.Item.Virus2);
                        i++;
                    }
                    else
                    {
                        xVal = 0;   // opposite field
                        xVal = 0;
                        field.setItem(xVal, yVal, Field.Item.Virus2);
                        i++;
                    }
                }
            }
            #endregion

            Field fieldCopy = field;
            field.fitnessfunction(false);
            for (int j = 0; j < field.size; j++)
            {
                for (int k = 0; k < field.size; k++)
                {

                    if (field.searchForVirus(j, k, !control) == true)
                    {

                        Field newField = new Field(field);
                        
                        if (newField.isItemEmpty(j, k))
                            newField.setItem(j, k, Field.Item.Virus2);
                        else
                            newField.setItem(j, k, Field.Item.Zombie2);
                    
                        possibleMoves.Add(newField);
                    }
                }
            }

            int maxFitness = -1;
            foreach (Field f in possibleMoves)
            {
                if (f.fitnessfunction(false) > maxFitness)
                {
                    maxFitness = f.fitnessfunction(false);
                    field = f;
                }
            }
            i++;

            pictureBox1.Refresh();

            if (i == 6)
            {
                bigRound++;
                pcTurn = false;
                i = 1;
            }
            else
            {
                pictureBox1_ComputerClick();
            }
        }

    }
}
