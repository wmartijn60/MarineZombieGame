using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceGridNode : MonoBehaviour
{
    private GameObject defence = null;
    public GameObject Defence { get { return defence; } set { defence = value; } }
    private bool spotTaken = false;
    public bool SpotTaken { get { return spotTaken; } set { spotTaken = value; } }
    private bool allowedToPlace = true;
    public bool AllowedToPlace { get { return allowedToPlace; } set { allowedToPlace = value; } }
    private int gridX;
    public int GridX { get { return gridX; } set { gridX = value; } }
    private int gridY;
    public int GridY { get { return gridY; } set { gridY = value; } }

}
