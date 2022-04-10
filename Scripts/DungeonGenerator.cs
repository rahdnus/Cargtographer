using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cartographer{
public class DungeonGenerator:MonoBehaviour
{
    [SerializeField] int graphSeed;
    private static DungeonGenerator instance;
    public static DungeonGenerator Instance{
        get{
            if(instance==null)
            {
                instance=new DungeonGenerator();
            }
            return instance;
        }
    }
    [SerializeField] DungeonSO dungeonSO;
    public void Start()
    {
        StartCoroutine(generateDungeon());
    }
    IEnumerator generateDungeon()
    {
        //Instantiate Graph


        DungeonGraph graph=DungeonGraphGenerator.Instance.generateDungeonGraph(graphSeed);

        graph.display();
        
        //instantiate empty Dungeon
        
        GameObject DungeonObject=new GameObject("Dungeon");
        Dungeon dungeon=DungeonObject.AddComponent<Dungeon>();
        
        Node currentNode=graph.startNode;
        Cell startCell=dungeonSO.getCellofType(Cell.Type.Start,Direction.undefined);

        GameObject startCellObject=GameObject.Instantiate(startCell.gameObject,Vector3.zero,Quaternion.identity,dungeon.transform);

        dungeon.AddCell(    
        startCellObject.GetComponent<Cell>()
        );
        
        Cell previousCell=startCellObject.GetComponent<Cell>();
        
        currentNode=currentNode.nextNode;

        while(currentNode!=null)
        {
            bool goodfit=false;
           
            int firstgateIndex=Utils.Instance.getRandomGate(previousCell.gates,Direction.undefined);
            
            int gateindex=firstgateIndex;

            while(!goodfit)
            {
                gateindex=(gateindex)%previousCell.gates.Length;
                Debug.Log(gateindex);
         

                Direction direction=Utils.Instance.getOppositeDirection(previousCell.gates[gateindex].direction);
                
                Cell.Type type=currentNode.type;
              
                Debug.Log(type.ToString()+" "+direction.ToString());
                Cell cell1=dungeonSO.getCellofType(currentNode.type,direction);
                GameObject temp=cell1.gameObject;
                Debug.Log(cell1.gameObject.name);
                GameObject cellGameObject=GameObject.Instantiate
                (
                temp,
                Vector3.zero,
                Quaternion.identity,
                dungeon.transform
                );
            
            
            Cell cell=cellGameObject.GetComponent<Cell>();

            int newgateindex=Utils.Instance.getRandomGate(cell.gates,direction);

            Vector3 offset=cellGameObject.transform.position-cell.gates[newgateindex].transform.position;
            Vector3 spawnpoint=previousCell.gates[gateindex].transform.position+offset;

            cellGameObject.transform.position=spawnpoint;

            if(Utils.Instance.checkCellCollision(cell,dungeon))
            {
                Debug.Log("collision");
                gateindex++;
                Destroy(cellGameObject);
                continue;
            }

            goodfit=true;
            dungeon.AddCell(cell);

            //once finialised and conflictless
            previousCell.gates[gateindex].shut=true;
            cell.gates[newgateindex].shut=true;
            previousCell=cell;
            currentNode=currentNode.nextNode;

            } 
         
            yield return new WaitForSeconds(0.5f);
            
        }
            /* 
             TODO(Node)  
                ->check if the cellprefab has required gate direction 
                    ->try again on conflict
                ->Intanstiate->AddCell->Offset
                ->Check bounds
                    ->try again on conflict
             */

            //OLD GameObject cellGameObject=GameObject.Instantiate(cellprefab.gameObject,position,Quaternion.identity,dungeon.transform);
            //OLD dungeon.AddCell(cellGameObject.GetComponent<Cell>());
            
       
     

        /*
            TODO(BranchNode)
             ->next start filling gates with branchnodes 
             ->Offset them accordingly
             ->Check bounds
                    -> try again on conflict
            */
        
        //first place dungeonSO.startcellPrefab at origin
        
        //OLD GameObject startCellObject=GameObject.Instantiate(dungeonSO.StartCellPrefab.gameObject,Vector3.zero,Quaternion.identity,dungeon.transform);

        //OLD dungeon.AddCell(    
        // startCellObject.GetComponent<Cell>()
        // );

        /* OLD
        Gate firstGate=dungeon.mycells[0].gates[1];

        Direction direction=firstGate.direction;
        Direction requiredDirection=Utils.Instance.getOppositeDirection(direction);
        
        Vector3 nextPosition=firstGate.transform.position;
       
        Cell newCell=dungeonSO.EndCellPrefab.GetComponent<Cell>();
       
        foreach(Gate gate in newCell.gates)
         {
             if(gate.direction==requiredDirection)
             {
                GameObject cellObject=GameObject.Instantiate(dungeonSO.EndCellPrefab.gameObject,Vector3.zero,Quaternion.identity,dungeon.transform);
                Cell cell=cellObject.GetComponent<Cell>();
                dungeon.AddCell(cell);

                Vector3 offset=newCell.transform.position-gate.transform.position;
                cellObject.transform.position=nextPosition+offset;
                break;
             }
         }   */


        /* get gate and assign intermediate cell using gate direction*/
        /* offset position using bounds */
        /*Get intermediate cells thru pacing graph and connect based on GateDirection
        Reject current cell if it encroaches on previously placed cells,Seal the gate if no new cell is compatible
        Prioritize POI cells they must be there.*/
    }
}

}