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

    void Start()
    {
        currentHealth = maxHealth;
        audioSource = GetComponent<AudioSource>();
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
        winPopup.SetActive(false);
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

        if (hitSound != null)
            audioSource.PlayOneShot(hitSound);

        if (currentHealth <= 0)
            Defeat();
    }

    void Defeat()
    {
        Debug.Log("Golem defeated!");
        winPopup.SetActive(true);
        Destroy(gameObject, 0.5f); // optional: add death anim
    }
}
