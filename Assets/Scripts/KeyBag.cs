using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBag : MonoBehaviour
{
    public int numOfKeys = 0;
    public string keyTag = "Key";
    public string doorTag = "Door";

    private void OnTriggerEnter(Collider col) {
        Debug.Log("HIGH");
        if (col.gameObject.CompareTag(keyTag)) {
            col.gameObject.SetActive(false);
            numOfKeys++;
            Debug.Log("GRABBED KEY");
        }
        else if (col.gameObject.CompareTag(doorTag) && numOfKeys > 0) {
            col.gameObject.transform.parent.gameObject.SetActive(false);
            numOfKeys--;
            Debug.Log("DOOR UNLOCKED");
        }
    }
}
