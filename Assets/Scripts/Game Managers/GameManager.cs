using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject[] gemPrefabs;
    public float spawnRate = 1.2f;
    public int scoreGoal = 10;

    int score = 0;
    bool win = false;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI levelCompleteText; 

    void Start()
    {
        InvokeRepeating("Spawn", 1f, spawnRate);
        levelCompleteText.gameObject.SetActive(false); 
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
        scoreText.text = "Score: <space=5>" + score;
        Debug.Log("Score: " + score);

        if (score >= scoreGoal && !win)
        {
            win = true;
            levelCompleteText.gameObject.SetActive(true); 
            levelCompleteText.text = "Level Complete!"; 
            Invoke(nameof(LoadNextLevel), 2f);
        }
    }

    void LoadNextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;

        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextIndex);
        }
        else
        {
            Debug.Log("Game complete! No more levels.");
        }
    }
}
