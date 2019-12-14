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
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DirectInput();
    }

    void DirectInput()
    {
        float dxk = Input.GetAxis(x_axis);
        float dxj = Input.GetAxis(x_axis + "_J");
        float dyk = Input.GetAxis(y_axis);
        float dyj = Input.GetAxis(y_axis + "_J");

        if (dxk != 0.0f || dyk != 0.0f)
        {
            rigidBody.velocity = new Vector2(dxk, dyk).normalized * 5.0f;
        }
        else
        {
            rigidBody.velocity = new Vector2(dxj, dyj) * 5.0f;
        }
    }
    void ChangePolarity()
    {
        //Input.GetKey(KeyCode.)
    }
}




















