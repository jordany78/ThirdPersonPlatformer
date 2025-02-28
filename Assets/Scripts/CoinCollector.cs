using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] public int coinCount = 0;

    void Start()
    {
        if (coinText != null)
        {
            coinText.text = "Score: " + coinCount;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coinCount++;

            Destroy(other.gameObject);

            if (coinText != null)
            {
                coinText.text = $"Score: {coinCount}";
            }

            Debug.Log("Coins Collected: " + coinCount);
        }
    }
}