using System.Collections.Generic;
using UnityEngine;

public class SlowArea : MonoBehaviour
{
    [SerializeField] private float effectTime = 1f;
    [SerializeField] private float slowSpeed = 0.2f;
    [SerializeField] private Collider2D area;

    public List<GameObject> inRange;

    void Start()
    {
        Destroy(gameObject, effectTime);
        SlowEntities();
    }

    public void SlowEntities()
    {
        for (int i = 0; i < inRange.Count; i++)
        {
            if (inRange[i] != null)
            {
                if (inRange[i].tag == "Zombie")
                {
                    inRange[i].GetComponent<Zombie>().speed -= slowSpeed;
                }
                else
                {
                    inRange[i].GetComponent<Survivor>().speed -= slowSpeed;
                }
            }
            else
            {
                inRange.RemoveAt(i);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Zombie" || other.tag == "Survivor")
        {
            if (other.gameObject.tag == "Zombie")
            {
                other.GetComponent<Zombie>().speed -= slowSpeed;
            }
            else
            {
                other.GetComponent<Survivor>().speed -= slowSpeed;
            }
            inRange.Remove(other.gameObject);
        }
        inRange.Add(other.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Zombie" || other.tag == "Survivor")
        {
            if (other.gameObject.tag == "Zombie")
            {
                other.GetComponent<Zombie>().speed += slowSpeed;
            }
            else
            {
                other.GetComponent<Survivor>().speed += slowSpeed;
            }
            inRange.Remove(other.gameObject);
        }
    }

    private void OnDestroy()
    {
        for (int i = 0; i < inRange.Count; i++)
        {
            if (inRange[i] != null)
            {
                if (inRange[i].tag == "Zombie")
                {
                    inRange[i].GetComponent<Zombie>().speed += slowSpeed;
                }
                else
                {
                    inRange[i].GetComponent<Survivor>().speed += slowSpeed;
                }
            }
            else
            {
                inRange.RemoveAt(i);
            }
        }
    }
}
