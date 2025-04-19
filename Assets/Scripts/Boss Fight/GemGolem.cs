using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GemGolem : MonoBehaviour
{
    public int maxHealth = 50;
    private int currentHealth;

    public Slider healthBar;
    public AudioClip hitSound;
    public AudioClip[] roarSounds;
    public float minRoarDelay = 4f;
    public float maxRoarDelay = 10f;
    public GameObject winPopup;

    private AudioSource audioSource;
    [SerializeField]
    private bool isAlive = true;

    void Start()
    {
        Debug.Log("GemGolem Start() called");

        isAlive = true;

        currentHealth = maxHealth;
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
            Debug.LogWarning("AudioSource is missing!");

        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
        winPopup.SetActive(false);

        Debug.Log("Starting Roar Coroutine. isAlive = " + isAlive);

   
        if (roarSounds.Length > 0)
        {
            Debug.Log("TEST ROAR: Playing one-shot roar at Start()");
            audioSource.PlayOneShot(roarSounds[0], 1f); // Full volume test
        }

        StartCoroutine(RandomRoarLoop());
    }

    private void OnMouseDown()
    {
        Debug.Log("Golem clicked!");
        TakeDamage(1);
    }

    void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthBar.value = currentHealth;
        Debug.Log("HP: " + currentHealth + " / " + healthBar.value);

        if (hitSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(hitSound);
        }

        if (currentHealth <= 0 && isAlive)
        {
            Defeat();
        }
    }

    void Defeat()
    {
        Debug.Log("Golem defeated!");
        isAlive = false;
        winPopup.SetActive(true);
        Destroy(gameObject, 0.5f);
    }

    IEnumerator RandomRoarLoop()
    {
        Debug.Log("Roar coroutine has started...");

        while (isAlive)
        {
            float delay = Random.Range(minRoarDelay, maxRoarDelay);
            Debug.Log($"Waiting {delay} seconds before next roar...");
            yield return new WaitForSeconds(delay);

            if (roarSounds.Length > 0 && audioSource != null)
            {
                int index = Random.Range(0, roarSounds.Length);
                AudioClip roar = roarSounds[index];

                Debug.Log($"Roaring with clip: {roar.name} (index {index}) - length: {roar.length}");
                audioSource.PlayOneShot(roar, 1f); 
            }
            else
            {
                Debug.Log("Missing audio source or no roar sounds assigned!");
            }
        }
    }
}
