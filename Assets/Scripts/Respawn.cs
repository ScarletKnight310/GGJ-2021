using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public string tagName = "Boss";
    public AudioClip aud;
    public float volume = 3;
    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.CompareTag(tagName)) {
            GetComponent<MovementPlayer>().enabled = false;
            GetComponent<AudioSource>().PlayOneShot(aud, volume);
            StartCoroutine(Wait());
        }
    }
    IEnumerator Wait() {
        yield return new WaitForSeconds(aud.length);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
