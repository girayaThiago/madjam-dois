using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Portal : MonoBehaviour
{
    PhysX physics;
    // Start is called before the first frame update
    void Start()
    {
        physics = FindObjectOfType<PhysX>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 3.0f);
    }

    private void FixedUpdate()
    {
        AddForces();
    }

    void AddForces()
    {
        foreach (Player p in Player.players)
        {
            float k = -physics.K;
            if (k != 0.0f)
            {
                Vector2 d = (p.transform.position - transform.position);
                float dist = d.magnitude;
                if (dist < 3.0f)
                {
                    Debug.Log(dist);
                    Vector2 d2 = d * d; // d square
                    Vector2 ra = d / dist;
                    Vector2 f = k * ra / d2.magnitude;
                    p.rigidBody.AddForce(f);
                }
            }
        }
    }

}
