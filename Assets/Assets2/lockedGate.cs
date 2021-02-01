using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockedGate : MonoBehaviour
{
    public GameObject key;
    public GameObject openedGate;
    public static lockedGate controller = null;
    public bool hasKey = false;
    public GameObject gateCrashEffects;
    public GameObject currentKey;
    public static Dictionary<GameObject, List<lockedGate>> KeyTable = new Dictionary<GameObject, List<lockedGate>>();

    public void RegisterGate(lockedGate gate)
    {
        GameObject key = gate.key;
        if (!KeyTable.ContainsKey(key))
        {
            KeyTable.Add(key, new List<lockedGate>());
            KeyTable[key].Add(gate);
        }
        print("registering " + gate.gameObject.name + " = " + key.name);
    }

    private void Awake()
    {
        if (controller == null)
        {
            controller = this;
        }
    }

    public void getKey(GameObject key)
    {
        
        if (currentKey != null && KeyTable.ContainsKey(currentKey))
        {
            foreach (var gate in KeyTable[currentKey])
            {
                gate.hasKey = false;
            }
            Destroy(currentKey);
            currentKey = null;
        }

        if (KeyTable.ContainsKey(key))
        {
            foreach (var gate in KeyTable[key])
            {
                print(gate.gameObject.name + " is unlocked");
                gate.hasKey = true;
            }
        }
        else
        {
            print("missing key " + key.name);
        }
        currentKey = key;
    }

    public void dropKey()
    {
        foreach (var gate in KeyTable[currentKey])
        {
            gate.hasKey = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // print("Gate hit " + collision.gameObject.name);
        if (collision.gameObject.tag == "Player")
        {

            if (hasKey == true)
            {
                openedGate.SetActive(true);
                var col = gameObject.GetComponent<Collider>();
                if (col)
                {
                    col.enabled = false;
                }
                var ren = gameObject.GetComponent<Renderer>();
                if (ren)
                {
                    ren.enabled = false;
                }
                if (currentKey)
                {
                    Destroy(currentKey);
                }
                currentKey = null;
            }
            else
            {
                gateCrashEffects.SetActive(true);
                gateCrashEffects.SendMessage("Crash");
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        lockedGate.controller.RegisterGate(this);

        openedGate.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
