using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameUIManager : MonoBehaviour
{
    public void RestartGame()
    {
        SceneTransitionManager stm = FindObjectOfType<SceneTransitionManager>();
        if (stm != null)
        {
            stm.FadeToScene("MainMenu");
        }
        else
        {
            SceneManager.LoadScene("MainMenu"); // fallback
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
