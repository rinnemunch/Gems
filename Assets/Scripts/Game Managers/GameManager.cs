using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] gemPrefabs;
    public float spawnRate = 1.2f;   // slower for Level 1
    public int scoreGoal = 10;       // win at 10

    int score = 0;
    bool win = false;

    public Text scoreText;
    public Image winText;

    void Start()
    {
        InvokeRepeating("Spawn", 1f, spawnRate);
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
        scoreText.text = "Score: " + score;
        Debug.Log("Score: " + score);

        if (score >= scoreGoal)
        {
            win = true;
            winText.gameObject.SetActive(true);
        }
    }
}
