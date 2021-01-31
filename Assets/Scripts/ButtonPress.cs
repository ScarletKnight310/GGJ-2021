using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPress : MonoBehaviour
{
    public GameObject player;
    public float distance = 3f;
    public Text text;

    bool isPressed = false;

    void OnMouseDown() {
        if (Vector3.Distance(transform.position, player.transform.position) < distance) {
            isPressed = true;
        }

    }

    void OnMouseUp() {
        isPressed = false;
    }

    void Update() {
        if (isPressed) {
            text.text = "Button Has Been Pressed";
            //Do something *****************************************************
        } else {
            if (Vector3.Distance(transform.position, player.transform.position) < distance) {
                text.text = "Hover Over and Click Mouse to Press";
            } else {
                text.text = "";
            }
        }
    }

    //put this script on the button
    //Object needs collider and rigidbody
    //add player to buttoPress' field
    //add text (childed to canvas) to buttoPress' field

}
