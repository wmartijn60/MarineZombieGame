using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefencesGrid : MonoBehaviour
{
    private int gridSizeX;
    private int gridSizeY;
    private GameObject[,] defencesGrid;
    private float gridCellWidth;
    private float gridCellHeight;

    private bool followMouse = false;
    private GameObject spawnedObject = null;

    public void CreateGrid(int gridWidth, int gridHeight, float cellWidth, float cellHeight) {
        gridSizeX = gridWidth;
        gridSizeY = gridHeight;
        gridCellWidth = cellWidth;
        gridCellHeight = cellHeight;

        defencesGrid = new GameObject[gridSizeX, gridSizeY];
        for (int i = 0; i < gridSizeX; i++) {
            for (int j = 0; j < gridSizeY; j++) {
                GameObject gridplace = new GameObject();
                gridplace.transform.parent = transform;
                gridplace.transform.localPosition = new Vector3(gridCellWidth * i + gridCellWidth/2, gridCellHeight * j + gridCellHeight/2, 0);
                gridplace.transform.localScale = new Vector3(gridCellWidth, gridCellHeight, 1);
                gridplace.AddComponent<BoxCollider2D>().isTrigger = true;
                defencesGrid[i, j] = gridplace;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateGrid(20,20,1f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            spawnedObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            followMouse = true;
        }
        if (Input.GetMouseButtonUp(0) && spawnedObject != null) {
            followMouse = false;
            Transform chosenTransform = null;
            float chosenTransformDistance = float.MaxValue;
            for (int i = 0; i < gridSizeX; i++) {
                for (int j = 0; j < gridSizeY; j++) {
                    float distance = Vector3.Distance(spawnedObject.transform.position, defencesGrid[i,j].transform.position);
                    if (distance < chosenTransformDistance) {
                        chosenTransform = defencesGrid[i, j].transform;
                        chosenTransformDistance = distance;
                    }
                }
            }
            spawnedObject.transform.position = chosenTransform.position;
            spawnedObject.transform.rotation = chosenTransform.rotation;
            spawnedObject = null;
        }
        if (followMouse) {
            spawnedObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
