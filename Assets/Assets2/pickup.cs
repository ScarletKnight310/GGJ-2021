using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public bool follow = false;

    GameObject lastCol;

    public bool isSuperBit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (follow == true)
        {
            gameObject.transform.position = new Vector3 (lastCol.transform.position.x, lastCol.transform.position.y, -5);
        }
    }

    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            follow = true;
            lastCol = col.gameObject;

            if (isSuperBit)
            {
                Flashlight.super = true;
            }
            else
            {
                lockedGate.controller.gameObject.SendMessage("getKey", gameObject);
            }
        }

    }
}
