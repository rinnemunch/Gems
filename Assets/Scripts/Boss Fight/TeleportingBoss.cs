using System.Collections;
using UnityEngine;

public class TeleportingBoss : MonoBehaviour
{
    public float teleportInterval = 2f;
    public Vector2 minBounds = new Vector2(-8f, -3f);
    public Vector2 maxBounds = new Vector2(8f, 3f);
    public SpriteRenderer sr;

    void Start()
    {
        InvokeRepeating(nameof(StartTeleport), 0f, teleportInterval);
    }

    void StartTeleport()
    {
        StartCoroutine(TeleportEffect());
    }

    IEnumerator TeleportEffect()
    {
        sr.color = new Color(1, 1, 1, 0); // Fade out
        yield return new WaitForSeconds(0.2f);

        float x = Random.Range(minBounds.x, maxBounds.x);
        float y = Random.Range(minBounds.y, maxBounds.y);
        transform.position = new Vector3(x, y, 0f);

        sr.color = new Color(1, 1, 1, 1); // Fade in
    }
}
