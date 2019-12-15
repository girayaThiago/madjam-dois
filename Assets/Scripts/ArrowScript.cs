using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{

    float range;
    float size;
    Vector3 speed;
    Vector3 rotation;

    public void init(float range, float size, Vector3 speed, Vector3 rotation)
    {
        float sizeScale = Random.Range(0.2f, 2.0f);
        this.range = range; //distance to travel before expiring
        this.size = size * sizeScale;
        this.speed = speed * sizeScale/2;
        Debug.Log(rotation);
        transform.rotation = Quaternion.Euler(rotation);
        transform.localScale = new Vector3(size, size, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        Vector3 nextPosition = (transform.position + speed * Time.fixedDeltaTime);
        float dist = (nextPosition - transform.position).magnitude;
        range -= dist;
        if (range <= 0)
        {
            Destroy(gameObject);
        }
        transform.position += speed * Time.fixedDeltaTime;
    }
}
