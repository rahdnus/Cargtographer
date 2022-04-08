using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Cartographer{

[CreateAssetMenu(fileName="Dungeon",menuName="SO/Dungeon")]
public class DungeonSO : ScriptableObject
{
   public Cell[] ArenaCellPrefabs;
   public Cell[] CorridorCellPrefabs;  

   public Cell StartCellPrefab,EndCellPrefab; 

   public Cell getCellofType(Cell.Type type,Direction direction)
   {
        int cellIndex=-1;
        switch(type)
          {
            case Cell.Type.Start:
                return StartCellPrefab;
            case Cell.Type.Arena:
                while(true)
                {
                 cellIndex = Random.Range(0, ArenaCellPrefabs.Length);
                 if(Utils.Instance.hasGateofDirection(ArenaCellPrefabs[cellIndex].gates,direction))
                      return ArenaCellPrefabs[cellIndex];
                }
           
            case Cell.Type.Corridor:
             while(true)
                {

                cellIndex = Random.Range(0, CorridorCellPrefabs.Length);
                 if(Utils.Instance.hasGateofDirection(CorridorCellPrefabs[cellIndex].gates,direction))
                    return CorridorCellPrefabs[cellIndex];
                }
            case Cell.Type.POI:
                return null;
            case Cell.Type.End:
                return EndCellPrefab;
            case Cell.Type.undefined:
                Debug.LogWarning("Undefined Cell Type");
                Debug.Break();
                return null;
            default:
                Debug.LogError("Invalid Type of Cell");
                Debug.Break();
                return null;
          }
   }
}
public class CellGroup
{

}
}