using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cartographer{
public class Cell : MonoBehaviour
{
    [System.Serializable]
   public enum Type{undefined,Arena,Corridor,POI,Start,End}
   public Type type;
//    public Transform center;
   public Gate[] gates;
   public Bounds bounds;



}

[System.Serializable]
public class Bounds{
    public float x0,x1;
    public float y0,y1;

[HideInInspector]public float skinWidth;
    Bounds()
    {
        skinWidth=0.125f;
    }
}

[System.Serializable]
public class Gate{
    public Transform transform;
    public bool shut=false;
    public Direction direction;

}

[System.Serializable]
public enum Direction{
    undefined,North,East,West,South
}

}