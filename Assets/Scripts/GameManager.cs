using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gem;

    int score = 0; 

    
    void Start()
    {
        Spawn();

        InvokeRepeating("Spawn", 1f, 1f); // Call Spawn every 1 second
    }

    
    void Update()
    {
        
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
        Debug.Log("Score: " + score); // Display the score in the console
    }
}
