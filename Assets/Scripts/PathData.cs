using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PathData", order = 1)]
public class PathData : ScriptableObject
{
    public Vector2[] position;
}
