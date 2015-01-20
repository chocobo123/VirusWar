using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace VirusWar
{
    public class TreeNode
    {
        public TreeNode parent = null;
        public List<TreeNode> children = new List<TreeNode>();
        public Field field;
        public Boolean player;
        public Int32 min = Int32.MinValue;
        public Int32 max = Int32.MaxValue;
        public Int32 rating;
        public Point pos = Point.Empty;

        public TreeNode(Field currentField, Boolean player) //without parent, first node
        {
            this.field = new Field(currentField);
            this.player = player;
        }

        public TreeNode(Field currentField, Boolean player, TreeNode parent)
        {
            this.field = new Field(currentField);
            this.player = player;
            this.parent = parent;
        }

        public void Tree(Int32 depth)
        {
            Field.Item Virus = player ? Field.Item.Virus2 : Field.Item.Virus1;
            Field.Item Zombie = player ? Field.Item.Zombie2 : Field.Item.Zombie1;

            if (depth < 2)
            {
                rating = field.ratingfunction(!player);
                return;
            }

            for (int i = 0; i < field.size; i++)
            {
                for (int j = 0; j < field.size; j++)
                {
                    if (field.searchForVirus(i, j, !player) == true)
                    {
                        Field newField = new Field(field);

                        if (newField.isItemEmpty(i, j))
                            newField.setItem(i, j, Virus);
                        else
                            newField.setItem(i, j, Zombie);

                        // create a node
                        TreeNode node = new TreeNode(newField, player, this);
                        node.pos = new Point(i, j);
                        
                        // determine the min/max of the nodes
                        foreach(TreeNode n in node.parent.children)
                        {
                            if (depth % 2 == 0)
                            {
                                if (n.rating > node.min)
                                    node.min = n.rating;  
                            }
                            else
                            {
                                if (n.rating < node.max)
                                    node.max = n.rating;
                            }
                        }

                        // alpha-cut
                        if (node.min > node.rating)
                            return;
                        // beta-cut
                        if (node.max < node.rating)
                            return;
                        
                        node.Tree(depth - 1);
                        
                        children.Add(node);
                    }
                           
                }
            }

            // determine the minimum/maximum of the children
            if (depth % 2 == 0)
                minimum();
            else
                maximum();

            
            
        }

        public void maximum()
        {
            rating = Int32.MinValue;
            foreach (TreeNode n in children)
            {
                if (n.rating > rating)
                    rating = n.rating;
            }
        }

        public void minimum()
        {
            rating = Int32.MaxValue;
            foreach (TreeNode n in children)
            {
                if (n.rating < rating)
                    rating = n.rating;
            }
        }

    }
}
