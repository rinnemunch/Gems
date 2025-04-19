using UnityEngine;

public class TeleportingBoss : MonoBehaviour
{
    public float teleportInterval = 2f;
    public Vector2 minBounds = new Vector2(-8f, -3f);
    public Vector2 maxBounds = new Vector2(8f, 3f);

    void Start()
    {
        InvokeRepeating(nameof(Teleport), 0f, teleportInterval);
    }

    void Teleport()
    {
        float x = Random.Range(minBounds.x, maxBounds.x);
        float y = Random.Range(minBounds.y, maxBounds.y);
        transform.position = new Vector3(x, y, 0f);
    }
}
