using UnityEngine;

public class Gem : MonoBehaviour
{
    //The gems of each level is the target

    void Start()
    {
        Destroy(gameObject, 2f); // Destroy the gem after (whatever you want) seconds
    }


    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
