using UnityEngine;

public class EndZoneChecker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger) return;
        if (collision.tag == "Survivor")
        {
            GameManager.ChangeCoinAmount(collision.GetComponent<Survivor>().CoinsAmountToGive);
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
