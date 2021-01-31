using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaplerPickUp : MonoBehaviour
{
    public GameObject player;
    public float distance = 3f;
    public Text text;
    public GameObject help;
    public AudioClip pickup;
    public float volumeScaleSFX = 0.25f;

    void Update() {
        if (Vector3.Distance(transform.position, player.transform.position) < distance) {
            text.text = "Grab the stapler (Left-Click mouse)";
        }

        if (Input.GetMouseButtonDown(0) && Vector3.Distance(transform.position, player.transform.position) < distance) {
            player.GetComponent<AudioSource>().PlayOneShot(pickup, volumeScaleSFX);
            player.GetComponent<Shoot>().enabled = true;
            help.SetActive(true);
            text.text = "You found a Stapler! \n...and a weirdly inspiring poster?";
            gameObject.SetActive(false);
        }
    }
}
