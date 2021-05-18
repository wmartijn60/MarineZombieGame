using UnityEngine;

public class EndZoneChecker : MonoBehaviour
{
    [SerializeField]private int survivorScore = 20;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger) return;
        if (collision.tag == "Survivor")
        {
            GameManager.ChangeCoinAmount(collision.GetComponent<Survivor>().CoinsAmountToGive);
            ScoreManager.Instance.AddScore(survivorScore);
            // activate coin animation survivor
        } else if (collision.tag == "Zombie") {
            GameManager.DamagePlayer();
        }
        if (collision.tag == "Survivor" || collision.tag == "Zombie")
        {
            // this may have to be changed to a better / proper way of doing it
            Destroy(collision.gameObject, 3f);
        }
    }
}
