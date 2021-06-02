using System.Collections.Generic;
using UnityEngine;

public class Mine : Defence
{
    [SerializeField] private float explodeDelay = 1f;
    [SerializeField] private Animator animator;
    public List<GameObject> slimePuddles;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Zombie")
        {
            animator.SetTrigger("Explode");
        }
    }

    void OnDestroy()
    {
        if (GameManager.PlacingState) return;
        Destroyed();
        int r = Random.Range(0, slimePuddles.Count);
        Instantiate(slimePuddles[r],transform.position,Quaternion.identity);
    }

    public override void Destroyed()
    {
        DefenceGridNode gridPos = DefencesGrid.GetGridPos(gameObject.transform.parent.gameObject);
        DefencesGrid.RemoveDefence(gridPos, this);
    }
}
