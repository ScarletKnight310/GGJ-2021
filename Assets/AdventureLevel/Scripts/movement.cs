using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 10000f;

    public float speedMult = 1.1f;

    float defaultSpeed;

    Rigidbody rb;

    int i = 0;

    public int w, a, s, d;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        defaultSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.dead)
        {

        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                w = 1;
                rb.AddForce(Vector3.up * speed * Time.deltaTime);
            }
            else
                w = 0;
                
            if (Input.GetKey(KeyCode.S))
            {
                s = 1;
                rb.AddForce(Vector3.down * speed * Time.deltaTime);
            }
            else
                s = 0;

            if (Input.GetKey(KeyCode.D))
            {
                d = 1;
                rb.AddForce(Vector3.right * speed * Time.deltaTime);
            }
            else
                d = 0;

            if (Input.GetKey(KeyCode.A))
            {
                a = 1;
                rb.AddForce(Vector3.left * speed * Time.deltaTime);
            }
            else
                a = 0;


            int numPressed = w + a + s + d;
            if (numPressed > 1)
            {
                if (speed > defaultSpeed / speedMult)
                    speed /= speedMult;

            }
            else
                speed = defaultSpeed;
        }
    }
}
