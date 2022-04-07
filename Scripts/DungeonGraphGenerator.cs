using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cartographer;

namespace Cartographer
{
    public class DungeonGraphGenerator
    {
        private static DungeonGraphGenerator instance;
        public static DungeonGraphGenerator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DungeonGraphGenerator();
                }
                return instance;
            }
        }
        public DungeonGraph generateDungeonGraph(int seed)
        {
            Random.InitState(seed);

            int numofNodes=Random.Range(0,20);
            DungeonGraph graph=new DungeonGraph();
            
            Node currentNode;
            graph.startNode=new Node(Cell.Type.Terminal);
            
            currentNode=graph.startNode;
            numofNodes--;
            while(numofNodes!=1)
            {

                currentNode.nextNode=new Node(Cell.Type.Arena);
                currentNode.branchNodes=new BranchNode[1];
                /* for loop for each branch node */
                currentNode=currentNode.nextNode;
                
                numofNodes--;
                
            }
            currentNode=new Node(Cell.Type.Terminal);

            return null;
        }
    }
}
