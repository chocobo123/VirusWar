using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            Field.Item Virus = player ? Field.Item.Virus1 : Field.Item.Virus2;
            Field.Item Zombie = player ? Field.Item.Zombie1 : Field.Item.Zombie2;

            if (depth < 1)
            {
                rating = field.ratingfunction(player);
                
                return;
            }

            for (int i = 1; i < field.size; i++)
            {
                for (int j = 1; j < field.size; j++)
                {
                    if (field.searchForVirus(i, j, player) == true)
                    {
                        Field newField = new Field(field);

                        if (newField.isItemEmpty(i, j))
                            newField.setItem(i, j, Virus);
                        else
                            newField.setItem(i, j, Zombie);

                        TreeNode node = new TreeNode(newField, player, this);
                        
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
                        
                        node.Tree(depth - 1);

                        children.Add(node);
                    }
                           
                }
            }
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
