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

        //l.range = fl.pRange;
        //l.intensity = fl.pLightIntensity;
        //l.spotAngle = fl.pLightWidth;

        lmb = Input.GetKey(KeyCode.Mouse0);

        if (!lmb)
        {
            l.enabled = false;
        }
    }
}
