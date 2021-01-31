using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerOpen : MonoBehaviour
{
    public MaterialChange[] mc = new MaterialChange[5];
    public Text text;
    // Update is called once per frame
    void Update()
    {
        if (mc[0].switched && mc[1].switched && mc[2].switched && mc[3].switched && mc[4].switched) {
            GetComponent<Open>().enabled = true;
            text.text = "Reversal is complete, \n" +
                        "leave at once.";
        }
    }
}
