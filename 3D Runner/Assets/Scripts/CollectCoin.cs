using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CollectCoin : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI CoinText;
    public PlayerController _playerController;
    public int maxScore;
    private Animator PlayerAnim;


    private void Start()
    {
        PlayerAnim = GetComponentInChildren<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddCoin();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("End"))
        {
            _playerController.runningSpeed = 0;
            if (score >= maxScore)
            {
                //Debug.Log("You Win");
                PlayerAnim.SetBool("win", true);
            }
            else
            {
                //Debug.Log("You lose");
                PlayerAnim.SetBool("lose", true);
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Collision"))
        {
            //Debug.Log("Touched Obstacle!...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void AddCoin()
    {
        score++;
        CoinText.text = "Score: " + score.ToString();
    }
}
