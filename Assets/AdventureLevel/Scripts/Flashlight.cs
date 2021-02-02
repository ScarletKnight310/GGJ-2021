using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Light l;

    public static bool super;

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
            if(!super)
            {
                l.range = pRange;
                l.intensity = pLightIntensity;
                l.spotAngle = pLightWidth;
                l.enabled = true;
            }
            else
            {
                l.color = Color.yellow;
                l.range = pRange * 10f;
                l.intensity = pLightIntensity * 10f;
                l.spotAngle = pLightWidth * 2f;
                l.enabled = true;
            }
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
