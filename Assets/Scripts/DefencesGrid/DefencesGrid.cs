using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefencesGrid : MonoBehaviour
{
    private int gridSizeX;
    private int gridSizeY;
    private DefenceGridNode[,] defencesGrid;
    private float gridCellWidth;
    private float gridCellHeight;

    private bool followMouse = false;
    private GameObject spawnedObject = null;
    private int closestGridX;
    private int closestGridY;

    [SerializeField] private Sprite tileSprite;
    [SerializeField] private GameObject barricadeObject;
    private Barricade barricade;

    //private List<DefenceGridNode> nodesInvolved = new List<DefenceGridNode>();

    public void CreateGrid(int gridWidth, int gridHeight, float cellWidth, float cellHeight) {
        gridSizeX = gridWidth;
        gridSizeY = gridHeight;
        gridCellWidth = cellWidth;
        gridCellHeight = cellHeight;

        defencesGrid = new DefenceGridNode[gridSizeX, gridSizeY];
        for (int i = 0; i < gridSizeX; i++) {
            for (int j = 0; j < gridSizeY; j++) {
                GameObject gridplace = new GameObject();
                gridplace.name = i + " " + j;
                gridplace.transform.parent = transform;
                gridplace.transform.localPosition = new Vector3(gridCellWidth * i + gridCellWidth/2, gridCellHeight * j + gridCellHeight/2, 0);
                gridplace.transform.localScale = new Vector3(gridCellWidth, gridCellHeight, 1);
                gridplace.AddComponent<BoxCollider2D>().isTrigger = true;
                DefenceGridNode defenceGridNode = gridplace.AddComponent<DefenceGridNode>();

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

    // Start is called before the first frame update
    void Start()
    {
        CreateGrid(29,9,0.55f,0.55f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            spawnedObject = Instantiate(barricadeObject);
            barricade = spawnedObject.GetComponent<Barricade>();
            followMouse = true;
        }
        if (Input.GetMouseButtonUp(0) && spawnedObject != null) {
            if (/*defencesGrid[closestGridX, closestGridY].SpotTaken*/ !CheckArea()) {
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

    private List<DefenceGridNode> GetArea() {
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

    /*private void OnDrawGizmos() {
        if (followMouse) {
            Transform chosenTransform = null;
            float chosenTransformDistance = float.MaxValue;
            for (int i = 0; i < gridSizeX; i++) {
                for (int j = 0; j < gridSizeY; j++) {
                    float distance = Vector3.Distance(spawnedObject.transform.position, defencesGrid[i, j].transform.position);
                    if (distance < chosenTransformDistance) {
                        chosenTransform = defencesGrid[i, j].transform;
                        chosenTransformDistance = distance;
                    }
                }
            }
            spawnedObject.transform.position = chosenTransform.position;
            spawnedObject.transform.rotation = chosenTransform.rotation;
        }
    }*/
}
