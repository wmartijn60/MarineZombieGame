using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierSwitch : MonoBehaviour
{
    [SerializeField] private List<GameObject> barriers;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.O))
        {
            EnableBarriers();
        }
        else if (Input.GetKey(KeyCode.P))
        {
            DisableBarriers();
        }
    }

    public void EnableBarriers()
    {
        for (int i = 0; i < barriers.Count; i++)
        {
            barriers[i].SetActive(true);
        }
    }

    public void DisableBarriers()
    {
        for (int i = 0; i < barriers.Count; i++)
        {
            barriers[i].SetActive(false);
        }
    }
}
