using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Portal : MonoBehaviour
{
    static bool victory_achieved = false;
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
                    //Debug.Log(dist);
                    Vector2 d2 = d * d; // d square
                    Vector2 ra = d / dist;
                    Vector2 f = k * ra / d2.magnitude;
                    p.rigidBody.AddForce(f);
                }
            }
        }
    }
    void VictoryCondition()
    {
        if (!victory_achieved)
        {
            Debug.Log("CALL");
            victory_achieved = true;
            //yield return new WaitForSecondsRealtime(5);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.name == "Player1" || collision.collider.gameObject.name == "Player2")
        {
            //D//ebug.Log("VICTORY");
            //Coroutine c = StartCoroutine("VictoryCondition"); // ());
            VictoryCondition();
        }
    }
}
