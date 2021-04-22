using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour
{
    private HealthSystem health;
    [SerializeField] private int gridSpaceWidth;
    public int GridSpaceWidth { get { return gridSpaceWidth; } }
    [SerializeField] private int gridSpaceHeight;
    public int GridSpaceHeight { get { return gridSpaceHeight; } }
    [SerializeField] private int originPosX;
    public int OriginPosX { get { return originPosX; } }
    [SerializeField] private int originPosY;
    public int OriginPosY { get { return originPosY; } }
    public Animator anim;

    void Start()
    {
        health = GetComponent<HealthSystem>();
        health.died += Destroyed;
    }

    private void Destroyed() {
        // play destruction animation
        //anim.SetBool("isAlive", false);
        DefenceGridNode gridPos = DefencesGrid.GetGridPos(gameObject);
        DefencesGrid.RemoveDefence(gridPos);
        Destroy(gameObject, 1f); // change time depending on animation duration
    }
}
