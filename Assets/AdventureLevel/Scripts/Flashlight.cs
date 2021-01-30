using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Light l;


    public float pLightWidth = 40f;
    public float pLightIntensity = 1300f;
    public float pRange = 150f;
    
    public float sLightWidth = 75f;
    public float sLightIntensity = 650f;
    public float sRange = 150f;

    // Update is called once per frame
    void Update()
    {
        bool lmb = Input.GetKey(KeyCode.Mouse0);
        bool rmb = Input.GetKey(KeyCode.Mouse1);

        if (lmb)
        {
            l.range = pRange;
            l.intensity = pLightIntensity;
            l.spotAngle = pLightWidth;
            l.enabled = true;
        }
        else if (rmb)
        {
            l.range = sRange;
            l.intensity = sLightIntensity;
            l.spotAngle = sLightWidth;
            l.enabled = true;
        }
        else
        {
            l.enabled = false;
        }
    }
}
