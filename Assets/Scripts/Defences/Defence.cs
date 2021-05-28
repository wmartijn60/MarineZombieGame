using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defence : MonoBehaviour
{
    [System.Serializable] public struct PlacementMark {
        public GameObject marker;
        public Sprite sprite;
    }
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
    [SerializeField] private List<PlacementMark> spaceTakingMarks;
    public List<PlacementMark> SpaceTakingMarks { get { return spaceTakingMarks; } }

    public virtual void PlaceDefence() {
        defenceSprite.sprite = firstFrame;
        spawnAnimator.SetTrigger("PlaceDefence");
        placementMark.enabled = false;
        defenceSprite.color = new Color(1f, 1f, 1f, 1);
        spaceTakingMarks[0].marker.SetActive(false);
        spaceTakingMarks[1].marker.SetActive(true);
        spaceTakingMarks[1].marker.GetComponent<Animator>().enabled = false;
        spaceTakingMarks[1].marker.GetComponent<SpriteRenderer>().sprite = spaceTakingMarks[1].sprite;
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
