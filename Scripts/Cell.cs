using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cartographer{
public class Cell : MonoBehaviour
{
    [System.Serializable]
   public enum Type{undefined, Arena, Corridor, POI, Terminal}
   public Type type;
   public Gate[] gates;
   public Vector3 center;
   public Bounds cellBound;
}

[System.Serializable]
public class Bounds{
    public float x0,x1;
    public float y0,y1;
}

[System.Serializable]
public class Gate{
    public Vector3 position;
    public Direction direction;
}

[System.Serializable]
public enum Direction{
    undefined,North,East,West,South
}

}