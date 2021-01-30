using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    public Transform des;
    public GameObject player;
    public float distance = 3f;
    public Text text;

    bool isHolding = false;

    void OnMouseDown() {
        if (Vector3.Distance(transform.position, player.transform.position)<distance) {
            isHolding = true;
            GetComponent<Rigidbody>().useGravity = false;
            transform.position = des.position;
            transform.parent = GameObject.Find("Destination").transform;
        }
        
    }

    void OnMouseUp() {
        isHolding = false;
        transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;

    }

    void Update() {
        if (isHolding) {
            text.text = "Release Mouse to Drop";
        } else {
            if (Vector3.Distance(this.transform.position, player.transform.position) < distance) {
                text.text = "Hover Over and Click Mouse to Pick up";
            } else {
                text.text = "";
            }
        }
        
    }


    //Put this script on every pickupable object in game.
    //Object needs collider and rigidbody
    //add des (childed to player) to pick up's field
    //add player to pick up's field
    //add text (childed to canvas) to pick up's field



}
