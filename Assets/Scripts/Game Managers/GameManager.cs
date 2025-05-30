using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject[] gemPrefabs;
    public float spawnRate = 1.2f;
    public int scoreGoal = 10;

    int score = 0;
    bool win = false;

    public TextMeshProUGUI scoreText;
    public GameObject levelCompleteSprite;

    void Start()
    {
        InvokeRepeating("Spawn", 1f, spawnRate);
        levelCompleteSprite.SetActive(false);
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
            StartCoroutine(AnimateLevelComplete(levelCompleteSprite));
            Invoke(nameof(TriggerFadeOut), 2f);
        }
    }

    void TriggerFadeOut()
    {
        SceneTransitionManager stm = FindObjectOfType<SceneTransitionManager>();
        if (stm != null)
        {
            int currentIndex = SceneManager.GetActiveScene().buildIndex;
            int nextIndex = currentIndex + 1;

            if (nextIndex < SceneManager.sceneCountInBuildSettings)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(nextIndex);
                string nextSceneName = System.IO.Path.GetFileNameWithoutExtension(path);
                stm.FadeToScene(nextSceneName);
            }
            else
            {
                Debug.LogWarning("Next scene index is out of range!");
            }
        }
        else
        {
            Debug.LogWarning("SceneTransitionManager not found.");
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

    IEnumerator AnimateLevelComplete(GameObject obj)
    {
        obj.SetActive(true);

        Image image = obj.GetComponent<Image>();
        SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();

        if (image != null)
            image.color = new Color(1, 1, 1, 0);

        if (sr != null)
            sr.color = new Color(1, 1, 1, 0);

        obj.transform.localScale = Vector3.zero;

        float duration = 0.5f;
        float time = 0f;

        while (time < duration)
        {
            float t = time / duration;

            obj.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one * 1.5f, t);

            if (image != null)
                image.color = new Color(1, 1, 1, t);

            if (sr != null)
                sr.color = new Color(1, 1, 1, t);

            time += Time.deltaTime;
            yield return null;
        }

        obj.transform.localScale = Vector3.one * 1.5f;

        if (image != null)
            image.color = Color.white;

        if (sr != null)
            sr.color = Color.white;
    }
}
