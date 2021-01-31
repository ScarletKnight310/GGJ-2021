using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBag : MonoBehaviour
{
    int numOfKeys = 0;
    public string keyTag = "Key";
    public string doorTag = "Door";
    public string endTag = "End";
    public Text numOfKeysText;
    private void OnTriggerEnter(Collider col) {
        if (col.gameObject.CompareTag(keyTag)) {
            col.gameObject.SetActive(false);
            numOfKeys++;
        }
        else if (col.gameObject.CompareTag(doorTag) && numOfKeys > 0) {
            Debug.Log("1232");
            col.gameObject.transform.parent.gameObject.GetComponent<Open>().enabled = true;
            numOfKeys--;
        }
        else if (col.gameObject.CompareTag(endTag)) {
            Debug.Log("Switch to next phase");
        }
        numOfKeysText.text = numOfKeys+"";
    }
}
