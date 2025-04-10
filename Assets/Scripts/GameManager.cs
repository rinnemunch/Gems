using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gem;

    int score = 0;

    public Text scoreText;
    bool win = false;
    public Image winText;
    
    void Start()
    {
        Spawn();

        InvokeRepeating("Spawn", 1f, 1f); // Call Spawn every 1 second
    }

    
    void Update()
    {
        if (win == true)
        {
            CancelInvoke("Spawn"); // Stop spawning gems
        }
    } 

    void Spawn()
    {
        float randomX = Random.Range(-8f, 8f);
        float randomY = Random.Range(-2.5f, 4f);

        Vector3 randomPosition = new Vector3(randomX, randomY, 0f); 

        Instantiate(gem, randomPosition, Quaternion.identity); 
    }

    public void IncreaseScore()
    {
        score++;
        Debug.Log("Score: " + score);

        scoreText.text = "Score: " + score;

        if (score >= 10)
        {
            win = true;

            winText.gameObject.SetActive(true); // Show the win text
        }
    }
}
