using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //Player[] players;
    //Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        //camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p1 = Player.players[0].transform.position;
        Vector3 p2 = Player.players[1].transform.position;
        float d = (p1 - p2).magnitude;
        Vector3 coords = Vector3.zero;

        Vector3 avg = (p1 + p2) * 0.5f;
        avg.z = transform.position.z;
        transform.position = avg;

        
        Camera c = GetComponent<Camera>();
        c.orthographicSize = Mathf.Clamp(d, 5.0f, 50.0f);
    }
}
