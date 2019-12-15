using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //Player[] players;
    //Camera camera;
    PhysX physics;
    Portal[] portals;
    public GameObject arrowPrefab;
    List<GameObject> arrows;
    //Player[] players;
    // Start is called before the first frame update
    void Start()
    {
        //camera = GetComponent<Camera>();
        //players = FindObjectsOfType<Player>();
        physics = FindObjectOfType<PhysX>();
        portals = FindObjectsOfType<Portal>();
        arrows = new List<GameObject>();

        foreach (Portal p in portals) {
            GameObject q = Instantiate(arrowPrefab, new Vector3(0,0,0), Quaternion.identity);
            q.GetComponent<QuestHelper>().target = p.gameObject;
            q.GetComponent<QuestHelper>().source = gameObject;
            //q.transform.parent = Camera.main.transform;
            arrows.Add(q);
        }
    }

    // Update is called once per frame
    void Update()
    {        
        Vector3 p1 = physics.players[0].transform.position;
        Vector3 p2 = physics.players[1].transform.position;
        Vector3 dist = (p1 - p2);
        
        Vector3 coords = Vector3.zero;
        Vector3 avg = (p1 + p2) * 0.5f;
        avg.z = transform.position.z;
        transform.position = avg;

        float dx2 = dist.x * dist.x;
        float dy2 = dist.y * dist.y;
        float fy = dy2; // (dx2 <= dy2) ? dx2 : 0.0f;
        float fx = dx2 * 0.5625f * 0.5625f;
        float d1 = Mathf.Sqrt(fx + fy);
        Camera c = GetComponent<Camera>();
        c.orthographicSize = Mathf.Clamp(d1*0.5f + 1.5f, 5.0f, 15.0f);
    }
}
