using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BallCode : MonoBehaviour
{
    private Rigidbody2D rb2;
    public float Yvel, Xvel;
    public float prevY, prevX;
    public BoxCollider2D Kick;
    public BoxCollider2D Swing;
    public bool Swung;
    public float slow = .99f;


    private void Awake()
    {
        rb2 = GetComponent<Rigidbody2D>(); 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Yvel = rb2.velocity.normalized.y;
        prevY = transform.position.normalized.y;

        Xvel = rb2.velocity.x;
        prevX = transform.position.x;

        if (rb2.velocity.x == 0f)
        {

            
            Swung = false;


        }
    }
    void OnTriggerEnter2D(Collider2D toss)
    {
        if (toss.gameObject.CompareTag("Kick"))
        {
            Kick = toss.gameObject.GetComponent<BoxCollider2D>();
            if(Kick.offset.x == 0.5f)
            {
                rb2.AddForce(new Vector2(rb2.velocity.x + 20.0f, 0.0f));


            }

            if (Kick.offset.x == -0.5f)
            {
                rb2.AddForce(new Vector2(rb2.velocity.x - 20.0f, 0.0f));


            }
        }

        if (toss.gameObject.CompareTag("Swing"))
        {
            Swing = toss.gameObject.GetComponent<BoxCollider2D>();
            if (Swing.offset.x == 0.5f)
            {
                rb2.AddForce(new Vector2(rb2.velocity.x + 40.0f, 0.0f));


            }

            if (Swing.offset.x == -0.5f)
            {
                rb2.AddForce(new Vector2(rb2.velocity.x - 40.0f, 0.0f));


            }

            Swung = true;
        }
        else if (toss.gameObject.CompareTag("Swing") && Swung == true)
        {
            Swing = toss.gameObject.GetComponent<BoxCollider2D>();
            if (Swing.offset.x == 0.5f)
            {

                rb2.AddForce(new Vector2(rb2.velocity.x * 2, 0.0f));

            }

            if (Swing.offset.x == -0.5f)
            {
                rb2.AddForce(new Vector2(rb2.velocity.x * 2, 0.0f));


            }
        }

    }

    //private void OnTriggerExit2D(Collider2D toss)
    //{
      

    //    //if (rb2.velocity.x > 10.0f)
    //    //{

    //    //    Vector2 Reverse = rb2.velocity / 1.0005f;

    //    //    rb2.AddForce(Reverse, ForceMode2D.Impulse);
    //    //}


    //    //if (rb2.velocity.x < -10.0f)
    //    //{

    //    //    Vector2 Reverse = rb2.velocity * 1.0005f;

    //    //    rb2.AddForce(Reverse, ForceMode2D.Impulse);

    //    //}



    //    //if (rb2.velocity.x >= 0.1 || rb2.velocity.x <= -0.1 || rb2.velocity.x == 0)
    //    //{
    //    //    rb2.velocity = new Vector2(0.0f, 0.0f);
    //    //    Kick = null;
    //    //    Swing = null;
    //    //    Swung = false;


    //    //}

    //}

}
