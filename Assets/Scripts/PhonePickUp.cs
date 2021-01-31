using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhonePickUp : MonoBehaviour
{
    public GameObject player;
    public float distance = 3f;
    public Text text;
    public AudioClip spawnStart;
    public AudioClip pickup;
    public GameObject help;
    public float volumeScaleSFX = 5f;
    public float volumeScale = 5f;
    public GameObject[] disableThese = new GameObject[1];

    void Update() {
        if (Vector3.Distance(transform.position, player.transform.position) < distance)
            text.text = "Grab your phone (Right-Click mouse)";


        if (Input.GetMouseButtonDown(1) && Vector3.Distance(transform.position, player.transform.position) < distance) {
            player.GetComponent<AudioSource>().PlayOneShot(pickup,volumeScaleSFX);
            for (int i = 0; i < disableThese.Length; i++) {
                disableThese[i].SetActive(!disableThese[i].activeSelf);
            }
            help.SetActive(true);

            player.GetComponent<Flashlight>().flashLight.SetActive(true);
            player.GetComponent<Flashlight>().gotFlashLight = true;

            text.text = "You found your phone! Better find a way out!";
            player.GetComponent<AudioSource>().clip = spawnStart;
            player.GetComponent<AudioSource>().PlayOneShot(spawnStart, volumeScale);
            gameObject.SetActive(false);
        }
    }

}
