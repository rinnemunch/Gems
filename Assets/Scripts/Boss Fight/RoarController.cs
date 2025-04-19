using System.Collections;
using UnityEngine;

public class RoarController : MonoBehaviour
{
    public AudioClip[] roarClips;
    public float minDelay = 4f;
    public float maxDelay = 10f;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayRandomRoars());
    }

    IEnumerator PlayRandomRoars()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            Debug.Log($"[RoarController] Waiting {delay} sec...");
            yield return new WaitForSeconds(delay);

            if (roarClips.Length > 0)
            {
                int index = Random.Range(0, roarClips.Length);
                AudioClip roar = roarClips[index];

                Debug.Log($"[RoarController] Playing: {roar.name}");
                audioSource.PlayOneShot(roar);
            }
        }
    }
}
