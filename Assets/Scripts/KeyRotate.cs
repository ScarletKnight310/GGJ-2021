using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRotate : MonoBehaviour
{
    public float RotationSpeed = 5f;

    void Update()
    {
        if (gameObject.activeSelf) {
            transform.Rotate(0, RotationSpeed * Time.deltaTime, 0);
        }
    }
}
