using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{
    private Light2D light2D;

    [Header("Flicker Settings")]
    public float flickerDuration = 0.5f;
    public float flickerInterval = 7f;
    public float minIntensity = 0.2f;
    public float maxIntensity = 1.5f;

    private void Start()
    {
        light2D = GetComponent<Light2D>();
        StartCoroutine(FlickerLoop());
    }

    System.Collections.IEnumerator FlickerLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(flickerInterval);

            float originalIntensity = light2D.intensity;

            // flicker effect
            float flickerTime = 0f;
            while (flickerTime < flickerDuration)
            {
                light2D.intensity = Random.Range(minIntensity, maxIntensity);
                flickerTime += 0.05f;
                yield return new WaitForSeconds(0.05f);
            }

            // restore intensity
            light2D.intensity = originalIntensity;
        }
    }
}