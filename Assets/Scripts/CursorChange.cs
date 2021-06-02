using UnityEngine;

public class CursorChange : MonoBehaviour
{
    public Texture2D cursor;
    public Vector3 positionOffset = Vector3.zero;

    void Start()
    {
        Cursor.SetCursor(cursor, positionOffset, CursorMode.Auto);
    }
}
