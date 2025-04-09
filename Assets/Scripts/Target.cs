using UnityEngine;

public class Target : MonoBehaviour
{
    //The gems of each level is the target

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
