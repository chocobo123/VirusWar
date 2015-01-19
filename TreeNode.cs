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

        public void TreeNode(Field currentField, Boolean player)
        {
            this.field = new Field(currentField);
            this.player = player;
        }

        public void Tree(Int32 depth)
        {

            for (int i = 1; i < currentField.size; i++)
            {
                for (int j = 1; j < currentField.size; j++)
                {
                    if(currentField.searchForVirus(i, j, player))
                    children = new List<TreeNode>();
                }
            }
            for(int i=0; i<depth; i++)
            {
                if(i % 2 == 0)
                    TreeNode(currentField, !player);
                else
                    TreeNode(currentField, player);
                if()
                    currentField.ratingfunction(player);
            }
        }
    }
}
