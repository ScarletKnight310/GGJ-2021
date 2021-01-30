using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{
    public float slideSpeed = 5f;
    public float openTime = 10f; // sec

    [Header("Move Axis")]
    public bool xAxis = false;
    public bool yAxis = false;
    public bool zAxis = false;

    private float TimeToStop;

    private void OnEnable() {
        TimeToStop = Time.time + openTime;
    }

    void Update(){
        transform.position = new Vector3(xAxis ? transform.position.x + (slideSpeed * Time.deltaTime) : transform.position.x,
                                        yAxis ? transform.position.y + (slideSpeed * Time.deltaTime) : transform.position.y,
                                        zAxis ? transform.position.z + (slideSpeed * Time.deltaTime) : transform.position.z);

        if(Time.time > TimeToStop) {
            gameObject.SetActive(false);
        }
    }
}
