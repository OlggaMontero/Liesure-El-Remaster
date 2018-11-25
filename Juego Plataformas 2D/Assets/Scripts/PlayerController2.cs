using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour {

    public float maxSpeed = 5f;
    public float speed = 2f;
    public bool grounded;
    //public bool carry;
    public float jumpPower = 6.5f;
    public int nBandeja;
    //public PickUp control;
    public bool hold;


    private Rigidbody2D rb2d;
    private Animator anim;
    private bool jump;


    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //carry = false;
        nBandeja = 0;
        hold = false;
    }

    // Update is called once per frame
    void Update()
    {

        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetFloat("MoveY", Mathf.Abs(rb2d.velocity.y));
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Bandeja", nBandeja);
        anim.SetBool("Hold", hold);
        //carry = control.player.carry;
        //Debug.Log("PC" +carry);
        //Debug.Log("PC hold " + hold);

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0)) && grounded)
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        Vector3 fixedVelocity = rb2d.velocity;
        fixedVelocity.x *= 0.75f;

        if (grounded)
        {
            rb2d.velocity = fixedVelocity;              //fricción artificial con el suelo (las plataformas son deslizantes para no quedarte enganchado en las paredes y poder saltar infinitamente)
        }

        float h = Input.GetAxis("Horizontal");

        rb2d.AddForce(Vector2.right * speed * h);

        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }

        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }

        if (h > 0.1f)                                               //Cambiar la orientación del personaje
        {
            transform.localScale = new Vector3(-0.1f, 0.1f, 0.1f);
        }

        if (h < -0.1f)
        {
            transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }

        if (jump)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);     //Al decir que es 1 impulso nos servirá una fuerza más "reducida"
            jump = false;
        }


    }
}
