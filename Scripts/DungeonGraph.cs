// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
namespace Cartographer{
    public class DungeonGraph
    {   
        public Node startNode;
    }
    public class Node{
        public Cell.Type type;
        public BranchNode[] branchNodes;//0->1->2->3
        public Node nextNode;
        public Node(Cell.Type _type)
        {
            this.type=_type;
        }
    }
    public class BranchNode{
        public Cell.Type type;
    }
}

