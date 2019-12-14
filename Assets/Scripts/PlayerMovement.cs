using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerMovement : MonoBehaviour
{
    public string player_id;
    SpriteRenderer spriteRenderer;
    Polarity polarity;
   
    Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        polarity = Polarity.Neutral;
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DirectInput();
    }
    void Update()
    {
        ChangePolarity();
    }

    void DirectInput()
    {
        float dxk = Input.GetAxis(player_id + "_Horizontal");
        float dxj = Input.GetAxis(player_id + "_Horizontal_J");
        float dyk = Input.GetAxis(player_id + "_Vertical");
        float dyj = Input.GetAxis(player_id + "_Vertical_J");

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
        if (Input.GetAxis(player_id + "_TogglePositive") > 0.0f) { polarity = Polarity.Positive; }
        else if (Input.GetAxis(player_id + "_ToggleNegative") > 0.0f) { polarity = Polarity.Negative; }
        else if (Input.GetAxis(player_id + "_ToggleNeutral") > 0.0f) { polarity = Polarity.Neutral; }

        switch(polarity)
        {
            case Polarity.Positive: spriteRenderer.color = Color.red; break;
            case Polarity.Negative: spriteRenderer.color = Color.blue; break;
            case Polarity.Neutral: spriteRenderer.color = Color.yellow; break;
        }
    }
}


public enum Polarity {
    Negative, Neutral, Positive
};
















