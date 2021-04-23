using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField]private float explodeDelay = 1f;
    [SerializeField]private Animator animator;
    public List<GameObject> slimePuddles;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Zombie")
        {
            animator.SetTrigger("Explode");
        }
    }

    void OnDestroy()
    {
        int r = Random.Range(0, slimePuddles.Count);
        Instantiate(slimePuddles[r],transform.position,Quaternion.identity);
    }
}
