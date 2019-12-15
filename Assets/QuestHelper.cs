using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestHelper : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject source {get;set;}
    public GameObject target { get; set; }
    float angle = 0.0f;

    // Update is called once per frame
    void Update()
    {

        float t = Mathf.Atan2(target.transform.position.y - source.transform.position.y, target.transform.position.x - source.transform.position.x) * Mathf.Rad2Deg;
        //Debug.Log(rotation);
        //transform.rotation = Quaternion.FromToRotation(source.transform.position-Vector3.zero, Vector3.zero - target.transform.position);
        //transform.Rotate(target.transform.position - source.transform.position);
        Vector2 v1 = source.transform.position;
        Vector2 v2 = target.transform.position;
        float cost = v1.x * v2.x + v1.y * v2.y;
        float den = (v1.magnitude * v2.magnitude);
        //float t = Mathf.Acos(cost/den);
        transform.Rotate(new Vector3(0,0,t-angle));
        angle = t;
        float d = -2.2f;
        transform.position = (v1 + v2) * 0.5f;
        

    }

}
