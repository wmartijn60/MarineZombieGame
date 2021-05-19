using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefencesGrid : MonoBehaviour
{
    static DefencesGrid instance;

    private int gridSizeX = 29;
    private int gridSizeY = 9;
    private float gridCellWidth = 0.555f;
    private float gridCellHeight = 0.555f;
    private DefenceGridNode[,] defencesGrid;

    private bool followMouse = false;
    private GameObject spawnedObject = null;
    private int closestGridX;
    private int closestGridY;
    private float distanceToClosestNode;

    [SerializeField] private Sprite tileSprite;
    [SerializeField] private Transform gridParent;
    [SerializeField] private Transform defenceParent;
    private Defence defence;
    private bool spawning = false;
   

    public void CreateGrid() {
        defencesGrid = new DefenceGridNode[gridSizeX, gridSizeY];
        for (int i = 0; i < gridSizeX; i++) {
            for (int j = 0; j < gridSizeY; j++) {
                GameObject gridplace = new GameObject();
                gridplace.name = i + " " + j;
                gridplace.transform.parent = gridParent;
                gridplace.transform.localPosition = new Vector3(gridCellWidth * i + gridCellWidth/2, gridCellHeight * j + gridCellHeight/2, 0);
                gridplace.transform.localScale = new Vector3(gridCellWidth, gridCellHeight, 1);
                gridplace.AddComponent<BoxCollider2D>().isTrigger = true;
                DefenceGridNode defenceGridNode = gridplace.AddComponent<DefenceGridNode>();
                defenceGridNode.GridX = i;
                defenceGridNode.GridY = j;

                SpriteRenderer spriteRenderer = gridplace.AddComponent<SpriteRenderer>();
                spriteRenderer.sprite = tileSprite;
                spriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);
                spriteRenderer.sortingOrder = 5;

                Collider2D[] collidedCollection = new Collider2D[5];
                ContactFilter2D filter = new ContactFilter2D();
                if(gridplace.GetComponent<BoxCollider2D>().OverlapCollider(filter, collidedCollection) > 0) {
                    defenceGridNode.AllowedToPlace = false;
                    spriteRenderer.enabled = false;
                }
                defencesGrid[i, j] = defenceGridNode;
            }
        }
    }

    void Awake() {
        instance = this;
        CreateGrid();
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0) && spawning && spawnedObject != null) {
            SetDefence();
        } else if (Input.GetMouseButtonUp(0) && !spawning && spawnedObject != null) {
            spawning = true;
        }
        if (followMouse) {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            spawnedObject.transform.position = pos;
            if (transform.hasChanged) {
                SnapToGrid();
            }
        }
    }

    public void SpawnDefence(GameObject defenceKind) {
        if (spawnedObject != null || !ItemManager.Instance.CanAfford(25)) return;
        spawnedObject = Instantiate(defenceKind, defenceParent);
        defence = spawnedObject.GetComponent<Defence>();
        if (defence == null) defence = spawnedObject.GetComponentInChildren<Defence>();
        followMouse = true;

    }

    private void SetDefence() {
        if (!CheckArea() || distanceToClosestNode >= 0.35f) {
            Destroy(spawnedObject);
        } else {
            defencesGrid[closestGridX, closestGridY].Defence = spawnedObject;
            List<DefenceGridNode> nodesInvolved = GetArea();
            for (int i = 0; i < nodesInvolved.Count; i++) {
                nodesInvolved[i].SpotTaken = true;
            }

            ItemManager.Instance.BuyItem(-25);
            defence.PlaceDefence();


        }
        followMouse = false;
        spawnedObject = null;
        spawning = false;

    }

    private bool CheckArea() {
        bool ableToPlace = true;
        List<DefenceGridNode> area = GetArea();
        for (int i = 0; i < area.Count; i++) {
            if (area[i].SpotTaken || !area[i].AllowedToPlace) {
                ableToPlace = false;
                break;
            }
        }
        return ableToPlace;
    }

    public static void StopPlacingDefence() {
        instance.gridParent.gameObject.SetActive(false);
        if (instance.spawnedObject == null) return;
        Destroy(instance.spawnedObject);
        instance.followMouse = false;
        instance.spawning = false;
        instance.spawnedObject = null;
    }

    public static void StartPlacingDefence() {
        //Debug.Log(instance);
        instance.gridParent.gameObject.SetActive(true);
    }

    public static void RemoveDefence(DefenceGridNode node, Defence defenceKind) {
        for (int i = node.GridX - defenceKind.OriginPosX; i < node.GridX + defenceKind.GridSpaceWidth - defenceKind.OriginPosX; i++) {
            for (int j = node.GridY - defenceKind.OriginPosY; j < node.GridY + defenceKind.GridSpaceHeight - defenceKind.OriginPosY; j++) {
                if (i >= 0 && i < instance.gridSizeX && j >= 0 && j < instance.gridSizeY) {
                    instance.defencesGrid[i, j].Defence = null;
                    instance.defencesGrid[i, j].SpotTaken = false;
                }
            }
        }
    }

    public static List<DefenceGridNode> GetArea() {
        List<DefenceGridNode> nodesInvolved = new List<DefenceGridNode>();
        for (int i = instance.closestGridX - instance.defence.OriginPosX; i < instance.closestGridX + instance.defence.GridSpaceWidth - instance.defence.OriginPosX; i++) {
            for (int j = instance.closestGridY - instance.defence.OriginPosY; j < instance.closestGridY + instance.defence.GridSpaceHeight - instance.defence.OriginPosY; j++) {
                if (i >= 0 && i < instance.gridSizeX && j >= 0 && j < instance.gridSizeY) {
                    nodesInvolved.Add(instance.defencesGrid[i,j]);
                }
            }
        }
        return nodesInvolved;
    }

    public static DefenceGridNode GetGridPos(GameObject defence) {
        DefenceGridNode gridPosition = null;
        for (int i = 0; i < instance.gridSizeX; i++) {
            for (int j = 0; j < instance.gridSizeY; j++) {
                if(instance.defencesGrid[i,j].Defence == defence) {
                    gridPosition = instance.defencesGrid[i, j];
                    return gridPosition;
                }
            }
        }
        return gridPosition;
    }

    private void SnapToGrid() {
        Transform chosenTransform = null;
        float chosenTransformDistance = float.MaxValue;
        for (int i = 0; i < gridSizeX; i++) {
            for (int j = 0; j < gridSizeY; j++) {
                if (defencesGrid[i, j].AllowedToPlace) {
                    float distance = Vector3.Distance(spawnedObject.transform.position, defencesGrid[i, j].transform.position);
                    if (distance < chosenTransformDistance) {
                        chosenTransform = defencesGrid[i, j].transform;
                        chosenTransformDistance = distance;
                        closestGridX = i;
                        closestGridY = j;
                    }
                }
            }
        }
        distanceToClosestNode = chosenTransformDistance;
        spawnedObject.transform.position = new Vector3(chosenTransform.position.x /*+ gridCellWidth / 2*/, chosenTransform.position.y /*+ gridCellHeight / 4*/, chosenTransform.position.z);
        spawnedObject.transform.rotation = chosenTransform.rotation;
    }
}
