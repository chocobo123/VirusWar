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
        int i = 1;

        public Form1()
        {
            InitializeComponent();
            field = new Field(11);

            pictureBox1.Width = Field.ItemSize * 11 + 1;
            pictureBox1.Height = Field.ItemSize * 11 + 1;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            field.Paint(e.Graphics, control);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int xVal = e.X / Field.ItemSize;
            int yVal = e.Y / Field.ItemSize;
            label1.Text = (xVal+1) + " x " + (yVal+1);
            
            Field.Item Virus = control ? Field.Item.Virus1 : Field.Item.Virus2;
            Field.Item Zombie = control ? Field.Item.Zombie1 : Field.Item.Zombie2;


            if (field.searchForVirus(xVal, yVal, control))
            {
                label2.Text = "";
                if (field.isItemEmpty(xVal, yVal))
                    field.setItem(xVal, yVal, Virus);
                else if (field.isThereItem(xVal, yVal, control))
                    field.setItem(xVal, yVal, Zombie);
                i++;
            }
            else
                label2.Text = "This move does not go!";
            

            if(i==6)
            {
                control = !control; 
                i = 1;
            }
            pictureBox1.Refresh();
            
        }
    }
}
