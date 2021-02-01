using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateOpen : MonoBehaviour
{
    public Transform openPosition;
    public float speed = 1;
    public bool gateRising = true;

    // Start is called before the first frame update
    void Start()
    {
        print("Gate awake");
    }

    // Update is called once per frame
    void Update()
    {
        if (gateRising)
        {
            
            float distance = Vector3.Distance(openPosition.position, transform.position);
            if (distance > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, openPosition.position, speed * Time.deltaTime);
            }
            else
            {
                gateRising = false;
            }
        }
    }
}
