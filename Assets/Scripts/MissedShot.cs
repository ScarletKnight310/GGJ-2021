using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissedShot : MonoBehaviour
{
    public float lifeSpan = 2f;

    private float endTime;
    private void Start() {
        endTime = Time.time + lifeSpan;
    }

    private void Update() {
        if(endTime < Time.time) {
            Shoot.instance.SendMessage("stapleHit", gameObject);
        }
    }
}
