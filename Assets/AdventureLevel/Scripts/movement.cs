using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 10000f;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.up * speed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.down * speed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * speed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * speed * Time.deltaTime);
        }
    }
}
