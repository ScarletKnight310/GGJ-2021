using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    public Light l;

    public Flashlight fl;

    public bool lmb;

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(transform.position, gameObject.transform.up * -1000f, Color.red);

        lmb = Input.GetKey(KeyCode.Mouse0);

        if (!lmb)
        {
            l.enabled = false;
        }
    }
}
