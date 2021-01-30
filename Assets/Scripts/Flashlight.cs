using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight: MonoBehaviour
{
    // enable after picking up
    public bool gotFlashLight = false;

    public GameObject flashLight;

    private void Awake() {
        flashLight.SetActive(false);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1) && gotFlashLight) {
            flashLight.SetActive(!flashLight.activeSelf);
        }
    }

}
