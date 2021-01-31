using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhonePickUp : MonoBehaviour
{
    public GameObject player;
    public float distance = 3f;
    public Text text;
    bool isPressed = false;

    public GameObject[] disableThese = new GameObject[1];
    private string lastText = "";

    private void Start() {
        lastText = text.text;
    }
   
    void Update() {
        if (Vector3.Distance(transform.position, player.transform.position) < distance) {
            text.text = "Grab your phone (Right-Click mouse)";
        } else {
            text.text = lastText;
        }

        if (Input.GetMouseButtonDown(1) && Vector3.Distance(transform.position, player.transform.position) < distance) {
            for (int i = 0; i < disableThese.Length; i++) {
                disableThese[i].SetActive(!disableThese[i].activeSelf);
            }

            
            player.GetComponent<Flashlight>().flashLight.SetActive(true);
            player.GetComponent<Flashlight>().gotFlashLight = true;

            text.text = "You found your phone! Better find a way out!";
            gameObject.SetActive(false);
        }
    }

    //put this script on the button
    //Object needs collider and rigidbody
    //add player to buttoPress' field
    //add text (childed to canvas) to buttoPress' field
}
