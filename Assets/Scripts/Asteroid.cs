using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Asteroid : MonoBehaviour //, Magnetic
{
    public Polarity default_polarity;
    public Polarity polarity { get; set; }
    public float mag_k { get; set; }
    PhysX physics;

    // Start is called before the first frame update
    void Start()
    {
        physics = FindObjectOfType<PhysX>();
        polarity = (Polarity) default_polarity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        AddForces();
    }

    void AddForces()
    {
        foreach (Player p in Player.players)
        {
            float k = physics.K * (float)p.polarity * (float)this.polarity;
            if (k != 0.0f)
            {
                Vector2 d = (p.transform.position - transform.position);
                Vector2 ra = d / d.magnitude;
                //d = d * d; // d square
                Vector2 f = k * ra / d.magnitude;
                p.rigidBody.AddForce(f);
            }
        }
    }
}
