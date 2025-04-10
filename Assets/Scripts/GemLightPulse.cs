using UnityEngine;

public class GemLightPulse : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D light2D;

    public float pulseSpeed = 2f;
    public float minIntensity = 0.8f;
    public float maxIntensity = 2f;

    void Update()
    {
        float pulse = Mathf.PingPong(Time.time * pulseSpeed, 1f);
        light2D.intensity = Mathf.Lerp(minIntensity, maxIntensity, pulse);
    }
}
