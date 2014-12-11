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

        public enum Item { Empty, Virus1, Virus2, Zomby1, Zomby2 };
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
            field[4, 2] = Item.Zomby1;
            field[5, 2] = Item.Zomby2;
        }

        public Boolean isItemEmpty(Int32 x, Int32 y)
        {
            
            return field[x,y]==Item.Empty;
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

                        case Item.Zomby1:
                            g.DrawImage(img4, i * ItemSize, j * ItemSize, ItemSize, ItemSize);
                            break;

                        case Item.Zomby2:
                            g.DrawImage(img5, i * ItemSize, j * ItemSize, ItemSize, ItemSize);
                            break;
                    }
                }
            }

            //Linien ins Spielfeld zeichen
            for (int i = 0; i < size+1; i++)
            {
                g.DrawLine(Pens.Black, 0, i * ItemSize, ItemSize*11, i * ItemSize);
                g.DrawLine(Pens.Black, i * ItemSize, 0, i * ItemSize, ItemSize * 11);
            }
        }
    }
}
