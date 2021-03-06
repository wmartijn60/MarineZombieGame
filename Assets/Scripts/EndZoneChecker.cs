using UnityEngine;

public class EndZoneChecker : MonoBehaviour
{
    [SerializeField] private int survivorScore = 20;

    [SerializeField] private Animator coinAnim;
    [SerializeField] private Animator zombieCounterAnim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger) return;
        if (collision.tag == "Survivor")
        {
            GameManager.ChangeCoinAmount(collision.GetComponent<Survivor>().CoinsAmountToGive);
            GameManager.SurvivorSurvived();
            ScoreManager.instance.AddScore(survivorScore);
            coinAnim.SetTrigger("GetCoin");
        } 
        else if (collision.tag == "Zombie") 
        {
            GameManager.DamagePlayer();
            zombieCounterAnim.SetTrigger("TakeDamage");

        }
        if (collision.tag == "Survivor" || collision.tag == "Zombie")
        {
            Destroy(collision.gameObject, 3f);
        }
    }
}
