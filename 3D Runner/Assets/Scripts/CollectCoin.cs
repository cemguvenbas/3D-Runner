using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectCoin : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI CoinText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddCoin();
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Collision"))
        {
            Debug.Log("Touched Obstacle!...");
        }
    }

    public void AddCoin()
    {
        score++;
        CoinText.text = "Score: " + score.ToString();
    }
}
