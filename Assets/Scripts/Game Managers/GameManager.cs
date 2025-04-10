using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] gemPrefabs; // array of gem types


    int score = 0;
    int scoreGoal = 20; // Level 2 goal

    public Text scoreText;
    bool win = false;
    public Image winText;

    void Start()
    {
        Spawn();
        InvokeRepeating("Spawn", 1f, 0.4f); // spawns faster than level 1
    }

    void Update()
    {
        if (win)
        {
            CancelInvoke("Spawn");
        }
    }

    void Spawn()
    {
        float randomX = Random.Range(-8f, 8f);
        float randomY = Random.Range(-2.5f, 4f);
        Vector3 randomPosition = new Vector3(randomX, randomY, 0f);

        int index = Random.Range(0, gemPrefabs.Length);
        GameObject newGem = Instantiate(gemPrefabs[index], randomPosition, Quaternion.identity);
        newGem.SetActive(true);
    }


    public void IncreaseScore()
    {
        score++;
        Debug.Log("Score: " + score);

        scoreText.text = "Score: " + score;

        if (score >= scoreGoal)
        {
            win = true;
            winText.gameObject.SetActive(true);
        }
    }
}
