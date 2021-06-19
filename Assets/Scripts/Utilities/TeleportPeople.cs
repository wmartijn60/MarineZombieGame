using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPeople : MonoBehaviour
{
    [SerializeField] private Collider2D area;

    private Vector3 teleportPos = new Vector3 (3, -4, 0);

    public List<GameObject> inRange;

    public void TeleportHumans()
    {
        for (int i = 0; i < inRange.Count; i++)
        {
            if (inRange[i] != null)
            {
                inRange[i].GetComponent<Transform>().position =teleportPos;
            }
            else
            {
                inRange.RemoveAt(i);
            }

        }
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Survivor")
        {
            inRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Survivor")
        {
            inRange.Remove(other.gameObject);
        }
    }
}
