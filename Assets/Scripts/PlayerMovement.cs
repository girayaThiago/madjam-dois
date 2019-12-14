using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerMovement : MonoBehaviour
{
    public string x_axis;
    public string y_axis;


    Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("a");
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dx = Input.GetAxis(x_axis);
        float dy = Input.GetAxis(y_axis);

        //rigidBody.velocity = new Vector2(dx, dy).normalized * 5.0f;
        rigidBody.velocity = new Vector2(dx, dy) * 5.0f; //.normalized * 5.0f;
        //transform.Translate(dx, dy, 0);
    }

    public void Somefunction(Vector2 v) { }

}














