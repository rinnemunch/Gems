using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GemGolem : MonoBehaviour
{
    public int maxHealth = 50;
    private int currentHealth;

    public Slider healthBar;
    public AudioClip hitSound;
    public GameObject youWinSprite;
    public SpriteRenderer sr;

    private AudioSource audioSource;
    private bool canTakeDamage = true;
    private bool isAlive = true;

    void Start()
    {
        Debug.Log("GemGolem Start() called");

        currentHealth = maxHealth;
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
            Debug.LogWarning("AudioSource is missing!");

        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;

        StartCoroutine(Blink());
    }

    void Update()
    {
        if (!isAlive) return;

        transform.position += new Vector3(0f, Mathf.Sin(Time.time * 2f) * 0.005f, 0f);
    }

    private void OnMouseDown()
    {
        if (!isAlive) return;

        Debug.Log("Golem clicked!");
        TakeDamage(1);
    }

    void TakeDamage(int amount)
    {
        if (!canTakeDamage || !isAlive) return;

        currentHealth -= amount;
        healthBar.value = currentHealth;
        Debug.Log("HP: " + currentHealth + " / " + healthBar.value);

        if (hitSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(hitSound);
        }

        StartCoroutine(FlashRed());

        if (currentHealth <= 0)
        {
            Defeat();
        }
    }

    IEnumerator Blink()
    {
        while (isAlive)
        {
            sr.enabled = true;
            canTakeDamage = true;
            yield return new WaitForSeconds(1f);

            sr.enabled = false;
            canTakeDamage = false;
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator FlashRed()
    {
        sr.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.white;
    }

    void Defeat()
    {
        Debug.Log("Golem defeated!");

        TeleportingBoss teleportScript = GetComponent<TeleportingBoss>();
        if (teleportScript != null)
        {
            teleportScript.DisableTeleporting();
        }


        isAlive = false;
        canTakeDamage = false;
        StopAllCoroutines();
        if (youWinSprite != null)
            youWinSprite.SetActive(true);

        StartCoroutine(DeathAnimation());
    }

    IEnumerator DeathAnimation()
    {
        Vector3 originalScale = transform.localScale;
        float duration = 1.5f;
        float timer = 0f;

        while (timer < duration)
        {
            float t = timer / duration;

            // Fade out
            sr.color = new Color(1, 1, 1, Mathf.Lerp(1f, 0f, t));

            // Scale down
            transform.localScale = Vector3.Lerp(originalScale, Vector3.zero, t);

            timer += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}
