using UnityEngine;

public class Gem : MonoBehaviour
{
    public GameManager gameManager;
    private bool clicked = false;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Destroy(gameObject, 2f); // Auto destroy after 2 seconds
    }

    private void OnMouseDown()
    {
        if (clicked) return;
        clicked = true;

        GetComponent<AudioSource>().Play();
        gameManager.IncreaseScore();
        Destroy(gameObject, 0.3f); // Delay so sound plays
    }
}
