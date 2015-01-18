using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirusWar
{
    class TreeNode
    {
        public TreeNode parents;
        public List<TreeNode> children;

        public void TreeNode(Field currentField, Boolean player)
        {
            for (int i = 1; i < currentField.size; i++)
            {
                for (int j = 1; j < currentField.size; j++)
                {
                    if(currentField.searchForVirus(i, j, player))
                    children = new List<TreeNode>();
                }
            }
        }

        public void Tree(Int32 depth, Field currentField, Boolean player)
        {
            for(int i=0; i<depth; i++)
            {
                TreeNode(currentField, player);
            }
        }
    }
}
