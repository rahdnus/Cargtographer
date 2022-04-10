using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cartographer{
public class Dungeon : MonoBehaviour
{
    public List<Cell> mycells=new List<Cell>();
/*     // TEMP 
    public Cell temp;
 */    
    public void AddCell(Cell cell)
    {

        mycells.Add(cell);
    }
 /*    public void Update()
    {
        if(Utils.Instance.checkCellCollision(temp,this))
        {
            Debug.Log("colliding");
        }
    } */
}
}