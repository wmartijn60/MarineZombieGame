using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveEffect : MonoBehaviour
{
    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
