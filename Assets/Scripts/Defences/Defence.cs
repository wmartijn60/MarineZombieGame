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
    [SerializeField] private SpriteRenderer placementMark;
    [SerializeField] private SpriteRenderer defenceSprite;
    [SerializeField] private Sprite firstFrame;
    [SerializeField] private protected Animator spawnAnimator;


    public virtual void PlaceDefence() {
        defenceSprite.sprite = firstFrame;
        spawnAnimator.SetTrigger("PlaceDefence");
        placementMark.enabled = false;
        defenceSprite.color = new Color(1f, 1f, 1f, 1);
       
        // do something with the placement animation here


    }

    public virtual void Destroyed() {
        // play destruction animation
        //anim.SetBool("isAlive", false);
        DefenceGridNode gridPos = DefencesGrid.GetGridPos(gameObject);
        DefencesGrid.RemoveDefence(gridPos, this);
        //Destroy(gameObject, 1f); // change time depending on animation duration
    }
}
