using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cartographer;

namespace Cartographer{
public class Dungeon : MonoBehaviour
{
    public List<Cell> mycells=new List<Cell>();
    public void AddCell(Cell cell)
    {
        mycells.Add(cell);
    }
}
}