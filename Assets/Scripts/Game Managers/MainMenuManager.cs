using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject instructionsPanel;
    public void StartGame()
    {
        FindObjectOfType<SceneTransitionManager>().FadeToScene("Level1");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit"); 
    }
    public void OpenInstructions()
    {
        instructionsPanel.SetActive(true);
    }

    public void CloseInstructions()
    {
        instructionsPanel.SetActive(false);
    }
}
