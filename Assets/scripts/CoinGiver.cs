using UnityEngine;

public class CoinGiver : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Survivor") {
            GameManager.ChangeCoinAmount(collision.GetComponent<Survivor>().CoinsAmountToGive);
        }
    }
}
