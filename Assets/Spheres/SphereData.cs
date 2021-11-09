using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SphereData
{
    public static float DownBound = CameraStats.GetInstance().MinY;
    public Transform SphereTransform;
    public Material Material;
    public int Points;
    public int Damage;
}

