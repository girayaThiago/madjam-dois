using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Supernova : MonoBehaviour
{
    float K;
    Collider collider;
    // Start is called before the first frame update
    void Start()
    {
        K = 1000.0f;
        collider = GetComponent<Collider>();
    }

    IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        GameObject player = collision.collider.gameObject;
        Vector2 v2 = player.transform.position - transform.position;
        player.GetComponent<Rigidbody2D>().AddForce(v2 * K);
        player.GetComponent<Rigidbody2D>().AddTorque(10.0f);
        transform.localScale *= 1.5f;
        GetComponent<Animator>().Play("supernova_explode");
        yield return new WaitForSecondsRealtime(1);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
