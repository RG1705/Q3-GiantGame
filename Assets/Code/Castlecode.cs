using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castlecode : MonoBehaviour
{
    public int CastleHealth = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boulder"))
        {
            Destroy(collision.gameObject);
            CastleHealth --;
            


        }

        if (CastleHealth == 0)
        {

            Destroy(gameObject);

        }


    }

}
