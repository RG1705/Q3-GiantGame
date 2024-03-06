using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallChecker : MonoBehaviour
{

    public GameObject Ball;
    public GameObject Ballfab;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        timer -= Time.deltaTime;
        if(Ball == null)
        {
            timer = 1.0f;
            Instantiate(Ballfab, new Vector2(0.0f, 4.0f), Quaternion.identity);
            Ball = GameObject.FindGameObjectWithTag("Boulder");
            Ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(Ball.GetComponent<Rigidbody2D>().velocity.x + 0.0f, -20.0f));


        }
        




    }
}
