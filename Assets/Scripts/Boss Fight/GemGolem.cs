using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GemGolem : MonoBehaviour
{
    public int maxHealth = 50;
    private int currentHealth;

    public Slider healthBar;
    public AudioClip hitSound;
    public GameObject winPopup;

    private AudioSource audioSource;
    public SpriteRenderer sr;
    private bool canTakeDamage = true;


    void Start()
    {
        Debug.Log("GemGolem Start() called");

        currentHealth = maxHealth;
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
            Debug.LogWarning("AudioSource is missing!");

        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
        winPopup.SetActive(false);
        StartCoroutine(Blink());

    }

    private void OnMouseDown()
    {
        Debug.Log("Golem clicked!");
        TakeDamage(1);
    }

    void TakeDamage(int amount)
    {
        if (!canTakeDamage) return;

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
        while (true)
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
        winPopup.SetActive(true);
        Destroy(gameObject, 0.5f);
    }
}
