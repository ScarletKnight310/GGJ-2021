using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    
    public float distDampening;

    private void FixedUpdate()
    {
        //Dampen the follow with Lerp, ignore Z
        transform.position = new Vector3( Mathf.Lerp(transform.position.x, target.position.x, Time.deltaTime * distDampening), Mathf.Lerp(transform.position.y, target.position.y, Time.deltaTime * distDampening), transform.position.z );
    }
}