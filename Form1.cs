﻿using System;
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
        int xVal;
        int yVal;

        public Form1()
        {
            InitializeComponent();
            field = new Field(11);

            pictureBox1.Width = Field.ItemSize * 11 + 1;
            pictureBox1.Height = Field.ItemSize * 11 + 1;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            field.Paint(e.Graphics);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            xVal = e.X / Field.ItemSize;
            yVal = e.Y / Field.ItemSize;
            label1.Text = (xVal+1) + " x " + (yVal+1);

            if (field.isItemEmpty(xVal, yVal))
                field.setItem(xVal, yVal, Field.Item.Virus1);

            if (field.isThereItem(xVal, yVal))
                field.setItem(xVal, yVal, Field.Item.Zombie1);

            pictureBox1.Refresh();
        }
    }
}