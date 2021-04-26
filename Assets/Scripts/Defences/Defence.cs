using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defence : MonoBehaviour
{
    [SerializeField] private int gridSpaceWidth;
    public int GridSpaceWidth { get { return gridSpaceWidth; } }
    [SerializeField] private int gridSpaceHeight;
    public int GridSpaceHeight { get { return gridSpaceHeight; } }
    [SerializeField] private int originPosX;
    public int OriginPosX { get { return originPosX; } }
    [SerializeField] private int originPosY;
    public int OriginPosY { get { return originPosY; } }

    public virtual void Destroyed() {
        // play destruction animation
        //anim.SetBool("isAlive", false);
        DefenceGridNode gridPos = DefencesGrid.GetGridPos(gameObject);
        DefencesGrid.RemoveDefence(gridPos);
        Destroy(gameObject, 1f); // change time depending on animation duration
    }
}
