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
    public class Field
    {
        protected Bitmap img1 = Properties.Resources.img1;
        protected Bitmap img2 = Properties.Resources.img2;
        protected Bitmap img3 = Properties.Resources.img3;
        protected Bitmap img4 = Properties.Resources.img4;
        protected Bitmap img5 = Properties.Resources.img5;

        public Int32 size;

        public enum Item { Empty, Virus1, Virus2, Zombie1, Zombie2 };
        protected Item[,] field;
        public const Int32 ItemSize = 32;


        public Field(Field previousField)
        {
            size = previousField.size;
            field = new Item[size, size];

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    field[i, j] = previousField.field[i, j];
        }


        public Field(Int32 size)
        {
            this.size = size;
            field = new Item[size, size];

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    field[i, j] = Item.Empty;

        }

        public Int32 fitnessfunction(Boolean player1)
        {
            Int32 fitness = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    //count possible moves
                    if (searchForVirus(i, j, player1) == true)
                        fitness++;
                    if (field[i, j] == Item.Zombie2)
                        fitness+=10;
                }
            }
            return fitness;
        }

        public Int32 ratingfunction(Boolean player1)
        {
            Int32 rating = 0; 
            rating = fitnessfunction(player1) - fitnessfunction(!player1);
            
            return rating;
        }

        public Boolean isItemEmpty(Int32 x, Int32 y)
        {
            return field[x,y]==Item.Empty;
        }

        public Boolean isThereItem(Int32 x, Int32 y, Boolean player1)
        {
            Item Virus2 = player1 ? Item.Virus2 : Item.Virus1;
            return field[x, y] == Virus2;
        }

        public Boolean searchForVirus(Int32 x, Int32 y, Boolean player1)
        {
            Item Virus2 = player1 ? Item.Virus2 : Item.Virus1;
            Item Virus1 = player1 ? Item.Virus1 : Item.Virus2;
            Item Zombie1 = player1 ? Item.Zombie1 : Item.Zombie2;
            List<Point> fieldsToAnalyze = new List<Point>();
            List<Point> analyzedFields = new List<Point>();

            if (field[x, y] == Item.Empty || field[x, y] == Virus2)
            {
                fieldsToAnalyze.Add(new Point(x, y));
            }

            while (fieldsToAnalyze.Count > 0)
            {

                Point pos = fieldsToAnalyze[0];
                fieldsToAnalyze.RemoveAt(0);
                analyzedFields.Add(pos);

                Point pos1 = new Point(pos.X - 1, pos.Y - 1);
                Point pos2 = new Point(pos.X - 1, pos.Y);
                Point pos3 = new Point(pos.X - 1, pos.Y + 1);
                Point pos4 = new Point(pos.X, pos.Y - 1);
                Point pos5 = new Point(pos.X, pos.Y + 1);
                Point pos6 = new Point(pos.X + 1, pos.Y - 1);
                Point pos7 = new Point(pos.X + 1, pos.Y);
                Point pos8 = new Point(pos.X + 1, pos.Y + 1);

                #region " Fields "
                if (!analyzedFields.Contains(pos1) && pos.X > 0 && pos.Y > 0 && field[pos.X - 1, pos.Y - 1] == Virus1)
                {
                    return true;
                }
                else if (!analyzedFields.Contains(pos1) && pos.X > 0 && pos.Y > 0 && field[pos.X - 1, pos.Y - 1] == Zombie1)
                {
                    fieldsToAnalyze.Add(pos1);
                }

                if (!analyzedFields.Contains(pos2) && pos.X > 0 && field[pos.X - 1, pos.Y] == Virus1)
                {
                    return true;
                }
                else if (!analyzedFields.Contains(pos2) && pos.X > 0 && field[pos.X - 1, pos.Y] == Zombie1)
                {
                    fieldsToAnalyze.Add(pos2);
                }

                if (!analyzedFields.Contains(pos3) && pos.X > 0 && pos.Y < size - 1 && field[pos.X - 1, pos.Y + 1] == Virus1)
                {
                    return true;
                }
                else if (!analyzedFields.Contains(pos3) && pos.X > 0 && pos.Y < size - 1 && field[pos.X - 1, pos.Y + 1] == Zombie1)
                {
                    fieldsToAnalyze.Add(pos3);
                }

                if (!analyzedFields.Contains(pos4) && pos.Y > 0 && field[pos.X, pos.Y - 1] == Virus1)
                {
                    return true;
                }
                else if (!analyzedFields.Contains(pos4) && pos.Y > 0 && field[pos.X, pos.Y - 1] == Zombie1)
                {
                    fieldsToAnalyze.Add(pos4);
                }

                if (!analyzedFields.Contains(pos5) && pos.Y < size - 1 && field[pos.X, pos.Y + 1] == Virus1)
                {
                    return true;
                }
                else if (!analyzedFields.Contains(pos5) && pos.Y < size - 1 && field[pos.X, pos.Y + 1] == Zombie1)
                {
                    fieldsToAnalyze.Add(pos5);
                }

                if (!analyzedFields.Contains(pos6) && pos.X < size - 1 && pos.Y > 0 && field[pos.X + 1, pos.Y - 1] == Virus1)
                {
                    return true;
                }
                else if (!analyzedFields.Contains(pos6) && pos.X < size - 1 && pos.Y > 0 && field[pos.X + 1, pos.Y - 1] == Zombie1)
                {
                    fieldsToAnalyze.Add(pos6);
                }

                if (!analyzedFields.Contains(pos7) && pos.X < size - 1 && field[pos.X + 1, pos.Y] == Virus1)
                {
                    return true;
                }
                else if (!analyzedFields.Contains(pos7) && pos.X < size - 1 && field[pos.X + 1, pos.Y] == Zombie1)
                {
                    fieldsToAnalyze.Add(pos7);
                }

                if (!analyzedFields.Contains(pos8) && pos.X < size - 1 && pos.Y < size - 1 && field[pos.X + 1, pos.Y + 1] == Virus1)
                {
                    return true;
                }
                else if (!analyzedFields.Contains(pos8) && pos.X < size - 1 && pos.Y < size - 1 && field[pos.X + 1, pos.Y + 1] == Zombie1)
                {
                    fieldsToAnalyze.Add(pos8);
                }
                #endregion
            }
            return false;
        }

        public void setItem(Int32 x, Int32 y, Item item)
        {
            field[x, y] = item;
        }

        public void Paint(Graphics g, Boolean player)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    switch (field[i, j])
                    {
                        case Item.Empty:
                            g.DrawImage(img1, i * ItemSize, j * ItemSize, ItemSize, ItemSize);
                            break;

                        case Item.Virus1:
                            g.DrawImage(img2, i * ItemSize, j * ItemSize, ItemSize, ItemSize);
                            break;

                        case Item.Virus2:
                            g.DrawImage(img3, i * ItemSize, j * ItemSize, ItemSize, ItemSize);
                            break;

                        case Item.Zombie1:
                            g.DrawImage(img4, i * ItemSize, j * ItemSize, ItemSize, ItemSize);
                            break;

                        case Item.Zombie2:
                            g.DrawImage(img5, i * ItemSize, j * ItemSize, ItemSize, ItemSize);
                            break;
                    }

                    if (searchForVirus(i, j, player))
                        g.DrawEllipse(player ? Pens.Blue : Pens.Red, i * ItemSize + ItemSize / 3, j * ItemSize + ItemSize / 3, ItemSize/3, ItemSize/3);
                }
            }

            for (int i = 0; i < size+1; i++)
            {
                g.DrawLine(Pens.Black, 0, i * ItemSize, ItemSize*11, i * ItemSize);
                g.DrawLine(Pens.Black, i * ItemSize, 0, i * ItemSize, ItemSize * 11);
            }
        }
    }
}