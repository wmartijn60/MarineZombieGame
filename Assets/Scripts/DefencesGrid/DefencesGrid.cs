using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefencesGrid : MonoBehaviour
{
    static DefencesGrid instance;

    private static int gridSizeX = 29;
    private static int gridSizeY = 9;
    private float gridCellWidth = 0.55f;
    private float gridCellHeight = 0.55f;
    private static DefenceGridNode[,] defencesGrid;

    private bool followMouse = false;
    private GameObject spawnedObject = null;
    private static int closestGridX;
    private static int closestGridY;

    [SerializeField] private Sprite tileSprite;
    [SerializeField] private GameObject barricadeObject;
    private static Barricade barricade;
    [SerializeField] private Transform gridParent;
    [SerializeField] private Transform defenceParent;
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

    void Start() {
        instance = this;
        CreateGrid();
    }

    void Update()
    {
        /*if (Input.GetMouseButtonDown(0)) {
            spawnedObject = Instantiate(barricadeObject);
            barricade = spawnedObject.GetComponent<Barricade>();
            followMouse = true;
        }*/
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

    public void SpawnDefence() {
        if (spawnedObject != null) return;
        spawnedObject = Instantiate(barricadeObject, defenceParent);
        barricade = spawnedObject.GetComponent<Barricade>();
        followMouse = true;
    }

    private void SetDefence() {
        if (!CheckArea()) {
            Destroy(spawnedObject);
        } else {
            defencesGrid[closestGridX, closestGridY].Defence = spawnedObject;
            List<DefenceGridNode> nodesInvolved = GetArea();
            for (int i = 0; i < nodesInvolved.Count; i++) {
                nodesInvolved[i].SpotTaken = true;
            }
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

    public static void RemoveDefence(DefenceGridNode node) {
        for (int i = node.GridX - barricade.OriginPosX; i < node.GridX + barricade.GridSpaceWidth - barricade.OriginPosX; i++) {
            for (int j = node.GridY - barricade.OriginPosY; j < node.GridY + barricade.GridSpaceHeight - barricade.OriginPosY; j++) {
                if (i >= 0 && i < gridSizeX && j >= 0 && j < gridSizeY) {
                    defencesGrid[i, j].Defence = null;
                    defencesGrid[i, j].SpotTaken = false;
                }
            }
        }
    }

    public static List<DefenceGridNode> GetArea() {
        List<DefenceGridNode> nodesInvolved = new List<DefenceGridNode>();
        for (int i = closestGridX - barricade.OriginPosX; i < closestGridX + barricade.GridSpaceWidth - barricade.OriginPosX; i++) {
            for (int j = closestGridY - barricade.OriginPosY; j < closestGridY + barricade.GridSpaceHeight - barricade.OriginPosY; j++) {
                if (i >= 0 && i < gridSizeX && j >= 0 && j < gridSizeY) {
                    nodesInvolved.Add(defencesGrid[i,j]);
                }
            }
        }
        return nodesInvolved;
    }

    public static DefenceGridNode GetGridPos(GameObject defence) {
        DefenceGridNode gridPosition = null;
        for (int i = 0; i < gridSizeX; i++) {
            for (int j = 0; j < gridSizeY; j++) {
                if(defencesGrid[i,j].Defence == defence) {
                    gridPosition = defencesGrid[i, j];
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
        spawnedObject.transform.position = new Vector3(chosenTransform.position.x + gridCellWidth / 2, chosenTransform.position.y + gridCellHeight / 4, chosenTransform.position.z);
        spawnedObject.transform.rotation = chosenTransform.rotation;
    }
}
