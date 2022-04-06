using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cartographer;

namespace Cartographer{
public class Dungeon : MonoBehaviour
{
    int[] arr1=new int[]{1,2};
    int[] arr2=new int[4];
    public void Start()
    {
        arr2=arr1;
        // arr2[3]=12;
        Debug.Log(arr2[0]);
        Debug.Log(arr2[1]);
        Debug.Log(arr2[2]);
        Debug.Log(arr2[3]);

    }

    public Cell[] mycells;

    public void AddCell(Cell cell)
    {
        Cell[] myupdatedCells=new Cell[mycells.Length+1];
        for(int i =0;i<mycells.Length;i++)
        {
            myupdatedCells[i]=mycells[i];
        }
        myupdatedCells[mycells.Length+1]=cell;

        mycells=new Cell[myupdatedCells.Length];
        mycells=myupdatedCells;
    }
}
}