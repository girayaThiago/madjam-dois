using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour, Magnetic
{
    public static List<Player> players = new List<Player>();
    public string player_id;
    SpriteRenderer spriteRenderer;
    public Polarity polarity { get; set; }
    public float mag_k { get; set; }
    PhysX physics;

    public Rigidbody2D rigidBody { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        physics = FindObjectOfType<PhysX>();
        polarity = Polarity.Neutral;
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        players.Add(this);
        PlayerPrefs.SetInt("time", 0);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        DirectInput();
        AddForces();
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
            rigidBody.velocity += new Vector2(dxk, dyk).normalized * Time.fixedDeltaTime;
        }
        else
        {
            rigidBody.velocity += new Vector2(dxj, dyj) * Time.fixedDeltaTime;
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
    void AddForces()
    {
        foreach(Player p in players)
        {
            //Input.GetKey(KeyCode.)
            if (p != this)
            {
                float k = physics.K * (float) p.polarity * (float) this.polarity;
                if (k != 0.0f)
                {
                    Vector2 d = (p.transform.position - transform.position);
                    //Vector2 d2 = d * d; // d square
                    Vector2 ra = d / d.magnitude;
                    Vector2 f = k * ra / d.magnitude;
                    p.rigidBody.AddForce(f);
                }
            } 
        }
    }
}



























