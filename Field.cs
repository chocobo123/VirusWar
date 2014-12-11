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
        protected Bitmap img1 = new Bitmap(@"..\..\images\img1.png");
        protected Bitmap img2 = new Bitmap(@"..\..\images\img2.png");
        protected Bitmap img3 = new Bitmap(@"..\..\images\img3.png");
        protected Bitmap img4 = new Bitmap(@"..\..\images\img4.png");
        protected Bitmap img5 = new Bitmap(@"..\..\images\img5.png");

        protected Int32 size;

        public enum Item { Empty, Virus1, Virus2, Zombie1, Zombie2 };
        protected Item[,] field;
        public const Int32 ItemSize = 32;

        public Field(Int32 size)
        {
            this.size = size;
            field = new Item[size, size];

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    field[i, j] = Item.Empty;

            field[2, 2] = Item.Virus1;
            field[3, 2] = Item.Virus2;
            field[4, 2] = Item.Zombie1;
            field[5, 2] = Item.Zombie2;
        }

        public Boolean isItemEmpty(Int32 x, Int32 y)
        {
            return field[x,y]==Item.Empty;
        }

        public Boolean isThereItem(Int32 x, Int32 y)
        {
            return field[x, y] == Item.Virus2;
        }

        public void searchForVirus(Int32 x, Int32 y)
        {
            Int32 i = x;
            Int32 j = y;
            List<Item> neighbor = new List<Item>();

            
                
                if (field[i - 1, j - 1] == Item.Zombie1)
                    neighbor.Add(field[i - 1, j - 1]);

                if (field[i - 1, j] == Item.Zombie1)
                    neighbor.Add(field[i - 1, j]);

                if (field[i - 1, j + 1] == Item.Zombie1)
                    neighbor.Add(field[i - 1, j + 1]);

                if (field[i, j - 1] == Item.Zombie1)
                    neighbor.Add(field[i, j - 1]);

                if (field[i, j + 1] == Item.Zombie1)
                    neighbor.Add(field[i, j + 1]);

                if (field[i + 1, j - 1] == Item.Zombie1)
                    neighbor.Add(field[i + 1, j - 1]);

                if (field[i + 1, j] == Item.Zombie1)
                    neighbor.Add(field[i + 1, j]);

                if (field[i + 1, j + 1] == Item.Zombie1)
                    neighbor.Add(field[i + 1, j + 1]);
                

            
        }

        public void setItem(Int32 x, Int32 y, Item item)
        {
            field[x, y] = item;
        }

        public void Paint(Graphics g)
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
