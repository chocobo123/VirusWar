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

        public TreeNode(Field currentField)
        {
            //for (int i = 1; i < Field.field.size; i++ )
                children = new List<TreeNode>();
        }
    }
}
