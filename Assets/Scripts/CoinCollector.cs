using TMPro;
using UnityEngine;
using UnityEngine.UI; // Required for UI components

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] public int coinCount = 0;

    void Start()
    {
        // Initialize the UI Text
        if (coinText != null)
        {
            coinText.text = "Score: " + coinCount;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player collided with a coin
        if (other.CompareTag("Coin"))
        {
            // Increment the coin count
            coinCount++;

            // Destroy the coin object
            Destroy(other.gameObject);

            // Update the UI Text
            if (coinText != null)
            {
                coinText.text = $"Score: {coinCount}";
            }

            // Log the number of coins collected (for testing)
            Debug.Log("Coins Collected: " + coinCount);
        }
    }
}