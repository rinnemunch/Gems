using UnityEngine;

public class Gem : MonoBehaviour
{
    public GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Destroy(gameObject, 2f); // Destroy the gem after (whatever you want) seconds
    }


    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        gameManager.IncreaseScore();
        Destroy(gameObject);    
    }
}
