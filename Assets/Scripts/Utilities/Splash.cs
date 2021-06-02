using UnityEngine;

public class Splash : MonoBehaviour
{
    [SerializeField] private GameObject impactLocation;
    [SerializeField] private GameObject puddle1;
    [SerializeField] private GameObject puddle2;
    [SerializeField] private ImpactDamage impactDamage;

    public void MakeASplash()
    {
        impactDamage.DamageEnemies();
        int r = Random.Range(0,2);
        if (r == 0)
        {
            GameObject puddle = Instantiate(puddle1,impactLocation.transform.position,Quaternion.identity);
            puddle.GetComponent<Animator>().SetTrigger("Puddle1");
        }
        else
        {
            GameObject puddle = Instantiate(puddle2, impactLocation.transform.position, Quaternion.identity);
            puddle.GetComponent<Animator>().SetTrigger("Puddle2");
        }
    }
}
