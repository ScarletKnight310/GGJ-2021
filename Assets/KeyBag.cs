using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBag : MonoBehaviour
{
    public int numOfKeys = 0;
    public string keyTag = "Key";
    public string doorTag = "Door";
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag(keyTag)) {
            Destroy(other);
            numOfKeys++;
        }
    }
}
