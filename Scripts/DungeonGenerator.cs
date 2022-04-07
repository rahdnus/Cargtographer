using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cartographer;

namespace Cartographer{


public class DungeonGenerator:MonoBehaviour
{
    public static DungeonGenerator instance;
    [SerializeField] DungeonSO dungeonSO;
    public void Awake()
    {
        instance=this;
        generateDungeon();
    }
    public void generateDungeon()
    {
        //instante empty Dungeon
        
        GameObject DungeonObject=new GameObject("Dungeon");
        Dungeon dungeon=DungeonObject.AddComponent<Dungeon>();
        
        //first place dungeonSO.startcellPrefab at origin
        
        GameObject startCellObject=GameObject.Instantiate(dungeonSO.StartCellPrefab,Vector3.zero,Quaternion.identity,dungeon.transform);

        dungeon.AddCell(    
        startCellObject.GetComponent<Cell>()
        );

        Gate firstGate=dungeon.mycells[0].gates[0];

        Direction direction=firstGate.direction;
        Direction requiredDirection=Utils.Instance.getOppositeDirection(direction);
        
        Vector3 nextPosition=firstGate.transform.position;
       
        Cell newCell=dungeonSO.EndCellPrefab.GetComponent<Cell>();
       
        foreach(Gate gate in newCell.gates)
         {
             if(gate.direction==requiredDirection)
             {
                GameObject cellObject=GameObject.Instantiate(dungeonSO.EndCellPrefab,Vector3.zero,Quaternion.identity,dungeon.transform);
                Cell cell=cellObject.GetComponent<Cell>();
                dungeon.AddCell(cell);


                Vector3 offset=newCell.transform.position-gate.transform.position;
                cellObject.transform.position=nextPosition+offset;

                // if(requiredDirection==Direction.South)
                // {

                // }
                // if(requiredDirection==Direction.North)
                // {
                //       float height=newCell.center.position.y-gate.transform.position.y;
                //       offset=nextPosition+Vector3.up*height;
                // }
                // else if(requiredDirection==Direction.West||requiredDirection==Direction.East)
                // {
                //       float width=cell.bounds.x1-cell.bounds.x0;
                //       offset=nextPosition+Vector3.forward*width;
                // }
                break;
             }
         }  

        /* get gate and assign intermediate cell using gate direction*/
        /* offset position using bounds */
        /*Get intermediate cells thru pacing graph and connect based on GateDirection
        Reject current cell if it encroaches on previously placed cells,Seal the gate if no new cell is compatible
        Prioritize POI cells they must be there.*/
    }
}

}