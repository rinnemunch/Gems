using UnityEngine;
using TMPro;

public class FadeInTMP : MonoBehaviour
{
    public float fadeSpeed = 2f;
    TextMeshProUGUI tmp;
    Color originalColor;

    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        originalColor = tmp.color;
        tmp.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);
    }

    void Update()
    {
        if (tmp.color.a < originalColor.a)
        {
            tmp.color = new Color(
                originalColor.r,
                originalColor.g,
                originalColor.b,
                Mathf.MoveTowards(tmp.color.a, originalColor.a, Time.deltaTime * fadeSpeed)
            );
        }
    }
}
