using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cartographer
{
public class Utils 
{
 private static Utils instance=null;

  public static Utils Instance
  {
      get{
          if(instance==null)
          {
            instance=new Utils();
          }
        return instance;
      }
  }

    public Gate getRandomGate(Gate[] gates,Direction direction)
    {
        while(true)
        {
            int index=Random.Range(0,gates.Length);
            if(gates[index].direction==direction)
                return gates[index];
        }
        
    }
    public int getIndexofGate(Gate[] gates,Gate gate)
    {
        for(int i=0;i<gates.Length;i++)
        {
            if(gates[i]==gate)
            {
                return i;
            }
        }
        Debug.Log(-1);
        return -1;
    }
    public int getRandomNum(int Length)
    {
        return Random.Range(0,Length);
    }
   public bool hasGateofDirection(Gate[] gates,Direction direction)
   {
       foreach(Gate gate in gates)
       {
           if(gate.direction==direction)
           {
               return true;
           }
       }
       return false;
   }
  public Direction getOppositeDirection(Direction inputDirection)
  {
       switch(inputDirection)
        {
            case Direction.North:
                return Direction.South;
            case Direction.East:
                return Direction.West;                
            case Direction.West:
                return Direction.East;
            case Direction.South:
                return Direction.North;
            case Direction.undefined:
                return Direction.undefined;
            default:
                return Direction.undefined;
            
        }
  }
}
}

