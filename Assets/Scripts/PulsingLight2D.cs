using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PulsingLight2D : MonoBehaviour
{
    public Light2D light2D;
    public float speed = 2f;
    public float minIntensity = 0.5f;
    public float maxIntensity = 2f;

    void Update()
    {
        float t = Mathf.PingPong(Time.time * speed, 1);
        light2D.intensity = Mathf.Lerp(minIntensity, maxIntensity, t);
    }
}
