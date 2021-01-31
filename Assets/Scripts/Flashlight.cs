using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight: MonoBehaviour
{
    // enable after picking up
    public bool gotFlashLight = false;

    public GameObject flashLight;
    public float flashLightRange = 10f;

    public GameObject enemy;
    public LayerMask enemyLayer;
    

    private void Awake() {
        flashLight.SetActive(false);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1) && gotFlashLight) {
            flashLight.SetActive(!flashLight.activeSelf);

            if (flashLight.activeSelf 
                && Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), flashLightRange, enemyLayer)) {
                // stun
                enemy.GetComponent<EnemyAI>().Stun();
            }
        }
    }

}
