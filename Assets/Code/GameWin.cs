using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWin : MonoBehaviour
{
    public GameObject Castlefab;
    public GameObject Castlefab2;
    public GameObject Castle1;
    public GameObject Castle2;
    public GameObject Ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Castle2 == null)
        {
            Debug.Log("Player 1 wins!");
            Ball.GetComponent<BallChecker>().enabled = false;
            Destroy(GameObject.Find("Ball(Clone)"));

        }
        if (Castle1 == null)
        {
            Debug.Log("Player 2 wins!");
            Ball.GetComponent<BallChecker>().enabled = false;
            Destroy(GameObject.Find("Ball(Clone)"));

        }



        if (Input.GetKey(KeyCode.R) && Castle1 == null)
        {

            Ball.GetComponent<BallChecker>().enabled = true;
            Instantiate(Castlefab, new Vector2(-10.0f, 0.0f), Quaternion.identity);
            Castle1 = GameObject.Find("Castle(Clone)");
            


        } else if (Input.GetKey(KeyCode.R)&& Castle2 == null)
        {

            

                Ball.GetComponent<BallChecker>().enabled = true;
                Instantiate(Castlefab2, new Vector2(10.0f, 0.0f), Quaternion.identity);
            Castle2 = GameObject.Find("Castle2(Clone)");



            


        }
    }
}
