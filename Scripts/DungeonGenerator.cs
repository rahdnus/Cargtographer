using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cartographer{
public class DungeonGenerator:MonoBehaviour
{
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
    public void Awake()
    {
        generateDungeon();
    }
    public void generateDungeon()
    {
        //Instantiate Graph
        DungeonGraph graph=DungeonGraphGenerator.Instance.generateDungeonGraph(1001);

        
        //instantiate empty Dungeon
        GameObject DungeonObject=new GameObject("Dungeon");
        Dungeon dungeon=DungeonObject.AddComponent<Dungeon>();
        
        //first place dungeonSO.startcellPrefab at origin
        
        GameObject startCellObject=GameObject.Instantiate(dungeonSO.StartCellPrefab.gameObject,Vector3.zero,Quaternion.identity,dungeon.transform);

        dungeon.AddCell(    
        startCellObject.GetComponent<Cell>()
        );

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
         }  

        /* get gate and assign intermediate cell using gate direction*/
        /* offset position using bounds */
        /*Get intermediate cells thru pacing graph and connect based on GateDirection
        Reject current cell if it encroaches on previously placed cells,Seal the gate if no new cell is compatible
        Prioritize POI cells they must be there.*/
    }
}

}