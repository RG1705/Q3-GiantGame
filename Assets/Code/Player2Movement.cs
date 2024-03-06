using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float sprintSpeed = 10f;
    public float puntForce = 500f;
    public float puntAngle = 45f;
    private Rigidbody2D rb2;
    public float Yvel, Xvel;
    public float prevY, prevX;
    public float CountDownTimer;
    public float CoolDownTimer;
    public BoxCollider2D Kick;
    public BoxCollider2D Swing;
    //private Animator ani;
    private SpriteRenderer PlayerSprite;
    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        //ani = GetComponent<Animator>();
        PlayerSprite = GetComponent<SpriteRenderer>();
        Kick = Kick.GetComponent<BoxCollider2D>();
        Swing = Swing.GetComponent<BoxCollider2D>();

        Kick.enabled = false;
        Swing.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        CountDownTimer -= Time.deltaTime;
        CoolDownTimer -= Time.deltaTime;

        Yvel = rb2.velocity.normalized.y;
        prevY = transform.position.y;

        Xvel = rb2.velocity.normalized.x;
        prevX = transform.position.x;


        //ani.SetFloat("Xvel", Yvel);
        //ani.SetFloat("Yvel", Xvel);



        if (Xvel > 0.01f)
        {

            PlayerSprite.flipX = true;

        }
        else if (Xvel < -0.01f)
        {

            PlayerSprite.flipX = false;

        }


        // Movement for Character
        float speed = Input.GetKey(KeyCode.N) ? sprintSpeed : walkSpeed;
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal2"), Input.GetAxisRaw("Vertical2")).normalized * speed;
        rb2.velocity = movement;

        // Listen for a punt
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Punt!");
            float fX = puntForce * Mathf.Cos(puntAngle * Mathf.Deg2Rad);
            float fY = puntForce * Mathf.Sin(puntAngle * Mathf.Deg2Rad);
            rb2.AddForce(new Vector2(fX, fY));
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            Kick.enabled = true;
            CoolDownTimer = 0.5f;


        }
        else if (Input.GetKeyUp(KeyCode.U) || CoolDownTimer <= 0)
        {
            Kick.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            Swing.enabled = true;
            CoolDownTimer = 0.5f;


        }
        else if (Input.GetKeyUp(KeyCode.O) || CoolDownTimer <= 0f)
        {
            Swing.enabled = false;
        }

        if (PlayerSprite.flipX)
        {
            Swing.offset = new Vector2(0.5f, 0);


            Kick.offset = new Vector2(0.5f, 0);

        }
        else if (!PlayerSprite.flipX)
        {

            Swing.offset = new Vector2(-0.5f, 0);


            Kick.offset = new Vector2(-0.5f, 0);

        }



        // Listen for a Reset (ESC)
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    transform.position = new Vector3(0, 0, 0);
        //    rb2.velocity = Vector2.zero;
        //}
    }
}
