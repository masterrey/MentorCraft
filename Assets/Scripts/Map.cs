using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Map 
{
    public int[,,] mapdata;
    public Map()
    {
        mapdata = new int[100, 100, 100];
    }
}
