using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowEmitter : MonoBehaviour
{

    public GameObject emitted;
    public Transform origin;
    public Transform end;
    public Transform originRange;
    private float magnitude;
    public float cooldown;
    public float rotation;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        magnitude = (end.position - origin.position).magnitude;
        rotation = Mathf.Atan2(end.position.y - origin.position.y, end.position.x - origin.position.x) * Mathf.Rad2Deg;

        Debug.Log(origin.position);
        Debug.Log(end.position);
        Debug.Log(rotation);
        timer += Time.deltaTime;
        if (timer >= cooldown)
        {

            //Debug.Log(Vector3.Angle(origin.position, end.position));
            GameObject arrow = Instantiate(emitted, Vector3.Lerp(origin.position, originRange.position, Random.Range(0.0f, 1f)), Quaternion.identity);
            arrow.GetComponent<ArrowScript>().init(magnitude, 2.0f, (end.position - origin.position).normalized * 10.0f, Vector3.forward* rotation);
            timer = 0;

        }


    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(origin.position, end.position);
        Gizmos.DrawLine(origin.position, originRange.position);
    }
}
