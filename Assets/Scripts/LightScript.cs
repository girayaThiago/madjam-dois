using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class LightScript : MonoBehaviour
{
    private Light2D luz;
    public float amplitude = 2;
    public float raio = 3;
    public float periodo = 4;
    public Color cor;
    // Start is called before the first frame update
    void Start()
    {
        luz = GetComponent<Light2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float t = Time.fixedTime * Mathf.PI / periodo;
        float sin = Mathf.Sin(t);

        luz.pointLightOuterRadius = raio + (amplitude * sin * sin);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            luz.color = cor;
        }
        else if (Input.GetKey(KeyCode.R))
        {
            luz.color = Color.red;
        }

    }
}
