using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class LightSwitch : MonoBehaviour
{
    public Player p;
    public Light2D l;
    public bool on;
    float onOffLerp = 0;
    float colorLerp = 0;
    public float maxIntensity;
    public float maxRadius;

    private void Start()
    {
        l = GetComponent<Light2D>();
    }

    private void Update()
    {
        if (p.polarity == 0)
        {
            onOffLerp -= Time.deltaTime * 2;
        } else
        {
            onOffLerp += Time.deltaTime * 2;
            if((int)p.polarity == 1)
            {
                colorLerp -= Time.deltaTime * 2;
            } else if ((int)p.polarity == -1)
            {
                colorLerp += Time.deltaTime * 2;
            }
            colorLerp = Mathf.Clamp01(colorLerp);
            l.color = Color.Lerp(Color.blue, Color.red, colorLerp);
        }
        onOffLerp = Mathf.Clamp01(onOffLerp);
        l.intensity = Mathf.Lerp(0.1f, maxIntensity, onOffLerp);
        l.pointLightInnerRadius = Mathf.Lerp(0.0f, maxRadius, onOffLerp);
    }
}
