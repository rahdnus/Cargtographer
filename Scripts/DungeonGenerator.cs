using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cartographer;

namespace Cartographer{


public class DungeonGenerator 
{
    public static DungeonGenerator instance;
    [SerializeField] DungeonSO dungeonSO;
    public void generateDungeon()
    {
        //instante empty Dungeon
        
        GameObject DungeonObject=new GameObject("Dungeon");
        Dungeon dungeon=DungeonObject.AddComponent<Dungeon>();
        
        //first place dungeonSO.startcellPrefab at origin
        
        GameObject.Instantiate(dungeonSO.StartCellPrefab,Vector3.zero,Quaternion.identity,dungeon.transform);


        /*Get intermediate cells thru pacing graph and connect based on GateDirection
        Reject current cell if it encroaches on previously placed cells,Seal the gate if no new cell is compatible
        Prioritize POI cells they must be there.*/

        GameObject.Instantiate(dungeonSO.EndCellPrefab,Vector3.zero,Quaternion.identity,dungeon.transform);
        

        


        
    }
}

}