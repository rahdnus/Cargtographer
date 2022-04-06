using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Cartographer{

[CreateAssetMenu(fileName="Dungeon",menuName="SO/Dungeon")]
public class DungeonSO : ScriptableObject
{
   public GameObject[] CellPrefab;  
   public GameObject StartCellPrefab,EndCellPrefab; 
}
}